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
    public partial class FindEntity : Form
    {
        public FindEntity()
        {
            InitializeComponent();

            var app = App.instance;
            var entityTypeIds = GetIdData("EntityType");
            var entityComponentIds = GetIdData("ComponentType");
            var userNames = app
                .GetData(app
                .GetQueryAdapter("SELECT DISTINCT [username] FROM [Entity]"))
                .AsEnumerable()
                .Select(v => new BoxData(v["username"], v["username"])).ToList();

            entityTypeIds.Insert(0, new BoxData("Любой", null));
            entityComponentIds.Insert(0, new BoxData("Любое", null));
            userNames.Insert(0, new BoxData("Любой", null));


            foreach (var entity in entityTypeIds)
                entityTypeBox.Items.Add(entity);

            foreach (var component in entityComponentIds)
                entityComponentTypeBox.Items.Add(component);

            foreach (var username in userNames)
                entityUserNameBox.Items.Add(username);

            entityTypeBox.SelectedIndex = 0;
            entityComponentTypeBox.SelectedIndex = 0;
            entityUserNameBox.SelectedIndex = 0;
            UpdateTable();
        }

        public object selectedEntityTypeId;
        public object selectedComponentTypeId;
        public object selectedEntityUsernameType;

        public class BoxData
        {
            public object name;
            public object value;
            public override string ToString()
            {
                return this.name.ToString();
            }
            public BoxData(object name, object value)
            {
                this.name = name;
                this.value = value;
            }
        }

        public List<BoxData> GetIdData(string tableName, string readableId = null)
        {
            var app = App.instance;
            var ids = app.GetData(app.GetIdAdapter(tableName, readableId)).AsEnumerable().Select(row => new BoxData(row["name"], row["id"]));
            return ids.ToList();
        }


        public void UpdateTable()
        {
            var selectedEntityTypeData = entityTypeBox.SelectedItem as BoxData;
            var selectedEntityUserNameData = entityUserNameBox.SelectedItem as BoxData;
            var selectedEntityComponentType = entityComponentTypeBox.SelectedItem as BoxData;

            var entityTypeQuery = selectedEntityTypeData?.value != null ? $@"[EntityType].[id]='{selectedEntityTypeData.value}'" : "";
            var entityUserNameQuery = selectedEntityUserNameData?.value != null ? $@"[Entity].[username]='{selectedEntityUserNameData.value}'" : "";
            var entityComponentQuery = selectedEntityComponentType?.value != null ? $@"[ComponentType].[id]='{selectedEntityComponentType.value}'" : "";

            var query = new List<string>() { entityTypeQuery, entityUserNameQuery, entityComponentQuery }.FindAll(v => v != "");

            var fullQuery = $@"
SELECT [Component].[id],
 [EntityType].[name] AS 'Тип сущности',
 [ComponentModel].[name] AS 'Имя модели компонента',
 [ComponentType].[name] AS 'Тип компонента',
 [ComponentModel].[price] AS 'Цена компонента'
 FROM [Component]
INNER JOIN [Entity] ON [Entity].[id]=[Component].[entity_id]
INNER JOIN [EntityModel] ON [EntityModel].[id]=[Entity].[entity_model_id]
INNER JOIN [EntityType] ON [EntityType].[id]=[EntityModel].[entity_type_id]
INNER JOIN [ComponentModel] ON [ComponentModel].[id] = [Component].[component_model_id]
INNER JOIN [ComponentType] ON [ComponentType].[id] = [ComponentModel].[component_type_id]
{(query.Count > 0 ? "WHERE " + string.Join("AND", query) : "")}";

            var data = App.instance.GetData(App.instance.GetQueryAdapter(fullQuery));
            componentsBox.DataSource = data;
            componentsBox.Rows.Add();
        }

        private void entityTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void entityUserNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void entityComponentTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }
    }
}
