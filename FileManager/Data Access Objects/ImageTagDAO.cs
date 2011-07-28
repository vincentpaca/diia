using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using EchoSystems.Common.Global;
using System.Data;
namespace EchoSystems.DIIA.FileManager.Data_Access_Objects
{
    public class ImageTagDAO
    {
        MySqlCommand loMySqlCommand;

        string lImageId;
        string lTag;

        object loImageTag;

        private void loadAttributes()
        {
            lImageId = loImageTag.GetType().GetProperty("ImageId").GetValue(loImageTag, null).ToString();
            lTag = GlobalFunctions.addSlashes(loImageTag.GetType().GetProperty("Tag").GetValue(loImageTag, null).ToString());
        }

        public void insert(object poImageTag, ref MySqlTransaction poMySqlTransaction)
        {
            try
            {
                loImageTag = poImageTag;
                loadAttributes();

                string _sql = "call spInsertImageTag('" + lImageId + "','" + lTag + "','" + GlobalVariables.goLoggedInUser + "')";
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

        public void update(object poImageTag, ref MySqlTransaction poMySqlTransaction)
        {
            try
            {
                loImageTag = poImageTag;
                loadAttributes();

                string _sql = "call spUpdateImageTag('" + lImageId + "','" + lTag + "','" + GlobalVariables.goLoggedInUser + "')";
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

        public DataTable getTags(string pImageId)
        {
            try
            {
                DataTable _dt = new DataTable();
                MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetImageTags('" + pImageId + "')", GlobalVariables.goMySqlConnection);
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

        public bool delete(object poImageTag)
        {
            try
            {
                loImageTag = poImageTag;
                loadAttributes();
                MySqlCommand _delete = new MySqlCommand("call spDeleteImageTag('" + lTag + "','" + lImageId + "','" + GlobalVariables.goLoggedInUser + "')", GlobalVariables.goMySqlConnection);
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
