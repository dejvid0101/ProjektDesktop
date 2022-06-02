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
    public partial class RatingCtrl : UserControl
    {
        public RatingCtrl()
        {
            InitializeComponent();
            
        }

        private void RatingCtrl_Load(object sender, EventArgs e)
        {

        }

        public void setRating(int rating, string name)
        {
            label1.Text = rating.ToString();    
            label2.Text = name;
        }

    }
}
