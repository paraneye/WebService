using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Element.Shared.Common
{
    public class ConnStrHelper
    {
        public static string getDbConnString()
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["RevealDbConn"].ConnectionString;
            return connStr;
        }
    }
}
