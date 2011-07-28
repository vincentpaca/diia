using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using EchoSystems.Common.Global;
using System.Data;

namespace EchoSystems.DIIA.FileManager.Data_Access_Objects
{
    public class DocumentDAO
    {
        MySqlCommand loMySqlCommand;

        string lTitle;
        string lPath;
        string lNewspaper;
        string lDocType;
        string lSection;
        string lPublishedDate;
        string lDocumentId;
        string lPreview;
        object loDocument;

        private void loadAttributes()
        {
            lTitle = GlobalFunctions.addSlashes(loDocument.GetType().GetProperty("Title").GetValue(loDocument, null).ToString());
            lPath = GlobalFunctions.addSlashes(loDocument.GetType().GetProperty("Path").GetValue(loDocument, null).ToString());
            lNewspaper = loDocument.GetType().GetProperty("Newspaper").GetValue(loDocument, null).ToString();
            lDocType = loDocument.GetType().GetProperty("Doctype").GetValue(loDocument, null).ToString();
            lSection = loDocument.GetType().GetProperty("Section").GetValue(loDocument, null).ToString();
            lPublishedDate = loDocument.GetType().GetProperty("PublishedDate").GetValue(loDocument, null).ToString();
            lPreview = loDocument.GetType().GetProperty("Preview").GetValue(loDocument, null).ToString();
            try 
            {
                lDocumentId = loDocument.GetType().GetProperty("DocumentId").GetValue(loDocument, null).ToString();
            }
            catch { }
        }

        public string insert(object poDocument, ref MySqlTransaction poMySqlTransaction)
        {
            try
            {
                loDocument = poDocument;
                loadAttributes();
                string _docid = "";
                string _sql = @"call spInsertDocument('" + lTitle + "','" + lPath + "','" + lNewspaper + "','" + lDocType + "','" + lSection + "','" + lPublishedDate + "','" + GlobalVariables.goLoggedInUser + "','" + lPreview + "')";
                loMySqlCommand = new MySqlCommand(_sql, GlobalVariables.goMySqlConnection);
                loMySqlCommand.Transaction = poMySqlTransaction;
                _docid = loMySqlCommand.ExecuteScalar().ToString();
                return _docid;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool update(object poDocument, ref MySqlTransaction pTrans)
        {
            try
            {
                loDocument = poDocument;
                loadAttributes();
                MySqlCommand _update = new MySqlCommand("call spUpdateDocument('" + lDocumentId + "','" + lNewspaper + "','" + lSection + "','" + lPublishedDate + "','" + GlobalVariables.goLoggedInUser + "')", GlobalVariables.goMySqlConnection);
                try
                {
                    int _rowsAffected = _update.ExecuteNonQuery();
                    if (_rowsAffected > 0)
                        return true;
                    return false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    _update.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable search(string pTags, string pNewsPaper, string pDocType, string pSection,int pTagCount, int pOffset, int pLimit, DateTime pFrom, DateTime pTo)
        {
            try
            {
                DataTable _dt = new DataTable();
                MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetDocuments(\"" + pTags + "\",'" + pNewsPaper + "',\"" + pDocType + "\",'" + pSection + "'," + pTagCount + "," + pOffset + "," + pLimit + ",'" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", pFrom) + "','" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", pTo) + "')", GlobalVariables.goMySqlConnection);
                try
                {
                    _adapter.Fill(_dt);
                    return _dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    _adapter.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int count(string pTags, string pNewsPaper, string pDocType, string pSection, int pTagCount, DateTime pFrom, DateTime pTo)
        {
            try
            {
                int _count = 0;
                MySqlCommand _adapter = new MySqlCommand("call spCountDocuments(\"" + pTags + "\",'" + pNewsPaper + "',\"" + pDocType + "\",'" + pSection + "'," + pTagCount + ",'" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", pFrom) + "','" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", pTo) + "')", GlobalVariables.goMySqlConnection);
                try
                {
                    try
                    {
                        _count = int.Parse(_adapter.ExecuteScalar().ToString());
                    }
                    catch
                    {
                        _count = 0;
                    }
                    return _count;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    _adapter.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get(string pDocumentId)
        {
            try
            {
                DataTable _dt = new DataTable();
                MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetDocument('" + pDocumentId + "')", GlobalVariables.goMySqlConnection);
                try
                {
                    _adapter.Fill(_dt);
                    return _dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    _adapter.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool delete(string pDocumentId)
        {
            try
            {
                MySqlCommand _delete = new MySqlCommand("call spDeleteDocument('" + pDocumentId + "')", GlobalVariables.goMySqlConnection);
                try
                {
                    int _rowsAffected = _delete.ExecuteNonQuery();
                    if (_rowsAffected > 0)
                        return true;
                    return false;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    _delete.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
