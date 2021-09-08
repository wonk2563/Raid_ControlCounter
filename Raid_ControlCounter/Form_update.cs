using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace Raid_ControlCounter
{
    public partial class Form_update : Form
    {
        public Form_update()
        {
            InitializeComponent();
        }
        private void updateForm_Load(object sender, EventArgs e)
        {
        }
        private void updateForm_Shown(object sender, EventArgs e)
        {
            ReadVersionByTXT();
            ReadVersion();
        }

        string appPath = AppDomain.CurrentDomain.BaseDirectory;
        string nowVersion = "";
        private void ReadVersionByTXT()
        {
            string path = appPath + "version.txt";
            if (System.IO.File.Exists(path))
            {
                nowVersion = File.ReadAllText(@path, Encoding.UTF8).Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");                
            }
            else
            {
                MessageBox.Show("無法獲取當前版本資訊", "錯誤");
            }
        }

        string[] updateInfo, fixInfo;
        string lastVersion = "";
        private void btn_updateNow_Click(object sender, EventArgs e)
        {
            ProcessStartInfo Info = new ProcessStartInfo();
            Info.FileName = "update.exe"; //執行的檔案名稱
            Info.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory; //檔案所在的目錄
            Process.Start(Info);
            Thread.Sleep(10);
            Application.Exit();
        }

        private void btn_remindNextTime_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void ReadVersion()
        {
            updateInfo = File.ReadAllLines("data/updateinfo.txt", Encoding.UTF8);
            if (updateInfo.Length != 0)
            {
                string fix = "";
                lastVersion = updateInfo[0];
                if (updateInfo.Length - 3 > 0)
                {
                    fixInfo = new string[updateInfo.Length - 3];
                    for (int i = 0; i < updateInfo.Length - 3; i++)
                        fixInfo[i] = updateInfo[i + 2];
                    fix = String.Join("\n", fixInfo);
                }
                if (fix == "")
                    fix = "無";

                if (int.Parse(nowVersion.Replace(".", "")) < int.Parse(lastVersion.Replace(".", "")))
                {
                    label1.Text = $"\n目前版本：{nowVersion}　更新版本：{lastVersion}\n\n" +
                       $"更新內容：\n" +
                       $"{fix}\n\n";
                }
                else
                {
                    this.Close();
                }
                File.Delete("data/updateinfo.txt");
                btn_remindNextTime.Enabled = true;
                btn_updateNow.Enabled = true;
            }
            else
                MessageBox.Show("獲取更新資訊失敗" + "\r\n請檢查網路是否正常", "錯誤");
        }
    }
}
