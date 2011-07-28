using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EchoSystems.DIIA.FileManager.Data_Access_Objects;
using System.Data;
namespace EchoSystems.DIIA.FileManager.Models
{
    public class ImageTag
    {
        ImageTagDAO loImageTagDAO;

        public ImageTag()
        {
            loImageTagDAO = new ImageTagDAO();
        }

        public string ImageId
        {
            get;
            set;
        }

        public string Tag
        {
            get;
            set;
        }

        public void insert(ref MySql.Data.MySqlClient.MySqlTransaction poMySqlTransaction)
        {
            loImageTagDAO.insert(this, ref poMySqlTransaction);
        }

        public void update(ref MySql.Data.MySqlClient.MySqlTransaction poMySqlTransaction)
        {
            loImageTagDAO.update(this, ref poMySqlTransaction);
        }

        public DataTable getTags(string pImageId)
        {
            return loImageTagDAO.getTags(pImageId);
        }

        public bool delete()
        {
            return loImageTagDAO.delete(this);
        }
    }
}
