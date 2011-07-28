using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EchoSystems.DIIA.Configuration.Data_Access_Objects;

namespace EchoSystems.DIIA.Configuration.Models
{
    public class Newspaper
    {
        NewspaperDAO loNewspaperDAO;

        public Newspaper()
        {
            loNewspaperDAO = new NewspaperDAO();
        }

        public DataTable get()
        {
            return loNewspaperDAO.get();
        }
    }
}
