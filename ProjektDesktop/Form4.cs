using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektDesktop
{
    public partial class Form4 : Form
    {
        private string api = "http://worldcup.sfg.io/matches";
        private string api2 = "https://world-cup-json-2018.herokuapp.com/matches";
        List<PlayerCtrl> ctrllist = new List<PlayerCtrl>();
        IList<Player> players = new List<Player>();
        int rating = 1;
        public Form4()
        {
            SetLanguage();
            InitializeComponent();
        }
        private void SetLanguage()
        {
            string vrr = DAL1.TextAccess.readFile(@"..\..\..\DAL1\Files\SprachDatei.txt");
            CultureInfo kltr;
            if (string.IsNullOrEmpty(vrr) || vrr == "Engleski") { kltr = new CultureInfo("en"); }
            else { kltr = new CultureInfo("hr"); }



            Thread.CurrentThread.CurrentUICulture = kltr;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void FillCBWData(string m)
        {
            try
            {
                IList<DAL1.QuickType.Tekma> list = DAL1.APIAccessTeams.GetData2(m);
                
                string r = DAL1.TextAccess.readFile(@"..\..\..\DAL1\Files\Datainitial.txt");
                foreach (var item in list)
                {

                    if (item.AwayTeam.Country == r.Substring(0, (r.Length - 6)))
                    {
                        foreach (var i in item.AwayTeamStatistics.StartingEleven)
                        {
                            Player p = FillPlayersList(i);
                            PlayerCtrl u = new PlayerCtrl();
                            u.FillControl(i.Name, Goals(i.Name, list, "g").ToString(), Goals(i.Name, list, "y").ToString(), p.Favourite);

                            ctrllist.Add(u);


                        }
                        foreach (var i in item.AwayTeamStatistics.Substitutes)
                        {
                            Player p = FillPlayersList(i);
                            PlayerCtrl u = new PlayerCtrl();
                            u.FillControl(i.Name, Goals(i.Name, list, "g").ToString(), Goals(i.Name, list, "y").ToString(), p.Favourite);
                            RatingCtrl rank = new RatingCtrl();

                            ctrllist.Add(u);

                        }
                        break;
                    }

                }

                ComparerGoals gg = new ComparerGoals();
                ctrllist.Sort(gg);

                foreach (var ctrl in ctrllist)
                {

                    flowLayoutPanel1.Controls.Add(ctrl);
                }

                FillLeaderboard();

            }

            // gumbovi za sortiranje po žutom katonu

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            
        }

        private void FillLeaderboard()
        {

            flowLayoutPanel2.Controls.Clear();
            
                foreach (var item in ctrllist)
                {
                    RatingCtrl rank = new RatingCtrl();
                    rank.setRating(rating, item.getName());
                    flowLayoutPanel2.Controls.Add(rank);
                    rating++;
                


            }
            rating = 1;
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

        private int Goals(string name, IList<DAL1.QuickType.Tekma> list, string what)
        {

            PlayerGoals pg = new PlayerGoals
            {
                Name = name,
                Goals = 0

            };

            if (what == "g")
            {



                foreach (var item in list)
                {
                    foreach (var e in item.AwayTeamEvents)
                    {
                        if (e.TypeOfEvent == DAL1.QuickType.TypeOfEvent.Goal)
                        {
                            if (pg.Name == e.Player)
                            {
                                pg.Goals++;
                            }

                        }
                    }
                    foreach (var e in item.HomeTeamEvents)
                    {
                        if (e.TypeOfEvent == DAL1.QuickType.TypeOfEvent.Goal)
                        {
                            if (pg.Name == e.Player)
                            {
                                pg.Goals++;
                            }

                        }
                    }

                }
            }
            else if (what == "y")
            {
                foreach (var item in list)
                {
                    foreach (var e in item.AwayTeamEvents)
                    {
                        if (e.TypeOfEvent == DAL1.QuickType.TypeOfEvent.YellowCard)
                        {
                            if (pg.Name == e.Player)
                            {
                                pg.Goals++;
                            }

                        }
                    }
                    foreach (var e in item.HomeTeamEvents)
                    {
                        if (e.TypeOfEvent == DAL1.QuickType.TypeOfEvent.YellowCard)
                        {
                            if (pg.Name == e.Player)
                            {
                                pg.Goals++;
                            }

                        }
                    }

                }
            }



            return pg.Goals;

        }

        private void goalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComparerGoals gg = new ComparerGoals();
            ctrllist.Sort(gg);

            flowLayoutPanel1.Controls.Clear();
            foreach (var item in ctrllist)
            {
                flowLayoutPanel1.Controls.Add(item);
            }

            FillLeaderboard();
        }

        private void yellowCardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComparerYC gg = new ComparerYC();
            ctrllist.Sort(gg);

            flowLayoutPanel1.Controls.Clear();
            foreach (var item in ctrllist)
            {
                flowLayoutPanel1.Controls.Add(item);
            }

            FillLeaderboard();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int pointY = e.MarginBounds.Y - 150;
            Font f = new Font("Serif", 20);
            IList list = new List<string[]>();

            int counter = 0;

            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            {
                PlayerCtrl item = (PlayerCtrl)flowLayoutPanel1.Controls[i];
                list.Add(item.ControlToString());

            }



            for (int i = 0; i < list.Count; i++)
            {

                string[] s = (string[])list[i];
                if (counter > 6)
                {
                    break;
                }
                if (flowLayoutPanel1.Controls.Count != 0)
                {
                    flowLayoutPanel1.Controls.RemoveAt(0);
                }


                pointY += 150;
                counter++;
                e.Graphics.DrawString(s[0], f, Brushes.Black, new PointF(e.MarginBounds.X, pointY));
                e.Graphics.DrawString($"Goals: "+s[1], f, Brushes.Black, new PointF(e.MarginBounds.X, pointY + 35));
                e.Graphics.DrawString($"Yellow cards: {s[2]}", f, Brushes.Black, new PointF(e.MarginBounds.X, pointY + 70));

            }


            for (int i = 0; i < list.Count; i++)
            {
                list.RemoveAt(0);
            }



            if (list.Count == 0)
            {
                e.HasMorePages = false;

            }
            else
            {

                e.HasMorePages = true;
                counter = 0;
            }



        }

        private void printDocument1_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            foreach (var ctrl in ctrllist)
            {

                flowLayoutPanel1.Controls.Add(ctrl);
            }
        }

        private void LoadForm()
        {
            if (flowLayoutPanel1.Controls.Count != 0)
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;

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

            this.Cursor = Cursors.Default;

            string[] files = Directory.GetFiles(@"..\..\..\DAL1\Images\");
            foreach (PlayerCtrl item in flowLayoutPanel1.Controls)
            {
                foreach (string file in files)
                {

                    if (item.getName().Trim() == file.GetUntilOrEmpty().Trim())
                    {
                        item.setPhoto(file);
                    }
                }
            }
            foreach (PlayerCtrl item in panel1.Controls)
            {
                foreach (string file in files)
                {

                    if (item.getName().Trim() == file.GetUntilOrEmpty().Trim())
                    {
                        item.setPhoto(file);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Postavke p = new Postavke();
            p.ShowDialog();
        }
    }

    class ComparerGoals : IComparer<PlayerCtrl>
    {

        public int Compare(PlayerCtrl x, PlayerCtrl y)
        {


            return y.playerCompare().CompareTo(x.playerCompare());
        }
    }

    class ComparerYC : IComparer<PlayerCtrl>
    {

        public int Compare(PlayerCtrl x, PlayerCtrl y)
        {


            return y.playerCompareYC().CompareTo(x.playerCompareYC());
        }
    }

    internal class PlayerGoals
    {
        public string Name { get; set; }
        public int Goals { get; set; }

    }



}
