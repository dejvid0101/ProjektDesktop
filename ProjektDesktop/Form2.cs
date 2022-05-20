using Newtonsoft.Json;
using RestSharp;
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
    public partial class Form2 : Form
    {
        public Form2()
        {


            Form1 f= new Form1();

            
            string v = DAL1.TextAccess.readFile(@"..\..\..\DAL1\Files\Initial.txt");
            string openForm2 = DAL1.TextAccess.readFile(@"..\..\..\DAL1\Files\Datanitial.txt");
            if (v == null||v=="")
            {
                
               f.ShowDialog();

        }
            InitializeComponent();
           
        }

        private void Form2_Load(object sender, EventArgs e) {
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

        private void Form2_Shown(object sender, EventArgs e)
        {
            
        }

        

        private void FillCBWData(IList<DAL1.Team> f)
        {
            foreach (var item in f)
            {
                comboBox1.Items.Add($"{item.Country} ({item.FifaCode})");
            }

            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
//StreamWriter wr = new StreamWriter("DataInitial.txt");
//            wr.WriteLine("");
//            wr.Close();
            string s=DAL1.TextAccess.readFile(@"..\..\..\DAL1\Files\Datainitial.txt");
            
            if (s==null||s=="")
            {
                DAL1.TextAccess.writeToFile($"{comboBox1.SelectedItem.ToString()}", @"..\..\..\DAL1\Files\Datainitial.txt");

                StreamWriter w = new StreamWriter(@"..\..\..\DAL1\Files\Datainitial.txt");
                w.WriteLine(comboBox1.SelectedItem);
                w.Close();
            }
            this.Close();
        }
    }
}
