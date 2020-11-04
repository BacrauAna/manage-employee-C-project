using Domain;
using Services;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ServerImplementation : MarshalByRefObject, IServices
    {
        private IUseriRepository ur;
        private ISarciniRepository sr;
        private IStariRepository str;

        private readonly IDictionary<String, IObserver> loggedClients;

        public ServerImplementation(IUseriRepository urep, ISarciniRepository usrep, IStariRepository ustrep)
        {
            this.ur = urep;
            this.sr = usrep;
            this.str = ustrep;
            loggedClients = new Dictionary<String, IObserver>();
        }

        public void login(Cont user, IObserver client)
        {
            if(ur.login(user.User, user.Pass) != null)
            {
                if (loggedClients.ContainsKey(user.User))
                {
                    throw new MyException("User already logged in");
                }
                loggedClients[user.User] = client;
            }
            else
            {
                throw new MyException("Autentification faild!");
            }
        }

        public void add(Users usr)
        {
            try
            {
                ur.save(usr);
            }
            catch (Exception e)
            {
                throw new MyException("save empl faild");
            }
        }

        public void delete(Users usr)
        {
            try
            {
                ur.delete(usr.Id);
            }
            catch (Exception e)
            {
                throw new MyException("delete empl faild");
            }
        }

        public void modify(Users usr)
        {
            try
            {
                ur.modify(usr);
            }
            catch (Exception e)
            {
                throw new MyException("modify empl faild");
            }
        }

        public void modifySrc(Sarcini sarcin, Cont user)
        {
            try
            {
                sr.modify(sarcin, user);
            }
            catch (Exception e)
            {
                throw new MyException("modify sarcina faild");
            }
        }

        public void preluat(Sarcini sarcini)
        {
            try
            {
                sr.preia(sarcini);
            }
            catch (Exception e)
            {
                throw new MyException("preia sarcina faild");
            }
        }

        public void progresat(Sarcini sarcini)
        {
            try
            {
                sr.progres(sarcini);
            }
            catch (Exception e)
            {
                throw new MyException("progras sarcina faild");
            }
        }

        public void finalizat(Sarcini sarcini)
        {
            try
            {
                sr.finalizare(sarcini);
            }
            catch (Exception e)
            {
                throw new MyException("progras sarcina faild");
            }
        }

        public void logout(Cont user, IObserver client)
        {
            IObserver localClients = loggedClients[user.User];
            if(localClients == null)
            {
                throw new MyException("User" + user.User + "is not logged in");
            }
            if (ur.logout(user.User, user.Pass) != null)
            {
                loggedClients.Remove(user.User);
                Console.WriteLine("ma aflu dupa logout in servimpl");
            }
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }

        public IEnumerable<Sarcini> getAllSarcini()
        {
            return sr.findAll();
        }

        public IEnumerable<Users> getAllUsActive()
        {
            return ur.getAllusAct();
        }

        public IEnumerable<Users> getAllUsers()
        {
            return ur.findAll();
        }

        public IEnumerable<Stari> getAllStari()
        {
            return str.findAll();
        }

        public IEnumerable<Sarcini> getAllSarcUser(Cont user)
        {
            return sr.findSarcUser(user.User);
        }

        
    }
}
