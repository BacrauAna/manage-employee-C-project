using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Sarcini : HasId<int>
    {
        private int id;
        private string descriere;
        private int durata;
        private string stareAct;
        private string sfaturi;
        private string angUser;

        public Sarcini (int id, string desc, int dur, string st, string sf, string au)
        {
            this.id = id;
            this.descriere = desc;
            this.durata = dur;
            this.stareAct = st;
            this.sfaturi = sf;
            this.angUser = au;
        }

        public int Id { get { return id; } set { id = value; } }

        public string Descriere { get { return descriere; } set { descriere = value; } }

        public int Durata { get { return durata; } set { durata = value; } }

        public string StareAct { get { return stareAct; } set { stareAct = value; } }

        public string Sfaturi { get { return sfaturi; } set { sfaturi = value; } }

        public string AngUser { get { return angUser; } set { angUser = value; } }

        public override string ToString()
        {
            return id.ToString() + " " + descriere.ToString() + " " + durata.ToString() + " " + stareAct.ToString() + " " + sfaturi.ToString();
        }
    }
}
