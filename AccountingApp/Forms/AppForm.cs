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
        private App app;
        private AppConfig config;

        public void SetTable(string name)
        {
            tableSwitchGroup.Text = "Таблица - " + App.LocalizeName(name);
            app.SetControl(name);
        }

        private void GenerateTableSwitch()
        {
            tableSwitch.Controls.Clear();
            tableSwitch.ColumnCount = config.controls.Length;
            foreach(var control in config.controls)
            {
                var button = new Button() { Text = App.LocalizeName(control.name), Dock = DockStyle.Fill };
                button.Click += (o, e) => SetTable(control.name);
                tableSwitch.Controls.Add(button);
            }
        }

        public AppForm()
        {
            InitializeComponent();

            config = new AppConfig(container,
               new AppTableControl(App.TABLE_COMPUTERS, new TableComputers(), new AppTableControl.DataColumn("id", "Ид.")),
               new AppTableControl(App.TABLE_PRINTERS, new TablePrinters(), new AppTableControl.DataColumn("id", "Ид."))
            );

            GenerateTableSwitch();

            app = new App();
            app.Initialize(config);

            SetTable(App.TABLE_COMPUTERS);
        }
    }
}
