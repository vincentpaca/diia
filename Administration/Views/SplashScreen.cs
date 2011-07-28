using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using EchoSystems.Administration.Controller;
using EchoSystems.Common.Global;

namespace EchoSystems.Administration.Views
{
    public partial class SplashScreen : Form
    {
        int lDelay;

        public SplashScreen()
        {
            InitializeComponent();
            lDelay = 200;
        }

        #region custom paint methods
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00080000; // Required: set WS_EX_LAYERED extended style
                return cp;
            }
        }

        //Updates the Form's display using API calls
        public void UpdateFormDisplay(Image backgroundImage)
        {
            IntPtr screenDc = API.GetDC(IntPtr.Zero);
            IntPtr memDc = API.CreateCompatibleDC(screenDc);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr oldBitmap = IntPtr.Zero;

            try
            {
                //Display-image
                Bitmap bmp = new Bitmap(backgroundImage);
                hBitmap = bmp.GetHbitmap(Color.FromArgb(0));  //Set the fact that background is transparent
                oldBitmap = API.SelectObject(memDc, hBitmap);

                //Display-rectangle
                Size size = bmp.Size;
                Point pointSource = new Point(0, 0);
                Point topPos = new Point(this.Left, this.Top);

                //Set up blending options
                API.BLENDFUNCTION blend = new API.BLENDFUNCTION();
                blend.BlendOp = API.AC_SRC_OVER;
                blend.BlendFlags = 0;
                blend.SourceConstantAlpha = 255;
                blend.AlphaFormat = API.AC_SRC_ALPHA;

                API.UpdateLayeredWindow(this.Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, API.ULW_ALPHA);

                //Clean-up
                bmp.Dispose();
                API.ReleaseDC(IntPtr.Zero, screenDc);
                if (hBitmap != IntPtr.Zero)
                {
                    API.SelectObject(memDc, oldBitmap);
                    API.DeleteObject(hBitmap);
                }
                API.DeleteDC(memDc);
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region internal API
        internal class API
        {
            public const byte AC_SRC_OVER = 0x00;
            public const byte AC_SRC_ALPHA = 0x01;
            public const Int32 ULW_ALPHA = 0x00000002;

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct BLENDFUNCTION
            {
                public byte BlendOp;
                public byte BlendFlags;
                public byte SourceConstantAlpha;
                public byte AlphaFormat;
            }

            [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);


            [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern IntPtr GetDC(IntPtr hWnd);

            [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

            [DllImport("user32.dll", ExactSpelling = true)]
            public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

            [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern bool DeleteDC(IntPtr hdc);


            [DllImport("gdi32.dll", ExactSpelling = true)]
            public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

            [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern bool DeleteObject(IntPtr hObject);
        }
        #endregion

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            UpdateFormDisplay(this.BackgroundImage);
            bwSplash.RunWorkerAsync();
        }

        private void bwSplash_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(lDelay);
            bwSplash.ReportProgress(0);
            Thread.Sleep(lDelay);
            Administration.Controller.Administration _oAdministration = new Controller.Administration();
            _oAdministration.openSQLConnection();
            Thread.Sleep(lDelay);
            bwSplash.ReportProgress(1);
            Thread.Sleep(lDelay);
            bwSplash.ReportProgress(2);
            Thread.Sleep(lDelay);
            _oAdministration.connectToFileServer();
            Thread.Sleep(lDelay);
            bwSplash.ReportProgress(6);
            _oAdministration.connectToImageServer();
            bwSplash.ReportProgress(7);
            Thread.Sleep(lDelay);
            bwSplash.ReportProgress(3);
            Thread.Sleep(lDelay);
            bwSplash.ReportProgress(4);
            GlobalVariables.goApplication = new Microsoft.Office.Interop.Word.Application();
            GlobalVariables.goDocument = new Microsoft.Office.Interop.Word.Document();
            bwSplash.ReportProgress(5);
            Thread.Sleep(lDelay);
            bwSplash.ReportProgress(8);
            _oAdministration.loadDLLs();
            bwSplash.ReportProgress(9);
            Thread.Sleep(lDelay);
        }

        private void bwSplash_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Object[] _oStatus = new Object[1];

            switch (e.ProgressPercentage)
            {
                case 0:
                    _oStatus[0] = "Attempting to connect to the database server...";
                    GlobalVariables.goMainMDI.GetType().GetMethod("updateStatus").Invoke(GlobalVariables.goMainMDI, _oStatus);
                    break;
                case 1:
                    _oStatus[0] = "Connection successful!";
                    GlobalVariables.goMainMDI.GetType().GetMethod("updateStatus").Invoke(GlobalVariables.goMainMDI, _oStatus);
                    break;
                case 2:
                    _oStatus[0] = "Attempting to connect to the file server...";
                    GlobalVariables.goMainMDI.GetType().GetMethod("updateStatus").Invoke(GlobalVariables.goMainMDI, _oStatus);
                    break;
                case 3:
                    _oStatus[0] = "File server online!";
                    GlobalVariables.goMainMDI.GetType().GetMethod("updateStatus").Invoke(GlobalVariables.goMainMDI, _oStatus);
                    break;
                case 4:
                    _oStatus[0] = "Loading Microsoft Office components...";
                    GlobalVariables.goMainMDI.GetType().GetMethod("updateStatus").Invoke(GlobalVariables.goMainMDI, _oStatus);
                    break;
                case 5:
                    _oStatus[0] = "Microsoft Office components loaded successfully!";
                    GlobalVariables.goMainMDI.GetType().GetMethod("updateStatus").Invoke(GlobalVariables.goMainMDI, _oStatus);
                    break;
                case 6:
                     _oStatus[0] = "Attempting to connect to the image server";
                    GlobalVariables.goMainMDI.GetType().GetMethod("updateStatus").Invoke(GlobalVariables.goMainMDI, _oStatus);
                    break;
                case 7:
                     _oStatus[0] = "Image server online!";
                    GlobalVariables.goMainMDI.GetType().GetMethod("updateStatus").Invoke(GlobalVariables.goMainMDI, _oStatus);
                    break;
                case 8:
                     _oStatus[0] = "Loading application modules";
                    GlobalVariables.goMainMDI.GetType().GetMethod("updateStatus").Invoke(GlobalVariables.goMainMDI, _oStatus);
                    break;
                case 9:
                     _oStatus[0] = "Done!";
                    GlobalVariables.goMainMDI.GetType().GetMethod("updateStatus").Invoke(GlobalVariables.goMainMDI, _oStatus);
                    break;

            }
        }

        private void bwSplash_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Object[] _oStatus = new Object[1];
            _oStatus[0] = "Online";
            GlobalVariables.goMainMDI.GetType().GetMethod("updateStatus").Invoke(GlobalVariables.goMainMDI, _oStatus);
            this.Close();
        }
    }
}
