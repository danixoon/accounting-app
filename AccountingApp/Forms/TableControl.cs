using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Globalization;
using System.Windows.Forms;

namespace AccountingApp.Forms
{
    public partial class TableControl : UserControl
    {
        private string tableId;
        private SqlDataAdapter dataAdapter;
        public TableControl(string tableId)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            this.tableId = tableId;

            FetchData();
        }

        void FetchData()
        {
            var dataBinding = App.instance.GetSource(tableId, out dataAdapter);
            var dataSource = (DataTable)dataBinding.DataSource;

            for(int i = 0; i < dataSource.Columns.Count; i++)
            {
                var columnId = dataSource.Columns[i].Caption;
                dataSource.Columns[i].ColumnName = App.instance.config.ResolveColumnName(tableId, columnId);
            }

            tableData.DataSource = dataBinding;
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            var bindingSource = ((BindingSource)tableData.DataSource);
            

            

            var dataTable = (DataTable)bindingSource.DataSource;

            
            var changes = dataTable.GetChanges();

            if (changes == null) return;

            dataAdapter.Update(changes);
            dataTable.AcceptChanges();
        }

        private void resetChanges_Click(object sender, EventArgs e)
        {
            FetchData();
        }
    }
}
