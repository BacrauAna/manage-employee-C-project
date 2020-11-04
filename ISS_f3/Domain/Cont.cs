using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Cont
    {
        private string user;
        private string pass;
        private string importanta;
        private int stare;


        public Cont (string u, string p, string i, int stare)
        {
            this.user = u;
            this.pass = p;
            this.importanta = i;
            this.stare = stare;
        }

        public string User { get { return user; } set { user = value; } }

        public string Pass { get { return pass; } set { pass = value; } }

        public string Importanta { get { return importanta; } set { importanta = value; } }

        public int Stare
        {
            get { return stare; }
            set { stare = value; }
        }

        public override string ToString()
        {
            if(stare == 1)
            {
                return user.ToString() + " " + importanta.ToString() + " la munca";
            }
            else
            {
                return user.ToString() + " " + importanta.ToString() + " iesit";
            }
        }
    }
}
