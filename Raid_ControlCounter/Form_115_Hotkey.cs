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
    public partial class Form_115_Hotkey : Form
    {
        GlobalKeyboardHook gHook;
        int hotkey = 0 , hotkey2 = 0;


        public Form_115_Hotkey()
        {
            InitializeComponent();
            comboBox1.SelectedItem = "L-CTRL";
            comboBox2.SelectedItem = "無";
            hotkey = 162;
            hotkey2 = 0;
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

            string path = AppDomain.CurrentDomain.BaseDirectory + "configs/115_config.txt";
            string[] lines = System.IO.File.ReadAllLines(@path);
            int i = 0;

            foreach (string line in lines)
            {
                configs[i] = line;
                i++;
            }
            configs[0] = "hotkey=" + hotkey;
            configs[1] = "hotkey2=" + hotkey2;

            System.IO.File.WriteAllLines(@AppPath + "/configs/115_config.txt", configs);
        }

        private void ReadIDsByTXT()
        {            
            string name = "", stutas = "";
            string path = AppDomain.CurrentDomain.BaseDirectory + "configs/115_config.txt";
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
                                    case "86":
                                        comboBox1.SelectedItem = "V";
                                        hotkey = 86;
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
                            if (name == "hotkey2")
                            {
                                switch (stutas)
                                {
                                    case "0":
                                        comboBox2.SelectedItem = "無";
                                        hotkey2 = 0;
                                        break;
                                    case "162":
                                        comboBox2.SelectedItem = "L-CTRL";
                                        hotkey2 = 162;
                                        break;
                                    case "163":
                                        comboBox2.SelectedItem = "R-CTRL";
                                        hotkey2 = 163;
                                        break;
                                    case "164":
                                        comboBox2.SelectedItem = "L-ALT";
                                        hotkey2 = 164;
                                        break;
                                    case "165":
                                        comboBox2.SelectedItem = "R-ALT";
                                        hotkey2 = 165;
                                        break;
                                    case "160":
                                        comboBox2.SelectedItem = "L-SHIFT";
                                        hotkey2 = 160;
                                        break;
                                    case "161":
                                        comboBox2.SelectedItem = "R-SHIFT";
                                        hotkey2 = 161;
                                        break;
                                    case "32":
                                        comboBox2.SelectedItem = "SPACE";
                                        hotkey2 = 32;
                                        break;
                                    case "81":
                                        comboBox2.SelectedItem = "Q";
                                        hotkey2 = 81;
                                        break;
                                    case "87":
                                        comboBox2.SelectedItem = "W";
                                        hotkey2 = 87;
                                        break;
                                    case "69":
                                        comboBox2.SelectedItem = "E";
                                        hotkey2 = 69;
                                        break;
                                    case "82":
                                        comboBox2.SelectedItem = "R";
                                        hotkey2 = 82;
                                        break;
                                    case "84":
                                        comboBox2.SelectedItem = "T";
                                        hotkey2 = 84;
                                        break;
                                    case "65":
                                        comboBox2.SelectedItem = "A";
                                        hotkey2 = 65;
                                        break;
                                    case "83":
                                        comboBox2.SelectedItem = "S";
                                        hotkey2 = 83;
                                        break;
                                    case "68":
                                        comboBox2.SelectedItem = "D";
                                        hotkey2 = 68;
                                        break;
                                    case "70":
                                        comboBox2.SelectedItem = "F";
                                        hotkey2 = 70;
                                        break;
                                    case "67":
                                        comboBox2.SelectedItem = "C";
                                        hotkey2 = 67;
                                        break;
                                    case "86":
                                        comboBox2.SelectedItem = "V";
                                        hotkey2 = 86;
                                        break;
                                    case "49":
                                        comboBox2.SelectedItem = "1";
                                        hotkey2 = 49;
                                        break;
                                    case "50":
                                        comboBox2.SelectedItem = "2";
                                        hotkey2 = 50;
                                        break;
                                    case "51":
                                        comboBox2.SelectedItem = "3";
                                        hotkey2 = 51;
                                        break;
                                    case "52":
                                        comboBox2.SelectedItem = "4";
                                        hotkey2 = 52;
                                        break;
                                    case "53":
                                        comboBox2.SelectedItem = "5";
                                        hotkey2 = 53;
                                        break;
                                    case "54":
                                        comboBox2.SelectedItem = "6";
                                        hotkey2 = 54;
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
            comboBox2.SelectedItem = "無";
            hotkey = 162;
            hotkey2 = 0;
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
                case "V":
                    hotkey = 86;
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox ComboBox2 = (ComboBox)sender;
            string selectedString2 = (string)ComboBox2.SelectedItem;
            // Convert it to lowercase.
            switch (selectedString2)
            {
                case "無":
                    hotkey2 = 0;
                    break;
                case "L-CTRL":
                    hotkey2 = 162;
                    break;
                case "R-CTRL":
                    hotkey2 = 163;
                    break;
                case "L-ALT":
                    hotkey2 = 164;
                    break;
                case "R-ALT":
                    hotkey2 = 165;
                    break;
                case "L-SHIFT":
                    hotkey2 = 160;
                    break;
                case "R-SHIFT":
                    hotkey2 = 161;
                    break;
                case "SPACE":
                    hotkey2 = 32;
                    break;
                case "Q":
                    hotkey2 = 81;
                    break;
                case "W":
                    hotkey2 = 87;
                    break;
                case "E":
                    hotkey2 = 69;
                    break;
                case "R":
                    hotkey2 = 82;
                    break;
                case "T":
                    hotkey2 = 84;
                    break;
                case "A":
                    hotkey2 = 65;
                    break;
                case "S":
                    hotkey2 = 83;
                    break;
                case "D":
                    hotkey2 = 68;
                    break;
                case "F":
                    hotkey2 = 70;
                    break;
                case "C":
                    hotkey2 = 67;
                    break;
                case "V":
                    hotkey2 = 86;
                    break;
                case "1":
                    hotkey2 = 49;
                    break;
                case "2":
                    hotkey2 = 50;
                    break;
                case "3":
                    hotkey2 = 51;
                    break;
                case "4":
                    hotkey2 = 52;
                    break;
                case "5":
                    hotkey2 = 53;
                    break;
                case "6":
                    hotkey2 = 54;
                    break;
            }
        }
    }
}
