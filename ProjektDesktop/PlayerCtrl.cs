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
    public partial class PlayerCtrl : UserControl
    {


        public bool Fave;
        public PlayerCtrl()
        {
            InitializeComponent();
        }


        private void UserControl1_Load(object sender, EventArgs e)
        {
            
        }

        

        public string XtractControl()
        {
            return $"{label4.Text}:{labelName.Text}:{labelShirt.Text}:{labelPosition.Text}";
        }

        public void FillControl(string name,string shirt,string position, bool favourite)
        {
            labelName.Text = name;
            labelShirt.Text = shirt;    
            labelPosition.Text = position;
            photo.ImageLocation = @"..\..\..\DAL1\Images\download.png";
            photo.SizeMode=PictureBoxSizeMode.StretchImage;
            if (favourite)
            {
                label4.Text = "Omiljeni";
                Fave = true;
            }
            else
            {
                label4.Text = "";
                Fave=false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void labelName_Click(object sender, EventArgs e)
        {

        }

        private void UserControl1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void photo_Click(object sender, EventArgs e)
        {

        }
    }
}
