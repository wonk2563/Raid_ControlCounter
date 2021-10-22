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
using System.Threading;
using System.Net;

namespace Raid_ControlCounter
{
    public partial class Form_SendMail : Form
    {
        public Form_SendMail(string sub, string con)
        {
            InitializeComponent();
            label_Box.Text = this.Text;
            this.Show();
            subject = sub;
            content = con;
            backgroundWorker_send.RunWorkerAsync();            
        }

        string subject, content;
        public string Subject
        {
            set
            {
                subject = value;
            }
            get
            {
                return subject;
            }
        }

        public string Content
        {
            set
            {
                content = value;
            }
            get
            {
                return content;
            }
        }


        //=================發送郵件=====================

        private void backgroundWorker_send_DoWork(object sender, DoWorkEventArgs e)
        {
            Send_mail();
        }

        private void backgroundWorker_send_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(e.ProgressPercentage == 10)
            {
                label1.Text = "回報中...";
                pictureBox1.Image = Properties.Resources.loading;
                pictureBox_refresh.Visible = false;
            }
            if (e.ProgressPercentage == 20)
            {
                label1.Text = "回報失敗！";
                pictureBox1.Image = Properties.Resources.error;
                pictureBox_refresh.Visible = true;
            }               
            if (e.ProgressPercentage == 100)
            {
                label1.Text = "回報成功！";
                pictureBox1.Image = Properties.Resources.done;
            }                
        }

        bool report_complete = false;
        private void backgroundWorker_send_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(report_complete)
                this.Close();
        }


        private void Send_mail()
        {
            try
            {
                backgroundWorker_send.ReportProgress(10);                

                var client = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(Properties.Resources.ReportMail, Properties.Resources.Pass)                    
                };
                client.Send(Properties.Resources.ReportMail, Properties.Resources.ReceiveMail, subject, content);

                backgroundWorker_send.ReportProgress(100);
                report_complete = true;

                Thread.Sleep(2000);                
            }
            catch (Exception ex)
            {
                report_complete = false;
                backgroundWorker_send.ReportProgress(20);
                MessageBox.Show(ex.Message, "錯誤");
            }
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


        //=================重寄按鈕=====================

        private void pictureBox_refresh_Click(object sender, EventArgs e)
        {
            backgroundWorker_send.RunWorkerAsync();
        }

        private void pictureBox_refresh_MouseEnter(object sender, EventArgs e)
        {
            pictureBox_refresh.BackgroundImage = Properties.Resources.refresh3;
        }

        private void pictureBox_refresh_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_refresh.BackgroundImage = Properties.Resources.refresh2;
        }

        private void pictureBox_refresh_MouseHover(object sender, EventArgs e)
        {
            // 建立the ToolTip 
            ToolTip toolTip1 = new ToolTip();
            // 設定顯示樣式
            toolTip1.AutoPopDelay = 5000;//提示資訊的可見時間
            toolTip1.InitialDelay = 500;//事件觸發多久後出現提示
            toolTip1.ReshowDelay = 500;//指標從一個控制元件移向另一個控制元件時，經過多久才會顯示下一個提示框
            toolTip1.ShowAlways = true;//是否顯示提示框
            //  設定伴隨的物件.
            toolTip1.SetToolTip(pictureBox_refresh, "重新寄送");//設定提示按鈕和提示內容
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
