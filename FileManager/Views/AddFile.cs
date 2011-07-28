using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using EchoSystems.DIIA.Configuration.Controller;
using EchoSystems.DIIA.FileManager.Models;
using EchoSystems.DIIA.Configuration.Models;
using EchoSystems.Common.Enum;
using EchoSystems.Common.Global;
using EchoSystems.DIIA.Configuration.Views;

namespace EchoSystems.DIIA.FileManager.Views
{
    public partial class AddFile : Form
    {
        Configuration.Controller.Configuration loConfiguration;
        DataTable loSections;
        DataTable loNewspapers;
        ComboBox cboAuthors;
        ComboBox cboEditors;
        Document loDocument;

        public ClosingType ClosingType
        {
            get;
            set;
        }

        public string Authors
        {
            get;
            set;
        }

        public string Editors
        {
            get;
            set;
        }

        public string Section
        {
            get;
            set;
        }

        public AddFile()
        {
            InitializeComponent();
            loConfiguration = new Configuration.Controller.Configuration();
            cboAuthors = new ComboBox();
            cboAuthors.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEditors = new ComboBox();
            cboEditors.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void AddFile_Load(object sender, EventArgs e)
        {
            
            loNewspapers = loConfiguration.getNewspapers();
            cboNewspaper.DataSource = loNewspapers;
            cboNewspaper.ValueMember = "NewsPaperId";
            cboNewspaper.DisplayMember = "Name";

            loadSections();

            DataTable _authors =  loConfiguration.getEmployeesByType("Reporter");
            cboAuthors.DataSource = _authors;
            cboAuthors.ValueMember = "EmployeeId";
            cboAuthors.DisplayMember = "Name";
            gridAuthors.Cols["Name"].Editor = cboAuthors;
            
            DataTable _editors = loConfiguration.getEmployeesByType("Editor");
            cboEditors.DataSource = _editors;
            cboEditors.ValueMember = "EmployeeId";
            cboEditors.DisplayMember = "Initials";
            gridEditors.Cols["Initials"].Editor = cboEditors;
        }

        private void loadSections()
        {
            loSections = loConfiguration.getSections(cboNewspaper.SelectedValue.ToString());
            cboSection.DataSource = loSections;
            cboSection.ValueMember = "SectionId";
            cboSection.DisplayMember = "Section";
            try
            {
                cboSection.SelectedValue = loConfiguration.getUserDefaultSection();
            }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClosingType = Common.Enum.ClosingType.Cancelled;
            Close();
        }

        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            gridAuthors.Rows.Count++;
        }

        private void btnAddEditor_Click(object sender, EventArgs e)
        {
            gridEditors.Rows.Count++;
        }

        private void txtBrowse_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog _fileDialog = new OpenFileDialog();
            _fileDialog.Title = "Select a file";
            _fileDialog.Filter = "DOC(*.doc)|*.doc|TXT(*.txt)|*.txt|PDF(*.pdf)|*.pdf|RTF(*.rtf)|*.rtf";
            _fileDialog.ShowDialog(this);
            txtBrowse.Text = _fileDialog.FileName;

            txtTitle.Text = GlobalFunctions.parseTitleFromFile(txtBrowse.Text);
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            loDocument = new Document();
            loDocument.DocumentId = "";
            loDocument.Title = txtTitle.Text;
            loDocument.Path = @"" + txtBrowse.Text;
            loDocument.Newspaper = cboNewspaper.SelectedValue.ToString();
            loDocument.Doctype = Path.GetExtension(txtBrowse.Text);
            loDocument.Section = cboSection.SelectedValue.ToString();
            Section = cboSection.Text;
            loDocument.PublishedDate = dtpPublishedDate.Value.ToString("yyyy-MM-dd HH:mm:ss");

            string[] _docAuthors = new string[gridAuthors.Rows.Count - 1];
            int _authCount = 0;
            for (int i = 1; i < gridAuthors.Rows.Count; i++)
            {
                _docAuthors[_authCount] = gridAuthors.GetDataDisplay(i, "ID");
                Authors += gridAuthors.GetDataDisplay(i, "Name");
                _authCount++;
            }
            loDocument.DocAuthors = _docAuthors;

            string[] _docEditors = new string[gridEditors.Rows.Count - 1];
            int _edCount = 0;
            for (int i = 1; i < gridEditors.Rows.Count; i++)
            {
                _docEditors[_edCount] = gridEditors.GetDataDisplay(i, "ID");
                Editors += gridEditors.GetDataDisplay(i, "Initials");
                _edCount++;
            }
            loDocument.DocEditors = _docEditors;

            loDocument.DocTags = txtTags.Text;

            ClosingType = Common.Enum.ClosingType.Accepted;
            Close();
        }

        public Document getDocument()
        {
            return loDocument;
        }

        private void gridAuthors_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            gridAuthors.SetData(gridAuthors.Row, "ID", this.cboAuthors.SelectedValue.ToString());
        }

        private void gridEditors_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            gridEditors.SetData(gridEditors.Row, "ID", this.cboEditors.SelectedValue.ToString());
        }

        private void btnAddNewAuthor_Click(object sender, EventArgs e)
        {
            NewEmployee _newEmployee = new NewEmployee("btnAddNewAuthor");
            _newEmployee.ShowDialog(this);

            DataTable _authors = loConfiguration.getEmployeesByType("Reporter");
            cboAuthors.DataSource = _authors;
            cboAuthors.ValueMember = "EmployeeId";
            cboAuthors.DisplayMember = "Name";
            gridAuthors.Cols["Name"].Editor = cboAuthors;
        }

        private void btnAddNewEditor_Click(object sender, EventArgs e)
        {
            NewEmployee _newEmployee = new NewEmployee("btnAddNewEditor");
            _newEmployee.ShowDialog(this);

            DataTable _editors = loConfiguration.getEmployeesByType("Editor");
            cboEditors.DataSource = _editors;
            cboEditors.ValueMember = "EmployeeId";
            cboEditors.DisplayMember = "Initials";
            gridEditors.Cols["Initials"].Editor = cboEditors;
        }

        private void btnRemoveAuthor_Click(object sender, EventArgs e)
        {
            if (gridAuthors.Rows.Count > 1)
            {
                DialogResult _res = MessageBox.Show("Are you sure you want to remove " + gridAuthors.GetDataDisplay(gridAuthors.Row, 0) + "?",
                                        "Confirmation",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question);
                if (_res == System.Windows.Forms.DialogResult.Yes)
                {
                    gridAuthors.RemoveItem(gridAuthors.Row);
                }
            }
            else
            {
                MessageBox.Show("There is nothing to delete!", "List Empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnRemoveEditor_Click(object sender, EventArgs e)
        {
            if (gridEditors.Rows.Count > 1)
            {
                DialogResult _res = MessageBox.Show("Are you sure you want to remove " + gridEditors.GetDataDisplay(gridEditors.Row, 0) + "?",
                                                    "Confirmation",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);
                if (_res == System.Windows.Forms.DialogResult.Yes)
                {
                    gridEditors.RemoveItem(gridEditors.Row);
                }
            }
            else
            {
                MessageBox.Show("There is nothing to delete!", "List Empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboNewspaper_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadSections();
        }
    }
}
