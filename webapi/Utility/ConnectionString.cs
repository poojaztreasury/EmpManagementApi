using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Utility
{
    public static class ConnectionString
    {
        private static string cName = "Data Source=.\\sqlexpress;Initial Catalog=Employee101;Integrated Security=True";
        public static string CName
        {
            get => cName;
        }
    }
}
