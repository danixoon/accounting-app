using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AccountingApp
{

    public class AppSchema
    {
        public string dbDataSource;
        public string dbInitialCatalog;
        public string dbUser;
        public string dbPassword;

        public class TableSchema
        {
            public string name;
            public string readableColumnId;
            public Dictionary<string, string> columns;
        }
        public Dictionary<string, string> columns;
        public Dictionary<string, TableSchema> tables;

    }

}