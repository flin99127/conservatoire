using conservatoire.Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace conservatoire.Modele
{
    public class Prof : Personne
    {
        private string instrument;
        private double salaire;

        public Prof(int unId, string unNom, string unPrenom, string unTel, string unMail, string uneAdresse, string unInstrument, double unSalaire) : base(unId, unNom, unPrenom, unTel, unMail, uneAdresse)
        {
            this.instrument = unInstrument;
            this.salaire = unSalaire;
        }
        public string Instrument { get => instrument; set => instrument = value; }
        public double Salaire { get => salaire; set => salaire = value; }
        public override string Description
        {
            get => (base.Description + ",  " + this.instrument + ",  " + this.salaire);
        }
    }
}
