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

        public void SetTable(string tableId)
        {
            tableSwitchGroup.Text = "Таблица - " + app.config.ResolveTableName(tableId);
            app.SetControl(tableId);
        }

        private void GenerateTableSwitch()
        {
            tableSwitch.Controls.Clear();
            tableSwitch.ColumnCount = app.config.controls.Length;
            foreach (var control in app.config.controls)
            {
                var button = new Button() { Text = app.config.ResolveTableName(control.tableId), Dock = DockStyle.Fill };
                button.Click += (o, e) => SetTable(control.tableId);
                tableSwitch.Controls.Add(button);
            }
        }

        public AppForm()
        {
            InitializeComponent();

            var schema = App.LoadSchema();
            var config = new AppConfig(container, schema);

            app = new App(config);
            app.Initialize();

            GenerateTableSwitch();

            SetTable(config.controls[0].tableId);
        }
    }
}