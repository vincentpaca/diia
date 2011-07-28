using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EchoSystems.DIIA.Configuration.Models;
using EchoSystems.DIIA.FileManager.Data_Access_Objects;
using MySql.Data.MySqlClient;
using System.Data;
namespace EchoSystems.DIIA.FileManager.Models
{
    public class DocEditor : Employee
    {

        DocEditorDAO loDocEditorDAO;

        public DocEditor()
        {
            loDocEditorDAO = new DocEditorDAO();
        }

        public string DocumentId
        {
            get;
            set;
        }

        public string EditorId
        {
            get;
            set;
        }

        public void insert(ref MySqlTransaction poMySqlTransaction)
        {
            loDocEditorDAO.insert(this, ref poMySqlTransaction);
        }

        public DataTable getEditors(string pDocumentId)
        {
            return loDocEditorDAO.getEditors(pDocumentId);
        }

        public bool delete()
        {
            return loDocEditorDAO.delete(EditorId, DocumentId);
        }
    }
}
