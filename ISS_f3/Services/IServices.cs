using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IServices
    {
        void login(Cont user, IObserver client);

        void logout(Cont user, IObserver client);

        IEnumerable<Sarcini> getAllSarcini();

        IEnumerable<Sarcini> getAllSarcUser(Cont user);

        IEnumerable<Users> getAllUsActive();

        IEnumerable<Users> getAllUsers();

        IEnumerable<Stari> getAllStari();

        void add(Users usr);

        void delete(Users usr);

        void modify(Users usr);

        void modifySrc(Sarcini sarcin, Cont user);

        void preluat(Sarcini sarcini);

        void progresat(Sarcini sarcini);

        void finalizat(Sarcini sarcini);
    }
}
