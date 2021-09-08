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
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            Process.Start("chrome.exe", "https://forum.gamer.com.tw/C.php?bsn=12259&snA=290689&tnum=1");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            Process.Start("chrome.exe", "https://forum.gamer.com.tw/C.php?bsn=12259&snA=291355&tnum=2&bPage=2");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            Process.Start("chrome.exe", "https://kelsword.web.fc2.com/charskill/noah_cl2t.htm#95_sactive");
        }
    }
}
