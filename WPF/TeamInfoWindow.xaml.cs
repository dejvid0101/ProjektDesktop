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
    /// Interaction logic for TeamInfoWindow.xaml
    /// </summary>
    public partial class TeamInfoWindow : Window
    {
        public TeamInfoWindow()
        {
            InitializeComponent();
        }

        // at load check helper files to see which team should be shown
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string j = DAL1.TextAccess.readFile(@"..\..\..\DAL1\Files\BtnHelper.txt");
            if (j=="1")
            {

            try
            {
                string r = DAL1.TextAccess.readFile(@"..\..\..\DAL1\Files\Datainitial.txt");
                IList<DAL1.Team> f = DAL1.TextAccess.readCountries();

                foreach (var item in f)
                {
                    if (r==$"{item.Country} ({item.FifaCode})")
                    {
                            lblWon.Content=$"{item.Country} ({item.FifaCode})";
                            lblWon1.Content = $"Wins: {item.Wins}";
                            lblLost.Content = $"Defeats: {item.Losses}";
                            lblDraw.Content = $"Draws: {item.Draws}";
                            lblDealt.Content = $"Goals scored: {item.GoalsFor}";
                            lblReceived.Content = $"Goals received: {item.GoalsAgainst}";

                            if (item.GoalDifferential<0)
                            {
                                lblDiff.Foreground = Brushes.Red;
                            }
                            lblDiff.Content = $"Goal differential: {item.GoalsFor - item.GoalsAgainst}";

                        }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            }
            else
            {

                try
                {
                    string r = DAL1.TextAccess.readFile(@"..\..\..\DAL1\Files\OppInfoWindowHelper.txt");
                    IList<DAL1.Team> f = DAL1.TextAccess.readCountries();

                    foreach (var item in f)
                    {
                        if (r == $"{item.Country}")
                        {
                            lblWon.Content = $"{item.Country} ({item.FifaCode})";
                            lblWon1.Content = $"Wins: {item.Wins}";
                            lblLost.Content = $"Defeats: {item.Losses}";
                            lblDraw.Content = $"Draws: {item.Draws}";
                            lblDealt.Content = $"Goals scored: {item.GoalsFor}";
                            lblReceived.Content = $"Goals received: {item.GoalsAgainst}";

                            if (item.GoalDifferential < 0)
                            {
                                lblDiff.Foreground = Brushes.Red;
                            }
                            lblDiff.Content = $"Goal differential: {item.GoalsFor - item.GoalsAgainst}";

                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            }
            
    }
}
