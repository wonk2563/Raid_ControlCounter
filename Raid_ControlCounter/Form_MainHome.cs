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
using System.Runtime.InteropServices;
using System.Net;

namespace Raid_ControlCounter
{
    public partial class Form_MainHome : Form
    {

        public Form_MainHome()
        {
            InitializeComponent();
            Initial();
            Create_LocationConfig();
            ReadIDsByTXT();
        }


        //=================計時器按鈕=====================

        Form_Raid_Home f1;
        _115 f_115;
        Form_CEL_Home f_cel;
        Form_VI_Home f_vi;
        Form_155_Home f_155;
        Form_Customize_Home f_Customize;
        Point start_location = new Point();
        private void btn_Raid_Click(object sender, EventArgs e)
        {
            if (f1 == null)
            {
                f1 = new Form_Raid_Home();
                f1.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
                f1.Owner = this;                
                f1.Show();
                start_location = Get_location(f1);

                if (location_raid != new Point(0, 0))
                {
                    Set_location(f1, location_raid);
                }
                else
                {
                    if (setting_by_self_raid == true)
                    {
                        Set_location(f1, location_raid);
                    }
                }

                Image image = Properties.Resources.Home_btn_on;
                btn_Raid.BackgroundImage = image;
            }
            else
            {
                f1.Close();                
            }
        }
        
        private void btn_115_Click(object sender, EventArgs e)
        {
            if (f_115 == null)
            {
                f_115 = new _115();
                f_115.FormClosed += new FormClosedEventHandler(Form115_FormClosed);
                f_115.Owner = this;
                f_115.Show();
                start_location = Get_location(f_115);

                if (location_115 != new Point(0, 0))
                {
                    Set_location(f_115, location_115);
                }
                else
                {
                    if (setting_by_self_115 == true)
                    {
                        Set_location(f_115, location_115);
                    }
                }

                Image image = Properties.Resources.Home_btn_on;
                btn_115.BackgroundImage = image;
            }
            else
            {
                f_115.Close();
            }
        }
                
        private void btn_cel_Click(object sender, EventArgs e)
        {
            if (f_cel == null)
            {
                f_cel = new Form_CEL_Home();
                f_cel.FormClosed += new FormClosedEventHandler(FormCEL_FormClosed);
                f_cel.Owner = this;
                f_cel.Show();
                start_location = Get_location(f_cel);

                if (location_cel != new Point(0, 0))
                {
                    Set_location(f_cel, location_cel);
                }
                else
                {
                    if (setting_by_self_cel == true)
                    {
                        Set_location(f_cel, location_cel);
                    }
                }

                Image image = Properties.Resources.Home_btn_on;
                btn_cel.BackgroundImage = image;
            }
            else
            {
                f_cel.Close();
            }
        }

        private void btn_vi_Click(object sender, EventArgs e)
        {
            if (f_vi == null)
            {
                f_vi = new Form_VI_Home();
                f_vi.FormClosed += new FormClosedEventHandler(FormVI_FormClosed);
                f_vi.Owner = this;
                f_vi.Show();
                start_location = Get_location(f_vi);

                if (location_vi != new Point(0, 0))
                {
                    Set_location(f_vi, location_vi);
                }
                else
                {
                    if (setting_by_self_vi == true)
                    {
                        Set_location(f_vi, location_vi);
                    }
                }

                Image image = Properties.Resources.Home_btn_on;
                btn_vi.BackgroundImage = image;
            }
            else
            {
                f_vi.Close();
            }
        }

        private void btn_155_Click(object sender, EventArgs e)
        {
            if (f_155 == null)
            {
                f_155 = new Form_155_Home();
                f_155.FormClosed += new FormClosedEventHandler(Form155_FormClosed);
                f_155.Owner = this;
                f_155.Show();
                start_location = Get_location(f_155);

                if (location_155 != new Point(0, 0))
                {
                    Set_location(f_155, location_155);
                }
                else
                {
                    if (setting_by_self_155 == true)
                    {
                        Set_location(f_155, location_155);
                    }
                }

                Image image = Properties.Resources.Home_btn_on;
                btn_155.BackgroundImage = image;
            }
            else
            {
                f_155.Close();
            }
        }

