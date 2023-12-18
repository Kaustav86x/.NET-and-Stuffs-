using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataMapping
{
    public class DapperORM : IDapperORM
    {
        private readonly IConfiguration _configuration;
        public string ConnectionString { get; set; }
        public string ProviderName { get; }

        public DapperORM(IConfiguration configuration)
        {
            _configuration = configuration;
            // Dapper setting
            // _configuration going into appsetting.json
            ConnectionString = _configuration.GetConnectionString("NTierMVCDBConnection");
            ProviderName = "System.Data.SqlClient";
        }
        // dapper connection string
        public IDbConnection GetDapperContextHelper() 
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
