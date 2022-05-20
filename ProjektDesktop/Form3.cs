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
    public partial class Form3 : Form
    {
        private Control selectedCtrl;
        private string api = "http://worldcup.sfg.io/matches";
        private string api2 = "https://world-cup-json-2018.herokuapp.com/matches";
        IList<Player> players = new List<Player>();
        IList<PlayerCtrl> favourites = new List<PlayerCtrl>();


        public Form3()
        {
            this.Cursor = Cursors.WaitCursor;

            Form2 f2 = new Form2();
            string openForm2 = DAL1.TextAccess.readFile("Datainitial.txt");
            if (openForm2 == null || openForm2 == "")
            {

                f2.ShowDialog();

            }
            InitializeComponent();
            this.Cursor = Cursors.Default;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            string j=DAL1.TextAccess.readFile("Initial.txt");
            string[] data=j.Split(':');
            if (data[0] == "Žensko nogometno")
            {
                FillCBWData(api);
            }
            else
            {
                FillCBWData(api2);
            }

            this.Cursor = Cursors.Default;
        }

        private void FillCBWData(string m)
        {
            try
            {
                IList<DAL1.QuickType.Tekma> list = DAL1.APIAccessTeams.GetData2(m);
                string r = DAL1.TextAccess.readFile("Datainitial.txt");
                foreach (var item in list)
                {

                    if (item.AwayTeam.Country == r.Substring(0, (r.Length - 6)))
                    {
                        foreach (var i in item.AwayTeamStatistics.StartingEleven)
                        {
                            Player p = FillPlayersList(i);
                            PlayerCtrl u = new PlayerCtrl();
                            u.FillControl(i.Name, i.ShirtNumber.ToString(), i.Position, p.Favourite);

                            u.MouseDown += U_MouseDown;

                            flowLayoutPanel1.Controls.Add(u);


                        }
                        foreach (var i in item.AwayTeamStatistics.Substitutes)
                        {
                            Player p = FillPlayersList(i);
                            PlayerCtrl u = new PlayerCtrl();
                            u.FillControl(i.Name, i.ShirtNumber.ToString(), i.Position, p.Favourite);
                            u.MouseDown += U_MouseDown;
                            flowLayoutPanel1.Controls.Add(u);
                        }
                        break;
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void U_Click(object sender, EventArgs e)
        {
            
        }

        private void U_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void U_MouseDown(object sender, MouseEventArgs e)
        {
            PlayerCtrl u = sender as PlayerCtrl;
            if (e.Button == MouseButtons.Right) { OznaciKontrolu(u);
            } else if (e.Button == MouseButtons.Left) { u.DoDragDrop(u, DragDropEffects.Copy); }
            
            
        }

        private void OznaciKontrolu(PlayerCtrl u)
        {
            if (u.BorderStyle == BorderStyle.None)
            {
                u.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            } else
            {
                u.BorderStyle = System.Windows.Forms.BorderStyle.None;
            }
        }

        private Player FillPlayersList(DAL1.QuickType.StartingEleven i)
        {
            Player p = new Player();
            try
            {
                using (StreamReader sr2 = new StreamReader("Favourites.txt"))
                {
                    string favourites = sr2.ReadToEnd();
                    string[] favouritesSplit = favourites.Split(':');

                    foreach (string favourite in favouritesSplit)
                    {
                        if (favourite == i.Name)
                        {
                            p.Favourite = true;
                            p.Name = i.Name;
                            players.Add(p);
                            break;
                        }
                        else
                        {

                            p.Favourite = false;
                            p.Name = i.Name;
                            players.Add(p);
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                Application.ExitThread();

            }
            return p;
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_DragOver(object sender, DragEventArgs e)
        {

        }

        private void flowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {

        }





        private void panel1_DragEnter_1(object sender, DragEventArgs e)
        {

        }

        private void panel1_DragDrop_1(object sender, DragEventArgs e)
        {


        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void panel1_DragDrop_2(object sender, DragEventArgs e)
        {
            //PlayerCtrl clickee = selectedCtrl as PlayerCtrl;
            //            string v = clickee.XtractControl();
            //            string[] vv = v.Split(':');
            //            clickee.FillControl(vv[1], vv[2], vv[3], clickee.Fave);
            //            clickee.BorderStyle = BorderStyle.None;
            //            panel1.Controls.Add(clickee);
            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            {
                PlayerCtrl player = flowLayoutPanel1.Controls[i] as PlayerCtrl;

                if (player.BorderStyle==BorderStyle.Fixed3D)
                {
                    favourites.Add(player);
                }
            }

            foreach (var item in favourites)
            {
                panel1.Controls.Add(item);
            }

        }
           

        private void panel1_DragEnter_2(object sender, DragEventArgs e)
        {
e.Effect = DragDropEffects.Copy;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            {
                PlayerCtrl player = flowLayoutPanel1.Controls[i] as PlayerCtrl;

                if (player.BorderStyle == BorderStyle.Fixed3D)
                {
                    favourites.Add(player);
                }
            }

            foreach (var item in favourites)
            {
                panel1.Controls.Add(item);
            }

        }
    }
}
