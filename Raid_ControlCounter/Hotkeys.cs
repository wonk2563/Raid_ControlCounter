using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raid_ControlCounter
{
    class Hotkeys
    {
        static string[] configs;
        public static void WriteToTXT(string hotkeyFileName , int[] hotkeys , string[] hotkeyNames , int Level = 0 , bool Auto = false)
        {
            if(hotkeyFileName == "CEL_config.txt")            
                configs = new string[hotkeys.Length + 2];            
            else
                configs = new string[hotkeys.Length];

            string path = AppDomain.CurrentDomain.BaseDirectory + "configs/" + hotkeyFileName;

            for(int i = 0; i <= hotkeys.Length-1; i++)
            {
                configs[i] = $"hotkey{i+1}=" + hotkeys[i] + "," + hotkeyNames[i];
            }

            if (hotkeyFileName == "CEL_config.txt")
            {
                configs[configs.Length - 1] = "level=" + Level;
                configs[configs.Length - 2] = "autocheak=" + Auto;
            }                

            System.IO.File.WriteAllLines(path, configs);
        }

        static string[] hotkeyNames;
        static int[] hotkeys;
        static int level;
        static bool auto_cheak;
        public static Tuple<int[] , string[] , int , bool> ReadTXT(string hotkeyFileName)
        {
            string name = "", stutas = "";
            string path = AppDomain.CurrentDomain.BaseDirectory + "configs/" + hotkeyFileName;            
            if (System.IO.File.Exists(path))
            {
                string[] lines = System.IO.File.ReadAllLines(@path);
                hotkeys = new int[lines.Length];
                hotkeyNames = new string[lines.Length];
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

                            if (name == "hotkey1")
                            {
                                hotkeys[0] = Int32.Parse(stutas.Split(',')[0]);
                                hotkeyNames[0] = stutas.Split(',')[1];
                            }
                            else if (name == "hotkey2")
                            {
                                hotkeys[1] = Int32.Parse(stutas.Split(',')[0]);
                                hotkeyNames[1] = stutas.Split(',')[1];
                            }

                            else if (name == "hotkey3")
                            {
                                hotkeys[2] = Int32.Parse(stutas.Split(',')[0]);
                                hotkeyNames[2] = stutas.Split(',')[1];
                            }

                            else if (name == "level")
                            {
                                level = Int32.Parse(stutas.Split(',')[0]);                                
                            }

                            else if (name == "autocheak")
                            {
                                auto_cheak = Convert.ToBoolean(stutas.Split(',')[0]);
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
            return Tuple.Create(hotkeys, hotkeyNames , level , auto_cheak);
        }
    }
}
