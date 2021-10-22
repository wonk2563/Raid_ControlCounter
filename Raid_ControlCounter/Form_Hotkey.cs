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
    public partial class Form_Hotkey : Form
    {
        GlobalKeyboardHook gHook;
        List<int> hotkey_list = new List<int>();
        string hotkeyName;

        string hotkeyFileName;
        bool singleChoose;

        public List<int> Gethokeys
        {
            get
            {
                return hotkey_list;
            }
        }

        public List<int> Sethokeys
        {
            set
            {
                hotkey_list = value;
            }
        }

        public string GethokeysName
        {
            get
            {
                return hotkeyName;
            }
        }


        public Form_Hotkey(string hotkeyFile = "", bool single = false)
        {
            InitializeComponent();            
            hotkeyFileName = hotkeyFile;
            singleChoose = single;
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
            if (hotkeyFileName != "")
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "configs/" + hotkeyFileName;
                string[] configs = new string[hotkey_list.Count];
                int i = 0;

                foreach (int hotkey in hotkey_list)
                {
                    configs[i] = hotkey.ToString();
                    i++;
                }

                System.IO.File.WriteAllLines(path, configs);
            }                  
        }

        private void ReadIDsByTXT()
        {   if(hotkeyFileName != "")
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "configs/" + hotkeyFileName;
                if (System.IO.File.Exists(path))
                {
                    string[] lines = System.IO.File.ReadAllLines(@path);
                    try
                    {
                        foreach (string line in lines)
                        {
                            foreach (PictureBox ctrl in groupBox1.Controls)
                            {
                                if (ctrl.Tag.ToString() == line)
                                {
                                    Change_PBox_Status(ctrl);
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WriteIDsToTXT();
            gHook.unhook();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Change_PBox_Status(null,true);
        }        

        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Change_PBox_Status(pictureBox);
        }

        private void Change_PBox_Status(PictureBox pictureBox , bool removeAll = false)
        {
            if (removeAll)
            {
                hotkey_list = new List<int>();
                hotkeyName = "";
                foreach (PictureBox pBOX in groupBox1.Controls)
                {
                    pBOX.BackColor = Color.Transparent;
                }
            }
            else
            {
                if (!hotkey_list.Exists(x => x == Int32.Parse((string)pictureBox.Tag)))
                {
                    if(singleChoose && hotkey_list.Count != 0)
                    {
                        hotkey_list = new List<int>();
                        hotkeyName = "";
                    }                        
                           
                    hotkey_list.Add(Int32.Parse((string)pictureBox.Tag));
                    hotkeyName = pictureBox.Name.Remove(0,11);
                    foreach (PictureBox pbox in groupBox1.Controls)
                    {
                        if (hotkey_list.Exists(x => x == Int32.Parse((string)pbox.Tag)))
                            pbox.BackColor = Color.DarkGray;
                        else
                            pbox.BackColor = Color.Transparent;
                    }
                }
                else
                {
                    hotkey_list.Remove(Int32.Parse((string)pictureBox.Tag));
                    pictureBox.BackColor = Color.Transparent;
                }
            }

            Console.WriteLine(hotkey_list.Count);
            if (hotkey_list.Count >= 4 && hotkey_list.Count <= 10 && hotkeyFileName == "vi_config.txt")
                label1.Text = "玥冥黎是最可愛的VI";
            else if (hotkey_list.Count > 10 && hotkey_list.Count < 57 && hotkeyFileName == "vi_config.txt")
                label1.Text = "超過10個技能？";
            else if (hotkey_list.Count == 57 && hotkeyFileName == "vi_config.txt")
                label1.Text = "你確定玩的是艾爾之光？";
            else
                label1.Text = "";
        }

        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.BackColor = Color.LightGray;
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            if (!hotkey_list.Exists(x => x == Int32.Parse((string)pictureBox.Tag)))
                pictureBox.BackColor = Color.Transparent;
            else
                pictureBox.BackColor = Color.DarkGray;
        }
    }
}
