using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using AccountingApp.Forms;
using Newtonsoft.Json;

namespace AccountingApp
{
    // Корневой класс приложения, контроллирует его поведение
    // Класс наследуется от класса "синглтон", тем самым позволяя получать доступ к 
    // функционалу приложения через запись App.instance.[любойметодпеременнаяитд]
    public class App : Singleton<App>
    {

        // Ссылка на конфигурацию приложения, предоставляет удобные
        public AppConfig config { get; private set; }

        // Словарь контролов-таблиц, хранящий в качестве ключа строку-идентификатор 
        // А в качестве значения данные о контроле с таблицей
        public Dictionary<string, TableControl> controlMap { get; private set; } = new Dictionary<string, TableControl>();

        // Строка подключения к базе данных
        private string connectionString;

        // Ид. текущей активной таблицы
        public string tableId { private set; get; }

        // Конструктор, принимающий конфигурацию приложения
        public App(AppConfig config)
        {
            // Вызов инициализирующего метода синглтона, позволяющего запустить его и 
            // после этого становится доступным доступ к экземпляру этого класса
            // по записи App.instance
            Initialize();

            // Строка подключения задаётся используя поля в схеме конфигурации
            connectionString = $"Data Source={config.schema.dbDataSource}; Initial Catalog={config.schema.dbInitialCatalog}; Integrated Security=true;";

            // Конфигурация присваивается полю класса
            this.config = config;

            // Для каждой таблицы, записанной в схеме
            foreach (var tableSchema in config.schema.tables)
            {
                // Получаем ключ (ид. таблицы)
                var tableId = tableSchema.Key;
                // Создаётся контрол таблицы
                // первый аргумент - ид. таблицы
                // второй аргумент - все ид. столбцов (ключи преобразовываются в массив)
                // третий аргумент - контрол, который является формой TableControl, данные о таблице
                var control = new TableControl(tableId);

                // Все контролы добавляются в словарь controlMap по ключу ид. таблицы
                // Теперь их можно там найти и обращаться
                controlMap.Add(tableId, control);
            }

            
         
                
        }

        // Метод проверяет правильна ли пара логин/пароль
        // Возвращает false, если неверно и true, если ок
        public bool CheckAuth(string username, string password)
        {
            // Запрос, собирающий пароль по имени пользователя
            var query = $"SELECT password FROM [Account] WHERE username='{username}'";
            // Данные, вернувшиеся из запроса (таблица)
            var data = App.instance.GetData(new SqlDataAdapter(query, connectionString));

            // Если таблиц вернулось больше нуля - смотрит, совпадает ли пароль с указанным, если нет - false, неверный пароль
            // Если меньше нуля - false, неверное имя пользователя
            return data.Rows.Count > 0 ? data.Rows[0]["password"].ToString() == password : false;
        }

        // Устанавливает контрол активным по соответствующему id табилцы
        public void SetControl(string tableId)
        {
            // Если таблицы по указанному id не нашлось - кидается исключение, что идентификатор неверный
            if (!controlMap.TryGetValue(tableId, out TableControl targetControl))
                throw new KeyNotFoundException("Invalid control id");


            // Получаем активный контрол по указанном tableId
            var activeAppControl = controlMap[tableId];

            // Устанавливаем tableId в качестве текущего, активного
            this.tableId = tableId;

            // Удаляем всё, что лежит в контейнере
            config.container.Controls.Clear();
            // Добавляем контрол
            config.container.Controls.Add(activeAppControl);

            // Вызываем метод OnSelect, вызывающий обновление данных контрола (таблицы)
            ((TableControl)activeAppControl).OnSelect();
        }

        // Возвращает адаптер для таблицы указанной в tableId
        public SqlDataAdapter GetAdapter(string tableId)
        {
            // Выборка всех данных из таблицы
            var query = $"SELECT * FROM [{tableId}]";
            

            return GetQueryAdapter(query);
        }

        // Возвращает все идентификаторы таблицы, выводя в качестве второго ключа - ключ с читаемым значением
        public SqlDataAdapter GetIdAdapter(string tableId, string readableId = null, string condition = null)
        {
            // Если ключ не задан в аргументах - используем тот, что указан в конфигурации
            readableId = readableId ?? config.ResolveReadableFKName(tableId);
            var readableIdPath = readableId.Split('.');

            string query;
            if(readableIdPath.Length == 1 && readableId[0].ToString().ToUpper() != readableId[0].ToString())
              query = $"SELECT [id], CONCAT ('[', [id], '] ', [{readableId}]) as 'name' FROM [{tableId}] {condition ?? ""}";
            else
            {
                var foreignTableId = readableIdPath[0];
                var foreignColumnId = config.ToSneakCase(readableIdPath[0]) + "_id";
                readableId = readableIdPath.Length == 1 ? config.ResolveReadableFKName(foreignTableId) : readableIdPath[1];
                query = $"SELECT [{tableId}].[id], CONCAT ('[', [{tableId}].[id], '] ', [{foreignTableId}].[{readableId}]) as 'name' FROM [{tableId}] INNER JOIN [{foreignTableId}] ON [{foreignTableId}].[id] = [{tableId}].[{foreignColumnId}] {condition ?? ""}";
            }
            

            return GetQueryAdapter(query);
        }

        // Возвращает адаптер по указанному запросу
        public SqlDataAdapter GetQueryAdapter(string query)
        {
            var adapter = new SqlDataAdapter(query, connectionString);
            return adapter;
        }

        // Получает данные из адаптера
        public DataTable GetData(SqlDataAdapter adapter)
        {
            DataTable table = new DataTable() { Locale = CultureInfo.InvariantCulture };
            adapter.Fill(table);
            return table;
        }

        // Вставляет в таблицу tableId данные, указанные в data
        public string InsertData(string tableId, Dictionary<string, string> data)
        {

            // Те столбцы, в которые вставляем, заключённые в квадратные кавычки
            var columns = $"[{string.Join("], [", data.Keys)}]";
            // Те значения, которые вставляем, заключённые в одинарные кавычки
            var values = $"'{string.Join("', '", data.Values)}'";

            // Запрос
            var query = $"INSERT INTO {tableId}({columns}) VALUES ({values})";

            try
            {
                // Создаём SQL подключение
                var sql = new SqlConnection(connectionString);
                // Открываем его
                sql.Open();
                // Создаём команду
                var command = sql.CreateCommand();
                command.CommandText = query;
                // Выполняем запрос
                var count = command.ExecuteNonQuery();
                // Закрываем подключение
                sql.Close();
                // И возвращаем null, если всё ок
                return null;
            }
            catch (Exception e)
            {
                // Если ошибка - возвращаем сообщение об ошибке
                return e.Message;
            }
        }

        /// <summary>
        /// Загружает схему данных таблиц приложения
        /// </summary>
        /// <returns> Объект схемы данных приложения </returns>
        public static AppSchema LoadSchema()
        {
            try
            {
                // Путь до схемы (отнсительно экзешника)
                string fileName = ".\\schema.json";

                // Считывается весь файл в строку
                string text = File.ReadAllText(fileName);

                // Преобразуется в экземпляр класса AppSchema
                var schema = JsonConvert.DeserializeObject<AppSchema>(text);

                // И возвращается
                return schema;
            }
            catch (Exception err)
            {
                // Если всё очень плохо - кидается ошибка
                MessageBox.Show(err.Message);
                Application.Exit();
                return null;
            }
        }
    }
}