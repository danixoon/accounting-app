using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingApp
{

    public class AppControl
    {
        /// <summary>
        /// Идентификатор таблицы (соответствует имени в бд)
        /// </summary>
        public string tableId;
        /// <summary>
        /// Ссылка на контрол
        /// </summary>
        public UserControl control;
        /// <summary>
        /// Идентификаторы столбцов
        /// </summary>
        public string[] columnIds;

        public AppControl(string tableId, string[] columnIds, UserControl control)
        {
            this.tableId = tableId;
            this.control = control;
            this.columnIds = columnIds;
        }
    }
}
