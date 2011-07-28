using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EchoSystems.DIIA.Views
{
    public partial class AboutUs : Form
    {
        public AboutUs()
        {
            InitializeComponent();
            textBox1.SelectionLength = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