        private void btn_Customize_Click(object sender, EventArgs e)
        {
            if (f_Customize == null)
            {
                f_Customize = new Form_Customize_Home();
                f_Customize.FormClosed += new FormClosedEventHandler(FormCustomize_FormClosed);
                f_Customize.Owner = this;
                f_Customize.Show();
                start_location = Get_location(f_Customize);

                if (location_Customize != new Point(0, 0))
                {
                    Set_location(f_Customize, location_Customize);
                }
                else
                {
                    if (setting_by_self_Customize == true)
                    {
                        Set_location(f_Customize, location_Customize);
                    }
                }

                Image image = Properties.Resources.Home_btn_on;
                btn_Customize.BackgroundImage = image;
            }
            else
            {
                f_Customize.Close();
            }
        }        


        //=================表單關閉=====================

        private void home_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteIDsToTXT();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {            
            WriteIDsToTXT();
            Image image = Properties.Resources.Home_btn_off;
            btn_Raid.BackgroundImage = image;
            f1 = null;
            GC.Collect();
        }

        private void Form115_FormClosed(object sender, FormClosedEventArgs e)
        {
            WriteIDsToTXT();
            Image image = Properties.Resources.Home_btn_off;
            btn_115.BackgroundImage = image;
            f_115 = null;
            GC.Collect();
        }

        private void FormCEL_FormClosed(object sender, FormClosedEventArgs e)
        {
            WriteIDsToTXT();
            Image image = Properties.Resources.Home_btn_off;
            btn_cel.BackgroundImage = image;
            f_cel = null;
            GC.Collect();
        }

        private void FormVI_FormClosed(object sender, FormClosedEventArgs e)
        {
            WriteIDsToTXT();
            Image image = Properties.Resources.Home_btn_off;
            btn_vi.BackgroundImage = image;
            f_vi = null;
            GC.Collect();
        }

        private void Form155_FormClosed(object sender, FormClosedEventArgs e)
        {
            WriteIDsToTXT();
            Image image = Properties.Resources.Home_btn_off;
            btn_155.BackgroundImage = image;
            f_155 = null;
            GC.Collect();
        }

        private void FormCustomize_FormClosed(object sender, FormClosedEventArgs e)
        {
            WriteIDsToTXT();
            Image image = Properties.Resources.Home_btn_off;
            btn_Customize.BackgroundImage = image;
            f_Customize = null;
            GC.Collect();
        }

        private void Formabout_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            dForm = null;
        }


        //=================其他按鈕=====================

        private void btn_update_Click(object sender, EventArgs e)
        {
            Cheak_update();
        }

        Form_About dForm;
        private void btn_about_Click(object sender, EventArgs e)
        {
            dForm = new Form_About();
            dForm.FormClosed += new FormClosedEventHandler(Formabout_FormClosed);
            dForm.Show();
            this.Hide();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {            
            //隱藏程式本身的視窗
            this.Hide();
            //通知欄顯示Icon
            notifyIcon.Visible = true;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {            
            foreach (Form form in this.OwnedForms)
            {
                form.Location = start_location;
            }           
        }


        //====================檢查更新=====================
        
        string lastVersion = "", nowVersion = "";
        private void Cheak_update()
        {
            string uriPath = AppDomain.CurrentDomain.BaseDirectory + "data/cheakURI.txt";
            string cheakURI = File.ReadAllText(@uriPath, Encoding.UTF8);
            DownloadStreamString(cheakURI);
        }

        public void DownloadStreamString(string url)
        {
            try
            {
                WebClient wc = new WebClient();
                wc.DownloadFileCompleted += update_DownloadFileCompleted;
                wc.DownloadFileAsync(new Uri(url), "data/updateinfo.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show("獲取更新資訊失敗。" + "\r\n" + ex.Message, "錯誤");
            }
        }

        string[] updateInfo;
        private void update_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            updateInfo = File.ReadAllLines("data/updateinfo.txt", Encoding.UTF8);
            if (updateInfo.Length != 0)
            {
                lastVersion = updateInfo[0].Replace(".", "");
                nowVersion = nowVersion = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "version.txt", Encoding.UTF8).Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "").Replace(".", "");
                if (int.Parse(nowVersion) < int.Parse(lastVersion))
                {
                    Form_update f3 = new Form_update();
                    f3.Show();
                }
                else
                {
                    File.Delete("data/updateinfo.txt");
                    MessageBox.Show("目前的版本與伺服器相同或更新。", "檢查更新");      
                }
            }
        }



        //=================縮小到工具列=====================

