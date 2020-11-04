using Domain;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ClientController : MarshalByRefObject, IObserver
    {
        private readonly IServices server;
        private Cont currentUser;

        public ClientController(IServices server)
        {
            this.server = server;
            currentUser = null;
        }

        public void login (String user, String pass)
        {
            Cont usr = new Cont(user, pass,"", 0);
            server.login(usr, this);
            Console.WriteLine("Succed loggin");
            currentUser = usr;
            Console.WriteLine("current user {0}", usr);
        }

        public void logout()
        {
            Console.WriteLine("controller logout");
            server.logout(currentUser, this);
            currentUser = null;
        }

        public IEnumerable<Sarcini> getSarcini()
        {
            return server.getAllSarcini();
        }

        public IEnumerable<Sarcini> getSarciniUser(String user)
        {
            Cont ac = new Cont(user, "", "", 0);
            return server.getAllSarcUser(ac);
        }

        public IEnumerable<Users> getActive()
        {
            return server.getAllUsActive();
        }

        public IEnumerable<Users> getUsers()
        {
            return server.getAllUsers();
        }

        public IEnumerable<Stari> getStari()
        {
            return server.getAllStari();
        }

        public void adauga (Users usr)
        {
            server.add(usr);
        }

        public void sterge (Users usr)
        {
            server.delete(usr);
        }

        public void modifica (Users usr)
        {
            server.modify(usr);
        }

        public void modificaSrc(Sarcini sar, Cont cnt)
        {
            server.modifySrc(sar, cnt);
        }

        public void preluata(Sarcini src)
        {
            server.preluat(src);
        }

        public void progresata(Sarcini src)
        {
            server.progresat(src);
        }

        public void finalizata(Sarcini src)
        {
            server.finalizat(src);
        }
    }
}
