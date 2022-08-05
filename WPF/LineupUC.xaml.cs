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
            IList<string> lines = new List<string>();   

            for (int i = 0; i < t.HomeTeamStatistics.StartingEleven.Length; i++)
            {
                string z= t.HomeTeamStatistics.StartingEleven[i].Name;
                if (t.HomeTeamStatistics.StartingEleven[i].Position== "Goalie")
                {
                    //lines.Add(z);
                    r1c0.lblName.Content = z;
                    r1c0.lblShirt.Content = t.HomeTeamStatistics.StartingEleven[i].ShirtNumber.ToString();
                    //make it work
                }
                
            }

            

            
        }
    }
}
