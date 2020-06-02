using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingApp.Forms
{
    public partial class AddDataForm : Form
    {
        private string tableId;
        public AddDataForm(string tableId)
        {
            InitializeComponent();
            this.tableId = tableId;
        }

        private void AddDataForm_Load(object sender, EventArgs e)
        {
            var config = App.instance.config;
            var columns = config.schema.tables[tableId].columns;
            foreach (var col in columns)
            {
                Control control;
                var name = config.ResolveColumnName(tableId, col.Key);
                if (col.Key == "id") continue;
                if (col.Key.EndsWith("_id"))
                {
                    var fkTableId = App.instance.config.ResolveFKColumnId(col.Key);
                    var adapter = App.instance.GetIdAdapter(fkTableId);
                    var data = new DataTable();
                    adapter.Fill(data);

                    control = new FieldInput(name, col.Key, data, "name", "data");
                }
                else control = new FieldInput(name, col.Key);

                inputContainer.Controls.Add(control);
            }
        }

        private void addDataButton_Click(object sender, EventArgs e)
        {
            var data = new Dictionary<string, string>();
            foreach(FieldInput control in inputContainer.Controls)
            {
                data.Add(control.id, control.value);
            }
            var result = App.instance.InsertData(tableId, data);
            MessageBox.Show(result == null ? "Данные успешно добавлены." : $"Произошла ошибка при добавлении:\n{result}");
        }
    }
}
