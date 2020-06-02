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
        // Возвращает значение поля
        public string value
        {
            get
            {
                // т.к. контрол может хранить и чекбоксы и текстовые поля,
                // необходим способ брать данные в двух случаях
                // берётся первый элемент в контейнере
                var control = flowLayoutContainer.Controls[0];
                // Если это переключатель
                if (control is ComboBox)
                {
                    // Собираем данные из него
                    DataRowView data = ((ComboBox)flowLayoutContainer.Controls[0]).SelectedValue as DataRowView;
                    // И возвращаем id, который он хранит
                    return data.Row["id"].ToString();
                }
                else
                    // В ином случае просто возвратим текст текстбокса
                    return control.Text;
            }
        }
        // Ид. столбца
        public string columnId { get; private set; }
        // Конструктор дропбокса
        public FieldInput(string name, string id, DataTable source, string displayId, string valueId)
        {
            InitializeComponent();
            this.columnId = id;
            fieldName.Text = name;
            var box = new ComboBox() { DataSource = source, DisplayMember = displayId, ValueMember = valueId, Width = 145 };
            flowLayoutContainer.Controls.Add(box);
        }
        // Конструктор текстбокса
        public FieldInput(string name, string id)
        {
            InitializeComponent();
            this.columnId = id;
            fieldName.Text = name;
            var input = new TextBox() { Width=145 };
            flowLayoutContainer.Controls.Add(input);
        }
    }
}
