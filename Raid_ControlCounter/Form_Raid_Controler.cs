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
    public partial class Form_Raid_Controler : Form
    {
        GlobalKeyboardHook gHook;
        int hotkey = 0;
        string selection = "";
        decimal ctrlSec = 0;


        public Form_Raid_Controler()
        {
            InitializeComponent();

            hotkeyName1 = "F";
            label1.Text = "F";
            hotkey = 70;

            ReadIDsByTXT();            
            gHook = new GlobalKeyboardHook();
            gHook.KeyDown += new KeyEventHandler(gHook_KeyDown);
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                gHook.HookedKeys.Add(key);
            gHook.hook();
        }

        private void gHook_KeyDown(object sender, KeyEventArgs e)
        {            
            if(e.KeyValue == 13)
            {
                WriteIDsToTXT();
                gHook.unhook();
                this.Close();
            }
        }

        private void WriteIDsToTXT()
        {
            string[] configs = new string[22];
            string AppPath = Assembly.GetExecutingAssembly().Location;
            AppPath = Path.GetDirectoryName(AppPath);

            string path = AppDomain.CurrentDomain.BaseDirectory + "configs/raid_config.txt";
            string[] lines = System.IO.File.ReadAllLines(@path);
            int i = 0;

            foreach (string line in lines)
            {
                configs[i] = line;
                i++;
            }
            configs[19] = "ctrlSec=" + ctrlSec;
            configs[20] = "hotkey=" + hotkey + "," + hotkeyName1;
            configs[21] = "selection=" + selection;

            System.IO.File.WriteAllLines(@AppPath + "/configs/raid_config.txt", configs);
        }

        private void ReadIDsByTXT()
        {            
            string name = "", stutas = "";
            string path = AppDomain.CurrentDomain.BaseDirectory + "configs/raid_config.txt";
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

                            if (name == "selection")
                            {
                                switch (stutas)
                                {
                                    case "DAB":
                                        radioButton1.Checked = true;
                                        break;
                                    case "NP":
                                        radioButton2.Checked = true;
                                        break;
                                    case "BL":
                                        radioButton3.Checked = true;
                                        break;
                                    case "AS":
                                        radioButton4.Checked = true;
                                        break;
                                    case "SH":
                                        radioButton5.Checked = true;
                                        break;
                                    case "DN":
                                        radioButton6.Checked = true;
                                        break;
                                    case "DA":
                                        radioButton9.Checked = true;
                                        break;
                                    case "HE":
                                        radioButton7.Checked = true;
                                        break;
                                    case "RS":
                                        radioButton8.Checked = true;
                                        break;
                                    case "BALL":
                                        radioButton10.Checked = true;
                                        break;
                                }
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
            WriteIDsToTXT();
            gHook.unhook();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton9.Checked = false;
            radioButton10.Checked = false;

            hotkeyName1 = "F";
            label1.Text = "F";
            hotkey = 70;

            selection = "";
        }

        private void ckb_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked == true)
            {
                (sender as RadioButton).BackColor = Color.FromArgb(225, 225, 225);
                foreach (var chk in this.Controls)
                {
                    if (chk is GroupBox)
                    {
                        foreach(var control in ((GroupBox)chk).Controls)
                        {
                            if (control is RadioButton && control != sender)
                            {                                
                                ((RadioButton)control).Checked = false;                                
                            }
                        }                        
                    }
                }
            }
            else
                (sender as RadioButton).BackColor = Color.WhiteSmoke;
        }


        private void checkBox8_CheckedChanged_1(object sender, EventArgs e)
        {
            ckb_CheckedChanged(sender, e);
            if (radioButton1.Checked)
            {                
                ctrlSec = 6.5m;
                selection = "DAB";
            }                
            else
                ctrlSec = 0;
            label3.Text = Convert.ToString(ctrlSec);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            ckb_CheckedChanged(sender, e);
            if (radioButton3.Checked)
            {
                ctrlSec = 5;
                selection = "BL";
            }                
            else
                ctrlSec = 0;
            label3.Text = Convert.ToString(ctrlSec);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ckb_CheckedChanged(sender, e);
            if (radioButton4.Checked)
            {
                ctrlSec = 5;
                selection = "AS";
            }                
            else
                ctrlSec = 0;
            label3.Text = Convert.ToString(ctrlSec);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ckb_CheckedChanged(sender, e);
            if (radioButton5.Checked)
            {
                ctrlSec = 5;
                selection = "SH";
            }                
            else
                ctrlSec = 0;
            label3.Text = Convert.ToString(ctrlSec);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            ckb_CheckedChanged(sender, e);
            if (radioButton6.Checked)
            {
                ctrlSec = 5;
                selection = "DN";
            }                
            else
                ctrlSec = 0;
            label3.Text = Convert.ToString(ctrlSec);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            ckb_CheckedChanged(sender, e);
            if (radioButton9.Checked)
            {
                ctrlSec = 4;
                selection = "DA";
            }                
            else
                ctrlSec = 0;
            label3.Text = Convert.ToString(ctrlSec);
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            ckb_CheckedChanged(sender, e);
            if (radioButton7.Checked)
            {
                ctrlSec = 5;
                selection = "HE";
            }
                
            else
                ctrlSec = 0;
            label3.Text = Convert.ToString(ctrlSec);
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            ckb_CheckedChanged(sender, e);
            if (radioButton8.Checked)
            {
                ctrlSec = 4;
                selection = "RS";
            }                
            else
                ctrlSec = 0;
            label3.Text = Convert.ToString(ctrlSec);
        }
        

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            ckb_CheckedChanged(sender, e);
            if (radioButton2.Checked)
            {
                ctrlSec = 5;
                selection = "NP";
            }               
            else
                ctrlSec = 0;
            label3.Text = Convert.ToString(ctrlSec);
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            ckb_CheckedChanged(sender, e);
            if (radioButton10.Checked)
            {
                ctrlSec = 4;
                selection = "BALL";
            }                
            else
                ctrlSec = 0;
            label3.Text = Convert.ToString(ctrlSec);
        }

        private void label6_Click(object sender, EventArgs e)
        {

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
        string hotkeyName, hotkeyName1;
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            hotkeyList = form_Hotkey.Gethokeys;
            hotkeyName = form_Hotkey.GethokeysName;
            if (hotkeyList.Count != 0)
                Init();
            gHook.hook();
            this.Show();
        }

        private void Init()
        {
            if (pBoxTag == 1)
            {
                hotkeyName1 = hotkeyName;
                label1.Text = hotkeyName1;
                hotkey = hotkeyList[0];
            }

            pBoxTag = 0;
        }
    }
}
