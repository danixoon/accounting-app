using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Globalization;
using System.Windows.Forms;

namespace AccountingApp.Forms
{
    public partial class TableControl : UserControl
    {
        private string tableId;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        public TableControl(string tableId)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            // Отключение генерации столбцов автоматически
            dataGridView.AutoGenerateColumns = false;

            this.tableId = tableId;
        }

        public void OnSelect()
        {
            Reset();
        }


        void Reset()
        {
            FetchData();
            GenerateColumns();
            GenerateAddFields();
        }

        

        void GenerateColumns()
        {
            dataGridView.Columns.Clear();
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                var columnId = dataTable.Columns[i].ColumnName;
                var columnName = App.instance.config.ResolveColumnName(tableId, columnId);

                if (columnId.EndsWith("_id"))
                {
                    var column = new DataGridViewComboBoxColumn() { Name = columnName, DataPropertyName = columnId, AutoComplete = true, ValueMember = "id", DisplayMember = "name" };
                    var adapter = App.instance.GetIdAdapter(App.instance.config.ResolveTableId(columnId));

                    var data = new DataTable
                    {
                        Locale = CultureInfo.InvariantCulture
                    };

                    adapter.Fill(data);

                    column.DataSource = data;
                    dataGridView.Columns.Add(column);
                }
                else
                {
                    var column = new DataGridViewTextBoxColumn() { Name = columnName, DataPropertyName = columnId };
                    dataGridView.Columns.Add(column);
                }
                //dataGridView.Columns[i].HeaderText = columnName;
                //tableData.Columns[i] = new DataGridViewCheckBoxColumn();
            }
        }

        void GenerateAddFields()
        {
            addGroup.Controls.Clear();
            addGroup.RowCount = dataTable.Columns.Count;

            foreach (DataColumn column in dataTable.Columns)
            {
                var columnId = column.ColumnName;
                var input = new FieldInput(App.instance.config.ResolveColumnName(tableId, columnId));
                input.Dock = DockStyle.Fill;

                addGroup.Controls.Add(input);
            }

            // Автовысота для каждого стиля строки
            TableLayoutRowStyleCollection styles = addGroup.RowStyles;
            foreach (RowStyle style in styles)
            {
                style.SizeType = SizeType.AutoSize;
            }

        }

        void FetchData()
        {
            dataAdapter = App.instance.GetAdapter(tableId);

            dataTable = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };

            dataAdapter.Fill(dataTable);

            dataGridView.DataSource = dataTable;
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            var dataTable = ((DataTable)dataGridView.DataSource);

            var changes = dataTable.GetChanges();

            if (changes == null) return;

            SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);

            builder.GetUpdateCommand();
            dataAdapter.Update(changes);

            dataTable.AcceptChanges();
        }

        private void resetChanges_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
