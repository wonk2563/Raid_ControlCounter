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
    public partial class _115 : Form
    {
        GlobalKeyboardHook gHook;
        int  hotkey = 0 , hotkey2 = 0;
        decimal _115_CD = 30;


        public _115()
        {
            InitializeComponent();
            gHook = new GlobalKeyboardHook();
            gHook.KeyDown += new KeyEventHandler(gHook_KeyDown);
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                gHook.HookedKeys.Add(key);
            gHook.hook();
            ReadIDsByTXT();            
        }

        private void gHook_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue == hotkey || e.KeyValue == hotkey2) && e.KeyValue != 0)
            {
                if (count_down == _115_CD)
                {
                    this.timer1.Stop();
                    count_down = _115_CD;
                    label1.Text = Convert.ToString(_115_CD);
                    this.timer1.Start();
                }                    
            }
        }

        private void 快捷鍵ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_115_Hotkey keysForm = new Form_115_Hotkey();
            keysForm.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            gHook.unhook();
            this.timer1.Stop();
            keysForm.Show();
            this.Hide();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            count_down = _115_CD;
            ReadIDsByTXT();
            gHook.hook();
        }
        private void ReadIDsByTXT()
        {
            string name = "", stutas = "";
            string path = AppDomain.CurrentDomain.BaseDirectory + "configs/115_config.txt";
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
                            if (name == "hotkey2")
                                hotkey2 = Int32.Parse(stutas);
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

            this.timer1.Stop();
            label1.Text = Convert.ToString(_115_CD);            
        }

        decimal count_down = 30;
        private void timer1_Tick(object sender, EventArgs e)
        {            
            count_down -= (decimal)0.1;
            label1.Text = Convert.ToString(count_down);
            if (count_down <= 0)
            {
                this.timer1.Stop();
                count_down = _115_CD;
                label1.Text = Convert.ToString(0);
            }
        }
    }
}
