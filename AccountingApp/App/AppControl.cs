using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingApp
{

    public class AppControl
    {
        public string name;
        public UserControl control;

        public AppControl(string name, UserControl control)
        {
            this.name = name;
            this.control = control;
        }
    }

    public class AppTableControl : AppControl
    {

        public struct DataColumn
        {
            public string headerId;
            public string headerName;

            public DataColumn(string headerId, string headerName)
            {
                this.headerId = headerId;
                this.headerName = headerName;
            }
        }

        public DataColumn[] columns;

        public AppTableControl(string name, UserControl control, params DataColumn[] columns) : base(name, control)
        {
            this.name = name;
            this.control = control;
            this.columns = columns;
        }
    }
}
