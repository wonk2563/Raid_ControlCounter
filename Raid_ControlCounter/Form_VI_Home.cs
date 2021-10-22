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
    public partial class Form_VI_Home : Form
    {
        GlobalKeyboardHook gHook;
        int vi_CD = 7;

        public Form_VI_Home()
        {
            InitializeComponent();
            label1.Text = Convert.ToString(count_down);
            gHook = new GlobalKeyboardHook();
            gHook.KeyDown += new KeyEventHandler(gHook_KeyDown);
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                gHook.HookedKeys.Add(key);
            gHook.hook();
            ReadKeysTXT();
        }

        private void gHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (count_down == 7)
            {
                foreach(int hotkey in hotkey_list)
                {
                    if (e.KeyValue == hotkey && e.KeyValue != 0)
                    {
                        this.timer1.Stop();
                        label1.Text = Convert.ToString(count_down);
                        stopTime = vi_CD * 1000;
                        stopWatch.Start();
                        this.timer1.Start();
                    }
                }                
            }            
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.DarkGray, ButtonBorderStyle.Solid);
        }

        private void 快捷鍵ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Hotkey keysForm = new Form_Hotkey("vi_config.txt");
            keysForm.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            gHook.unhook();
            this.timer1.Stop();
            stopWatch.Reset();
            count_down = 7;
            label1.Text = Convert.ToString(count_down);
            keysForm.Show();
            this.Hide();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            ReadKeysTXT();
            gHook.hook();
        }

        decimal count_down = 7;
        decimal stopTime, remainingTime;
        Stopwatch stopWatch = new Stopwatch();
        private void timer1_Tick(object sender, EventArgs e)
        {
            remainingTime = decimal.Round((stopTime - stopWatch.ElapsedMilliseconds) / 1000, 1);
            count_down = remainingTime;
            label1.Text = Convert.ToString(remainingTime);
            if (stopTime <= stopWatch.ElapsedMilliseconds)
            {
                stopWatch.Reset();
                timer1.Stop();
                count_down = vi_CD;
                label1.Text = Convert.ToString(0);
            }
        }

        List<int> hotkey_list = new List<int>();
        private void ReadKeysTXT()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "configs/vi_config.txt";
            if (System.IO.File.Exists(path))
            {
                try
                {
                    hotkey_list = new List<int>();
                    string[] lines = System.IO.File.ReadAllLines(@path);

                    foreach (string line in lines)
                    {
                        hotkey_list.Add(Int32.Parse(line));
                    }
                }
                catch (Exception)
                {
                    File.Create(path).Close();
                    ReadKeysTXT();
                    return;
                }
            }
            else
            {
                File.Create(path).Close();
                ReadKeysTXT();
                return;
            }

            this.timer1.Stop();
            stopWatch.Reset();
            label1.Text = Convert.ToString(vi_CD);
        }
    }
}
