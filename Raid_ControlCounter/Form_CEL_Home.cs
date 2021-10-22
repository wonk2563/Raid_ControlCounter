using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace Raid_ControlCounter
{
    public partial class Form_CEL_Home : Form
    {
        GlobalKeyboardHook gHook;
        IntPtr el_hWnd;
        int hotkey = 0, hotkey2 = 0, level = 250;
        bool autocheak = true , bkw_cancel = false;


        public Form_CEL_Home()
        {
            InitializeComponent();
            label1.Text = effectList[0].ToString();
            stopTime = effectList[0] * 1000;
            ReadIDsByTXT();

            Get_el_hwnd();

            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(bgwWorker_ProgressChanged);
            backgroundWorker1.WorkerReportsProgress = true;
            if (autocheak)
            {
                Start_BGWorker();
            }    

            gHook = new GlobalKeyboardHook();
            gHook.KeyDown += new KeyEventHandler(gHook_KeyDown);
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                gHook.HookedKeys.Add(key);
            gHook.hook();
        }

        bool isStop = false , manual_start = false;
        private void gHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == hotkey && e.KeyValue != 0 && !counting)
            {
                if (!isStop)
                {
                    Stop_BGWorker();
                    effectNum = 0;
                    stopTime = effectList[0] * 1000;
                    Change_Label_Text_and_Color("光線蒐集", Color.SteelBlue);
                    timer_count.Start();
                    stopWatch.Start();
                    manual_start = true;
                }
                else
                {
                    Start_Counting();
                }               
            }
            else if (e.KeyValue == hotkey2 && e.KeyValue != 0 && !isStop)
            {
                Stop_Counting();
            }
        }

        public void Stop_Counting()
        {
            timer_count.Stop();
            stopWatch.Stop();
            isStop = true;
            counting = false;
        }

        public void Start_Counting()
        {
            timer_count.Start();
            stopWatch.Start();
            isStop = false;
            counting = true;
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.DarkGray, ButtonBorderStyle.Solid);
        }


        //======================================================

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (!bkw_cancel)
                {
                    Get_el_hwnd();
                    if (el_hWnd != (IntPtr)0)
                    {
                        if(!counting && !isStop)
                            backgroundWorker1.ReportProgress(80);

                        Get_ELcap_Hash();

                        if (Is_Entering_Games() && !counting)
                        {
                            while (Is_Entering_Games())
                            {
                                Get_ELcap_Hash();
                                GC.Collect();
                                Thread.Sleep(100);
                            }
                            backgroundWorker1.ReportProgress(100);
                        }                        
                    }
                    else
                    {
                        backgroundWorker1.ReportProgress(90);
                    }
                    GC.Collect();                    
                    Thread.Sleep(200);
                }
                else
                    break;
            }            
        }

        private void Stop_BGWorker()
        {
            bkw_cancel = true;
        }

        private void Start_BGWorker()
        {
            bkw_cancel = false;
            if(!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();            
        }

        private void bgwWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            if (e.ProgressPercentage is 60)
            {
                Stop_Counting();
            }
            if (e.ProgressPercentage is 70)
            {
                Start_Counting();
            }
            if (e.ProgressPercentage is 80)
            {
                Change_Label_Text_and_Color("光線蒐集",Color.SteelBlue);
            }
            else if (e.ProgressPercentage is 90 && !manual_start)
            {
                Change_Label_Text_and_Color("未偵測到遊戲", Color.Firebrick);
            }
            else if (e.ProgressPercentage is 100)
            {
                stopWatch.Reset();
                timer_count.Start();
                stopWatch.Start();
            }
        }

        bool counting = false;
        decimal[] effectList = { 20 , 20 , 15 , 5 };
        decimal stopTime, remainingTime;
        int effectNum = 0;
        Stopwatch stopWatch = new Stopwatch();
        private void timer_count_Tick(object sender, EventArgs e)
        {
            counting = true;
            remainingTime = decimal.Round((stopTime - stopWatch.ElapsedMilliseconds) / 1000, 1);
            label1.Text = Convert.ToString(remainingTime);
            if (stopTime <= stopWatch.ElapsedMilliseconds)
            {
                stopWatch.Reset();

                if (effectNum == 3)
                    effectNum = 0;
                else
                    effectNum++;                
                stopTime = effectList[effectNum] * 1000;
                label1.Text = Convert.ToString(effectList[effectNum]);

                if(effectNum == 0)  //光線蒐集
                {
                    Change_Label_Text_and_Color("光線蒐集", Color.SteelBlue);
                }
                else if (effectNum == 1)    //月亮空亡
                {
                    Change_Label_Text_and_Color("月亮空亡", Color.Purple);
                }
                else if (effectNum == 2)    //審判
                {
                    Change_Label_Text_and_Color("審判", Color.Olive);
                }
                else if (effectNum == 3)    //未知
                {
                    Change_Label_Text_and_Color("未知", Color.Firebrick);
                }

                stopWatch.Start();
            }            
        }

        private void 快捷鍵與靈敏度設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_CEL_Hotkey setting = new Form_CEL_Hotkey();
            setting.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            Stop_BGWorker();
            setting.Show();
            this.Hide();
        }

        private void 重置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autocheak && !backgroundWorker1.IsBusy)
            {
                Start_BGWorker();             
            }
            TimerReset();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            ReadIDsByTXT();
            if (autocheak && !backgroundWorker1.IsBusy && !manual_start) //有開啟自動偵測並且沒有在偵測中，也不是手動模式
            {
                Start_BGWorker();
            }
            else if (!autocheak) //沒有開啟自動偵測
            {
                Stop_BGWorker();
                TimerReset();
            }
        }

        public void TimerReset() //重置計時
        {            
            timer_count.Stop();
            stopWatch.Reset();
            effectNum = 0;
            label1.Text = Convert.ToString(effectList[0]);
            Change_Label_Text_and_Color("光線蒐集", Color.SteelBlue);
            counting = false;
            isStop = false;
            manual_start = false;
        }

        public void Change_Label_Text_and_Color(string st , Color color)
        {
            label2.Text = st;
            label2.ForeColor = color;
        }

        private void ReadIDsByTXT()
        {
            string name = "", stutas = "";
            string path = AppDomain.CurrentDomain.BaseDirectory + "configs/CEL_config.txt";
            string Hashpath = AppDomain.CurrentDomain.BaseDirectory + "image/Hash.txt";
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

                            if (name == "hotkey1")
                                hotkey = Int32.Parse(stutas.Split(',')[0]);
                            if (name == "hotkey2")
                                hotkey2 = Int32.Parse(stutas.Split(',')[0]);
                            if (name == "level")
                                level = Int32.Parse(stutas) + 200;
                            if (name == "autocheak")
                                autocheak = Convert.ToBoolean(stutas);
                        }
                    }

                    lines = System.IO.File.ReadAllLines(Hashpath);
                    hashList = new List<string>();
                    foreach (string line in lines)
                    {
                        hashList.Add(line);
                    }
                }
                catch (Exception)
                {
                    File.Create(path).Close();
                    ReadIDsByTXT();
                    return;
                }
            }
            else
            {
                File.Create(path).Close();
                ReadIDsByTXT();
                return;
            }
        }

        //=================獲取視窗句柄=====================

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        // Delegate to filter which windows to include 
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        /// <summary> Get the text for the window pointed to by hWnd </summary>
        public static string GetWindowText(IntPtr hWnd)
        {
            int size = GetWindowTextLength(hWnd);
            if (size > 0)
            {
                var builder = new StringBuilder(size + 1);
                GetWindowText(hWnd, builder, builder.Capacity);
                return builder.ToString();
            }

            return String.Empty;
        }

        /// <summary> Find all windows that match the given filter </summary>
        /// <param name="filter"> A delegate that returns true for windows
        ///    that should be returned and false for windows that should
        ///    not be returned </param>
        public static IEnumerable<IntPtr> FindWindows(EnumWindowsProc filter)
        {
            IntPtr found = IntPtr.Zero;
            List<IntPtr> windows = new List<IntPtr>();

            EnumWindows(delegate (IntPtr wnd, IntPtr param)
            {
                if (filter(wnd, param))
                {
                    // only add the windows that pass the filter
                    windows.Add(wnd);
                }

                // but return true here so that we iterate all windows
                return true;
            }, IntPtr.Zero);

            return windows;
        }

        /// <summary> Find all windows that contain the given title text </summary>
        /// <param name="titleText"> The text that the window title must contain. </param>
        public static IEnumerable<IntPtr> FindWindowsWithText(string titleText)
        {
            return FindWindows(delegate (IntPtr wnd, IntPtr param)
            {
                return GetWindowText(wnd).Contains(titleText);
            });
        }


        //----------------------------獲取螢幕縮放率-------------------------------------
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        public enum DeviceCap
        {
            VERTRES = 10,
            DESKTOPVERTRES = 117,
        }

        public float getScalingFactor()
        {
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            int LogicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.VERTRES);
            int PhysicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);
            float ScreenScalingFactor = (float)PhysicalScreenHeight / (float)LogicalScreenHeight;
            g.Dispose();

            return ScreenScalingFactor; // 1.25 = 125%
        }


        //=================截圖=====================

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rectangle rect);
        
        [DllImport("gdi32.dll")]
        private static extern int DeleteDC(
         IntPtr hdc           // handle to DC
         );
        
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(
         IntPtr hwnd
         );

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        //獲取艾爾之光的視窗句柄
        IEnumerable<IntPtr> windows;
        private void Get_el_hwnd()
        {
            windows = FindWindowsWithText("Elsword - ");
            foreach (IntPtr i in windows)
            {
                el_hWnd = i;
            }
        }

        //擷取特定視窗的畫面
        IntPtr hscrdc;
        Bitmap bmp;
        public Bitmap GetWindowCapture(IntPtr hWnd , float dpi)
        {
            try
            {
                hscrdc = GetWindowDC(hWnd);
                Rectangle windowRect = new Rectangle();
                GetWindowRect(hWnd, ref windowRect);

                int width = Math.Abs((int)((windowRect.Width - windowRect.X) * dpi));
                int height = Math.Abs((int)((windowRect.Height - windowRect.Y) * dpi));
                int win_X = (int)(windowRect.X * dpi);
                int win_Y = (int)(windowRect.Y * dpi);
                bmp = new Bitmap(width,
                    height);
                var size = new Size(width,
                    height);
                Graphics graphics = Graphics.FromImage(bmp as Image);
                graphics.CopyFromScreen(win_X, win_Y, 0, 0, size);
                graphics.Dispose();
                DeleteDC(hscrdc);//删除用过的对象

                return bmp;
            }
            catch (Exception)
            {
                throw;
            }           
        }

        //擷取艾爾之光的畫面
        float dpi;
        private void Cap_El_SC()
        {
            dpi = getScalingFactor();

            // 將Bitmap物件轉換為平台指標
            IntPtr gdibitmap = GetWindowCapture(el_hWnd, dpi).GetHbitmap();
            SourceImg = Image.FromHbitmap(gdibitmap);

            // 進行Bitmap資源的釋放
            DeleteObject(gdibitmap);
            bmp.Dispose();
                        
        }


        //======================比較圖片相似度=============================

        public bool Is_Entering_Games()  //比較轉場圖片相似度
        {
            CalcAllSimilarDegree();

            bool isSimilar = false;
            foreach (int similar in similarList)
            {
                if (similar <= level)
                    isSimilar =  true;
            }
            return isSimilar;
        }

        List<int> similarList;
        public void CalcAllSimilarDegree()  //計算所有圖片相似度
        {
            similarList = new List<int>();
            foreach (string hash in hashList)
            {
                similarList.Add(CalcSimilarDegree(SourceImg_Hash, hash));
            }
        }

        /*public bool Is_Dark()
        {
            bool isSim = false;
            if (CalcSimilarDegree(SourceImg_Hash, Properties.Resources.DarkImageHash.ToString()) <= level)
                isSim = true;
            return isSim;
        }*/

        List<string> hashList;
        /*public void GetAllHash()    //獲取所有圖片的Hash值
        {
            hashList = new List<string>();
            foreach (string fname in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "image/"))
            {
                Image img = Image.FromFile(fname);
                hashList.Add(GetHash(img));
            }
        }*/

        public void Get_ELcap_Hash()
        {
            Cap_El_SC();
            SourceImg_Hash = GetHash(SourceImg);
        }


        Image SourceImg;
        string SourceImg_Hash;
        Byte[] grayValues;
        Byte average;
        String reslut;
        public String GetHash(Image img)
        {
            grayValues = ReduceColor(ReduceSize(img));
            average = CalcAverage(grayValues);
            reslut = ComputeBits(grayValues, average);
            return reslut;
        }

        // Step 1 : Reduce size to 8*8
        private Image ReduceSize(Image img, int width = 32, int height = 32)
        {            
            return img.GetThumbnailImage(width, height, () => { return false; }, IntPtr.Zero);
        }

        // Step 2 : Reduce Color
        Bitmap bitMap;
        Byte[] grayValues2;

        private void Paint_Panel(object sender, PaintEventArgs e)
        {

        }

        private Byte[] ReduceColor(Image image)
        {
            bitMap = new Bitmap(image);
            grayValues2 = new Byte[image.Width * image.Height];

            for (int x = 0; x < image.Width; x++)
                for (int y = 0; y < image.Height; y++)
                {
                    Color color = bitMap.GetPixel(x, y);
                    byte grayValue = (byte)((color.R * 30 + color.G * 59 + color.B * 11) / 100);
                    grayValues2[x * image.Width + y] = grayValue;
                }
            bitMap.Dispose();
            return grayValues2;
        }

        // Step 3 : Average the colors
        private Byte CalcAverage(byte[] values)
        {
            int sum = 0;
            for (int i = 0; i < values.Length; i++)
                sum += (int)values[i];
            return Convert.ToByte(sum / values.Length);
        }

        // Step 4 : Compute the bits
        char[] result;
        private String ComputeBits(byte[] values, byte averageValue)
        {
            result = new char[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < averageValue)
                    result[i] = '0';
                else
                    result[i] = '1';
            }
            return new String(result);
        }

        // Compare hash
        public static Int32 CalcSimilarDegree(string a, string b)
        {
            if (a.Length != b.Length)
                throw new ArgumentException();
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    count++;
            }
            return count;
        }

    }
}
