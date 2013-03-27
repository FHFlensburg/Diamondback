using System.Windows;
using AdminTool.Client.View;

namespace AdminTool.Client.Controller
{
   public partial class Start : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            ///
            ///
            ///##
            WndLogin startWindow = new WndLogin();
            startWindow.Show();
            WndIndex secondWindow = new WndIndex();
            secondWindow.Show();
        }
    }
}
