using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Utility
{
    public static class ConnectionString
    {
        private static string cName = "Server=DESKTOP-5VOJSQT; Database=ADOCrud; Trusted_Connection=True; MultipleActiveResultSets=True;";   
        public static string CName { get { return cName; } }
    }
}
