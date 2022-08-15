using DAL1.QuickType;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for LineupUC.xaml
    /// </summary>
    public partial class LineupUC : UserControl
    {
        public LineupUC()
        {
            InitializeComponent();
        }

        // fill and position Player UCs on LineupUC
        public void FillField(DAL1.QuickType.Tekma t)
        {
            IList<string> defenders = new List<string>();
            IList<string> midfielders = new List<string>();
            IList<string> forwards = new List<string>();


            for (int i = 0; i < t.HomeTeamStatistics.StartingEleven.Length; i++)
            {
                string z= t.HomeTeamStatistics.StartingEleven[i].Name;
                string s= t.HomeTeamStatistics.StartingEleven[i].ShirtNumber.ToString();
                if (t.HomeTeamStatistics.StartingEleven[i].Position== "Goalie")
                {
                    //lines.Add(z);
                    r1c0.lblName.Content = z;
                    r1c0.Visibility = Visibility.Visible;
                    r1c0.lblTeam.Content = t.HomeTeam.Code;
                    //work in progress
                }
                if (t.HomeTeamStatistics.StartingEleven[i].Position== "Defender")
                {
                   defenders.Add(z);
                    
                }
                if (t.HomeTeamStatistics.StartingEleven[i].Position== "Midfield")
                {
                   midfielders.Add(z);
                    
                }
                if (t.HomeTeamStatistics.StartingEleven[i].Position== "Forward")
                {
                   forwards.Add(z);
                    
                }
                
            }

            while (defenders.Count!=0)
            {
                if (defenders.Count==4)
                {
                    r3c1.lblName.Content = defenders[0];
                    r3c1.Visibility = Visibility.Visible;
                    r3c1.lblTeam.Content = t.HomeTeam.Code;
                    defenders.RemoveAt(0);
                }
                else if (defenders.Count==3)
                {
                    r1c1.lblName.Content = defenders[0];
                    r1c1.Visibility = Visibility.Visible;
                    r1c1.lblTeam.Content = t.HomeTeam.Code;
                    defenders.RemoveAt(0);
                }
                else if (defenders.Count == 2)
                {
                    r2c1.lblName.Content = defenders[0];
                    r2c1.Visibility = Visibility.Visible;
                    r2c1.lblTeam.Content = t.HomeTeam.Code;
                    defenders.RemoveAt(0);
                }else if (defenders.Count == 1)
                {
                    r0c1.lblName.Content = defenders[0];
                    r0c1.Visibility = Visibility.Visible;
                    r0c1.lblTeam.Content = t.HomeTeam.Code;
                    defenders.RemoveAt(0);
                }

            }
            while (midfielders.Count!=0)
            {
                if (midfielders.Count==4)
                {
                    r3c2.lblName.Content = midfielders[0];
                    r3c2.Visibility = Visibility.Visible;
                    r3c2.lblTeam.Content = t.HomeTeam.Code;
                    midfielders.RemoveAt(0);
                }
                else if (midfielders.Count==3)
                {
                    r1c2.lblName.Content = midfielders[0];
                    r1c2.Visibility = Visibility.Visible;
                    r1c2.lblTeam.Content = t.HomeTeam.Code;
                    midfielders.RemoveAt(0);
                }
                else if (midfielders.Count == 2)
                {
                    r2c2.lblName.Content = midfielders[0];
                    r2c2.Visibility = Visibility.Visible;
                    r2c2.lblTeam.Content = t.HomeTeam.Code;
                    midfielders.RemoveAt(0);
                }else if (midfielders.Count == 1)
                {
                    r0c2.lblName.Content = midfielders[0];
                    r0c2.Visibility = Visibility.Visible;
                    r0c2.lblTeam.Content = t.HomeTeam.Code;
                    midfielders.RemoveAt(0);
                }

            }

            while (forwards.Count != 0)
            {
                if (forwards.Count == 4)
                {
                    r3c3.lblName.Content = forwards[0];
                    r3c3.Visibility = Visibility.Visible;
                    r3c3.lblTeam.Content = t.HomeTeam.Code;
                    forwards.RemoveAt(0);
                }
                else if (forwards.Count == 3)
                {
                    r1c3.lblName.Content = forwards[0];
                    r1c3.Visibility = Visibility.Visible;
                    r1c3.lblTeam.Content = t.HomeTeam.Code;
                    forwards.RemoveAt(0);
                }
                else if (forwards.Count == 2)
                {
                    r2c3.lblName.Content = forwards[0];
                    r2c3.Visibility = Visibility.Visible;
                    r2c3.lblTeam.Content = t.HomeTeam.Code;
                    forwards.RemoveAt(0);
                }
                else if (forwards.Count == 1)
                {
                    r0c3.lblName.Content = forwards[0];
                    r0c3.Visibility = Visibility.Visible;
                    r0c3.lblTeam.Content = t.HomeTeam.Code;
                    forwards.RemoveAt(0);
                }

            }

            defenders.Clear();
            midfielders.Clear();
            forwards.Clear();

            for (int i = 0; i < t.AwayTeamStatistics.StartingEleven.Length; i++)
            {
                string z = t.AwayTeamStatistics.StartingEleven[i].Name;
                string s = t.AwayTeamStatistics.StartingEleven[i].ShirtNumber.ToString();
                if (t.AwayTeamStatistics.StartingEleven[i].Position == "Goalie")
                {
                    //lines.Add(z);
                    r2c7.lblName.Content = z;
                    r2c7.Visibility = Visibility.Visible;
                    r2c7.lblTeam.Content = t.AwayTeam.Code;
                    //work in progress
                }
                if (t.AwayTeamStatistics.StartingEleven[i].Position == "Defender")
                {
                    defenders.Add(z);

                }
                if (t.AwayTeamStatistics.StartingEleven[i].Position == "Midfield")
                {
                    midfielders.Add(z);

                }
                if (t.AwayTeamStatistics.StartingEleven[i].Position == "Forward")
                {
                    forwards.Add(z);

                }

            }  // test please

            while (defenders.Count != 0)
            {
                if (defenders.Count == 4)
                {
                    r3c6.lblName.Content = defenders[0];
                    r3c6.Visibility = Visibility.Visible;
                    r3c6.lblTeam.Content = t.AwayTeam.Code;
                    defenders.RemoveAt(0);
                }
                else if (defenders.Count == 3)
                {
                    r1c6.lblName.Content = defenders[0];
                    r1c6.Visibility = Visibility.Visible;
                    r1c6.lblTeam.Content = t.AwayTeam.Code;
                    defenders.RemoveAt(0);
                }
                else if (defenders.Count == 2)
                {
                    r2c6.lblName.Content = defenders[0];
                    r2c6.Visibility = Visibility.Visible;
                    r2c6.lblTeam.Content = t.AwayTeam.Code;
                    defenders.RemoveAt(0);
                }
                else if (defenders.Count == 1)
                {
                    r0c6.lblName.Content = defenders[0];
                    r0c6.Visibility = Visibility.Visible;
                    r0c6.lblTeam.Content = t.AwayTeam.Code;
                    defenders.RemoveAt(0);
                }

            }
            while (midfielders.Count != 0)
            {
                if (midfielders.Count == 4)
                {
                    r3c5.lblName.Content = midfielders[0];
                    r3c5.Visibility = Visibility.Visible;
                    r3c5.lblTeam.Content = t.AwayTeam.Code;
                    midfielders.RemoveAt(0);
                }
                else if (midfielders.Count == 3)
                {
                    r1c5.lblName.Content = midfielders[0];
                    r1c5.Visibility = Visibility.Visible;
                    r1c5.lblTeam.Content = t.AwayTeam.Code;
                    midfielders.RemoveAt(0);
                }
                else if (midfielders.Count == 2)
                {
                    r2c5.lblName.Content = midfielders[0];
                    r2c5.Visibility = Visibility.Visible;
                    r2c5.lblTeam.Content = t.AwayTeam.Code;
                    midfielders.RemoveAt(0);
                }
                else if (midfielders.Count == 1)
                {
                    r0c5.lblName.Content = midfielders[0];
                    r0c5.Visibility = Visibility.Visible;
                    r0c5.lblTeam.Content = t.AwayTeam.Code;
                    midfielders.RemoveAt(0);
                }

            }

            while (forwards.Count != 0)
            {
                if (forwards.Count == 4)
                {
                    r3c4.lblName.Content = forwards[0];
                    r3c4.Visibility = Visibility.Visible;
                    r3c4.lblTeam.Content = t.AwayTeam.Code;
                    forwards.RemoveAt(0);
                }
                else if (forwards.Count == 3)
                {
                    r1c4.lblName.Content = forwards[0];
                    r1c4.Visibility = Visibility.Visible;
                    r1c4.lblTeam.Content = t.AwayTeam.Code;
                    forwards.RemoveAt(0);
                }
                else if (forwards.Count == 2)
                {
                    r2c4.lblName.Content = forwards[0];
                    r2c4.Visibility = Visibility.Visible;
                    r2c4.lblTeam.Content = t.AwayTeam.Code;
                    forwards.RemoveAt(0);
                }
                else if (forwards.Count == 1)
                {
                    r0c4.lblName.Content = forwards[0];
                    r0c4.Visibility = Visibility.Visible;
                    r0c4.lblTeam.Content = t.AwayTeam.Code;
                    forwards.RemoveAt(0);
                }

            }


        

    }

        private void r1c0_MouseEnter(object sender, MouseEventArgs e)
        {
            Player p=sender as Player;
            p.Background = Brushes.DarkGray; p.lblName.Foreground = Brushes.White;
            p.lblTeam.Foreground = Brushes.White;
            Cursor = Cursors.Hand;
        }
        // white half mouseleave
        private void r1c0_MouseLeave(object sender, MouseEventArgs e)
        {
            Player p = sender as Player;
            p.Background = Brushes.White; p.lblName.Foreground = Brushes.Black;
            p.lblTeam.Foreground = Brushes.Black;
            Cursor = Cursors.Arrow;
        }
        // bisque half mouseleave
        private void r0c4_MouseLeave(object sender, MouseEventArgs e)
        {
            Player p = sender as Player;
            p.Background = Brushes.Bisque; p.lblName.Foreground = Brushes.Black;
            p.lblTeam.Foreground = Brushes.Black;
            Cursor = Cursors.Arrow;
        }

        private void r1c0_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Cursor = Cursors.Wait;
            Player player = sender as Player;
            string c = player.lblName.Content.ToString();
            DAL1.TextAccess.writeToFile(c, @"..\..\..\DAL1\Files\PlayerInfoHelper.txt");
            PlayerInfoWindow p = new PlayerInfoWindow();
            
            p.Show();
        }
    }
}
