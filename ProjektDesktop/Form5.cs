using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektDesktop
{
    public partial class Form5 : Form
    {

        private string api = "http://worldcup.sfg.io/matches";
        private string api2 = "https://world-cup-json-2018.herokuapp.com/matches";
        List<PlayerCtrl> ctrllist = new List<PlayerCtrl>();
        IList<Player> players = new List<Player>();
        int rating = 1;

        public Form5()
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

        private void Form5_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

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

            this.Cursor = Cursors.Default;
        }

        private void FillCBWData(string api)
        {
            try
            {
                IList<DAL1.QuickType.Tekma> list = DAL1.APIAccessTeams.GetData2(api);

                string r = DAL1.TextAccess.readFile(@"..\..\..\DAL1\Files\Datainitial.txt");
                foreach (var item in list)
                {

                    if (item.AwayTeam.Country == r.Substring(0, (r.Length - 6)) || item.HomeTeam.Country == r.Substring(0, (r.Length - 6)))
                    {

                        PlayerCtrl u = new PlayerCtrl();
                        u.FillControl(item.HomeTeamCountry + " - " + item.AwayTeamCountry, item.Attendance.ToString(), item.Venue, false);

                        ctrllist.Add(u);
                    }

                }

                ComparerGoals gg = new ComparerGoals();
                ctrllist.Sort(gg);

                foreach (var ctrl in ctrllist)
                {

                    flowLayoutPanel1.Controls.Add(ctrl);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font f = new Font("Serif", 8);
            int pointY = e.MarginBounds.Y-40;
            e.Graphics.DrawString("Matches:", f, Brushes.Black, new PointF(e.MarginBounds.X, pointY));

            
            foreach (PlayerCtrl item in flowLayoutPanel1.Controls)
            {
                pointY += 40;
                string[] info = item.ControlToString();
                e.Graphics.DrawString(info[0], f, Brushes.Black, new PointF(e.MarginBounds.X, pointY));
                e.Graphics.DrawString(info[1] +" zuschauer", f, Brushes.Black, new PointF(e.MarginBounds.X, pointY+10));
                e.Graphics.DrawString($"Lokation: {info[2]}", f, Brushes.Black, new PointF(e.MarginBounds.X, pointY+20));
            }

            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog()==DialogResult.OK)
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
}
    
