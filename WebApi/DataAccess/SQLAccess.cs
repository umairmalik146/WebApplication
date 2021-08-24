using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Helpers
{
    public class SQLAccess
    {
        public static SqlConnection con = new SqlConnection();
        public SQLAccess()
        {

        }
        public static string GiveConnectionString()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            return configuration.GetConnectionString("ConnectionString");

        }
    }
}