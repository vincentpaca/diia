using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using EchoSystems.DIIA.Configuration.Models;
using EchoSystems.DIIA.FileManager.Models;
using EchoSystems.Common.Global;
using MySql.Data.MySqlClient;
namespace EchoSystems.DIIA.FileSearch.Controller
{
    public class FileSearch
    {
        #region "SEARCHUI"
        public DataTable getNewsPapers()
        {
            Newspaper _newspapers = new Newspaper();
            return _newspapers.get();
        }

        public DataTable getDocTypes(string pType)
        {
            DataTable _dt = new DataTable();
            DocType _doctypes = new DocType();
            _dt = _doctypes.get();
            if (pType == "search")
            {
                DataRow _dRow = _dt.NewRow();
                _dRow["DocType"] = "raw";
                _dt.Rows.Add(_dRow);
                _dRow = _dt.NewRow();
                _dRow["DocType"] = "ALL";
                _dt.Rows.Add(_dRow);
            }
            return _dt;
        }

        public DataTable getSections(string pType, string pNewspaper)
        {
            DataTable _dt = new DataTable();
            Section _section = new Section();
            _dt = _section.get(pNewspaper);
            if (pType == "search")
            {
                DataRow _dRow = _dt.NewRow();
                _dRow["SectionId"] = "";
                _dRow["Section"] = "ALL";
                _dt.Rows.Add(_dRow);
            }
            return _dt;
        }

        public DataTable searchDocument(string pNewsPaper, string pDocType, string pSection,string pSearchTag, DateTime pFrom, DateTime pTo, int pLimit, int pOffset)
        {
            Document _document = new Document();
            if (pDocType == "raw")
            {
                pDocType = ".doc .docx .txt .rtf";
            }
            else if (pDocType == "ALL")
            {
                pDocType = "";
            }
            int _tagCount = 0;
            string _strTags = "";
            if (pSearchTag != "")
            {
                string[] _artags = GlobalFunctions.addSlashes(pSearchTag).Split(' ');
                IList<string> _tags = GlobalFunctions.removeRedundancy(_artags);

                _tagCount = _tags.Count;
                foreach (string _str in _tags)
                {
                    _strTags = _strTags + "'" + _str + "',";
                }
                _strTags = _strTags.Substring(0, _strTags.Length - 1);
            }
            return _document.search(_strTags, pNewsPaper, prepareDoctype(pDocType), pSection, _tagCount, pOffset, pLimit, pFrom, pTo);
        }

        public int countDocuments(string pNewsPaper, string pDocType, string pSection, string pSearchTag, DateTime pFrom, DateTime pTo)
        {
            Document _document = new Document();
            if (pDocType == "raw")
            {
                pDocType = ".doc .docx .txt .rtf";
            }
            else if (pDocType == "ALL")
            {
                pDocType = "";
            }
            int _tagCount = 0;
            string _strTags = "";
            if (pSearchTag != "")
            {
                string[] _artags = GlobalFunctions.addSlashes(pSearchTag).Split(' ');
                IList<string> _tags = GlobalFunctions.removeRedundancy(_artags);

                _tagCount = _tags.Count;
                foreach (string _str in _tags)
                {
                    _strTags = _strTags + "'" + _str + "',";
                }
                _strTags = _strTags.Substring(0, _strTags.Length - 1);
            }
            return _document.count(_strTags, pNewsPaper, prepareDoctype(pDocType), pSection, _tagCount, pFrom, pTo);
        }

        private string prepareDoctype(string pDoctype)
        {
            if (pDoctype.Length > 0)
            {
                string _str = "";
                foreach (string _doctype in pDoctype.Split(' '))
                {
                    _str = _str + "'" + _doctype + "',";
                }
                _str = _str.Substring(0, _str.Length - 1);
                return _str;
            }
            else
            {
                return "";
            }
            
        }

        public Document getDocument(string pDocumentId)
        {
            Document _doc = new Document(pDocumentId);
            return _doc;
        }


        public DataTable getEmployeesByType(string pEmployeeType)
        {
            EchoSystems.DIIA.Configuration.Controller.Configuration _configuration = new EchoSystems.DIIA.Configuration.Controller.Configuration();
            return _configuration.getEmployeesByType(pEmployeeType);
        }

