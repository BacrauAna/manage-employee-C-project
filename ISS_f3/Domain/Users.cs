using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Users: HasId<int>
    {
        private int id;
        private string user;
        private string pass;
        private string importanta;
        private string nume;
        private string prenume;
        private int salariu;
        private string adresa;
        private int stare;

        public Users (int id, string user, string pass, string imp, string n, string p, int sal, string adr, int stare)
        {
            this.id = id;
            this.user = user;
            this.pass = pass;
            this.importanta = imp;
            this.nume = n;
            this.prenume = p;
            this.salariu = sal;
            this.adresa = adr;
            this.stare = stare;
        }

        public int Id { get { return id; } set { id = value; } }

        public string User { get { return user; } set { user = value; } }

        public string Pass { get { return pass; } set { pass = value; } }

        public string Iportanta { get { return importanta; } set { importanta = value; } }
        
        public string Nume { get { return nume; } set { nume = value; } }

        public string Prenume { get { return prenume; } set { prenume = value; } }

        public int Salariu { get { return salariu; } set { salariu = value; } }

        public string Adresa { get { return adresa; } set { adresa = value; } }

        public int Stare { get { return stare; } set { stare = value; } }

        public override string ToString()
        {
            return id.ToString() + " " + nume.ToString() + " " + prenume.ToString() + " " + importanta.ToString() + " " + salariu.ToString() + " " + adresa.ToString();
        }
    }
}
