using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EchoSystems.DIIA.FileManager.Data_Access_Objects;
namespace EchoSystems.DIIA.FileManager.Models
{
    public class DocType
    {
        DocTypeDAO loDocTypeDao;
        
        public DocType()
        {
            loDocTypeDao = new DocTypeDAO();
        }

        public DataTable get()
        {
            return loDocTypeDao.get();
        }
                
    }
}
