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
using System.Net.Mail;

namespace Raid_ControlCounter
{
    public partial class Form_Report : Form
    {
        public Form_Report()
        {
            InitializeComponent();
            label_Box.Text = this.Text;
        }

        private void Form_Report_Activated(object sender, EventArgs e)
        {
            richTextBox_main.Focus();
        }

        private void FormSend_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }


        //=================按鈕=====================

        private void btn_send_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"請問是否要回報以下內容？\n\n主旨：{richTextBox_main.Text}\n問題描述：{richTextBox_content.Text}","回報",MessageBoxButtons.OKCancel);
            if(result == DialogResult.OK)
            {
                Form_SendMail form_SendMail = new Form_SendMail(richTextBox_main.Text,richTextBox_content.Text);
                form_SendMail.FormClosed += new FormClosedEventHandler(FormSend_FormClosed);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }        


        //=================內容變更=====================

        private void richTextBox_main_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox_content.Text != "" && richTextBox_main.Text != "")
                btn_send.Enabled = true;
            else
                btn_send.Enabled = false;

            richTextBox_main.Font = new Font("OPPOSans M", 9, FontStyle.Regular);
        }

        private void richTextBox_content_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox_content.Text != "" && richTextBox_main.Text != "")
                btn_send.Enabled = true;
            else
                btn_send.Enabled = false;

            richTextBox_content.Font = new Font("OPPOSans M", 9, FontStyle.Regular);
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
