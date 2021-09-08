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
    public partial class Form_Raid_Resis : Form
    {
        GlobalKeyboardHook gHook;
        int resis = 0;
        

        public Form_Raid_Resis()
        {
            InitializeComponent();
            ReadIDsByTXT();
            label3.Text = Convert.ToString(resis);
            gHook = new GlobalKeyboardHook();
            gHook.KeyDown += new KeyEventHandler(gHook_KeyDown);
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                gHook.HookedKeys.Add(key);
            gHook.hook();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void gHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                WriteIDsToTXT();
                gHook.unhook();
                this.Close();
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
            RM.Checked = false;
            OZ.Checked = false;
            RH.Checked = false;
            NI.Checked = false;
            CE.Checked = false;
            MN.Checked = false;
            BQ.Checked = false;
            ES.Checked = false;
            BR.Checked = false;
            VI.Checked = false;
            RS.Checked = false;
            HE.Checked = false;
            BL.Checked = false;
            ICE.Checked = false;
            HERO.Checked = false;
            DARK.Checked = false;
            NP.Checked = false;
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

            if (RM.Checked == false)
                configs[0] = "RM=false";
            else
                configs[0] = "RM=true";

            if (OZ.Checked == false)
                configs[1] = "OZ=false";
            else
                configs[1] = "OZ=true";

            if (RH.Checked == false)
                configs[2] = "RH=false";
            else
                configs[2] = "RH=true";

            if (NI.Checked == false)
                configs[3] = "NI=false";
            else
                configs[3] = "NI=true";

            if (CE.Checked == false)
                configs[4] = "CE=false";
            else
                configs[4] = "CE=true";

            if (MN.Checked == false)
                configs[5] = "MN=false";
            else
                configs[5] = "MN=true";

            if (BQ.Checked == false)
                configs[6] = "BQ=false";
            else
                configs[6] = "BQ=true";

            if (ES.Checked == false)
                configs[7] = "ES=false";
            else
                configs[7] = "ES=true";

            if (BR.Checked == false)
                configs[8] = "BR=false";
            else
                configs[8] = "BR=true";

            if (VI.Checked == false)
                configs[9] = "VI=false";
            else
                configs[9] = "VI=true";

            if (RS.Checked == false)
                configs[10] = "RS=false";
            else
                configs[10] = "RS=true";

            if (HE.Checked == false)
                configs[11] = "HE=false";
            else
                configs[11] = "HE=true";

            if (BL.Checked == false)
                configs[12] = "BL=false";
            else
                configs[12] = "BL=true";

            if (NP.Checked == false)
                configs[13] = "NP=false";
            else
                configs[13] = "NP=true";

            if (ICE.Checked == false)
                configs[14] = "ICE=false";
            else
                configs[14] = "ICE=true";

            if (HERO.Checked == false)
                configs[15] = "HERO=false";
            else
                configs[15] = "HERO=true";

            if (DARK.Checked == false)
                configs[16] = "DARK=false";
            else
                configs[16] = "DARK=true";            

            configs[17] = "BQresis=" + bqresis2;
            configs[18] = "resis=" + resis;

            System.IO.File.WriteAllLines(@AppPath + "/configs/raid_config.txt", configs);
        }

        private void ReadIDsByTXT()
        {           
            string name="", stutas="";
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
                            if(words.Length == 2)
                            {
                                name = words[0];
                                stutas = words[1];
                            }

                            if (name == "RM")
                                RM.Checked = bool.Parse(stutas);
                            if (name == "OZ")
                                OZ.Checked = bool.Parse(stutas);
                            if (name == "RH")
                                RH.Checked = bool.Parse(stutas);
                            if (name == "NI")
                                NI.Checked = bool.Parse(stutas);
                            if (name == "CE")
                                CE.Checked = bool.Parse(stutas);
                            if (name == "MN")
                                MN.Checked = bool.Parse(stutas);
                            if (name == "BQ")
                                BQ.Checked = bool.Parse(stutas);
                            if (name == "ES")
                                ES.Checked = bool.Parse(stutas);
                            if (name == "BR")
                                BR.Checked = bool.Parse(stutas);
                            if (name == "VI")
                                VI.Checked = bool.Parse(stutas);
                            if (name == "RS")
                                RS.Checked = bool.Parse(stutas);
                            if (name == "HE")
                                HE.Checked = bool.Parse(stutas);
                            if (name == "BL")
                                BL.Checked = bool.Parse(stutas);
                            if (name == "ICE")
                                ICE.Checked = bool.Parse(stutas);
                            if (name == "HERO")
                                HERO.Checked = bool.Parse(stutas);
                            if (name == "DARK")
                                DARK.Checked = bool.Parse(stutas);
                            if (name == "NP")
                                NP.Checked = bool.Parse(stutas);
                            if (name == "resis")
                                resis = Int32.Parse(stutas);
                            if (name == "BQresis")
                                bqresis2 = Int32.Parse(stutas);                            
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

        private void Change_backcolor(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == true)            
                (sender as CheckBox).BackColor = Color.FromArgb(225, 225, 225);            
            else
                (sender as CheckBox).BackColor = Color.WhiteSmoke;
        }

        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (RM.Checked)            
                resis += 380;
            else           
                resis -= 380;
            
            Change_backcolor(sender,e);
            label3.Text = Convert.ToString(resis);
        }       

        private void OZ_CheckedChanged(object sender, EventArgs e)
        {
            if (OZ.Checked)                           
                resis += 260;     
            else            
                resis -= 260;

            Change_backcolor(sender, e);
            label3.Text = Convert.ToString(resis);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (RH.Checked)
                resis += 150;
            else
                resis -= 150;

            Change_backcolor(sender, e);
            label3.Text = Convert.ToString(resis);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (NI.Checked)
                resis += 250;
            else
                resis -= 250;

            Change_backcolor(sender, e);
            label3.Text = Convert.ToString(resis);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (CE.Checked)
                resis += 30;
            else
                resis -= 30;

            Change_backcolor(sender, e);
            label3.Text = Convert.ToString(resis);
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (VI.Checked)
                resis += 250;
            else
                resis -= 250;

            Change_backcolor(sender, e);
            label3.Text = Convert.ToString(resis);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (BR.Checked)
                resis += 100;
            else
                resis -= 100;

            Change_backcolor(sender, e);
            label3.Text = Convert.ToString(resis);
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (ES.Checked)
                resis += 160;
            else
                resis -= 160;

            Change_backcolor(sender, e);
            label3.Text = Convert.ToString(resis);
        }

        double bqresis=0,bqresis2=0;
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            
            if (BQ.Checked)
            {
                bqresis = (500 - (500 - resis)) * 1.5;
                bqresis2 = bqresis;
                resis += (int)bqresis;
            }
            else
            {                
                resis -= (int)bqresis2;
            }

            Change_backcolor(sender, e);
            label3.Text = Convert.ToString(resis);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (MN.Checked)
                resis += 50;
            else
                resis -= 50;

            Change_backcolor(sender, e);
            label3.Text = Convert.ToString(resis);
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (BL.Checked)
                resis += 150;
            else
                resis -= 150;

            Change_backcolor(sender, e);
            label3.Text = Convert.ToString(resis);
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (HE.Checked)
                resis += 100;
            else
                resis -= 100;

            Change_backcolor(sender, e);
            label3.Text = Convert.ToString(resis);
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (RS.Checked)
                resis += 150;
            else
                resis -= 150;

            Change_backcolor(sender, e);
            label3.Text = Convert.ToString(resis);
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (DARK.Checked)
                resis += 100;
            else
                resis -= 100;

            Change_backcolor(sender, e);
            label3.Text = Convert.ToString(resis);
        }        

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (ICE.Checked)
                resis += 150;
            else
                resis -= 150;

            Change_backcolor(sender, e);
            label3.Text = Convert.ToString(resis);
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (NP.Checked)
                resis += 150;
            else
                resis -= 150;

            Change_backcolor(sender, e);
            label3.Text = Convert.ToString(resis);
        }       

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (HERO.Checked)
                resis += 150;
            else
                resis -= 150;

            Change_backcolor(sender, e);
            label3.Text = Convert.ToString(resis);
        }
    }
}
