using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp
{

    public struct AppConfig
    {
        public Control container;
        public AppControl[] controls;

        public AppConfig(Control container, params AppControl[] controlsData)
        {
            this.controls = controlsData;
            this.container = container;
        }
    }

    public class App : ISingleton<AppConfig>
    {
        public const string TABLE_COMPUTERS = "computers";
        public const string TABLE_PRINTERS = "printers";

        public static App instance { get; private set; }

        public Control container { get; private set; }
        public Dictionary<string, AppControl> controlMap { get; private set; } = new Dictionary<string, AppControl>();

        public List<string> controlHistory { get; private set; } = new List<string>();
        public UserControl activeControl;


        public static string LocalizeName(string key)
        {
            switch (key)
            {
                case TABLE_COMPUTERS:
                    return "Компьютеры";
                case TABLE_PRINTERS:
                    return "Принтеры";
                default:
                    throw new Exception("Key not exists");
            }
        }

        public void SetControl(string name)
        {
            if (!controlMap.TryGetValue(name, out AppControl targetControl)) throw new KeyNotFoundException("Invalid control name");

            activeControl = targetControl.control;

            container.Controls.Clear();
            container.Controls.Add(activeControl);
        }

        public bool isInitialized { get; private set; } = false;
        public void Initialize(AppConfig config)
        {
            container = config.container;

            isInitialized = true;
            instance = this;

            foreach (var control in config.controls)
                controlMap.Add(control.name, control);

        }
    }
}

