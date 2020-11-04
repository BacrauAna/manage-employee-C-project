using Domain;
using Persistence.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class StariRepository : IStariRepository
    {
        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Stari> findAll()
        {
            IDbConnection con = Database.getConnection();
            IList<Stari> rez = new List<Stari>();
            using(var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from stari";

                using(var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        string st = dataR.GetString(1);

                        Stari sta = new Stari(id, st);
                        rez.Add(sta);
                    }
                }
            }
            return rez;

        }

        public Stari findOne(int id)
        {
            throw new NotImplementedException();
        }

        public void save(Stari entity)
        {
            throw new NotImplementedException();
        }
    }
}
