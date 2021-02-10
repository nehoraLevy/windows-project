using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    static public class FactoryAndSingltoneDAL
    {
        static Idal dal = null;
        static public Idal GetIdal()
        {
            if(dal==null)
            {
                dal = new DAL_XML_imp();
            }
            return dal;
        }
    }
}
