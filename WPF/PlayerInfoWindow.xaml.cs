using System;
using System.Collections.Generic;
using System.IO;
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
            }
            else
            {
                list = DAL1.APIAccessTeams.GetData2(api2);
            }

            int goalscntr = 0;
            int yellowcntr = 0;

            string r = DAL1.TextAccess.readFile(@"..\..\..\DAL1\Files\PlayerInfoHelper.txt");
            foreach (var item in list)
            {
               
                            foreach (var l in item.AwayTeamEvents)
                            {
                                if (l.TypeOfEvent == DAL1.QuickType.TypeOfEvent.Goal)
                                {
                                    if (lblName.Content.ToString().Trim() == l.Player)
                                    {
                                        goalscntr++;
                                    }

                                }
                            }
                            foreach (var l in item.HomeTeamEvents)
                            {
                                if (l.TypeOfEvent == DAL1.QuickType.TypeOfEvent.Goal)
                                {
                                    if (lblName.Content.ToString().Trim() == l.Player)
                                    {
                                        goalscntr++;
                                    }

                                }
                            }

                        }
                    
                    
                        foreach (var item in list)
                        {
                            foreach (var l in item.AwayTeamEvents)
                            {
                                if (l.TypeOfEvent == DAL1.QuickType.TypeOfEvent.YellowCard)
                                {
                                    if (lblName.Content.ToString().Trim() == l.Player)
                                    {
                                        yellowcntr++;
                                    }

                                }
                            }
                            foreach (var l in item.HomeTeamEvents)
                            {
                                if (l.TypeOfEvent == DAL1.QuickType.TypeOfEvent.YellowCard)
                                {
                                    if (lblName.Content.ToString().Trim() == l.Player)
                                    {
                                        yellowcntr++;
                                    }

                                }
                            }

                        }
            lblGoals.Content = "Ukupno golova: " + goalscntr;
            lblYellow.Content = "Ukupno žutih kartona: " + yellowcntr;




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
                            lblCaptain.Content = "Team member";

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

            string[] files = Directory.GetFiles(@"..\..\..\DAL1\Images\");

            foreach (string file in files)
            {

                if (lblName.Content.ToString().Trim() == file.GetUntilOrEmpty().Trim())
                {
                    imgBox.Source = new BitmapImage(new Uri(@"C:\Users\David\OneDrive - Visoko uciliste Algebra\Desktop\ProjektDesktop\DAL1\Images\"+ lblName.Content.ToString().Trim() +".png"));
                }
            }



        }
        
    }
    static class Helper
    {
        public static string GetUntilOrEmpty(this string text, string stopAt = ".")
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.LastIndexOf(stopAt, StringComparison.Ordinal) - 21;


                if (charLocation > 0)
                {
                    return text.Substring(21, charLocation);
                }
            }

            return String.Empty;
        }


    }
}
