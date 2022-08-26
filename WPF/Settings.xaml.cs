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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private char delim = ':';

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure?",
                                     "Confirm Choice",
                                     MessageBoxButton.YesNo);
            if (confirmResult == MessageBoxResult.Yes)
            {
                
            }
            else
            {
                return;
            }
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Molimo odaberite vrijednosti");
                return;
            }


            try
            {
                DAL1.TextAccess.writeToFile($"{comboBox2.SelectedValue.ToString().Substring(38)}{delim}{comboBox1.SelectedValue.ToString().Substring(38)}" +
                    $"{delim}{comboBox3.SelectedValue.ToString().Substring(38)}", @"..\..\..\DAL1\Files\Initial.txt");
                DAL1.TextAccess.writeToFile($"{comboBox1.SelectedItem.ToString().Substring(38)}", @"..\..\..\DAL1\Files\SprachDatei.txt");
                MessageBox.Show("Please restart app to see changes.");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


            this.Close();

        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
