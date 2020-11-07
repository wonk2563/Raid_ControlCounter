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
using System;

namespace Raid_ControlCounter
{
    public partial class Form1 : Form
    {
        GlobalKeyboardHook gHook;
        int resis = 0,ctrlSec=0,hotkey=0;
        decimal freezeTime = 0;


        public Form1()
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
            string path = AppDomain.CurrentDomain.BaseDirectory + "config.txt";
            File.Exists(path);
            File.Create(path).Close();
        }

        private void gHook_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyValue == hotkey && e.KeyValue != 0)
            {
                this.timer1.Stop();
                freezeTime = ctrlSec * ((300m + resis) / 500m);
                freezeTime = Decimal.Round(freezeTime);
                label1.Text = Convert.ToString(freezeTime);                
                this.timer1.Start();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void 降抗手段選擇ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 bForm = new Form2();
            bForm.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            gHook.unhook();
            this.timer1.Stop();
            bForm.Show();
            this.Hide();
        }
        private void 控場手段與快捷鍵ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form3 cForm = new Form3();
            cForm.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            gHook.unhook();
            this.timer1.Stop();
            cForm.Show();
            this.Hide();
        }
        private void ej0M6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 dForm = new Form4();
            dForm.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            gHook.unhook();
            this.timer1.Stop();
            dForm.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            freezeTime -= (decimal)1;
            label1.Text = Convert.ToString(freezeTime);
            if(freezeTime <= 0)
            {
                this.timer1.Stop();
                freezeTime = 0;
                label1.Text = Convert.ToString(freezeTime);
            }
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
            string path = AppDomain.CurrentDomain.BaseDirectory + "config.txt";
            if (System.IO.File.Exists(path))
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
                        if(name == "ctrlSec")
                            ctrlSec = Int32.Parse(stutas);
                        if (name == "hotkey")
                            hotkey = Int32.Parse(stutas);
                    }
                }
            }
            freezeTime = ctrlSec * ((300m + resis) / 500m);
            freezeTime = Decimal.Round(freezeTime);
            label1.Text = Convert.ToString(freezeTime);
        }
    }
}
