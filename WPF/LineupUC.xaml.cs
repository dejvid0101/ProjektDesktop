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
                    r0c1.lblName.Content = defenders[0];
                    r0c1.Visibility = Visibility.Visible;
                    defenders.RemoveAt(0);
                }
                else if (defenders.Count==3)
                {
                    r1c1.lblName.Content = defenders[0];
                    r1c1.Visibility = Visibility.Visible;
                    defenders.RemoveAt(0);
                }
                else if (defenders.Count == 2)
                {
                    r2c1.lblName.Content = defenders[0];
                    r2c1.Visibility = Visibility.Visible;
                    defenders.RemoveAt(0);
                }else if (defenders.Count == 1)
                {
                    r3c1.lblName.Content = defenders[0];
                    r3c1.Visibility = Visibility.Visible;
                    defenders.RemoveAt(0);
                }

            }
            while (midfielders.Count!=0)
            {
                if (midfielders.Count==4)
                {
                    r0c2.lblName.Content = midfielders[0];
                    r0c2.Visibility = Visibility.Visible;
                    midfielders.RemoveAt(0);
                }
                else if (midfielders.Count==3)
                {
                    r1c2.lblName.Content = midfielders[0];
                    r1c2.Visibility = Visibility.Visible;
                    midfielders.RemoveAt(0);
                }
                else if (midfielders.Count == 2)
                {
                    r2c2.lblName.Content = midfielders[0];
                    r2c2.Visibility = Visibility.Visible;
                    midfielders.RemoveAt(0);
                }else if (midfielders.Count == 1)
                {
                    r3c2.lblName.Content = midfielders[0];
                    r3c2.Visibility = Visibility.Visible;
                    midfielders.RemoveAt(0);
                }

            }

            while (forwards.Count != 0)
            {
                if (forwards.Count == 4)
                {
                    r0c3.lblName.Content = forwards[0];
                    r0c3.Visibility = Visibility.Visible;
                    forwards.RemoveAt(0);
                }
                else if (forwards.Count == 3)
                {
                    r1c3.lblName.Content = forwards[0];
                    r1c3.Visibility = Visibility.Visible;
                    forwards.RemoveAt(0);
                }
                else if (forwards.Count == 2)
                {
                    r2c3.lblName.Content = forwards[0];
                    r2c3.Visibility = Visibility.Visible;
                    forwards.RemoveAt(0);
                }
                else if (forwards.Count == 1)
                {
                    r3c3.lblName.Content = forwards[0];
                    r3c3.Visibility = Visibility.Visible;
                    forwards.RemoveAt(0);
                }

            }


        }
    }
}
