using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EchoSystems.DIIA.Configuration.Data_Access_Objects;

namespace EchoSystems.DIIA.Configuration.Models
{
    public class Section
    {
        SectionDAO loSectionDAO;

        public Section()
        {
            loSectionDAO = new SectionDAO();
        }

        public DataTable get()
        {
            return loSectionDAO.get("");
        }

        public DataTable get(string pNewspaperId)
        {
            return loSectionDAO.get(pNewspaperId);
        }

        public string getSectionName(string pSection)
        {
            return loSectionDAO.getSectionName(pSection);
        }

        public string getUserDefaultSection()
        {
            return loSectionDAO.getUserDefaultSection();
        }
    }
}
