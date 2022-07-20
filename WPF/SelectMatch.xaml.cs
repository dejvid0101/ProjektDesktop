using DAL1;
using ProjektDesktop;
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
    /// Interaction logic for SelectMatch.xaml
    /// </summary>
    public partial class SelectMatch : Window
    {
        private string api = "http://worldcup.sfg.io/matches";
        private string api2 = "https://world-cup-json-2018.herokuapp.com/matches";

        public SelectMatch()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                IList<DAL1.Team> f = DAL1.TextAccess.readCountries();

                foreach (var item in f)
                {
                    comboBox1.Items.Add($"{item.Country} ({item.FifaCode})");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            
        }

        private void FillCBWData(string api)
        {
            try
            {
                IList<DAL1.QuickType.Tekma> list = DAL1.APIAccessTeams.GetData2(api);

                string r = DAL1.TextAccess.readFile(@"..\..\..\DAL1\Files\Datainitial.txt");
                foreach (var item in list)
                {

                    if (item.AwayTeam.Country == r.Substring(0, (r.Length - 6)))
                    {

                        comboBox2.Items.Add(item.HomeTeam.Country);
                    }
                    else if (item.HomeTeam.Country == r.Substring(0, (r.Length - 6)))
                    {
                        comboBox2.Items.Add(item.AwayTeam.Country);
                    }

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox1.SelectedItem==null)
            {
                return;
            }
            DAL1.TextAccess.writeToFile($"{comboBox1.SelectedItem.ToString()}", @"..\..\..\DAL1\Files\Datainitial.txt");

            this.Cursor = Cursors.Wait;

            comboBox2.Items.Clear();

            string j = DAL1.TextAccess.readFile(@"..\..\..\DAL1\Files\Initial.txt");
            string[] data = j.Split(':');
            if (data[0] == "Žensko nogometno")
            {
                // fill controls with data and append to layoutpanel
                FillCBWData(api);
            }
            else
            {
                // fill controls with data and append to layoutpanel
                FillCBWData(api2);
            }

            this.Cursor = Cursors.Arrow;
        }

        private void comboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox2.SelectedItem==null)
            {
                return;
            }

            try
            {

                string cb1Helper = comboBox1.SelectedItem.ToString().Substring(0, ((comboBox1.SelectedItem.ToString().Length) - 6));
                string cb2Helper = comboBox2.SelectedItem.ToString();

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

                foreach (var item in list)
                {

                    if (item.HomeTeam.Country.ToString() == cb1Helper &&
                        item.AwayTeam.Country.ToString()==cb2Helper)
                    {

                        lblHost.Content = item.HomeTeam.Code;
                        lblOpp.Content = item.AwayTeam.Code;

                        lblResult1.Content = item.HomeTeam.Goals.ToString();
                        lblResult2.Content = item.AwayTeam.Goals.ToString();
                    }
                    else if (item.AwayTeam.Country.ToString() ==cb1Helper &&
                        item.HomeTeam.Country.ToString() == cb2Helper)
                    {
                        lblOpp.Content = item.HomeTeam.Code;
                        lblHost.Content = item.AwayTeam.Code;

                        lblResult2.Content = item.HomeTeam.Goals.ToString();
                        lblResult1.Content = item.AwayTeam.Goals.ToString();
                    }

                }

            }
            catch (NullReferenceException nex)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 

        }
    }
}
