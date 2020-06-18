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

        // Схема данных
        public AppSchema schema;

        public AppConfig(Control container, AppSchema schema)
        {
            this.container = container;
            this.schema = schema;
        }

        // Получает читаемое имя для вторичного ключа
        public string ResolveReadableFKName(string tableId)
        {
            //var tableId = ResolveTableId(columnId);
            var tableSchema = schema.tables[tableId];
            var readableId = tableSchema.readableColumnId;
            return readableId ?? "id";
        }

        // Получает читаемое имя таблицы по её ид
        public string ResolveTableName(string tableId)
        {
            var table = schema.tables[tableId];
            return table?.name;
        }

        // Возвращает ид. таблицы по вторичному ключу
        public string ResolveTableId(string columnId)
        {
            var tableId = string.Join("", columnId.Substring(0, columnId.Length - 3).Split('_').Select(v => (v[0].ToString().ToUpper() + v.Substring(1))));
            return tableId;
        }

        public string ToSneakCase(string text)
        {
            return string.Join("", text.Select((c, i) =>
            {
                var ch = c.ToString();
                if (i == 0) return ch.ToLower();
                return ch.ToUpper() == ch ? $"_{ch.ToLower()}" : ch;
            }));
        }

        // Возвращает имя столбца по вторичному ключу
        public string ResolveFKColumnName(string columnId)
        {
            var tableId = ResolveTableId(columnId);

            return ResolveTableName(tableId);
        }

        // Возвращает имя столбца по таблице и столбцу
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

        // Возвращает имя столбца по столбцу (только дефолтные значения)
        public string ResolveColumnName(string columnId)
        {
            if (columnId.EndsWith("_id"))
                return ResolveFKColumnName(columnId);

            schema.columns.TryGetValue(columnId, out string columnName);

            return columnName;
        }
    }
}
