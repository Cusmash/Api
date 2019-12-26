using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MonApiGuate.Services
{
    public class PingSql
    {
        public bool IsServerConnected(bool throwExceptionOnError = false)
        {
            string connectionString = null;
            connectionString = "Server=.;Database=GTDB;User Id = sa; Password=CAPUFE";
            
            bool dbConnection = false;

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();
                    cnn.Close();
                    dbConnection = true;
                }
                catch (Exception e)
                {
                    if (throwExceptionOnError) throw e;
                    dbConnection = false;
                }
            }
            return dbConnection;
        }
    }
}
