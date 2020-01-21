using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace netCoreAPI.Structure.Contexts
{
    public partial class MainContext
    {
        static IConfigurationRoot dbConfiguration;
        static string dbConnectionString;
        public readonly SqlConnection dbConnection;

        public MainContext()
        {
            dbConnectionString = dbConfiguration.GetSection("ConnectionStrings:VerifastDB").Value;
            dbConnection = new SqlConnection(dbConnectionString);
        }
    }
}
