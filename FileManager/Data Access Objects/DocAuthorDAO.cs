using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using EchoSystems.Common.Global;
using System.Data;
namespace EchoSystems.DIIA.FileManager.Data_Access_Objects
{
    public class DocAuthorDAO
    {
        MySqlCommand loMySqlCommand;

        string lDocumentId;
        string lAuthorId;

        object loDocAuthor;

        private void loadAttributes()
        {
            lDocumentId = loDocAuthor.GetType().GetProperty("DocumentId").GetValue(loDocAuthor, null).ToString();
            lAuthorId = loDocAuthor.GetType().GetProperty("AuthorId").GetValue(loDocAuthor, null).ToString();
        }

        public void insert(object poDocAuthor, ref MySqlTransaction poMySqlTransaction)
        {
            try
            {
                loDocAuthor = poDocAuthor;
                loadAttributes();
                string _sql = "call spInsertDocAuthor('" + lDocumentId + "','" + lAuthorId + "','" + GlobalVariables.goLoggedInUser + "')";
                loMySqlCommand = new MySqlCommand(_sql, GlobalVariables.goMySqlConnection);
                loMySqlCommand.Transaction = poMySqlTransaction;
                loMySqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                loMySqlCommand.Dispose();
            }
        }

        public DataTable getAuthors(string pDocumentId)
        {
            try
            {
                DataTable _dt = new DataTable();
                MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetDocAuthors('" + pDocumentId + "')", GlobalVariables.goMySqlConnection);
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

        public bool delete(string pId, string pDocumentId)
        {
            try
            {
                MySqlCommand _delete = new MySqlCommand("call spDeleteDocAuthor('" + pId + "','" + pDocumentId + "','" + GlobalVariables.goLoggedInUser + "')", GlobalVariables.goMySqlConnection);
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
