using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Utils
{
    public static class Database
    {
        private static IDbConnection instance;
        public static IDbConnection getConnection()
        {
            if (instance == null || instance.State == System.Data.ConnectionState.Closed)
            {
                instance = GetNewConnection();
                instance.Open();
            }
            return instance;
        }

        public static IDbConnection GetNewConnection()
        {

            return ConnectionFactory.getInstance().createConnection();
        }
    }
}
