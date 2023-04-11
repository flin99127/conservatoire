using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conservatoire.Modele
{
    public class Inscription
    {
        private int idProf;
        private int idEleve;
        private int numSeance;
        private DateTime dateInscri;
        public Inscription(int idProf, int idEleve, int numSeance, DateTime dateInscri)
        {
            this.idProf = idProf;
            this.idEleve = idEleve;
            this.numSeance = numSeance;
            this.dateInscri = dateInscri;
        }
    }
}
