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
    // Форма добавления данных в таблицу
    public partial class AddDataForm : Form
    {
        // Ид. таблицы, к которой добавляется
        private string tableId;
        public AddDataForm(string tableId)
        {
            InitializeComponent();
            this.tableId = tableId;
        }

        // После загрузки формы
        private void AddDataForm_Load(object sender, EventArgs e)
        {
            // Получаем конфиг
            var config = App.instance.config;
            // Получаем все столбцы к текущей таблице
            var columns = config.schema.tables[tableId].columns;
            foreach (var col in columns)
            {
                
                Control control;
                // Получаем имя столбца, читаемое
                var name = config.ResolveColumnName(tableId, col.Key);
                // Если это идентификатор - не добавляем
                if (col.Key == "id") continue;
                // Если это вторичный ключ
                if (col.Key.EndsWith("_id"))
                {
                    // Получаем ид. таблицы, на которую ссылается этот ключ
                    var fkTableId = App.instance.config.ResolveTableId(col.Key);
                    // Получаем данные таблицы
                    var data = App.instance.GetData(App.instance.GetIdAdapter(fkTableId));
                    
                    // Создаём дропдаун с данными первичного ключа и названия из таблицы
                    control = new FieldInput(name, col.Key, data, "name", "data");
                }
                // В ином случае создаётся обычное текстовое поле
                else control = new FieldInput(name, col.Key);

                // Добавляется в контейнер
                inputContainer.Controls.Add(control);
            }
        }

        // При клике на кнопку добавления
        private void addDataButton_Click(object sender, EventArgs e)
        {
            // Словарь данных для отправления
            var data = new Dictionary<string, string>();
            foreach(FieldInput control in inputContainer.Controls)
            {
                // Забираем значение и ид. столбца, добавляя в словарь
                data.Add(control.columnId, control.value);
            }
            // Вставляем данные, высвечиваем ошибку
            var result = App.instance.InsertData(tableId, data);
            MessageBox.Show(result == null ? "Данные успешно добавлены." : $"Произошла ошибка при добавлении:\n{result}");
        }
    }
}
