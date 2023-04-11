using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conservatoire.Modele
{
    public class Seance
    {
        private int idProf;
        private int numSeance;
        private string tranche;
        private string jour;
        private int niv;
        private int capacite;

        public Seance(int idProf, int numSeance, string tranche, string jour, int niv, int capacite)
        {
            this.idProf = idProf;
            this.numSeance = numSeance;
            this.tranche = tranche;
            this.jour = jour;
            this.niv = niv;
            this.capacite = capacite;
        }
        public string Sea
        {
            get => (" " + this.numSeance + ",  " + this.tranche + ",  " + this.jour + ",  " + this.niv + ",  " + this.capacite);
        }

        public int NumSeance { get => numSeance; set => numSeance = value; }

    }
}
