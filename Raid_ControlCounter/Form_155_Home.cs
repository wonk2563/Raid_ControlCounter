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
    public partial class Form_155_Home : Form
    {
        GlobalKeyboardHook gHook;
        int hotkey = 0;

        public Form_155_Home()
        {
            InitializeComponent();
            label1.Text = tornado.ToString();
            gHook = new GlobalKeyboardHook();
            gHook.KeyDown += new KeyEventHandler(gHook_KeyDown);
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                gHook.HookedKeys.Add(key);
            gHook.hook();
            SetHotkeyValue(Hotkeys.ReadTXT("155_config.txt"));
        }

        bool counting = false;
        private void gHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == hotkey && e.KeyValue != 0 && !counting)
            {
                stopTime = tornado * 1000;
                timer_count.Start();
                stopWatch.Start();
                counting = true;
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.DarkGray, ButtonBorderStyle.Solid);
        }


        decimal count_down = 100, tornado = 100;
        decimal stopTime, remainingTime;
        Stopwatch stopWatch = new Stopwatch();
        private void timer_count_Tick(object sender, EventArgs e)
        {
            remainingTime = decimal.Round((stopTime - stopWatch.ElapsedMilliseconds) / 1000, 1);
            label1.Text = Convert.ToString(remainingTime);
            if (stopTime <= stopWatch.ElapsedMilliseconds)
            {
                stopWatch.Reset();
                label1.Text = Convert.ToString(tornado);
                stopWatch.Start();
            }     
        }

        private void 快捷鍵與靈敏度設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_155_Hotkey setting = new Form_155_Hotkey();
            setting.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            gHook.unhook();
            setting.Show();
            this.Hide();
        }

        private void 重置ToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            timer_count.Stop();
            stopWatch.Restart();
            count_down = tornado;
            label1.Text = Convert.ToString(count_down);
            counting = false;
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            SetHotkeyValue(Hotkeys.ReadTXT("155_config.txt"));
            gHook.hook();
        }

        private void SetHotkeyValue(Tuple<int[], string[], int, bool> tuple)
        {
            if (tuple.Item1.Length > 0)
                hotkey = tuple.Item1[0];
        }
    }
}
