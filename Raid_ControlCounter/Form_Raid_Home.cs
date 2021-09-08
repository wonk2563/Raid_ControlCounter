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
using System.Threading;

namespace Raid_ControlCounter
{
    public partial class Form_Raid_Home : Form
    {
        GlobalKeyboardHook gHook;
        int resis = 0,hotkey=0;
        decimal freezeTime = 0, ctrlSec = 0;
        bool isNP = false;


        public Form_Raid_Home()
        {
            InitializeComponent();            
            gHook = new GlobalKeyboardHook();
            gHook.KeyDown += new KeyEventHandler(gHook_KeyDown);
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                gHook.HookedKeys.Add(key);
            gHook.hook();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            ReadIDsByTXT();
        }

        private void gHook_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyValue == hotkey && e.KeyValue != 0)
            {
                this.timer1.Stop();
                freezeTime = ctrlSec * ((300m + resis) / 500m);
                freezeTime = Decimal.Round(freezeTime,1);
                label1.Text = Convert.ToString(freezeTime);

                if (isNP)
                    backgroundWorker1.RunWorkerAsync();
                else
                    this.timer1.Start();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void 降抗手段選擇ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Raid_Resis bForm = new Form_Raid_Resis();
            bForm.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            gHook.unhook();
            this.timer1.Stop();
            bForm.Show();
            this.Hide();
        }
        private void 控場手段與快捷鍵ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form_Raid_Controler cForm = new Form_Raid_Controler();
            cForm.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            gHook.unhook();
            this.timer1.Stop();
            cForm.Show();
            this.Hide();
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            freezeTime -= (decimal)0.1;
            label1.Text = Convert.ToString(freezeTime);
            if(freezeTime <= 0)
            {
                this.timer1.Stop();
                freezeTime = 0;
                label1.Text = Convert.ToString(freezeTime);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(1800);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer1.Start();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            ReadIDsByTXT();
            gHook.hook();
        }

        private void ReadIDsByTXT()
        {
            string name="", stutas="";
            string path = AppDomain.CurrentDomain.BaseDirectory + "configs/raid_config.txt";
            if (System.IO.File.Exists(path))
            {
                try
                {
                    string[] lines = System.IO.File.ReadAllLines(@path);

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

                            if (name == "resis")
                                resis = Int32.Parse(stutas);
                            if (name == "ctrlSec")
                                ctrlSec = decimal.Parse(stutas);
                            if (name == "hotkey")
                                hotkey = Int32.Parse(stutas);
                            if (name == "selection")
                                if(stutas == "NP")
                                    isNP = true;
                                else
                                    isNP = false;
                        }
                    }
                }
                catch (Exception)
                {                    
                    File.Exists(path);
                    File.Create(path).Close();
                    ReadIDsByTXT();
                    return;
                }                
            }
            else
            {                
                File.Exists(path);
                File.Create(path).Close();
                ReadIDsByTXT();
                return;
            }
            freezeTime = ctrlSec * ((300m + resis) / 500m);
            freezeTime = Decimal.Round(freezeTime,1);
            label1.Text = Convert.ToString(freezeTime);
            if (freezeTime <= 0)
            {
                this.timer1.Stop();
                freezeTime = 0;
                label1.Text = Convert.ToString(freezeTime);
            }
        }
    }
}
