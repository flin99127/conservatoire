using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conservatoire.Modele
{
    public class Trimestre
    {
        private string libelle;
        private DateTime datePaie;
        private string paye;
        public Trimestre(string libelle, DateTime datePaie, string paye)
        {
            this.libelle = libelle;
            this.datePaie = datePaie;
            this.paye = paye;
        }
        public virtual string Description
        {
            get => (" " + this.libelle + ",  " + this.datePaie + ",  " + this.paye);
        }
    }
}
