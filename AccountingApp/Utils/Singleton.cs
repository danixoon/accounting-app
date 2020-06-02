using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingApp
{
    // Синглтон. Позволяет создать класс, присвоив статическое ему поле instance
    // К которому в последствии можно обращаться. Это паттерн в программировании, можешь почитать о нём
    // Синглтон нельзя создать дважды, данный класс реализует эту проверку
    // Объективно - он не нужен, но изначально задумывался и хорошая вещь в принципе
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