using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using EchoSystems.DIIA.FileManager.Data_Access_Objects;
using System.Data;
using EchoSystems.Common.Global;
namespace EchoSystems.DIIA.FileManager.Models
{
    public class ImageBO
    {
        ImageDAO loImageDAO;

        public ImageBO()
        {
            loImageDAO = new ImageDAO();
        }

        public ImageBO(string pImageId) : this()
        {
            loadObject(get(pImageId));
            loadTags(pImageId);
        }

        private void loadObject(DataTable pImage)
        {
            if (pImage.Rows.Count > 0)
            {
                foreach (DataColumn _col in pImage.Columns)
                {
                    try
                    {
                        if (typeof(string) == this.GetType().GetProperty(_col.ColumnName).PropertyType)
                        {
                            this.GetType().GetProperty(_col.ColumnName).SetValue(this, pImage.Rows[0][_col.ColumnName].ToString(), null);
                        }
                        else if (typeof(DateTime) == this.GetType().GetProperty(_col.ColumnName).PropertyType)
                        {
                            this.GetType().GetProperty(_col.ColumnName).SetValue(this, DateTime.Parse(pImage.Rows[0][_col.ColumnName].ToString()), null);
                        }
                    }
                    catch { }
                }
            }
        }

        public void loadTags(string pImageId)
        {
            ImageTag _docTags = new ImageTag();
            DataTable _tags = _docTags.getTags(pImageId);
            string _dT = "";
            int _row = 0;
            foreach (DataRow _dRow in _tags.Rows)
            {
                _dT = _dT + _dRow["Tag"].ToString() + ",";
                _row++;
            }
            if (_dT.Length > 1)
                _dT = _dT.Substring(0, _dT.Length - 1);
            Tags = _dT;
        }

        public string ImageID
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

        public string Caption
        {
            get;
            set;
        }

        public string Location
        {
            get;
            set;
        }

        public string PhotographerId
        {
            get;
            set;
        }

        public DateTime DateTaken
        {
            get;
            set;
        }

        public string Tags
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public string insert(ref MySqlTransaction poMySqlTransaction)
        {
           return loImageDAO.insert(this, ref poMySqlTransaction);
        }

        public bool update()
        {
            return loImageDAO.update(this);
        }

        public DataTable search(string pTags, int pTagCount, int pOffset, int pLimit, DateTime pFrom, DateTime pTo)
        {
            return loImageDAO.search(pTags, pTagCount, pOffset, pLimit, pFrom, pTo);
        }

        public int count(string pTags, int pTagCount, DateTime pFrom, DateTime pTo)
        {
            return loImageDAO.count(pTags, pTagCount, pFrom, pTo);
        }

        public DataTable get(string pImageId)
        {
            return loImageDAO.get(pImageId);
        }

        public string[] getImageTagsArr()
        {
            return Tags.Split(',');
        }

        public bool delete()
        {
            return loImageDAO.delete(ImageID);
        }
    }
}
