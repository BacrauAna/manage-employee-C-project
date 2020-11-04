using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public interface ISarciniRepository : ICrudRepository<int, Sarcini>
    {
        IEnumerable<Sarcini> findSarcUser(string user);
        void modify(Sarcini src, Cont cnt);
        void preia(Sarcini src);
        void progres(Sarcini src);

        void finalizare(Sarcini src);
    }
}