        public bool deleteDocument(string pDocumentId)
        {
            Document _oDocument = new Document(pDocumentId);
            string _path = _oDocument.DocumentId + _oDocument.Doctype;
            bool _del = _oDocument.delete();
            if (_del)
            {
                try
                {
                    File.Move(GlobalVariables.goFileServer + @"\" + _path, GlobalVariables.goRecycleBin + @"\" + _path);
                }
                catch { }
            }
            return _del;
        }

        public bool deleteImage(string pImageId)
        {
            ImageBO _oImage = new ImageBO(pImageId);
            string[] _type = _oImage.Path.Split('.');
            string _path = _oImage.ImageID + "." + _type[_type.Length - 1];
            bool _del = _oImage.delete();
            if (_del)
            {
                try
                {
                    File.Move(GlobalVariables.goImageServer + @"\" + _path, GlobalVariables.goRecycleBin + @"\" + _path);
                }
                catch { }
            }
            return _del;
        }

        #endregion

        #region "VIEWFILE"
        public bool saveDocument(Document pDocument)
        {

            MySqlTransaction _trans = GlobalVariables.goMySqlConnection.BeginTransaction();
            try
            {
                pDocument.update(ref _trans);
                _trans.Commit();
            }
            catch (Exception ex)
            {
                _trans.Rollback();
                throw ex;
            }
            finally
            {
                _trans.Dispose();
            }
            return true;
        }

        public bool saveAuthors(string pAuthors, string pDocumentId)
        {
            DocAuthor loDocAuthor = new DocAuthor();
            string[] _authors = pAuthors.Split(',');
            MySqlTransaction loMySqlTransaction = GlobalVariables.goMySqlConnection.BeginTransaction();
            try
            {
                foreach (string _str in _authors)
                {
                    loDocAuthor.AuthorId = _str;
                    loDocAuthor.DocumentId = pDocumentId;
                    loDocAuthor.insert(ref loMySqlTransaction);
                }
                loMySqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                loMySqlTransaction.Rollback();
                throw ex;
            }
            finally
            {
                loMySqlTransaction.Dispose();
            }
            return true;
        }

        public bool saveEditors(string pEditors, string pDocumentId)
        {
            DocEditor loDocEditor = new DocEditor();
            string[] _editors = pEditors.Split(',');
            MySqlTransaction loMySqlTransaction = GlobalVariables.goMySqlConnection.BeginTransaction();
            try
            {
                foreach (string _str in _editors)
                {
                    loDocEditor.EditorId = _str;
                    loDocEditor.DocumentId = pDocumentId;
                    loDocEditor.insert(ref loMySqlTransaction);
                }
                loMySqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                loMySqlTransaction.Rollback();
                throw ex;
            }
            finally
            {
                loMySqlTransaction.Dispose();
            }
            return true;
        }

        public bool saveTags(string pTags, string pDocumentId)
        {
            DocTag loDocTag = new DocTag();
            string[] _tags = pTags.Split(',');
            MySqlTransaction loMySqlTransaction = GlobalVariables.goMySqlConnection.BeginTransaction();
            try
            {
                foreach (string _str in _tags)
                {
                    loDocTag.Tag = _str;
                    loDocTag.DocumentId = pDocumentId;
                    loDocTag.insert(ref loMySqlTransaction);
                }
                loMySqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                loMySqlTransaction.Rollback();
                throw ex;
            }
            finally
            {
                loMySqlTransaction.Dispose();
            }
            return true;
        }

        public bool deleteAuthor(string pId, string pDocumentId)
        {
            DocAuthor loDocAuthor = new DocAuthor();
            loDocAuthor.AuthorId = pId;
            loDocAuthor.DocumentId = pDocumentId;
            return loDocAuthor.delete();
        }

        public bool deleteEditor(string pId, string pDocumentId)
        {
            DocEditor loDocEditor = new DocEditor();
            loDocEditor.EditorId = pId;
            loDocEditor.DocumentId = pDocumentId;
            return loDocEditor.delete();
        }

        public bool deleteTag(string pId, string pDocumentId)
        {
            DocTag loDocTag = new DocTag();
            loDocTag.Tag = pId;
            loDocTag.DocumentId = pDocumentId;
            return loDocTag.delete();
        }

        public DataTable searchImage(string pSearchTag, DateTime pFrom, DateTime pTo, int pLimit, int pOffset)
        {
            ImageBO _image = new ImageBO();
            int _tagCount = 0;
            string _strTags = "";
            if (pSearchTag != "")
            {
                string[] _artags = GlobalFunctions.addSlashes(pSearchTag).Split(' ');
                IList<string> _tags = GlobalFunctions.removeRedundancy(_artags);

                _tagCount = _tags.Count;
                foreach (string _str in _tags)
                {
                    _strTags = _strTags + "'" + _str + "',";
                }
                _strTags = _strTags.Substring(0, _strTags.Length - 1);
            }
            return _image.search(_strTags, _tagCount, pOffset, pLimit, pFrom, pTo);
        }

        public int countImages(string pSearchTag, DateTime pFrom, DateTime pTo)
        {
            ImageBO _image = new ImageBO();
            int _tagCount = 0;
            string _strTags = "";
            if (pSearchTag != "")
            {
                string[] _artags = GlobalFunctions.addSlashes(pSearchTag).Split(' ');
                IList<string> _tags = GlobalFunctions.removeRedundancy(_artags);

                _tagCount = _tags.Count;
                foreach (string _str in _tags)
                {
                    _strTags = _strTags + "'" + _str + "',";
                }
                _strTags = _strTags.Substring(0, _strTags.Length - 1);
            }
            return _image.count(_strTags, _tagCount, pFrom, pTo);
        }
        #endregion
        #region "VIEWIMAGE"
        public ImageBO getImage(string pImageId)
        {
            ImageBO _image = new ImageBO(pImageId);
            return _image;
        }

        public bool saveImage(ImageBO poImage)
        {
            return poImage.update();
        }

        public bool deleteImageTag(string pTag, string pImageId)
        {
            ImageTag loImageTag = new ImageTag();
            loImageTag.Tag = pTag;
            loImageTag.ImageId = pImageId;
            return loImageTag.delete();
        }

        public bool saveImageTags(string pTags, string pImageId)
        {
            ImageTag loImageTag = new ImageTag();
            string[] _tags = pTags.Split(',');
            MySqlTransaction loMySqlTransaction = GlobalVariables.goMySqlConnection.BeginTransaction();
            try
            {
                foreach (string _str in _tags)
                {
                    loImageTag.Tag = _str;
                    loImageTag.ImageId = pImageId;
                    loImageTag.insert(ref loMySqlTransaction);
                }
                loMySqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                loMySqlTransaction.Rollback();
                throw ex;
            }
            finally
            {
                loMySqlTransaction.Dispose();
            }
            return true;
        }

        #endregion
    }
}
