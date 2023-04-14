using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace conservatoire.Modele
{
    public class Instrument
    {
        private string libelle;

        public Instrument(string unLibelle)
        {
            this.libelle = unLibelle;
        }
        public string Libelle { get => libelle; set => libelle = value; }
    }
}
