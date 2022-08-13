using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for PlayerInfoWindow.xaml
    /// </summary>
    public partial class PlayerInfoWindow : Window
    {
        private string api = "http://worldcup.sfg.io/matches";
        private string api2 = "https://world-cup-json-2018.herokuapp.com/matches";

        public PlayerInfoWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string z = DAL1.TextAccess.readFile(@"..\..\..\DAL1\Files\PlayerInfoHelper.txt");
            lblName.Content = z;
            IList<DAL1.QuickType.Tekma> list = null;

            string j = DAL1.TextAccess.readFile(@"..\..\..\DAL1\Files\Initial.txt");
            string[] data = j.Split(':');
            if (data[0] == "Žensko nogometno")
            {

                list = DAL1.APIAccessTeams.GetData2(api);
            } else
            {
                list = DAL1.APIAccessTeams.GetData2(api2);
            }

            string r = DAL1.TextAccess.readFile(@"..\..\..\DAL1\Files\PlayerInfoHelper.txt");
            foreach (var item in list)
            {
                for (int i = 0; i < item.AwayTeamStatistics.StartingEleven.Length; i++)
                {
                    if (item.AwayTeamStatistics.StartingEleven[i].Name == r)
                    {

                        lblShirt.Content = item.AwayTeamStatistics.StartingEleven[i].ShirtNumber;
                        lblPosition.Content = item.AwayTeamStatistics.StartingEleven[i].Position;

                        if (!item.AwayTeamStatistics.StartingEleven[i].Captain)
                        {
                            lblCaptain.Content = "";

                        }
                        else if (item.AwayTeamStatistics.StartingEleven[i].Captain)
                        {
                            lblCaptain.Content = "Captain";
                        }

                        // do the same for other attributes
                        break;
                    }


                }

               


            }

            
        }
    }
}
