using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingApp.Forms
{

    public partial class FieldInput : UserControl
    {
        public string value
        {
            get
            {
                var control = flowLayoutContainer.Controls[0];
                if (control is ComboBox)
                {
                    DataRowView data = ((ComboBox)flowLayoutContainer.Controls[0]).SelectedValue as DataRowView;
                    return data.Row["id"].ToString();
                }
                else
                    return control.Text;
            }
        }
        public string id { get; private set; }
        public FieldInput(string name, string id, DataTable source, string displayId, string valueId)
        {
            InitializeComponent();
            this.id = id;
            fieldName.Text = name;
            var box = new ComboBox() { DataSource = source, DisplayMember = displayId, ValueMember = valueId, Width = 145 };
            flowLayoutContainer.Controls.Add(box);
        }
        public FieldInput(string name, string id)
        {
            InitializeComponent();
            this.id = id;
            fieldName.Text = name;
            var input = new TextBox() { Width=145 };
            flowLayoutContainer.Controls.Add(input);
        }
    }
}