        //宣告NotifyIcon
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private void Initial()
        {
            notifyIcon = new NotifyIcon();
            
            //設定通知欄在滑鼠移至Icon上的要顯示的文字
            notifyIcon.Text = "毛毛計時TREE";
            //Logo
            notifyIcon.Icon = (System.Drawing.Icon)(Properties.Resources.icon);
            
            //設定按下Icon發生的事件
            notifyIcon.Click += (sender, e) => {
                //取消再通知欄顯示Icon
                notifyIcon.Visible = false;
                //顯示在工具列
                this.ShowInTaskbar = true;
                //讓表單顯示在最上層
                this.TopMost = true;
                //顯示程式的視窗
                this.Show();
                //不讓表單總是顯示在最上層
                this.TopMost = false;
            };
        }


        //=================紀錄表單最後位置=====================

        private Point Get_location(Form form)
        {
            return form.Location;
        }

        private void Set_location(Form form,Point point)
        {
            form.Location = point;
        }

        private void Create_LocationConfig()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "configs/location_config.txt";
            if (!System.IO.File.Exists(path))
            {
                try
                {
                    File.Create(path).Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        Point location_raid, location_115, location_vi, location_cel, location_155 , location_Customize;
        bool setting_by_self_raid = false , setting_by_self_115 = false , setting_by_self_cel = false , setting_by_self_vi = false, setting_by_self_155 = false , setting_by_self_Customize = false;
        private void ReadIDsByTXT()
        {
            string name = "", stutas = "";
            string path = AppDomain.CurrentDomain.BaseDirectory + "configs/location_config.txt";
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

                            if(name == "raid_location")
                            {
                                string[] coords = stutas.Split(',');
                                location_raid = new Point(Int32.Parse(coords[0]), Int32.Parse(coords[1]));
                                setting_by_self_raid = true;
                            }
                            if (name == "115_location")
                            {
                                string[] coords = stutas.Split(',');
                                location_115 = new Point(Int32.Parse(coords[0]), Int32.Parse(coords[1]));
                                setting_by_self_115 = true;
                            }
                            if (name == "cel_location")
                            {
                                string[] coords = stutas.Split(',');
                                location_cel = new Point(Int32.Parse(coords[0]), Int32.Parse(coords[1]));
                                setting_by_self_cel = true;
                            }
                            if (name == "vi_location")
                            {
                                string[] coords = stutas.Split(',');
                                location_vi = new Point(Int32.Parse(coords[0]), Int32.Parse(coords[1]));
                                setting_by_self_vi = true;
                            }
                            if (name == "155_location")
                            {
                                string[] coords = stutas.Split(',');
                                location_155 = new Point(Int32.Parse(coords[0]), Int32.Parse(coords[1]));
                                setting_by_self_155 = true;
                            }
                            if (name == "Customize_location")
                            {
                                string[] coords = stutas.Split(',');
                                location_Customize = new Point(Int32.Parse(coords[0]), Int32.Parse(coords[1]));
                                setting_by_self_Customize = true;
                            }
                        }
                    }
                }
                catch (Exception)
                {                    
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

        private void WriteIDsToTXT()
        {
            string[] configs = new string[6];
            string AppPath = Assembly.GetExecutingAssembly().Location;
            AppPath = Path.GetDirectoryName(AppPath);

            string path = AppDomain.CurrentDomain.BaseDirectory + "configs/location_config.txt";
            string[] lines = System.IO.File.ReadAllLines(@path);
            int i = 0;
            foreach (string line in lines)
            {
                configs[i] = line;
                i++;
            }
            
            if (f1 != null)
            {
                location_raid = Get_location(f1);
                configs[0] = "raid_location=" + location_raid.X.ToString() + "," + location_raid.Y.ToString();
            }

            if(f_115 != null)
            {
                location_115 = Get_location(f_115);
                configs[1] = "115_location=" + location_115.X.ToString() + "," + location_115.Y.ToString();
            }

            if (f_cel != null)
            {
                location_cel = Get_location(f_cel);
                configs[2] = "cel_location=" + location_cel.X.ToString() + "," + location_cel.Y.ToString();
            }

            if (f_vi != null)
            {
                location_vi = Get_location(f_vi);
                configs[3] = "vi_location=" + location_vi.X.ToString() + "," + location_vi.Y.ToString();
            }

            if (f_155 != null)
            {
                location_155 = Get_location(f_155);
                configs[4] = "155_location=" + location_155.X.ToString() + "," + location_155.Y.ToString();
            }

            if (f_Customize != null)
            {
                location_Customize = Get_location(f_Customize);
                configs[5] = "Customize_location=" + location_Customize.X.ToString() + "," + location_Customize.Y.ToString();
            }

            System.IO.File.WriteAllLines(@AppPath + "/configs/location_config.txt", configs);
        }
    }
}
