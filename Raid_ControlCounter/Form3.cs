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
    public partial class Form3 : Form
    {
        GlobalKeyboardHook gHook;
        int ctrlSec = 0,hotkey = 0;


        public Form3()
        {
            InitializeComponent();
            comboBox1.SelectedItem = "F";
            hotkey = 70;
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
            string[] configs = new string[20];
            string AppPath = Assembly.GetExecutingAssembly().Location;
            AppPath = Path.GetDirectoryName(AppPath);

            string path = AppDomain.CurrentDomain.BaseDirectory + "config.txt";
            string[] lines = System.IO.File.ReadAllLines(@path);
            int i = 0;

            foreach (string line in lines)
            {
                configs[i] = line;
                i++;
            }
            configs[18] = "ctrlSec=" + ctrlSec;
            configs[19] = "hotkey=" + hotkey;

            System.IO.File.WriteAllLines(@AppPath + "/config.txt", configs);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WriteIDsToTXT();
            gHook.unhook();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;      
            checkBox8.Checked = false;
            checkBox10.Checked = false;
            checkBox12.Checked = false;
            checkBox17.Checked = false;
            comboBox1.SelectedItem = "F";
            hotkey = 70;
        }

        private void ckb_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == true)
            {
                foreach (CheckBox chk in (sender as CheckBox).Parent.Controls)
                {
                    if (chk != sender)
                    {
                        chk.Checked = false;
                    }
                }
            }
        }

        private void checkBox8_CheckedChanged_1(object sender, EventArgs e)
        {
            ckb_CheckedChanged(sender, e);
            if (checkBox8.Checked)
                ctrlSec = 7;
            else
                ctrlSec = 0;
            label3.Text = Convert.ToString(ctrlSec);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            ckb_CheckedChanged(sender, e);
            if (checkBox5.Checked)
                ctrlSec = 5;
            else
                ctrlSec = 0;
            label3.Text = Convert.ToString(ctrlSec);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ckb_CheckedChanged(sender, e);
            if (checkBox1.Checked)
                ctrlSec = 5;
            else
                ctrlSec = 0;
            label3.Text = Convert.ToString(ctrlSec);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ckb_CheckedChanged(sender, e);
            if (checkBox2.Checked)
                ctrlSec = 5;
            else
                ctrlSec = 0;
            label3.Text = Convert.ToString(ctrlSec);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            ckb_CheckedChanged(sender, e);
            if (checkBox3.Checked)
                ctrlSec = 5;
            else
                ctrlSec = 0;
            label3.Text = Convert.ToString(ctrlSec);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            ckb_CheckedChanged(sender, e);
            if (checkBox4.Checked)
                ctrlSec = 4;
            else
                ctrlSec = 0;
            label3.Text = Convert.ToString(ctrlSec);
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            ckb_CheckedChanged(sender, e);
            if (checkBox12.Checked)
                ctrlSec = 5;
            else
                ctrlSec = 0;
            label3.Text = Convert.ToString(ctrlSec);
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            ckb_CheckedChanged(sender, e);
            if (checkBox10.Checked)
                ctrlSec = 4;
            else
                ctrlSec = 0;
            label3.Text = Convert.ToString(ctrlSec);
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

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            ckb_CheckedChanged(sender, e);
            if (checkBox17.Checked)
                ctrlSec = 4;
            else
                ctrlSec = 0;
            label3.Text = Convert.ToString(ctrlSec);
        }
    }
}
