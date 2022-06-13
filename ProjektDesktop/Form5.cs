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
    public partial class Form5 : Form
    {

        private string api = "http://worldcup.sfg.io/matches";
        private string api2 = "https://world-cup-json-2018.herokuapp.com/matches";
        List<PlayerCtrl> ctrllist = new List<PlayerCtrl>();
        IList<Player> players = new List<Player>();
        int rating = 1;

        public Form5()
        {
            InitializeComponent();
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
            Font f = new Font("Serif", 24);
            e.Graphics.DrawString("Bardo and",f,Brushes.Azure,new PointF(e.MarginBounds.X, e.MarginBounds.Y));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog()==DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
    }
}
    
