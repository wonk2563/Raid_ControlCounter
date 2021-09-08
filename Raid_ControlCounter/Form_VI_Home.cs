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

namespace Raid_ControlCounter
{
    public partial class Form_VI_Home : Form
    {
        GlobalKeyboardHook gHook;
        int hotkey = 0 , vi_CD = 7;

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
                if (e.KeyValue == hotkey && e.KeyValue != 0)
                {
                    this.timer1.Stop();
                    label1.Text = Convert.ToString(count_down);
                    this.timer1.Start();
                }
            }            
        }

        private void 快捷鍵ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_VI_Hotkey keysForm = new Form_VI_Hotkey();
            keysForm.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            gHook.unhook();
            this.timer1.Stop();
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            count_down -= (decimal)0.1;
            label1.Text = Convert.ToString(count_down);
            if (count_down <= 0)
            {
                this.timer1.Stop();
                count_down = vi_CD;
                label1.Text = Convert.ToString(0);
            }
        }

        private void ReadKeysTXT()
        {
            string name = "", stutas = "";
            string path = AppDomain.CurrentDomain.BaseDirectory + "configs/vi_config.txt";
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
                                hotkey = Int32.Parse(stutas);
                        }
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
            label1.Text = Convert.ToString(vi_CD);
        }
    }
}
