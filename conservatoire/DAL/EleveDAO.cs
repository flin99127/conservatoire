using conservatoire.Modele;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conservatoire.DAL
{
    public class EleveDAO
    {
        // attributs de connexion statiques
        private static string provider = "localhost";
        private static string dataBase = "musique";
        private static string uid = "root";
        private static string mdp = "";
        private static ConnexionSql maConnexionSql;
        private static MySqlCommand Ocom;
        public static List<Eleve> getEleve()
        {
            List<Eleve> ele = new List<Eleve>();

            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();
                Ocom = maConnexionSql.reqExec("Select id, nom, prenom, tel, mail, adresse, niveau, bourse from personne join eleve on personne.id = eleve.ideleve");
                MySqlDataReader reader = Ocom.ExecuteReader();
                Eleve e;

                while (reader.Read())
                {
                    int numero = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);
                    string prenom = (string)reader.GetValue(2);
                    string tel = (string)reader.GetValue(3);
                    string mail = (string)reader.GetValue(4);
                    string adresse = (string)reader.GetValue(5);
                    int niv = (int)reader.GetValue(6);
                    int bourse = (int)reader.GetValue(7);

                    //Instanciation d'un Emplye
                    e = new Eleve(numero, nom, prenom, tel, mail, adresse, niv, bourse);

                    // Ajout de cet employe à la liste 
                    ele.Add(e);
                }
                reader.Close();

                maConnexionSql.closeConnection();

                // Envoi de la liste au Manager
                return (ele);
            }
            catch (Exception m)
            {
                throw (m);
            }
        }
        public static List<Eleve> getEleveInsci(int unNumSeance)
        {
            List<Eleve> ele = new List<Eleve>();

            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();
                Ocom = maConnexionSql.reqExec("Select id, nom, prenom, tel, mail, adresse, niveau, bourse from personne join eleve on personne.id = eleve.ideleve where id in (select  ideleve from inscription where numseance = " + unNumSeance + ")");
                MySqlDataReader reader = Ocom.ExecuteReader();
                Eleve e;

                while (reader.Read())
                {
                    int numero = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);
                    string prenom = (string)reader.GetValue(2);
                    string tel = (string)reader.GetValue(3);
                    string mail = (string)reader.GetValue(4);
                    string adresse = (string)reader.GetValue(5);
                    int niv = (int)reader.GetValue(6);
                    int bourse = (int)reader.GetValue(7);

                    //Instanciation d'un Emplye
                    e = new Eleve(numero, nom, prenom, tel, mail, adresse, niv, bourse);

                    // Ajout de cet employe à la liste 
                    ele.Add(e);
                }
                reader.Close();

                maConnexionSql.closeConnection();

                // Envoi de la liste au Manager
                return (ele);
            }
            catch (Exception m)
            {
                throw (m);
            }
        }
    }
}
