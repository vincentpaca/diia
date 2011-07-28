using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace EchoSystems.Common.Views
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        #region Form Dragging API Support
        //The SendMessage function sends a message to a window or windows.

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]

        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        //ReleaseCapture releases a mouse capture

        [DllImportAttribute("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]

        public static extern bool ReleaseCapture();

        #endregion

        /// <summary>
        /// Respond to the picture box mousedown event to
        /// drag the borderless form around (left click and drag)/// </summary>

        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            // drag the form without the caption bar

            // present on left mouse button

            if (e.Button == MouseButtons.Left)
            {

                ReleaseCapture();

                SendMessage(this.Handle, 0xa1, 0x2, 0);

            }

        }

        public void setProgress(string pProgress)
        {
            lblProgressText.Text = pProgress;
        }
    }
}
