using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Raid_ControlCounter
{
    public partial class Form_About : Form
    {
        public Form_About()
        {
            InitializeComponent();
            label_Box.Text = this.Text;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            Process.Start("https://forum.gamer.com.tw/C.php?bsn=12259&snA=290689&tnum=1");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel3.LinkVisited = true;
            Process.Start("https://forum.gamer.com.tw/C.php?bsn=12259&snA=291355&tnum=2&bPage=2");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel4.LinkVisited = true;
            Process.Start("https://kelsword.web.fc2.com/charskill/noah_2line_2t.htm#95_sactive");
        }

        //=================關閉按鈕=====================

        private void pictureBox_EXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox_EXIT_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_EXIT.BackgroundImage = Properties.Resources.EXIT;
        }

        private void pictureBox_EXIT_MouseEnter(object sender, EventArgs e)
        {
            pictureBox_EXIT.BackgroundImage = Properties.Resources.EXIT_ON;
        }

        //=================拖動視窗=====================

        private Point mPoint;
        private void panel_CTRLBar_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void panel_CTRLBar_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void label_Box_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void label_Box_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }
    }
}
