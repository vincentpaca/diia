using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EchoSystems.DIIA.Configuration.Models;
using EchoSystems.DIIA.FileManager.Data_Access_Objects;
using System.Data;
namespace EchoSystems.DIIA.FileManager.Models
{
    public class DocAuthor : Employee
    {
        DocAuthorDAO loDocAuthorDAO;

        public DocAuthor()
        {
            loDocAuthorDAO = new DocAuthorDAO();
        }

        public string DocumentId
        {
            get;
            set;
        }

        public string AuthorId
        {
            get;
            set;
        }

        public void insert(ref MySql.Data.MySqlClient.MySqlTransaction poMySqlTransaction)
        {
            loDocAuthorDAO.insert(this, ref poMySqlTransaction);
        }

        public DataTable getAuthors(string pDocumentId)
        {
            return loDocAuthorDAO.getAuthors(pDocumentId);
        }

        public bool delete()
        {
            return loDocAuthorDAO.delete(AuthorId, DocumentId);
        }
    }
}
