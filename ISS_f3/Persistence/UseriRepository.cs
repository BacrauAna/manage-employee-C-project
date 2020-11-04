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
    public class UseriRepository : IUseriRepository
    {
        public Cont login(string user, string pass)
        {
            IDbConnection con = Database.getConnection();
            using(var comm = con.CreateCommand())
            {
                comm.CommandText = "select pass,importanta from useri where user=@usr";
                IDbDataParameter param = comm.CreateParameter();
                param.ParameterName = "@usr";
                param.Value = user;
                comm.Parameters.Add(param);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        string pas = dataR.GetString(0);
                        string imp = dataR.GetString(1);
                        int st = 1;
                        

                        if (modify_stare(user))
                        {
                            Cont t = new Cont(user, pas, imp, st);
                            return t;
                        }
                    }
                }
            }
            return null;
        }

        public Cont logout(string user, string pass)
        {
            IDbConnection con = Database.getConnection();
            using(var comm = con.CreateCommand())
            {
                comm.CommandText = "select pass,importanta from useri where user=@usr";
                IDbDataParameter param = comm.CreateParameter();
                param.ParameterName = "@usr";
                param.Value = user;
                comm.Parameters.Add(param);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        string pas = dataR.GetString(0);
                        string imp = dataR.GetString(1);
                        int st = 0;


                        if (modify_stare_out(user))
                        {
                            Cont t = new Cont(user, pas, imp, st);
                            return t;
                        }
                    }
                }
            }
            return null;
        }
        

        public bool modify_stare(string user)
        {
            IDbConnection con = Database.getConnection();
            using(var comm = con.CreateCommand())
            {
                comm.CommandText = "update useri set stare=1 where user=@u";
                var param = comm.CreateParameter();
                param.ParameterName = "@u";
                param.Value = user;
                comm.Parameters.Add(param);

                var res = comm.ExecuteNonQuery();
                if (res != 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool modify_stare_out(string user)
        {
            IDbConnection con = Database.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update useri set stare=0 where user=@u";
                var param = comm.CreateParameter();
                param.ParameterName = "@u";
                param.Value = user;
                comm.Parameters.Add(param);

                var res = comm.ExecuteNonQuery();
                if (res != 0)
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<Users> getAllusAct()
        {
            IDbConnection con = Database.getConnection();

            IList<Users> res = new List<Users>();
            using(var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from useri where importanta<>'sef' and stare=1 and importanta<>'sefa'";

                using(var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        string user = dataR.GetString(1);
                        string pass = dataR.GetString(2);
                        string import = dataR.GetString(3);
                        string nume = dataR.GetString(4);
                        string pren = dataR.GetString(5);
                        int salariu = dataR.GetInt32(6);
                        string adr = dataR.GetString(7);
                        int stare = dataR.GetInt32(8);

                        Users us = new Users(id, user, pass, import, nume, pren, salariu, adr, stare);
                        res.Add(us);
                    }
                }
            }
            return res;
        }

        public void delete(int id)
        {
            IDbConnection con = Database.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from useri where id=@id";

                var paramid = comm.CreateParameter();
                paramid.ParameterName = "@id";
                paramid.Value = id;
                comm.Parameters.Add(paramid);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                {
                    throw new ReadOnlyException("No empl deleted!");
                }
            }
        }

        public IEnumerable<Users> findAll()
        {
            IDbConnection con = Database.getConnection();

            IList<Users> res = new List<Users>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from useri";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        string user = dataR.GetString(1);
                        string pass = dataR.GetString(2);
                        string import = dataR.GetString(3);
                        string nume = dataR.GetString(4);
                        string pren = dataR.GetString(5);
                        int salariu = dataR.GetInt32(6);
                        string adr = dataR.GetString(7);
                        int stare = dataR.GetInt32(8);

                        Users us = new Users(id, user, pass, import, nume, pren, salariu, adr, stare);
                        res.Add(us);
                    }
                }
            }
            return res;
        }

        public Users findOne(int id)
        {
            throw new NotImplementedException();
        }

        public void modify (Users entity)
        {
            IDbConnection con = Database.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update useri set user=@us, pass=@pa, importanta=@imp, nume=@n, prenume=@p, salariu=@sa, adresa=@adr, stare=@st where id=@id";

                var paramus = comm.CreateParameter();
                paramus.ParameterName = "@us";
                paramus.Value = entity.User;
                comm.Parameters.Add(paramus);

                var parampass = comm.CreateParameter();
                parampass.ParameterName = "@pa";
                parampass.Value = entity.Pass;
                comm.Parameters.Add(parampass);

                var paramimp = comm.CreateParameter();
                paramimp.ParameterName = "@imp";
                paramimp.Value = entity.Iportanta;
                comm.Parameters.Add(paramimp);

                var paramn = comm.CreateParameter();
                paramn.ParameterName = "@n";
                paramn.Value = entity.Nume;
                comm.Parameters.Add(paramn);

                var paramp = comm.CreateParameter();
                paramp.ParameterName = "@p";
                paramp.Value = entity.Prenume;
                comm.Parameters.Add(paramp);

                var paramsa = comm.CreateParameter();
                paramsa.ParameterName = "@sa";
                paramsa.Value = entity.Salariu;
                comm.Parameters.Add(paramsa);

                var paramadr = comm.CreateParameter();
                paramadr.ParameterName = "@adr";
                paramadr.Value = entity.Adresa;
                comm.Parameters.Add(paramadr);

                var paramst = comm.CreateParameter();
                paramst.ParameterName = "@st";
                paramst.Value = entity.Stare;
                comm.Parameters.Add(paramst);

                var paramid = comm.CreateParameter();
                paramid.ParameterName = "@id";
                paramid.Value = entity.Id;
                comm.Parameters.Add(paramid);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                {
                    throw new ReadOnlyException("No empl modify!");
                }
            }
        }

        public void save(Users entity)
        {
            IDbConnection con = Database.getConnection();
            using(var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into useri (user, pass, importanta, nume, prenume, salariu, adresa, stare) values (@us, @pa,@imp,@n,@p,@sa,@adr,@st)";

                var paramus = comm.CreateParameter();
                paramus.ParameterName = "@us";
                paramus.Value = entity.User;
                comm.Parameters.Add(paramus);

                var parampass = comm.CreateParameter();
                parampass.ParameterName = "@pa";
                parampass.Value = entity.Pass;
                comm.Parameters.Add(parampass);

                var paramimp = comm.CreateParameter();
                paramimp.ParameterName = "@imp";
                paramimp.Value = entity.Iportanta;
                comm.Parameters.Add(paramimp);

                var paramn = comm.CreateParameter();
                paramn.ParameterName = "@n";
                paramn.Value = entity.Nume;
                comm.Parameters.Add(paramn);

                var paramp = comm.CreateParameter();
                paramp.ParameterName = "@p";
                paramp.Value = entity.Prenume;
                comm.Parameters.Add(paramp);

                var paramsa = comm.CreateParameter();
                paramsa.ParameterName = "@sa";
                paramsa.Value = entity.Salariu;
                comm.Parameters.Add(paramsa);

                var paramadr = comm.CreateParameter();
                paramadr.ParameterName = "@adr";
                paramadr.Value = entity.Adresa;
                comm.Parameters.Add(paramadr);

                var paramst = comm.CreateParameter();
                paramst.ParameterName = "@st";
                paramst.Value = entity.Stare;
                comm.Parameters.Add(paramst);

                var result = comm.ExecuteNonQuery();
                if(result == 0)
                {
                    throw new ReadOnlyException("No empl added!");
                }
            }
        }
    }
}
