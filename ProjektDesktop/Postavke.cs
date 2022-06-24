using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektDesktop
{
    public partial class Postavke : Form
    {
        private char delim = ':';
        public Postavke()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure?",
                                     "Confirm Choice",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                
            }
            else
            {
                return;
            }

            if (comboBox2.SelectedItem == null||comboBox3.SelectedItem==null )
            {
                MessageBox.Show("Molimo odaberite vrijednosti");
                return;
            }


            try
            {
                DAL1.TextAccess.writeToFile($"{comboBox1.SelectedItem.ToString()}{delim}{comboBox2.SelectedItem.ToString()}", @"..\..\..\DAL1\Files\Initial.txt");
                DAL1.TextAccess.writeToFile($"{comboBox3.SelectedItem.ToString()}", @"..\..\..\DAL1\Files\Datainitial.txt");

               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


            this.Close();


        }

        private void FillCBWData(IList<DAL1.Team> f)
        {
            foreach (var item in f)
            {
                comboBox3.Items.Add($"{item.Country} ({item.FifaCode})");
            }


        }

        private void Postavke_Load(object sender, EventArgs e)
        {
            string s = DAL1.TextAccess.readFile(@"..\..\..\DAL1\Files\Initial.txt");
            string[] vs = s.Split(':');
            if (vs[1] == "Engleski")
            {
                comboBox2.SelectedItem=comboBox2.Items[1];
            }
            else { comboBox2.SelectedItem=comboBox2.Items[0]; }

            try
            {
                label1.Text = DAL1.TextAccess.fillLabel();
                FillCBWData(DAL1.TextAccess.readCountries());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Molimo odaberite jezik");
                return;
            }
            else
            {


                try
                {
                    DAL1.TextAccess.writeToFile($"{comboBox1.SelectedItem.ToString()}{delim}{comboBox2.SelectedItem.ToString()}", @"..\..\..\DAL1\Files\Initial.txt");
                    comboBox3.Items.Clear();
                    FillCBWData(DAL1.TextAccess.readCountries());

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                if (comboBox1.SelectedItem.ToString() == "Žensko nogometno")
                {

                }
            }
        }
    }
}
