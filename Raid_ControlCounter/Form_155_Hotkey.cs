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
    public partial class Form_155_Hotkey : Form
    {
        GlobalKeyboardHook gHook;
        int hotkey = 0;


        public Form_155_Hotkey()
        {
            InitializeComponent();

            hotkeyName = "LCtrl";
            label1.Text = "LCtrl";
            hotkey = 162;

            SetHotkeyValue(Hotkeys.ReadTXT("155_config.txt"));

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
                int[] hotkeys = new int[] { hotkey };
                string[] hotkeyNames = new string[] { hotkeyName };
                Hotkeys.WriteToTXT("155_config.txt", hotkeys, hotkeyNames);

                gHook.unhook();
                this.Close();
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            int[] hotkeys = new int[] { hotkey };
            string[] hotkeyNames = new string[] { hotkeyName };
            Hotkeys.WriteToTXT("155_config.txt", hotkeys, hotkeyNames);

            gHook.unhook();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hotkeyName = "LCtrl";
            label1.Text = "LCtrl";
            hotkey = 162;
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

            pBoxTag = 0;
        }

        private void SetHotkeyValue(Tuple<int[], string[], int, bool> tuple)
        {
            if(tuple.Item1.Length > 0)
            {
                hotkey = tuple.Item1[0];

                hotkeyName = tuple.Item2[0];
                label1.Text = hotkeyName;
            }            
        }
    }
}
