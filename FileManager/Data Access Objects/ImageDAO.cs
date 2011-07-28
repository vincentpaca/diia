using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using EchoSystems.Common.Global;
using System.Data;
namespace EchoSystems.DIIA.FileManager.Data_Access_Objects
{
    public class ImageDAO
    {
        MySqlCommand loMySqlCommand;

        string lImageID;
        string lTitle;
        string lPath;
        string lCaption;
        string lLocation;
        string lPhotographerId;
        string lDateTaken;
       
        object loImage;

        private void loadAttributes()
        {
            lTitle = GlobalFunctions.addSlashes(loImage.GetType().GetProperty("Title").GetValue(loImage, null).ToString());
            lPath = loImage.GetType().GetProperty("Path").GetValue(loImage, null).ToString();
            lCaption = GlobalFunctions.addSlashes(loImage.GetType().GetProperty("Caption").GetValue(loImage, null).ToString());
            lLocation = GlobalFunctions.addSlashes(loImage.GetType().GetProperty("Location").GetValue(loImage, null).ToString());
            lPhotographerId = loImage.GetType().GetProperty("PhotographerId").GetValue(loImage, null).ToString();
            lDateTaken = DateTime.Parse(loImage.GetType().GetProperty("DateTaken").GetValue(loImage, null).ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                lImageID = loImage.GetType().GetProperty("ImageID").GetValue(loImage, null).ToString();
            }
            catch { }
        }

        public string insert(object poImage, ref MySqlTransaction poMySqlTransaction)
        {
            try
            {
                loImage = poImage;
                loadAttributes();

                string _sql = "call spInsertImage('" + lTitle + "','" + lPath + "','" + lCaption + "','" + lLocation + "','"
                    + lPhotographerId + "','" + lDateTaken + "','" + GlobalVariables.goLoggedInUser + "')";

                loMySqlCommand = new MySqlCommand(_sql, GlobalVariables.goMySqlConnection);
                loMySqlCommand.Transaction = poMySqlTransaction;
                return loMySqlCommand.ExecuteScalar().ToString();
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

        public DataTable search(string pTags, int pTagCount, int pOffset, int pLimit, DateTime pFrom, DateTime pTo)
        {
            try
            {
                DataTable _dt = new DataTable();
                MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetImages(\"" + pTags + "\"," + pTagCount + "," + pOffset + "," + pLimit + ",'" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", pFrom) + "','" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", pTo) + "')", GlobalVariables.goMySqlConnection);
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

        public int count(string pTags, int pTagCount, DateTime pFrom, DateTime pTo)
        {
            try
            {
                int _count = 0;
                MySqlCommand _adapter = new MySqlCommand("call spCountImages(\"" + pTags + "\"," + pTagCount + ",'" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", pFrom) + "','" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", pTo) + "')", GlobalVariables.goMySqlConnection);
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

        public DataTable get(string pImageId)
        {
            try
            {
                DataTable _dt = new DataTable();
                MySqlDataAdapter _adapter = new MySqlDataAdapter("call spGetImage('" + pImageId + "')", GlobalVariables.goMySqlConnection);
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

        public bool update(object poImage)
        {
            try
            {
                loImage = poImage;
                loadAttributes();
                MySqlCommand _update = new MySqlCommand("call spUpdateImage('" + lImageID + "','" + lPhotographerId + "','" + lLocation + "','" + lCaption + "','" + lDateTaken + "','" + GlobalVariables.goLoggedInUser + "')", GlobalVariables.goMySqlConnection);
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

        public bool delete(string pImageID)
        {
            try
            {
                MySqlCommand _delete = new MySqlCommand("call spDeleteImage('" + pImageID + "')", GlobalVariables.goMySqlConnection);
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
