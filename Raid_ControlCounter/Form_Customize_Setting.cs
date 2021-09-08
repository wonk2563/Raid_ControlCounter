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
    public partial class Form_Customize_Setting : Form
    {
        GlobalKeyboardHook gHook;
        int hotkey = 0 , seconds = 0;


        public Form_Customize_Setting()
        {
            InitializeComponent();
            comboBox1.SelectedItem = "L-CTRL";
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
            configs[0] = "hotkey=" + hotkey;

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
                                switch (stutas)
                                {
                                    case "162":
                                        comboBox1.SelectedItem = "L-CTRL";
                                        hotkey = 162;
                                        break;
                                    case "163":
                                        comboBox1.SelectedItem = "R-CTRL";
                                        hotkey = 163;
                                        break;
                                    case "164":
                                        comboBox1.SelectedItem = "L-ALT";
                                        hotkey = 164;
                                        break;
                                    case "165":
                                        comboBox1.SelectedItem = "R-ALT";
                                        hotkey = 165;
                                        break;
                                    case "160":
                                        comboBox1.SelectedItem = "L-SHIFT";
                                        hotkey = 160;
                                        break;
                                    case "161":
                                        comboBox1.SelectedItem = "R-SHIFT";
                                        hotkey = 161;
                                        break;
                                    case "32":
                                        comboBox1.SelectedItem = "SPACE";
                                        hotkey = 32;
                                        break;
                                    case "19":
                                        comboBox1.SelectedItem = "BREAK / PAUSE";
                                        hotkey = 19;
                                        break;
                                    case "36":
                                        comboBox1.SelectedItem = "HOME";
                                        hotkey = 36;
                                        break;
                                    case "33":
                                        comboBox1.SelectedItem = "PAGE UP";
                                        hotkey = 33;
                                        break;
                                    case "34":
                                        comboBox1.SelectedItem = "PAGE DOWN";
                                        hotkey = 34;
                                        break;
                                    case "112":
                                        comboBox1.SelectedItem = "F1";
                                        hotkey = 112;
                                        break;
                                    case "113":
                                        comboBox1.SelectedItem = "F2";
                                        hotkey = 113;
                                        break;
                                    case "114":
                                        comboBox1.SelectedItem = "F3";
                                        hotkey = 114;
                                        break;
                                    case "115":
                                        comboBox1.SelectedItem = "F4";
                                        hotkey = 115;
                                        break;
                                    case "116":
                                        comboBox1.SelectedItem = "F5";
                                        hotkey = 116;
                                        break;
                                    case "117":
                                        comboBox1.SelectedItem = "F6";
                                        hotkey = 117;
                                        break;
                                    case "118":
                                        comboBox1.SelectedItem = "F7";
                                        hotkey = 118;
                                        break;
                                    case "119":
                                        comboBox1.SelectedItem = "F8";
                                        hotkey = 119;
                                        break;
                                    case "120":
                                        comboBox1.SelectedItem = "F9";
                                        hotkey = 120;
                                        break;
                                    case "121":
                                        comboBox1.SelectedItem = "F10";
                                        hotkey = 121;
                                        break;
                                    case "122":
                                        comboBox1.SelectedItem = "F11";
                                        hotkey = 122;
                                        break;
                                    case "123":
                                        comboBox1.SelectedItem = "F12";
                                        hotkey = 123;
                                        break;
                                    case "81":
                                        comboBox1.SelectedItem = "Q";
                                        hotkey = 81;
                                        break;
                                    case "87":
                                        comboBox1.SelectedItem = "W";
                                        hotkey = 87;
                                        break;
                                    case "69":
                                        comboBox1.SelectedItem = "E";
                                        hotkey = 69;
                                        break;
                                    case "82":
                                        comboBox1.SelectedItem = "R";
                                        hotkey = 82;
                                        break;
                                    case "84":
                                        comboBox1.SelectedItem = "T";
                                        hotkey = 84;
                                        break;
                                    case "65":
                                        comboBox1.SelectedItem = "A";
                                        hotkey = 65;
                                        break;
                                    case "83":
                                        comboBox1.SelectedItem = "S";
                                        hotkey = 83;
                                        break;
                                    case "68":
                                        comboBox1.SelectedItem = "D";
                                        hotkey = 68;
                                        break;
                                    case "70":
                                        comboBox1.SelectedItem = "F";
                                        hotkey = 70;
                                        break;
                                    case "67":
                                        comboBox1.SelectedItem = "C";
                                        hotkey = 67;
                                        break;
                                    case "49":
                                        comboBox1.SelectedItem = "1";
                                        hotkey = 49;
                                        break;
                                    case "50":
                                        comboBox1.SelectedItem = "2";
                                        hotkey = 50;
                                        break;
                                    case "51":
                                        comboBox1.SelectedItem = "3";
                                        hotkey = 51;
                                        break;
                                    case "52":
                                        comboBox1.SelectedItem = "4";
                                        hotkey = 52;
                                        break;
                                    case "53":
                                        comboBox1.SelectedItem = "5";
                                        hotkey = 53;
                                        break;
                                    case "54":
                                        comboBox1.SelectedItem = "6";
                                        hotkey = 54;
                                        break;
                                }
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
            WriteIDsToTXT();
            gHook.unhook();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            comboBox1.SelectedItem = "L-CTRL";
            hotkey = 162;
            textBox1.Text = "";
            seconds = 0;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox ComboBox1 = (ComboBox)sender;
            string selectedString = (string)ComboBox1.SelectedItem;
            // Convert it to lowercase.
            switch (selectedString)
            {
                case "L-CTRL":
                    hotkey = 162;
                    break;
                case "R-CTRL":
                    hotkey = 163;
                    break;
                case "L-ALT":
                    hotkey = 164;
                    break;
                case "R-ALT":
                    hotkey = 165;
                    break;
                case "L-SHIFT":
                    hotkey = 160;
                    break;
                case "R-SHIFT":
                    hotkey = 161;
                    break;
                case "SPACE":
                    hotkey = 32;
                    break;
                case "BREAK / PAUSE":
                    hotkey = 19;
                    break;
                case "HOME":
                    hotkey = 36;
                    break;
                case "PAGE UP":
                    hotkey = 33;
                    break;
                case "PAGE DOWN":
                    hotkey = 34;
                    break;
                case "F1":
                    hotkey = 112;
                    break;
                case "F2":
                    hotkey = 113;
                    break;
                case "F3":
                    hotkey = 114;
                    break;
                case "F4":
                    hotkey = 115;
                    break;
                case "F5":
                    hotkey = 116;
                    break;
                case "F6":
                    hotkey = 117;
                    break;
                case "F7":
                    hotkey = 118;
                    break;
                case "F8":
                    hotkey = 119;
                    break;
                case "F9":
                    hotkey = 120;
                    break;
                case "F10":
                    hotkey = 121;
                    break;
                case "F11":
                    hotkey = 122;
                    break;
                case "F12":
                    hotkey = 123;
                    break;
                case "Q":
                    hotkey = 81;
                    break;
                case "W":
                    hotkey = 87;
                    break;
                case "E":
                    hotkey = 69;
                    break;
                case "R":
                    hotkey = 82;
                    break;
                case "T":
                    hotkey = 84;
                    break;
                case "A":
                    hotkey = 65;
                    break;
                case "S":
                    hotkey = 83;
                    break;
                case "D":
                    hotkey = 68;
                    break;
                case "F":
                    hotkey = 70;
                    break;
                case "C":
                    hotkey = 67;
                    break;
                case "1":
                    hotkey = 49;
                    break;
                case "2":
                    hotkey = 50;
                    break;
                case "3":
                    hotkey = 51;
                    break;
                case "4":
                    hotkey = 52;
                    break;
                case "5":
                    hotkey = 53;
                    break;
                case "6":
                    hotkey = 54;
                    break;
            }
        }
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 | (int)e.KeyChar > 57) & (int)e.KeyChar != 8)
            {
                e.Handled = true;
                seconds = Int32.Parse(textBox1.Text);
            }
        }
    }
}
