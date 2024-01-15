using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piwnica
{
    public static class ConnectionManager
    {

        public static string LoadConnectionString(string id = "BasementDB")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        /*
         * 
         * Total random stuff
         */

    }
}
