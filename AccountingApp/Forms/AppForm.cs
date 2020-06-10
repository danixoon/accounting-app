using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountingApp.Forms;

namespace AccountingApp
{
    public partial class AppForm : Form
    {
        // Ссылочка на контроллер приложения
        private App app;
        // Элемент переключателя таблиц
        private struct SwitchBoxItem
        {
            // Ид. таблицы
            public string tableId;
            // Имя таблицы
            public string tableName;
            public override string ToString()
            {
                return tableName;
            }
            public SwitchBoxItem(string tableId, string tableName)
            {
                this.tableId = tableId;
                this.tableName = tableName;
            }
        }

        // Устанавливает таблицу по ид. активной
        public void SetTable(string tableId)
        {
            app.SetControl(tableId);
        }

        // Генерирует возможные таблицы в переключатель
        private void GenerateTableSwitch()
        {
            switchTableBox.Items.Clear();
            foreach (var control in app.controlMap)
            {
                switchTableBox.Items.Insert(switchTableBox.Items.Count, new SwitchBoxItem(control.Key, app.config.ResolveTableName(control.Key)));
            }
            switchTableBox.SelectedIndex = 0;
        }

        public AppForm()
        {
            InitializeComponent();
        }
        // При изменении чекбокса
        private void switchTableBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var switchBox = (ComboBox)sender;
            var selectedItem = (SwitchBoxItem)switchBox.SelectedItem;

            // Меняем таблицу на выбранную
            SetTable(selectedItem.tableId);
        }

        private void menu_showEntities_Click(object sender, EventArgs e)
        {

        }

        // При загрузке приложения
        private void AppForm_Load(object sender, EventArgs e)
        {
            // Создаём схему
            var schema = App.LoadSchema();
            // Создаём конфиг
            var config = new AppConfig(container, schema);
            
            app = new App(config);

            //// Создаём формочку авторизации
            //Auth auth = new Auth();
            //if (auth.ShowDialog() != DialogResult.OK)
            //{
            //    // Если авторизация не прошла - отключаем приложение
            //    Application.Exit();
            //    return;
            //}
            //else
            //{
                // Иначе генерируем переключатели таблиц и ставим первую таблицу
                // в списке таблиц на активную
                GenerateTableSwitch();
                SetTable(app.controlMap.First().Key);
            //}
        }

        // Вызывает формочку на добавление данных в таблицу
        private void showAddDataForm_menu_Click(object sender, EventArgs e)
        {
            var form = new AddDataForm(App.instance.tableId);
            form.ShowDialog();
            // После отключения диплога - перезапускаем формочку
            app.SetControl(App.instance.tableId);
        }

        // При нажатии на отчётную кнопочку поиска
        private void findEntity_menu_Click(object sender, EventArgs e)
        {
            // Открываем формочку поиска
            var form = new FindEntity();
            form.ShowDialog();
        }
    }
}