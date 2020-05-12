using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp
{
    interface ISingleton<T>
    {
        void Initialize(T config);
        bool isInitialized { get; }
    }
}
