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
using static Raid_ControlCounter.Hotkeys;

namespace Raid_ControlCounter
{
    public partial class Form_CEL_Hotkey : Form
    {
        GlobalKeyboardHook gHook;
        int hotkey = 0 , hotkey2 = 0 , level = 50;


        public Form_CEL_Hotkey()
        {
            InitializeComponent();

            hotkeyName = "LCtrl";
            hotkeyName2 = "LCtrl";
            label1.Text = "LCtrl";
            label2.Text = "LCtrl";
            hotkey = 162;
            hotkey2 = 162;

            checkBox_autocheak.Checked = true;
            trackBar1.Value = 40;
            level = 40;

            SetHotkeyValue(Hotkeys.ReadTXT("CEL_config.txt"));

            label_var.Text = level.ToString();
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
                int[] hotkeys = new int[] { hotkey, hotkey2 };
                string[] hotkeyNames = new string[] { hotkeyName, hotkeyName2 };
                Hotkeys.WriteToTXT("CEL_config.txt", hotkeys, hotkeyNames , level , auto_cheak);

                gHook.unhook();
                this.Close();
            }
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            int[] hotkeys = new int[] { hotkey, hotkey2 };
            string[] hotkeyNames = new string[] { hotkeyName, hotkeyName2 };
            Hotkeys.WriteToTXT("CEL_config.txt", hotkeys, hotkeyNames, level, auto_cheak);

            gHook.unhook();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hotkeyName = "LCtrl";
            hotkeyName2 = "LCtrl";
            label1.Text = "LCtrl";
            label2.Text = "LCtrl";
            hotkey = 162;
            hotkey2 = 162;

            auto_cheak = true;
            checkBox_autocheak.Checked = true;

            trackBar1.Value = 40;
            level = 40;
            label_var.Text = level.ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            level = trackBar1.Value;
            label_var.Text = level.ToString();
        }

        bool auto_cheak = true;
        private void checkBox_autocheak_CheckedChanged(object sender, EventArgs e)
        {
            auto_cheak = checkBox_autocheak.Checked;
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
        string hotkeyName, hotkeyName2;
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
                label1.Text = hotkeyName;
                hotkey = hotkeyList[0];
            }
            else if (pBoxTag == 2)
            {
                hotkeyName2 = hotkeyName;
                label2.Text = hotkeyName2;
                hotkey2 = hotkeyList[0];
            }

            pBoxTag = 0;
        }

        private void SetHotkeyValue(Tuple<int[], string[] , int , bool> tuple)
        {
            if(tuple.Item1.Length > 0)
            {
                hotkey = tuple.Item1[0];
                hotkey2 = tuple.Item1[1];

                hotkeyName = tuple.Item2[0];
                label1.Text = hotkeyName;

                hotkeyName2 = tuple.Item2[1];
                label2.Text = hotkeyName2;

                level = tuple.Item3;

                auto_cheak = tuple.Item4;
            }
            trackBar1.Value = level;
        }




    }
}
