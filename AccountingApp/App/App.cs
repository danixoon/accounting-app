using System;
using System.IO;
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

        private string connectionString;

        public string tableId { private set; get; }

        public App(AppConfig config)
        {
            Initialize();

            connectionString = $"Data Source={config.schema.dbDataSource}; Initial Catalog={config.schema.dbInitialCatalog}; Integrated Security=true;";

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

        public bool CheckAuth(string username, string password)
        {
            var query = $"SELECT password FROM [Account] WHERE username='{username}'";
            var dataAdapter = new SqlDataAdapter(query, connectionString);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            return table.Rows.Count > 0 ? table.Rows[0]["password"].ToString() == password : false;
        }

        public void SetControl(string tableId)
        {
            if (!controlMap.TryGetValue(tableId, out AppControl targetControl))
                throw new KeyNotFoundException("Invalid control id");

            this.tableId = tableId;

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

        public SqlDataAdapter GetIdAdapter(string tableId, string readableId = null)
        {
            readableId = readableId ?? config.ResolveReadableFKName(tableId);
            var query = $"SELECT [id], [{readableId}] as 'name' FROM [{tableId}]";
            var dataAdapter = new SqlDataAdapter(query, connectionString);

            return dataAdapter;
        }

        public SqlDataAdapter GetQueryAdapter(string query)
        {
            var adapter = new SqlDataAdapter(query, connectionString);
            return adapter;
        }

        public DataTable GetData(SqlDataAdapter adapter)
        {
            DataTable table = new DataTable() { Locale = CultureInfo.InvariantCulture };
            adapter.Fill(table);
            return table;
        }

        public string InsertData(string tableId, Dictionary<string, string> data)
        {

            var columns = $"[{string.Join("], [", data.Keys)}]";
            var values = $"'{string.Join("', '", data.Values)}'";

            var query = $"INSERT INTO {tableId}({columns}) VALUES ({values})";

            try
            {
                var sql = new SqlConnection(connectionString);
                sql.Open();
                var command = sql.CreateCommand();
                command.CommandText = query;
                var count = command.ExecuteNonQuery();
                sql.Close();
                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// Загружает схему данных таблиц приложения
        /// </summary>
        /// <returns> Объект схемы данных приложения </returns>
        public static AppSchema LoadSchema()
        {
            try
            {
                string fileName = ".\\schema.json";

                string text = File.ReadAllText(fileName);

                var schema = JsonConvert.DeserializeObject<AppSchema>(text);

                return schema;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                throw new Exception();
            }
        }
    }
}