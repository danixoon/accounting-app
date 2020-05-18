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

        public AppSchema schema;

        public AppConfig(Control container, AppSchema schema)
        {
            this.container = container;
            this.schema = schema;
        }

        public string ResolveTableName(string tableId)
        {
            var table = schema.tables[tableId];
            return table?.name;
        }

        public string ResolveFKColumnName(string columnId)
        {
            var tableId = string.Join("", columnId.Substring(0, columnId.Length - 3).Split('_').Select(v => (v[0].ToString().ToUpper() + v.Substring(1))));

            return ResolveTableName(tableId);
        }

        public string ResolveColumnName(string tableId, string columnId)
        {
            string tableName = null;
            var table = schema.tables[tableId];
            var exists = table?.columns.TryGetValue(columnId, out tableName) ?? false;

            if (tableName == null)
                tableName = ResolveColumnName(columnId);
            else if (tableName.EndsWith("_id"))
                ResolveFKColumnName(tableName);

            return tableName;
        }

        public string ResolveColumnName(string columnId)
        {
            if (columnId.EndsWith("_id"))
                return ResolveFKColumnName(columnId);
            
            schema.columns.TryGetValue(columnId, out string columnName);

            return columnName;
        }
    }
}
