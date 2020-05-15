using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountingApp.Forms;


namespace AccountingApp
{
    /// <summary>
    /// Конфигурация данных приложения
    /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// Контрол-контейнер корня приложения
        /// </summary>
        public Control container;
        /// <summary>
        /// Контролы, переключаемые приложением
        /// </summary>
        public AppControl[] controls;
        public AppSchema schema;

        public AppConfig(Control container, AppSchema schema)
        {
            var controls = new List<AppControl>();

            foreach (var tableSchema in schema.tables)
            {
                var control = new AppControl(tableSchema.Key, tableSchema.Value.columns.Keys.ToArray(), new TableControl());
                controls.Add(control);
            }

            this.controls = controls.ToArray();
            this.container = container;
            this.schema = schema;
        }

        public string ResolveTableName(string tableId)
        {
            var table = schema.tables[tableId];
            return table?.name;
        }

        public string ResolveColumnName(string tableId, string columnId)
        {
            var table = schema.tables[tableId];
            return table?.columns[columnId];
        }

        public string ResolveColumnName(string columnId)
        {
            return schema.columns[columnId];
        }
    }
}
