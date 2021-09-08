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
    public partial class Form_VI_Hotkey : Form
    {
        GlobalKeyboardHook gHook;
        int hotkey = 0;


        public Form_VI_Hotkey()
        {
            InitializeComponent();
            comboBox1.SelectedItem = "F";
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
            string[] configs = new string[1];
            string AppPath = Assembly.GetExecutingAssembly().Location;
            AppPath = Path.GetDirectoryName(AppPath);

            string path = AppDomain.CurrentDomain.BaseDirectory + "configs/vi_config.txt";
            string[] lines = System.IO.File.ReadAllLines(@path);
            int i = 0;

            foreach (string line in lines)
            {
                configs[i] = line;
                i++;
            }
            configs[0] = "hotkey=" + hotkey;            

            System.IO.File.WriteAllLines(@AppPath + "/configs/vi_config.txt", configs);
        }

        private void ReadIDsByTXT()
        {            
            string name = "", stutas = "";
            string path = AppDomain.CurrentDomain.BaseDirectory + "configs/vi_config.txt";
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
            comboBox1.SelectedItem = "F";
            hotkey = 70;
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
    }
}
