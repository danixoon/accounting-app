using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace AccountingApp
{
    public class App : Singleton<App>
    {

        public AppConfig config { get; private set; }

        public Dictionary<string, AppControl> controlMap { get; private set; } = new Dictionary<string, AppControl>();

        public List<string> controlHistory { get; private set; } = new List<string>();
        public UserControl activeControl;

        public App(AppConfig config)
        {
            this.config = config;

            foreach (var control in config.controls)
                controlMap.Add(control.tableId, control);
        }

        public void SetControl(string tableId)
        {
            if (!controlMap.TryGetValue(tableId, out AppControl targetControl))
                throw new KeyNotFoundException("Invalid control id");


            activeControl = targetControl.control;

            config.container.Controls.Clear();
            config.container.Controls.Add(activeControl);
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