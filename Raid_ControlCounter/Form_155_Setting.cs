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
    public partial class Form_155_Setting : Form
    {
        GlobalKeyboardHook gHook;
        int hotkey = 0;


        public Form_155_Setting()
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
            string[] configs = new string[1];
            string AppPath = Assembly.GetExecutingAssembly().Location;
            AppPath = Path.GetDirectoryName(AppPath);

            string path = AppDomain.CurrentDomain.BaseDirectory + "configs/155_config.txt";
            string[] lines = System.IO.File.ReadAllLines(@path);
            int i = 0;

            foreach (string line in lines)
            {
                configs[i] = line;
                i++;
            }
            configs[0] = "hotkey=" + hotkey;

            System.IO.File.WriteAllLines(@AppPath + "/configs/155_config.txt", configs);
        }

        private void ReadIDsByTXT()
        {            
            string name = "", stutas = "";
            string path = AppDomain.CurrentDomain.BaseDirectory + "configs/155_config.txt";
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
            comboBox1.SelectedItem = "L-CTRL";
            hotkey = 162;
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
            }
        }
    }
}
