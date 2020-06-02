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
    // Контрол, отображающий таблицу и способы её управления (сохранение, отмена изменений)
    public partial class TableControl : UserControl
    {
        // Идентификатор таблицы
        private string tableId;
        // SQL адаптер данных, заполняющий таблицу
        private SqlDataAdapter dataAdapter;
        // Полученные данные с таблицы
        private DataTable dataTable;
        public TableControl(string tableId)
        {
            InitializeComponent();
            // Необходимо для того, чтобы контрол расширился на весь контейнер
            Dock = DockStyle.Fill;

            // Отключение генерации столбцов автоматически
            dataGridView.AutoGenerateColumns = false;

            this.tableId = tableId;
        }

        // Вызывает App.cs, когда выбирается таблица
        public void OnSelect()
        {
            // При выборе - перезагружаем данные
            Reset();
        }


        // Функция, перезагружающая данные из таблицы и генерирующая столбцы
        void Reset()
        {
            FetchData();
            GenerateColumns();
        }

        
        // Функция, генерирующая столбцы из данных
        void GenerateColumns()
        {
            // Удаляем все уже созданные столбцы
            dataGridView.Columns.Clear();
            // Для каждого столбца в столбцах таблицы
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                // Получаем идентификатор столбца
                var columnId = dataTable.Columns[i].ColumnName;
                // Получаем читаемое имя столбца
                var columnName = App.instance.config.ResolveColumnName(tableId, columnId);

                // Если ид. столбца оканчивается на _id - понимаем, что столбец является вторичным ключом
                if (columnId.EndsWith("_id"))
                {

                    var column = new DataGridViewComboBoxColumn() { Name = columnName, DataPropertyName = columnId, AutoComplete = true, ValueMember = "id", DisplayMember = "name" };
                    var data = App.instance.GetData(App.instance.GetIdAdapter(App.instance.config.ResolveTableId(columnId)));

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

        // Получает данные с бд и обновляет таблицу
        void FetchData()
        {
            dataTable = App.instance.GetData(App.instance.GetAdapter(tableId));

            dataGridView.DataSource = dataTable;
        }

        
        // При сохранении
        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            var dataTable = ((DataTable)dataGridView.DataSource);
            // Получаем изменения
            var changes = dataTable.GetChanges();

            // Если изменений нет - функция выходит
            if (changes == null) return;

            // Иначе создаются билдеры для обновления в бд
            SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);

            // Необходимая функция для апдейта данных средствами шарпа лёгким способом
            builder.GetUpdateCommand();
            dataAdapter.Update(changes);

            // Обнуляем изменения, всё сохранено
            dataTable.AcceptChanges();
        }

        // Перезагружаем данные, обновляя их и обнуляя изменения
        private void resetChanges_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
