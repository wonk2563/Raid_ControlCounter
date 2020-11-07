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
    public partial class Form2 : Form
    {
        GlobalKeyboardHook gHook;
        int resis = 0;

        public Form2()
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
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox13.Checked = false;
            checkBox14.Checked = false;
            checkBox15.Checked = false;
            checkBox11.Checked = false;
            checkBox12.Checked = false;
            checkBox17.Checked = false;
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

            if (checkBox1.Checked == false)
                configs[0] = "checkBox1=false";
            else
                configs[0] = "checkBox1=true";

            if (checkBox2.Checked == false)
                configs[1] = "checkBox2=false";
            else
                configs[1] = "checkBox2=true";

            if (checkBox3.Checked == false)
                configs[2] = "checkBox3=false";
            else
                configs[2] = "checkBox3=true";

            if (checkBox4.Checked == false)
                configs[3] = "checkBox4=false";
            else
                configs[3] = "checkBox4=true";

            if (checkBox5.Checked == false)
                configs[4] = "checkBox5=false";
            else
                configs[4] = "checkBox5=true";

            if (checkBox6.Checked == false)
                configs[5] = "checkBox6=false";
            else
                configs[5] = "checkBox6=true";

            if (checkBox7.Checked == false)
                configs[6] = "checkBox7=false";
            else
                configs[6] = "checkBox7=true";

            if (checkBox8.Checked == false)
                configs[7] = "checkBox8=false";
            else
                configs[7] = "checkBox8=true";

            if (checkBox9.Checked == false)
                configs[8] = "checkBox9=false";
            else
                configs[8] = "checkBox9=true";

            if (checkBox10.Checked == false)
                configs[9] = "checkBox10=false";
            else
                configs[9] = "checkBox10=true";

            if (checkBox13.Checked == false)
                configs[10] = "checkBox13=false";
            else
                configs[10] = "checkBox13=true";

            if (checkBox14.Checked == false)
                configs[11] = "checkBox14=false";
            else
                configs[11] = "checkBox14=true";

            if (checkBox15.Checked == false)
                configs[12] = "checkBox15=false";
            else
                configs[12] = "checkBox15=true";

            if (checkBox11.Checked == false)
                configs[13] = "checkBox11=false";
            else
                configs[13] = "checkBox11=true";

            if (checkBox12.Checked == false)
                configs[14] = "checkBox12=false";
            else
                configs[14] = "checkBox12=true";

            if (checkBox17.Checked == false)
                configs[15] = "checkBox17=false";
            else
                configs[15] = "checkBox17=true";

            configs[16] = "BQresis=" + bqresis2;
            configs[17] = "resis=" + resis;

            System.IO.File.WriteAllLines(@AppPath + "/config.txt", configs);
        }

        private void ReadIDsByTXT()
        {           
            string name="", stutas="";
            string path = AppDomain.CurrentDomain.BaseDirectory + "config.txt";
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

                            if (name == "checkBox1")
                                checkBox1.Checked = bool.Parse(stutas);
                            if (name == "checkBox2")
                                checkBox2.Checked = bool.Parse(stutas);
                            if (name == "checkBox3")
                                checkBox3.Checked = bool.Parse(stutas);
                            if (name == "checkBox4")
                                checkBox4.Checked = bool.Parse(stutas);
                            if (name == "checkBox5")
                                checkBox5.Checked = bool.Parse(stutas);
                            if (name == "checkBox6")
                                checkBox6.Checked = bool.Parse(stutas);
                            if (name == "checkBox7")
                                checkBox7.Checked = bool.Parse(stutas);
                            if (name == "checkBox8")
                                checkBox8.Checked = bool.Parse(stutas);
                            if (name == "checkBox9")
                                checkBox9.Checked = bool.Parse(stutas);
                            if (name == "checkBox10")
                                checkBox10.Checked = bool.Parse(stutas);
                            if (name == "checkBox13")
                                checkBox13.Checked = bool.Parse(stutas);
                            if (name == "checkBox14")
                                checkBox14.Checked = bool.Parse(stutas);
                            if (name == "checkBox15")
                                checkBox15.Checked = bool.Parse(stutas);
                            if (name == "checkBox11")
                                checkBox11.Checked = bool.Parse(stutas);
                            if (name == "checkBox12")
                                checkBox12.Checked = bool.Parse(stutas);
                            if (name == "checkBox17")
                                checkBox17.Checked = bool.Parse(stutas);
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

        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)            
                resis += 380;
            else
                resis -= 380;
            label3.Text = Convert.ToString(resis);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                resis += 260;
            else
                resis -= 260;
            label3.Text = Convert.ToString(resis);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                resis += 150;
            else
                resis -= 150;
            label3.Text = Convert.ToString(resis);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
                resis += 250;
            else
                resis -= 250;
            label3.Text = Convert.ToString(resis);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
                resis += 30;
            else
                resis -= 30;
            label3.Text = Convert.ToString(resis);
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
                resis += 250;
            else
                resis -= 250;
            label3.Text = Convert.ToString(resis);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
                resis += 100;
            else
                resis -= 100;
            label3.Text = Convert.ToString(resis);
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
                resis += 160;
            else
                resis -= 160;
            label3.Text = Convert.ToString(resis);
        }

        double bqresis=0,bqresis2=0;
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox7.Checked)
            {
                bqresis = (500 - (500 - resis)) * 1.5;
                bqresis2 = bqresis;
                resis += (int)bqresis;
            }
            else
            {                
                resis -= (int)bqresis2;
            }               
            label3.Text = Convert.ToString(resis);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
                resis += 50;
            else
                resis -= 50;
            label3.Text = Convert.ToString(resis);
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked)
                resis += 150;
            else
                resis -= 150;
            label3.Text = Convert.ToString(resis);
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked)
                resis += 100;
            else
                resis -= 100;
            label3.Text = Convert.ToString(resis);
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked)
                resis += 150;
            else
                resis -= 150;
            label3.Text = Convert.ToString(resis);
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked)
                resis += 100;
            else
                resis -= 100;
            label3.Text = Convert.ToString(resis);
        }        

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
                resis += 150;
            else
                resis -= 150;
            label3.Text = Convert.ToString(resis);
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked)
                resis += 150;
            else
                resis -= 150;
            label3.Text = Convert.ToString(resis);
        }
    }
}
