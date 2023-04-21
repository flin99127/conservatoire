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
        private string nomProf;
        private string prenomProf;
        private string nomEleve;
        private string prenomEleve;
        private string tranche;
        private string jour;
        public Inscription(int idProf, string nomProf, string prenomProf, int idEleve, string nomEleve, string prenomEleve, int numSeance, string tranche, string jour, DateTime dateInscri)
        {
            this.idProf = idProf;
            this.nomProf = nomProf;
            this.prenomProf = prenomProf;
            this.idEleve = idEleve;
            this.nomEleve = nomEleve;
            this.prenomEleve = prenomEleve;
            this.numSeance = numSeance;
            this.tranche = tranche;
            this.jour = jour;
            this.dateInscri = dateInscri;
        }
        public virtual string Description
        {
            get => ("Prof : " + this.nomProf + " " + this.prenomProf + ", Eleve : " + this.nomEleve + " " + this .prenomEleve + ",  " + this.tranche + ",  " + this.jour + ",  " + this.dateInscri);
        }
        public int IdEleve { get => idEleve; set => idEleve = value; }
        public int NumSeance { get => numSeance; set => numSeance = value; }
    }
}