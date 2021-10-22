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
using System.Reflection;

namespace Raid_ControlCounter
{
    public partial class Form_Customize_Hotkey : Form
    {
        GlobalKeyboardHook gHook;
        int hotkey = 0 , seconds = 0;


        public Form_Customize_Hotkey()
        {
            InitializeComponent();

            hotkeyName = "LCtrl";
            label1.Text = "LCtrl";
            hotkey = 162;

            ReadIDsByTXT();

            gHook = new GlobalKeyboardHook();
            gHook.KeyDown += new KeyEventHandler(gHook_KeyDown);
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                gHook.HookedKeys.Add(key);
            gHook.hook();            
        }

        private void gHook_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyValue);
            if(e.KeyValue == 13)
            {
                if (textBox1.Text != "")
                    seconds = Int32.Parse(textBox1.Text);
                WriteIDsToTXT();
                gHook.unhook();
                this.Close();
            }
        }

        private void WriteIDsToTXT()
        {
            string[] configs = new string[2];
            string AppPath = Assembly.GetExecutingAssembly().Location;
            AppPath = Path.GetDirectoryName(AppPath);

            string path = AppDomain.CurrentDomain.BaseDirectory + "configs/Customize_config.txt";
            string[] lines = System.IO.File.ReadAllLines(@path);
            int i = 0;

            foreach (string line in lines)
            {
                configs[i] = line;
                i++;
            }
            configs[0] = "hotkey=" + hotkey + "," + hotkeyName;

            if (textBox1.Text != "")
                seconds = Int32.Parse(textBox1.Text);
            else
                seconds = 0;

            configs[1] = "seconds=" + seconds;

            System.IO.File.WriteAllLines(@AppPath + "/configs/Customize_config.txt", configs);
        }

        private void ReadIDsByTXT()
        {            
            string name = "", stutas = "";
            string path = AppDomain.CurrentDomain.BaseDirectory + "configs/Customize_config.txt";
            if (System.IO.File.Exists(path))
            {
                string[] lines = System.IO.File.ReadAllLines(@path);
                try
                {
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
                            {
                                hotkey = Int32.Parse(stutas.Split(',')[0]);
                                hotkeyName = stutas.Split(',')[1];
                                label1.Text = hotkeyName;
                            }
                            if (name == "seconds")
                            {
                                seconds = Int32.Parse(stutas);
                                if (seconds != 0)
                                    textBox1.Text = seconds.ToString();
                            }                                
                        }                        
                    }
                }
                catch (Exception)
                {
                    File.Exists(path);
                    File.Create(path).Close();
                }
            }
            else
            {
                try
                {
                    File.Create(path).Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
                seconds = Int32.Parse(textBox1.Text);
            WriteIDsToTXT();
            gHook.unhook();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hotkeyName = "LCtrl";
            label1.Text = "LCtrl";
            hotkey = 162;

            textBox1.Text = "";
            seconds = 0;
        }   

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 | (int)e.KeyChar > 57) & (int)e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        //======================快捷鍵設定=========================
        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.BackColor = Color.LightGray;
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.BackColor = Color.Transparent;
        }

        Form_Hotkey form_Hotkey;
        int pBoxTag = 0;
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pBoxTag = Int32.Parse(pictureBox.Tag.ToString());
            form_Hotkey = new Form_Hotkey("", true);
            form_Hotkey.FormClosing += new FormClosingEventHandler(Form_FormClosing);
            form_Hotkey.Show();
            gHook.unhook();
            this.Hide();
        }

        List<int> hotkeyList = new List<int>();
        string hotkeyName;
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            hotkeyList = form_Hotkey.Gethokeys;
            hotkey = hotkeyList[0];

            hotkeyName = form_Hotkey.GethokeysName;
            label1.Text = hotkeyName;

            if (hotkeyList.Count != 0)
                Init();

            gHook.hook();
            this.Show();
        }

        private void Init()
        {
            if (pBoxTag == 1)
            {
                label1.Text = hotkeyName;
                hotkey = hotkeyList[0];
            }

            pBoxTag = 0;
        }
    }
}
