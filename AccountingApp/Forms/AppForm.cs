﻿using System;
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
        private struct SwitchBoxItem
        {
            public string tableId;
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

        public void SetTable(string tableId)
        {
            app.SetControl(tableId);
        }

        private void GenerateTableSwitch()
        {
            switchTableBox.Items.Clear();
            foreach (var control in app.controls)
            {
                switchTableBox.Items.Insert(switchTableBox.Items.Count, new SwitchBoxItem(control.tableId, app.config.ResolveTableName(control.tableId)));
            }
            switchTableBox.SelectedIndex = 0;
        }

        public AppForm()
        {
            InitializeComponent();

            var schema = App.LoadSchema();
            var config = new AppConfig(container, schema);

            app = new App(config);

            GenerateTableSwitch();

            SetTable(app.controls[0].tableId);
        }

        private void switchTableBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var switchBox = (ComboBox)sender;
            var selectedItem = (SwitchBoxItem)switchBox.SelectedItem;

            SetTable(selectedItem.tableId);
        }
    }
}