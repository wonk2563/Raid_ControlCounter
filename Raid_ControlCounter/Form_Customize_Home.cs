using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Raid_ControlCounter
{
    public partial class Form_Customize_Home : Form
    {
        GlobalKeyboardHook gHook;
        int hotkey = 0;
        decimal seconds = 0;

        public Form_Customize_Home()
        {
            InitializeComponent();
            ReadIDsByTXT();
            label1.Text = seconds.ToString();
            gHook = new GlobalKeyboardHook();
            gHook.KeyDown += new KeyEventHandler(gHook_KeyDown);
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                gHook.HookedKeys.Add(key);
            gHook.hook();            
        }
                
        private void gHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == hotkey && e.KeyValue != 0)
            {
                stopWatch.Restart();
                timer_count.Stop();
                stopTime = seconds * 1000;
                stopWatch.Start();
                timer_count.Start();
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.DarkGray, ButtonBorderStyle.Solid);
        }


        decimal stopTime, remainingTime;
        Stopwatch stopWatch = new Stopwatch();
        private void timer_count_Tick(object sender, EventArgs e)
        {
            remainingTime = decimal.Round((stopTime - stopWatch.ElapsedMilliseconds) / 1000, 1);
            label1.Text = Convert.ToString(remainingTime);
            if (stopTime <= stopWatch.ElapsedMilliseconds)
            {
                stopWatch.Reset();
                timer_count.Stop();
                label1.Text = Convert.ToString(0);
            }          
        }

        private void 快捷鍵與靈敏度設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer_count.Stop();
            Form_Customize_Hotkey setting = new Form_Customize_Hotkey();
            setting.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            gHook.unhook();
            setting.Show();
            this.Hide();
        }

        private void 重置ToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            timer_count.Stop();
            label1.Text = Convert.ToString(seconds);
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            ReadIDsByTXT();
            gHook.hook();
        }

        private void ReadIDsByTXT()
        {
            string name = "", stutas = "";
            string path = AppDomain.CurrentDomain.BaseDirectory + "configs/Customize_config.txt";
            if (System.IO.File.Exists(path))
            {
                try
                {
                    string[] lines = System.IO.File.ReadAllLines(@path);

                    foreach (string line in lines)
                    {
                        string[] words = line.Split('=');
                        for (int j = 0; j < words.Length; j++)
                        {
                            if (words.Length == 2)
                            {
                                name = words[0];
                                stutas = words[1];
                            }

                            if (name == "hotkey")
                                hotkey = Int32.Parse(stutas.Split(',')[0]);
                            if (name == "seconds")
                            {
                                seconds = Int32.Parse(stutas);
                                label1.Text = seconds.ToString();
                            }                                
                        }
                    }
                }
                catch (Exception)
                {
                    File.Create(path).Close();
                    ReadIDsByTXT();
                    return;
                }
            }
            else
            {
                File.Create(path).Close();
                ReadIDsByTXT();
                return;
            }
        }
    }
}
