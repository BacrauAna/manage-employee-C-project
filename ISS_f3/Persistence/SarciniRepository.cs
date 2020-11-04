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
    public class SarciniRepository : ISarciniRepository
    {
        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sarcini> findAll()
        {
            IDbConnection con = Database.getConnection();

            IList<Sarcini> res = new List<Sarcini>();

            using(var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from sarcini where angajat is null and stareAct='nepreluat'";
                using(var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        string des = dataR.GetString(1);
                        int dur = dataR.GetInt32(2);
                        string stare = dataR.GetString(3);
                        string sfaturi = dataR.GetString(4);
                        //string ang = dataR.GetString(5);

                        Sarcini sa = new Sarcini(id, des, dur, stare, sfaturi,"");
                        res.Add(sa);
                    }
                }
            }
            return res;

        }

        public void preia(Sarcini src)
        {
            IDbConnection con = Database.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update sarcini set stareAct='preluat' where id=@id";

                var paramid = comm.CreateParameter();
                paramid.ParameterName = "@id";
                paramid.Value = src.Id;
                comm.Parameters.Add(paramid);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                {
                    throw new RepositoryException("No sarcini modify");
                }
            }
        }

        public void progres(Sarcini src)
        {
            IDbConnection con = Database.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update sarcini set stareAct='progres' where id=@id";

                var paramid = comm.CreateParameter();
                paramid.ParameterName = "@id";
                paramid.Value = src.Id;
                comm.Parameters.Add(paramid);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                {
                    throw new RepositoryException("No sarcini modify progres");
                }
            }
        }

        public void finalizare(Sarcini src)
        {
            IDbConnection con = Database.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update sarcini set stareAct='finalizat' where id=@id";

                var paramid = comm.CreateParameter();
                paramid.ParameterName = "@id";
                paramid.Value = src.Id;
                comm.Parameters.Add(paramid);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                {
                    throw new RepositoryException("No sarcini modify progres");
                }
            }
        }

        public void modify(Sarcini src, Cont cnt)
        {
            IDbConnection con = Database.getConnection();

            using(var comm = con.CreateCommand())
            {
                comm.CommandText = "update sarcini set angajat=@user where id=@id";

                var paramang = comm.CreateParameter();
                paramang.ParameterName = "@user";
                paramang.Value = cnt.User;
                comm.Parameters.Add(paramang);

                var paramid = comm.CreateParameter();
                paramid.ParameterName = "@id";
                paramid.Value = src.Id;
                comm.Parameters.Add(paramid);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                {
                    throw new RepositoryException("No sarcini modify");
                }
            }
        }

        public IEnumerable<Sarcini> findSarcUser(string user)
        {
            IDbConnection con = Database.getConnection();

            IList<Sarcini> res = new List<Sarcini>();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from sarcini where angajat=@usr and stareAct<>'finalizat'";
                var param = comm.CreateParameter();
                param.ParameterName = "@usr";
                param.Value = user;
                comm.Parameters.Add(param);
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        string des = dataR.GetString(1);
                        int dur = dataR.GetInt32(2);
                        string stare = dataR.GetString(3);
                        string sfaturi = dataR.GetString(4);
                        string ang = dataR.GetString(5);

                        Sarcini sa = new Sarcini(id, des, dur, stare, sfaturi, ang);
                        res.Add(sa);
                    }
                }
            }
            return res;
        }

        public Sarcini findOne(int id)
        {
            throw new NotImplementedException();
        }

        public void save(Sarcini entity)
        {
            throw new NotImplementedException();
        }
    }
}
