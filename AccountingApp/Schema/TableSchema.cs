using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AccountingApp
{
    // Схема таблицы
    public class AppSchema
    {
        // Источник данных (имя сервера)
        public string dbDataSource;
        // База данных
        public string dbInitialCatalog;
        // Имя пользователя, не используется
        public string dbUser;
        // Имя пароль, не используется
        public string dbPassword;

        // Схема таблицы
        public class TableSchema
        {
            // Читаемое имя, название таблицы
            public string name;
            // Ид. столбца с читаемым значением
            public string readableColumnId;
            public Dictionary<string, string> columns;
        }
        // Все стандартные читаемые именования столбцов
        public Dictionary<string, string> columns;
        // Все таблицы, доступные для вывода в бд
        public Dictionary<string, TableSchema> tables;

    }

}