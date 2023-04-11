using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conservatoire.Modele
{
    public class Personne
    {
        private int id;
        private string nom;
        private string prenom;
        private string tel;
        private string mail;
        private string adresse;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; }

        public Personne(int unId, string unNom, string unPrenom, string unTel, string unMail, string uneAdresse)
        {
            this.id = unId;
            this.nom = unNom;
            this.prenom = unPrenom;
            this.tel = unTel;
            this.mail = unMail;
            this.adresse = uneAdresse;
        }
        public Personne()
        {

        }
        public virtual string Description
        {
            get => ("Id : " + this.id + " " + this.nom + " " + this.prenom + ",  " + this.tel + ",  " + this.mail + ",  " + this.adresse);
        }
    }
}
