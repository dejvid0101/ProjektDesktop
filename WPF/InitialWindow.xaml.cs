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
    /// Interaction logic for InitialWindow.xaml
    /// </summary>
    public partial class InitialWindow : Window
    {
        public InitialWindow()
        {
            
            InitializeComponent();
        }

        private char delim = ':';

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
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
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


            this.Close();

        }
    }
}
