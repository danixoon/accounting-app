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
        public string value { get { return this.fieldValue.Text; } set { fieldValue.Text = value; } }
        public FieldInput(string name, string defaultValue = "")
        {
            InitializeComponent();
            fieldName.Text = name;
            fieldValue.Text = defaultValue;
        }
    }
}
