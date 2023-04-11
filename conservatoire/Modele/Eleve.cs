using conservatoire.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conservatoire.Modele
{
    public class Eleve : Personne
    {
        private int niv;
        private int bourse;

        public Eleve(int unId, string unNom, string unPrenom, string unTel, string unMail, string uneAdresse, int niv, int bourse) : base(unId, unNom, unPrenom, unTel, unMail, uneAdresse)
        {
            this.niv = niv;
            this.bourse = bourse;
        }
        public override string Description
        {
            get => (base.Description + ",  " + this.niv + ",  " + this.bourse);
        }
    }
}
