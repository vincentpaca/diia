using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EchoSystems.DIIA.FileManager.Data_Access_Objects;

namespace EchoSystems.DIIA.FileManager.Models
{
    public class Document
    {
        DocumentDAO loDocumentDAO;

        public Document()
        {
            loDocumentDAO = new DocumentDAO();
        }

        public Document(string pDocument) : this()
        {
            loadObject(get(pDocument));
            loadAuthors(pDocument);
            loadEditors(pDocument);
            loadTags(pDocument);
        }

        public void loadObject(DataTable _document)
        {
            if (_document.Rows.Count > 0)
            {
                foreach (DataColumn _col in _document.Columns)
                {
                    try
                    {
                        this.GetType().GetProperty(_col.ColumnName).SetValue(this, _document.Rows[0][_col.ColumnName].ToString(), null);
                    }
                    catch { }
                }
            }
        }

        public void loadAuthors(string pDocumentId)
        {
            DocAuthor _docAuthors = new DocAuthor();
            DataTable _authors = _docAuthors.getAuthors(pDocumentId);
            string[] _dA = new string[_authors.Rows.Count];
            int _row = 0;
            foreach (DataRow _dRow in _authors.Rows)
            {
                _dA[_row] = _dRow["AuthorId"].ToString();
                _row++;
            }
            DocAuthors = _dA;
        }

        public void loadEditors(string pDocumentId)
        {
            DocEditor _docEditors = new DocEditor();
            DataTable _editors = _docEditors.getEditors(pDocumentId);
            string[] _dE = new string[_editors.Rows.Count];
            int _row = 0;
            foreach (DataRow _dRow in _editors.Rows)
            {
                _dE[_row] = _dRow["EditorId"].ToString();
                _row++;
            }
            DocEditors = _dE;
        }

        public void loadTags(string pDocumentId)
        {
            DocTag _docTags = new DocTag();
            DataTable _tags = _docTags.getTags(pDocumentId);
            string _dT = "";
            int _row = 0;
            foreach (DataRow _dRow in _tags.Rows)
            {
                _dT = _dT + _dRow["Tag"].ToString() + ",";
                _row++;
            }
            if(_dT.Length > 1)
                _dT = _dT.Substring(0, _dT.Length - 1);
            DocTags = _dT;
        }

        public string DocumentId
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;    
        }

        public string Path
        {
            get;
            set;
        }

        public string Newspaper
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

        public string PublishedDate
        {
            get;
            set;
        }

        public string[] DocAuthors
        {
            get;
            set;
        }

        public string[] DocEditors
        {
            get;
            set;
        }

        public string DocTags
        {
            get;
            set;
        }

        public string Preview
        {
            get;
            set;
        }

        public string[] getDocTagsArr()
        {
            return DocTags.Split(',');
        }

        public string insert(ref MySql.Data.MySqlClient.MySqlTransaction poMySqlTransaction)
        {
            return loDocumentDAO.insert(this, ref poMySqlTransaction);
        }

        public bool update(ref MySql.Data.MySqlClient.MySqlTransaction pTrans)
        {
            return loDocumentDAO.update(this, ref pTrans);
        }

        public DataTable search(string pTags, string pNewsPaper, string pDocType, string pSection, int pTagCount, int pOffset, int pLimit, DateTime pFrom , DateTime pTo)
        {
            return loDocumentDAO.search(pTags, pNewsPaper, pDocType, pSection, pTagCount, pOffset, pLimit, pFrom, pTo);
        }

        public int count(string pTags, string pNewsPaper, string pDocType, string pSection, int pTagCount, DateTime pFrom, DateTime pTo)
        {
            return loDocumentDAO.count(pTags, pNewsPaper, pDocType, pSection, pTagCount, pFrom, pTo);
        }

        public DataTable get(string pDocumentId)
        {
            return loDocumentDAO.get(pDocumentId);
        }

        public bool delete()
        {
            return loDocumentDAO.delete(DocumentId);
        }
    }
}
