using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using AccountingApp.Forms;
using Newtonsoft.Json;

namespace AccountingApp
{
    public class App : Singleton<App>
    {

        public AppConfig config { get; private set; }
        /// <summary>
        /// Контролы, переключаемые приложением
        /// </summary>
        public AppControl[] controls;

        public Dictionary<string, AppControl> controlMap { get; private set; } = new Dictionary<string, AppControl>();

        public List<string> controlHistory { get; private set; } = new List<string>();
        public UserControl activeControl;

        private string connectionString =
                "Data Source=DESKTOP-5442AM3\\SQLEXPRESS;" +
                "Initial Catalog=AccountingApp;" +
                "User id=root;" +
                "Password=14881488;";

        public App(AppConfig config)
        {
            Initialize();

            this.config = config;

            var controls = new List<AppControl>();

            foreach (var tableSchema in config.schema.tables)
            {
                var tableId = tableSchema.Key;
                var control = new AppControl(tableId, tableSchema.Value.columns.Keys.ToArray(), new TableControl(tableId));
                controls.Add(control);
            }

            this.controls = controls.ToArray();

            foreach (var control in controls)
                controlMap.Add(control.tableId, control);
        }

        public void SetControl(string tableId)
        {
            if (!controlMap.TryGetValue(tableId, out AppControl targetControl))
                throw new KeyNotFoundException("Invalid control id");


            activeControl = targetControl.control;
            ((TableControl)activeControl).OnSelect();

            config.container.Controls.Clear();
            config.container.Controls.Add(activeControl);
        }

        public SqlDataAdapter GetAdapter(string tableId)
        {
            var query = $"SELECT * FROM [{tableId}]";
            var dataAdapter = new SqlDataAdapter(query, connectionString); 

            return dataAdapter;
        }

        public SqlDataAdapter GetIdAdapter(string tableId)
        {
            var readableId = config.ResolveReadableFKName(tableId);
            var query = $"SELECT [id], [{readableId}] as 'name' FROM [{tableId}]";
            var dataAdapter = new SqlDataAdapter(query, connectionString);

            return dataAdapter;
        }

        /// <summary>
        /// Загружает схему данных таблиц приложения
        /// </summary>
        /// <returns> Объект схемы данных приложения </returns>
        public static AppSchema LoadSchema()
        {
            var data = Encoding.UTF8.GetString(Properties.Resources.schema);
            var schema = JsonConvert.DeserializeObject<AppSchema>(data);

            return schema;
        }
    }
}