using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektDesktop
{
    public partial class Form1 : Form
    {
        private char delim = ':';
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem==null||comboBox2.SelectedItem==null || comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Molimo odaberite vrijednosti");
                return;
            }
            
           
      try
            {
                DAL1.TextAccess.writeToFile($"{comboBox1.SelectedItem.ToString()}{delim}{comboBox2.SelectedItem.ToString()}{delim}{comboBox3.SelectedItem.ToString()}", @"..\..\..\DAL1\Files\Initial.txt");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            
           this.Close();
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
