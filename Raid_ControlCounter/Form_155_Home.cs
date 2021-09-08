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
            ReadIDsByTXT();
        }

        bool counting = false;
        private void gHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == hotkey && e.KeyValue != 0 && !counting)
            {                
                timer_count.Start();
                counting = true;
            }
        }

        decimal count_down = 100, tornado = 100;
        private void timer_count_Tick(object sender, EventArgs e)
        {
            count_down -= (decimal)0.1;
            label1.Text = Convert.ToString(count_down);
            if (count_down <= 0)
            {
                count_down = tornado;
                label1.Text = Convert.ToString(count_down);
            }            
        }

        private void 快捷鍵與靈敏度設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_155_Setting setting = new Form_155_Setting();
            setting.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            gHook.unhook();
            setting.Show();
            this.Hide();
        }

        private void 重置ToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            timer_count.Stop();
            count_down = tornado;
            label1.Text = Convert.ToString(count_down);
            counting = false;
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
            string path = AppDomain.CurrentDomain.BaseDirectory + "configs/155_config.txt";
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
