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
            
            string openForm2 = DAL1.TextAccess.readFile(@"..\..\..\DAL1\Files\Initial.txt");
            if (openForm2 == null || openForm2 == "")
            {
                this.Hide();
InitialWindow f2 = new InitialWindow();
                f2.ShowDialog();
                this.Show();
            }

            string j = DAL1.TextAccess.readFile(@"..\..\..\DAL1\Files\Initial.txt");
            string[] data = j.Split(':');
            if (data[2] == "1280*720")
            {
                Application.Current.MainWindow.Height = 720;
                Application.Current.MainWindow.Width = 1280;
            }
            else if (data[2] =="800*600")
            {
                Application.Current.MainWindow.Height = 600;
                Application.Current.MainWindow.Width = 800;
            } else if (data[2] == "1920*1080")
            {
                Application.Current.MainWindow.Height = 1080;
                Application.Current.MainWindow.Width = 1920;
            } else
            {
                Application.Current.MainWindow.Height = 1080;
                Application.Current.MainWindow.Width = 1920;
            }
            

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
            Cursor=Cursors.Wait;

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
                FillCBWData(api);
            }
            else
            {
                FillCBWData(api2);
            }

            this.Cursor = Cursors.Arrow;
        }

        private void comboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cursor = Cursors.Wait;

            UCField.r1c1.Visibility = Visibility.Hidden;
            UCField.r2c1.Visibility = Visibility.Hidden;
            UCField.r0c1.Visibility = Visibility.Hidden;
            UCField.r3c1.Visibility = Visibility.Hidden;
            UCField.r1c2.Visibility = Visibility.Hidden;
            UCField.r2c2.Visibility = Visibility.Hidden;
            UCField.r3c2.Visibility = Visibility.Hidden;
            UCField.r0c2.Visibility = Visibility.Hidden;
            UCField.r1c3.Visibility = Visibility.Hidden;
            UCField.r0c3.Visibility = Visibility.Hidden;
            UCField.r2c3.Visibility = Visibility.Hidden;
            UCField.r3c3.Visibility = Visibility.Hidden;
            UCField.r3c4.Visibility = Visibility.Hidden;
            UCField.r2c4.Visibility = Visibility.Hidden;
            UCField.r1c4.Visibility = Visibility.Hidden;
            UCField.r0c4.Visibility = Visibility.Hidden;
            UCField.r0c5.Visibility = Visibility.Hidden;
            UCField.r1c5.Visibility = Visibility.Hidden;
            UCField.r2c5.Visibility = Visibility.Hidden;
            UCField.r3c5.Visibility = Visibility.Hidden;
            UCField.r3c6.Visibility = Visibility.Hidden;
            UCField.r2c6.Visibility = Visibility.Hidden;
            UCField.r1c6.Visibility = Visibility.Hidden;
            UCField.r0c6.Visibility = Visibility.Hidden;
            UCField.r1c0.Visibility = Visibility.Hidden;
            UCField.r2c7.Visibility = Visibility.Hidden;

            if (comboBox2.SelectedItem==null)
            {
                return;
            }

            DAL1.TextAccess.writeToFile($"{comboBox2.SelectedItem.ToString()}", @"..\..\..\DAL1\Files\OppInfoWindowHelper.txt");


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
                // select country according to selected item and do something with the info
                foreach (var item in list)
                {

                    if (item.HomeTeam.Country.ToString() == cb1Helper &&
                        item.AwayTeam.Country.ToString()==cb2Helper)
                    {
                        lblHost.Content = item.HomeTeam.Code;
                        lblOpp.Content = item.AwayTeam.Code;

                        lblResult1.Content = "  "+item.HomeTeam.Goals.ToString();
                        lblResult2.Content = item.AwayTeam.Goals.ToString();

                        UCField.FillField(item);
                    }
                    else if (item.AwayTeam.Country.ToString() ==cb1Helper &&
                        item.HomeTeam.Country.ToString() == cb2Helper)
                    {
                        lblOpp.Content = item.HomeTeam.Code;
                        lblHost.Content = item.AwayTeam.Code;

                        lblResult2.Content = item.HomeTeam.Goals.ToString();
                        lblResult1.Content = "  "+ item.AwayTeam.Goals.ToString();

                        UCField.FillField(item);
                    }

                }

            }
            catch (NullReferenceException)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Cursor = Cursors.Arrow;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DAL1.TextAccess.writeToFile("1",@"..\..\..\DAL1\Files\BtnHelper.txt");
            TeamInfoWindow t=new TeamInfoWindow();
            t.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DAL1.TextAccess.writeToFile("2", @"..\..\..\DAL1\Files\BtnHelper.txt");
            TeamInfoWindow t = new TeamInfoWindow();
            t.Show();
        }

        private void UCField_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
