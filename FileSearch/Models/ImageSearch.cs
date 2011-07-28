using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace EchoSystems.DIIA.FileSearch.Models
{
    public class ImageSearch : PictureBox
    {
        public string Caption
        {
            get;
            set;
        }

        public string ImageId
        {
            get;
            set;
        }
    }
}
