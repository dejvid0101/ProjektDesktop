using System.Globalization;
using System.Windows;

namespace WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        App()
        {
            string vrr = DAL1.TextAccess.readFile(@"..\..\..\DAL1\Files\SprachDatei.txt");
            CultureInfo kltr;
            if (string.IsNullOrEmpty(vrr) || vrr == "Engleski") { kltr = new CultureInfo("en-US"); }
            else { kltr = new CultureInfo("hr-HR"); }




            System.Threading.Thread.CurrentThread.CurrentUICulture = kltr;
        }


    }
}
