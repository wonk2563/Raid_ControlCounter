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
using static Raid_ControlCounter.Hotkeys;

namespace Raid_ControlCounter
{
    public partial class _115 : Form
    {
        GlobalKeyboardHook gHook;
        int  hotkey = 0 , hotkey2 = 0, hotkey3 = 0;
        decimal _115_CD = 60;

        public _115()
        {
            InitializeComponent();
            gHook = new GlobalKeyboardHook();
            gHook.KeyDown += new KeyEventHandler(gHook_KeyDown);
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                gHook.HookedKeys.Add(key);
            gHook.hook();

            SetHotkeyValue(Hotkeys.ReadTXT("115_config.txt"));
            Stop();
        }

        private void gHook_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue == hotkey || e.KeyValue == hotkey2) && e.KeyValue != 0)
            {
                if (count_down == _115_CD)
                {
                    Start();
                }                    
            }
            if (e.KeyValue == hotkey3 && count_down != _115_CD)
            {
                Start();
            }
        }        

        private void Start()
        {
            this.timer1.Stop();
            stopWatch.Restart();
            count_down = _115_CD;
            label1.Text = Convert.ToString(_115_CD);
            stopTime = _115_CD * 1000;
            this.timer1.Start();
            stopWatch.Start();
        }

        private void Stop()
        {
            this.timer1.Stop();
            label1.Text = Convert.ToString(_115_CD);
        }


        private void panel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.DarkGray, ButtonBorderStyle.Solid);
        }

        private void 快捷鍵ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_115_Hotkey keysForm = new Form_115_Hotkey();
            keysForm.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            gHook.unhook();
            this.timer1.Stop();
            stopWatch.Restart();
            keysForm.Show();
            this.Hide();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            count_down = _115_CD;
            Stop();
            SetHotkeyValue(Hotkeys.ReadTXT("115_config.txt"));
            gHook.hook();
        }        

        decimal count_down = 60;
        decimal stopTime, remainingTime;
        Stopwatch stopWatch = new Stopwatch();
        private void timer1_Tick(object sender, EventArgs e)
        {
            remainingTime = decimal.Round((stopTime - stopWatch.ElapsedMilliseconds) / 1000, 1);
            count_down = remainingTime;
            label1.Text = Convert.ToString(remainingTime);
            if (stopTime <= stopWatch.ElapsedMilliseconds)
            {
                timer1.Stop();
                stopWatch.Restart();
                count_down = _115_CD;
                label1.Text = Convert.ToString(0);
            }
        }

        private void SetHotkeyValue(Tuple<int[], string[], int, bool> tuple)
        {
            if (tuple.Item1.Length > 0)
            {
                hotkey = tuple.Item1[0];
                hotkey2 = tuple.Item1[1];
                hotkey3 = tuple.Item1[2];
            }            
        }
    }
}
