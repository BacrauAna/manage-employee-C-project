using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Utils
{
    public abstract class ConnectionFactory
    {
        static ConnectionFactory instance;
        protected ConnectionFactory() { }
        public static ConnectionFactory getInstance()
        {
            if (instance == null)
            {

                Assembly assem = Assembly.GetExecutingAssembly();
                Type[] types = assem.GetTypes();
                foreach (var type in types)
                {
                    if (type.IsSubclassOf(typeof(ConnectionFactory)))
                        instance = (ConnectionFactory)Activator.CreateInstance(type);
                }
            }
            return instance;
        }


        //public abstract IDbConnection createConnection(string st);
        public abstract IDbConnection createConnection();
    }

    public class SQLiteConnectionFactory : ConnectionFactory
    {
        public override IDbConnection createConnection()
        {
            SQLiteConnection sqlite_conn;
            //Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=C:\\Users\\Anisoara Bacrau\\Desktop\\an2\\MPP\\iss.db");

            return sqlite_conn;


            /*//string con = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection(st);

            return sqlite_conn;*/
        }
    }
}
