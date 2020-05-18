using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingApp
{
    public abstract class Singleton<T> where T : class
    {
        public static bool isInitialized { get; private set; }
        public static T instance { get; private set; }
        public Singleton()
        {
            if (Singleton<T>.isInitialized) throw new Exception("Already initialized");
        }
        protected void Initialize()
        {
            if (Singleton<T>.isInitialized) throw new Exception("Already initialized");
            Singleton<T>.instance = this as T;
            Singleton<T>.isInitialized = true;
        }
    }
}