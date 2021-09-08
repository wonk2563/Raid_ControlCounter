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

namespace Raid_ControlCounter
{
    public partial class Form_CEL_Home : Form
    {
        GlobalKeyboardHook gHook;
        IntPtr el_hWnd;
        int hotkey = 0, level = 250;
        bool autocheak = true , bkw_cancel = false;


        public Form_CEL_Home()
        {
            InitializeComponent();
            label1.Text = before_unknow.ToString();
            ReadIDsByTXT();

            Get_el_hwnd();
            convertImg_Hash = GetHash(convertImg);
            convertImg2_Hash = GetHash(convertImg2);

            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(bgwWorker_ProgressChanged);
            backgroundWorker1.WorkerReportsProgress = true;
            if (autocheak)
            {
                backgroundWorker1.RunWorkerAsync();
                bkw_cancel = false;
            }    

            gHook = new GlobalKeyboardHook();
            gHook.KeyDown += new KeyEventHandler(gHook_KeyDown);
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                gHook.HookedKeys.Add(key);
            gHook.hook();
        }

        private void gHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == hotkey && e.KeyValue != 0 && !counting)
            {
                label2.Text = "未知倒數";
                label2.ForeColor = Color.Black;
                bkw_cancel = true;
                timer_count.Start();
            }
        }

        int similarDegree = 500 , similarDegree2 = 500;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (!bkw_cancel)
                {
                    Get_el_hwnd();
                    if (el_hWnd != (IntPtr)0)
                    {
                        backgroundWorker1.ReportProgress(80);

                        Cap_El_SC();
                        SourceImg_Hash = GetHash(SourceImg);
                        similarDegree = CalcSimilarDegree(SourceImg_Hash, convertImg_Hash);
                        similarDegree2 = CalcSimilarDegree(SourceImg_Hash, convertImg2_Hash);
                    }
                    else
                    {
                        backgroundWorker1.ReportProgress(90);
                    }
                    GC.Collect();

                    if ((similarDegree <= level || similarDegree2 <= level) && !counting)
                    {
                        while (similarDegree <= level || similarDegree2 <= level)
                        {
                            Cap_El_SC();
                            SourceImg_Hash = GetHash(SourceImg);
                            similarDegree = CalcSimilarDegree(SourceImg_Hash, convertImg_Hash);
                            similarDegree2 = CalcSimilarDegree(SourceImg_Hash, convertImg2_Hash);
                            GC.Collect();
                            Thread.Sleep(500);
                        }
                        backgroundWorker1.ReportProgress(100);
                        break;
                    }
                    Thread.Sleep(500);
                }
                else
                    break;
            }            
        }

        private void bgwWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage is 80)
            {
                label2.Text = "未知倒數";
                label2.ForeColor = Color.Black;
            }
            else if (e.ProgressPercentage is 90)
            {
                label2.Text = "未偵測到遊戲";
                label2.ForeColor = Color.Firebrick;
            }
            else if (e.ProgressPercentage is 100)
                timer_count.Start();
        }

        bool unknow = false , counting = false;
        decimal count_down = 55, before_unknow = 55, unknow_now = 5;
        private void timer_count_Tick(object sender, EventArgs e)
        {
            count_down -= (decimal)0.1;
            label1.Text = Convert.ToString(count_down);
            if (!unknow && count_down <= 0)
            {                
                count_down = unknow_now;
                label1.Text = Convert.ToString(unknow_now);
                label2.Text = "未知持續中";
                label2.ForeColor = Color.Firebrick;
                unknow = true;
            }
            else if (unknow && count_down <= 0)
            {
                count_down = before_unknow;
                label1.Text = Convert.ToString(before_unknow);
                label2.Text = "未知倒數";
                label2.ForeColor = Color.Black;
                unknow = false;
            }
        }

        private void 快捷鍵與靈敏度設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_CEL_Setting setting = new Form_CEL_Setting();
            setting.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            bkw_cancel = true;
            setting.Show();
            this.Hide();
        }

        private void 重置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autocheak && !backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
                bkw_cancel = false;
            }
            timer_count.Stop();
            count_down = before_unknow;
            label1.Text = Convert.ToString(before_unknow);
            label2.Text = "未知倒數";
            label2.ForeColor = Color.Black;
            unknow = false;
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            ReadIDsByTXT();
            if (autocheak && !backgroundWorker1.IsBusy)
            {
                bkw_cancel = false;
                backgroundWorker1.RunWorkerAsync();
            }           
            else
                bkw_cancel = true;
        }

        private void ReadIDsByTXT()
        {
            string name = "", stutas = "";
            string path = AppDomain.CurrentDomain.BaseDirectory + "configs/CEL_config.txt";
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

                            if (name == "hotkey")
                                hotkey = Int32.Parse(stutas);
                            if (name == "level")
                                level = Int32.Parse(stutas) + 200;
                            if (name == "autocheak")
                                autocheak = Convert.ToBoolean(stutas);
                        }
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


        Image SourceImg, 
            convertImg = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "image/convert.png"),
            convertImg2 = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "image/convert2.png");
        string SourceImg_Hash, convertImg_Hash, convertImg2_Hash;
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
