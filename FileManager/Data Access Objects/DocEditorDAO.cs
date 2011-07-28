using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EchoSystems.Common.Global;

namespace EchoSystems.DIIA.FileManager.Data_Access_Objects
{
    public class DocEditorDAO
    {
        MySqlCommand loMySqlCommand;

        string lDocumentId;
        string lEditorId;

        object loDocEditor;

        private void loadAttributes()
        {
            lDocumentId = loDocEditor.GetType().GetProperty("DocumentId").GetValue(loDocEditor, null).ToString();
            lEditorId = loDocEditor.GetType().GetProperty("EditorId").GetValue(loDocEditor, null).ToString();
        }

        public void insert(object poDocEditor, ref MySqlTransaction poMySqlTransaction)
        {
            try
            {
                loDocEditor = poDocEditor;
                loadAttributes();
                string _sql = "call spInsertDocEditor('" + lDocumentId + "','" + lEditorId + "','" + GlobalVariables.goLoggedInUser + "')";
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

        public DataTable getEditors(string pDocumentId)
        {
            try
            {
                DataTable _dt = new DataTable();
                MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetDocEditors('" + pDocumentId + "')", GlobalVariables.goMySqlConnection);
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
                MySqlCommand _delete = new MySqlCommand("call spDeleteDocEditor('" + pId + "','" + pDocumentId + "','" + GlobalVariables.goLoggedInUser + "')", GlobalVariables.goMySqlConnection);
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
