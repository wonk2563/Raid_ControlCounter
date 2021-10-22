using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;

namespace Raid_ControlCounter
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            InstallFont();

            if(font_is_install[0] && font_is_install[1])
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form_MainHome());
            }
        }


        
        //using System.Runtime.InteropServices;
        [DllImport("gdi32", EntryPoint = "AddFontResource")]
        public static extern int AddFontResourceA(string lpFileName);
        [DllImport("gdi32", EntryPoint = "RemoveFontResource")]
        public static extern int RemoveFontResourceA(string lpFileName);

        static List<bool> font_is_install = new List<bool>();
        
        private static void InstallFont()
        {
            string[] fontNames = { "Futura Bk BT" , "OPPOSans M" };
            Font font;

            foreach(string name in fontNames)
            {
                try
                {
                    font = new Font(name, 10);
                    if (font.Name != name)
                    {
                        Steup_fonts(name);
                        return;
                    }
                }
                catch (Exception)
                {
                    Steup_fonts(name);
                    return;
                }

                font_is_install.Add(true);
            }            
        }

        static private void Steup_fonts(string fontName)
        {
            font_is_install.Add(false);

            string FontFullPath = Path.Combine(Path.GetTempPath(), fontName + ".ttf");
            GetFontFromResource(FontFullPath);

            //要事先先加入Regedit
            string winFontPath = Environment.GetEnvironmentVariable("WinDir") + $"\\fonts\\{fontName}.ttf";

            //File.Delete(winFontPath);
            if (!File.Exists(winFontPath))
            {
                File.Copy(FontFullPath, winFontPath);
            }
            
            AddFontResourceA(winFontPath);

            //註冊Registry
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts",
                fontName,
                $"{fontName}.ttf",
                RegistryValueKind.String);

            Application.Restart();
        }


        /// <summary>
        /// 把內嵌字型檔案抓出來存放在本機暫存區
        /// </summary>
        /// <param name="FontFullName">字型檔案完整路徑</param>
        static private void GetFontFromResource(string FontFullName)
        {
            if (File.Exists(FontFullName)) return;
            byte[] FontData = { };

            if (FontFullName.EndsWith("Futura Bk BT.ttf"))
                FontData = Properties.Resources.Futura_Bk_BT;

            else if (FontFullName.EndsWith("OPPOSans M.ttf"))
                FontData = Properties.Resources.OPPOSans_M;

            File.WriteAllBytes(FontFullName, FontData);
        }
    }
}
