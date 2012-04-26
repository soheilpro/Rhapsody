using System;
using System.Windows.Forms;
using Rhapsody.Core;
using Rhapsody.Properties;
using Rhapsody.UI;

namespace Rhapsody
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            if (!Settings.Default.Upgraded)
            {
                Settings.Default.Upgrade();
                Settings.Default.Upgraded = true;
            }

            var context = new Context();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(context));
        }
    }
}
