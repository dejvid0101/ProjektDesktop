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
        private string api = "http://worldcup.sfg.io/matches";
        private string api2 = "https://world-cup-json-2018.herokuapp.com/matches";
        IList<Player> players = new List<Player>();
        IList<PlayerCtrl> favourites = new List<PlayerCtrl>();
        IList<PlayerCtrl> ctrllist = new List<PlayerCtrl>();

        int brojkopija=0;


        public Form3()
        {
            this.Cursor = Cursors.WaitCursor;

            Form2 f2 = new Form2();
            string openForm2 = DAL1.TextAccess.readFile(@"..\..\..\DAL1\Files\Datainitial.txt");
            if (openForm2 == null || openForm2 == "")
            {

                f2.ShowDialog();
            }
            InitializeComponent();
            this.Cursor = Cursors.Default;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count!=0)
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            string j=DAL1.TextAccess.readFile(@"..\..\..\DAL1\Files\Initial.txt");
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

            string[] files = Directory.GetFiles(@"..\..\..\DAL1\Images\");
            foreach (PlayerCtrl item in flowLayoutPanel1.Controls)
            {
                foreach (string file in files)
                {
                    
                    if (item.getName().Trim()== file.GetUntilOrEmpty().Trim())
                    {
                        item.setPhoto(file);
                    }
                }
            }
            foreach (PlayerCtrl item in panel1.Controls)
            {
                foreach (string file in files)
                {
                    
                    if (item.getName().Trim()== file.GetUntilOrEmpty().Trim())
                    {
                        item.setPhoto(file);
                    }
                }
            }
        }

        private void FillCBWData(string m)
        {
            try
            {
                IList<DAL1.QuickType.Tekma> list = DAL1.APIAccessTeams.GetData2(m);
                IList<PlayerCtrl> ctrllist=new List<PlayerCtrl>();
                string r = DAL1.TextAccess.readFile(@"..\..\..\DAL1\Files\Datainitial.txt");
                foreach (var item in list)
                {

                    if (item.AwayTeam.Country == r.Substring(0, (r.Length - 6)))
                    {
                        foreach (var i in item.AwayTeamStatistics.StartingEleven)
                        {
                            Player p = FillPlayersList(i);
                            PlayerCtrl u = new PlayerCtrl();
                            u.FillControl(i.Name, i.ShirtNumber.ToString(), i.Position.ToString(), p.Favourite);
                            
                            u.MouseDown += U_MouseDown;

                            flowLayoutPanel1.Controls.Add(u);
                            ctrllist.Add(u);

                        }
                        foreach (var i in item.AwayTeamStatistics.Substitutes)
                        {
                            Player p = FillPlayersList(i);
                            PlayerCtrl u = new PlayerCtrl();
                            u.FillControl(i.Name, i.ShirtNumber.ToString(), i.Position.ToString(), p.Favourite);
                            u.MouseDown += U_MouseDown;
                            
                            flowLayoutPanel1.Controls.Add(u);
                            ctrllist.Add(u);
                        }
                        break;
                    }

                }

                foreach(var ctrl in ctrllist)
                {
                    if (ctrl.IsFavourite())
                    {
                        panel1.Controls.Add(ctrl);
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
                string test = DAL1.TextAccess.readFile(@"..\..\..\DAL1\Files\Favourites.txt");
                if (test == "" || test == null)
                {

                    p.Favourite = false;
                    p.Name = i.Name;
                    players.Add(p);
                    return p;

                }


                    IList<String> favourites = DAL1.TextAccess.readFile2(@"..\..\..\DAL1\Files\Favourites.txt");
                    

                    foreach (string favourite in favourites)
                    {
                    string[] faves = favourite.Split(':');

                    foreach (string fave in faves)
                    {

                        if (fave == i.Name)
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
            PlayerCtrl p; 
            IList<String> a = new List<String>();
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                p = panel1.Controls[i] as PlayerCtrl;
               
                a.Add(p.ControlToString2());
                string[] list = new string[a.Count];
                for (int j = 0; j < a.Count; j++)
                {
                    list[j] = $"{a[j]}"+":";
                }
                DAL1.TextAccess.writeToFaves(list, @"..\..\..\DAL1\Files\Favourites.txt");
            }

                //retrieve string array list from ctrl
                //write to file from each string array


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            IList<PlayerCtrl> list = new List<PlayerCtrl>();
            foreach (PlayerCtrl item in flowLayoutPanel1.Controls)
            {
                if (item.BorderStyle==BorderStyle.Fixed3D)
                {
                    list.Add(item);
                }
            }

            if (list.Count>1||list.Count<1)
            {
                MessageBox.Show("Please only select one player.");
                return;
            }

            OpenFileDialog opnfd = new OpenFileDialog
            {
                Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|PNG Image|*.png"
            };

            if (opnfd.ShowDialog() == DialogResult.OK)
            { 
                string fileName = opnfd.FileName;
                string safeFileName = $"{list[0].getName()}.png";

                try
                {
                    string path = @"..\..\..\DAL1\Images\";
                    
                    
                    File.Copy(fileName, path + safeFileName);
                    
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                foreach (PlayerCtrl item in list)
                {
                    item.setPhoto(@"..\..\..\DAL1\Images\" + safeFileName);
                }
            }
            opnfd.Dispose();

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int pointY = e.MarginBounds.Y-150;
            Font f = new Font("Serif", 24);
            
            int counter =0;

            foreach (PlayerCtrl pctrl in flowLayoutPanel1.Controls)
            {
                
                flowLayoutPanel2.Controls.Add(pctrl);
            }

            

            foreach(PlayerCtrl pctrl in flowLayoutPanel2.Controls)
            {
                if (counter>6)
                {
                    break;
                }
                pointY += 150;
                counter++;
                string[] info = pctrl.ControlToString();
                flowLayoutPanel2.Controls.Remove(pctrl);
                e.Graphics.DrawString(info[0], f, Brushes.Black, new PointF(e.MarginBounds.X, pointY));
                e.Graphics.DrawString(info[1], f, Brushes.Black, new PointF(e.MarginBounds.X, pointY + 35));
                e.Graphics.DrawString($"{info[2]}", f, Brushes.Black, new PointF(e.MarginBounds.X, pointY + 70));

            }

            

            
            
           

            if (flowLayoutPanel2.Controls.Count==0)
            {
                e.HasMorePages = false;
                
            }
            else
            {
                e.HasMorePages = true;
            }


            
        }

        

        private void button6_MouseClick(object sender, MouseEventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
    }
    static class Helper
    {
        public static string GetUntilOrEmpty(this string text, string stopAt = ".")
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.LastIndexOf(stopAt, StringComparison.Ordinal)-21;
                

                if (charLocation > 0)
                {
                    return text.Substring(21, charLocation);
                }
            }

            return String.Empty;
        }

        
    }

   
}

