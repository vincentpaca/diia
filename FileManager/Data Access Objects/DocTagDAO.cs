using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EchoSystems.Common.Global;
namespace EchoSystems.DIIA.FileManager.Data_Access_Objects
{
    public class DocTagDAO
    {
        MySqlCommand loMySqlCommand;

        string lDocTag;
        string lDocumentId;

        object loDocTag;

        private void loadAttributes()
        {
            lDocTag = loDocTag.GetType().GetProperty("Tag").GetValue(loDocTag, null).ToString();
            lDocumentId = loDocTag.GetType().GetProperty("DocumentId").GetValue(loDocTag, null).ToString();
        }

        public void insert(object poDocTag, ref MySqlTransaction poMySqlTransaction)
        {
            try
            {
                loDocTag = poDocTag;
                loadAttributes();
                string _sql = "call spInsertDocTag('" + lDocumentId + "','" + lDocTag + "','" + GlobalVariables.goLoggedInUser + "')";
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

        public void update(object poDocTag, ref MySqlTransaction poMySqlTransaction)
        {
            try
            {
                loDocTag = poDocTag;
                loadAttributes();
                string _sql = "call spUpdateDocTag('" + lDocumentId + "','" + lDocTag + "')";
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

        public DataTable getTags(string pDocumentId)
        {
            try
            {
                DataTable _dt = new DataTable();
                MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetDocTags('" + pDocumentId + "')", GlobalVariables.goMySqlConnection);
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

        public bool delete(object poDocTag)
        {
            try
            {
                loDocTag = poDocTag;
                loadAttributes();
                MySqlCommand _delete = new MySqlCommand("call spDeleteDocTag('" + lDocTag + "','" + lDocumentId + "','" + GlobalVariables.goLoggedInUser + "')", GlobalVariables.goMySqlConnection);
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
