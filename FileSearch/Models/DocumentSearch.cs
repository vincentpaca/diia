using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using EchoSystems.DIIA.Configuration.Controller;

namespace EchoSystems.DIIA.FileSearch.Models
{
    public class DocumentSearch : FlowLayoutPanel
    {
        Configuration.Controller.Configuration loConfig;

        public DocumentSearch()
        {
            this.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            loConfig = new Configuration.Controller.Configuration();
        }

        public string Title
        {
            get;
            set;
        }
        public string Preview
        {
            get;
            set;
        }
        public string NewsPaper
        {
            get;
            set;
        }

        public DateTime PublishedDate
        {
            get;
            set;
        }

        public string DocumentId
        {
            get;
            set;

        }

        public string Doctype
        {
            get;
            set;
        }

        public string Section
        {
            get;
            set;
        }

        public void populate()
        {
            Label _label = new Label();
            _label.Text = Title;
            _label.AutoSize = true;
            //_label.Size = new System.Drawing.Size(43, 13);
            _label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            this.Controls.Add(_label);
            //Label _newsPaper = new Label();
            //_newsPaper.Text = NewsPaper;
            //_newsPaper.Left = _label.Left;
            //this.Controls.Add(_newsPaper);
            Label _section = new Label();
            _section.Text = loConfig.getSectionName(Section);
            _section.Left = _label.Left;
            _section.Font = new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            this.Controls.Add(_section);
            Label _date = new Label();
            _date.Text = string.Format("{0:MMMM dd, yyyy}", PublishedDate);
            _date.Left = _label.Left;
            _date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Italic);
            this.Controls.Add(_date);
        }
    }
}
