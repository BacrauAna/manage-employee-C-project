using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Stari : HasId<int>
    {
        private int id;
        private string stare;

        public Stari(int id, string sta)
        {
            this.id = id;
            this.stare = sta;
        }

        public int Id { get { return id; } set { id = value; } }

        public string Stare { get { return stare; } set { stare = value; } }

        public override string ToString()
        {
            return id.ToString() + " " + stare.ToString();
        }
    }
}
