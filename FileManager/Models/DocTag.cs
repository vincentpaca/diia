using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using EchoSystems.DIIA.FileManager.Data_Access_Objects;
using System.Data;
namespace EchoSystems.DIIA.FileManager.Models
{
    public class DocTag
    {
        DocTagDAO loDocTagDAO;

        public DocTag()
        {
            loDocTagDAO = new DocTagDAO();
        }

        public string DocumentId
        {
            get;
            set;
        }

        public string Tag
        {
            get;
            set;
        }

        public void insert(ref MySqlTransaction poMySqlTransaction)
        {
            loDocTagDAO.insert(this, ref poMySqlTransaction);
        }

        public void update(ref MySqlTransaction poMySqlTransaction)
        {
            loDocTagDAO.update(this, ref poMySqlTransaction);
        }

        public DataTable getTags(string pDocumentId)
        {
            return loDocTagDAO.getTags(pDocumentId);
        }

        public bool delete()
        {
            return loDocTagDAO.delete(this);
        }
    }
}
