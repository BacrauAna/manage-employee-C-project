using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public interface IUseriRepository : ICrudRepository<int, Users>
    {
        Cont login(string user, string pass);
        Cont logout(string user, string pass);
        IEnumerable<Users> getAllusAct();

        void modify(Users entity);
    }
}
