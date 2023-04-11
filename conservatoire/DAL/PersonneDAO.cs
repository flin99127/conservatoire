using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using conservatoire.Modele;

namespace conservatoire.DAL
{
    public class PersonneDAO
    {
        // attributs de connexion statiques
        private static string provider = "localhost";
        private static string dataBase = "musique";
        private static string uid = "root";
        private static string mdp = "";
        private static ConnexionSql maConnexionSql;
        private static MySqlCommand Ocom;

        public static List<Personne> getPersonne()
        {
            List<Personne> pn = new List<Personne>();

            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();
                Ocom = maConnexionSql.reqExec("Select * from personne");
                MySqlDataReader reader = Ocom.ExecuteReader();
                Personne p;

                while (reader.Read())
                {
                    int numero = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);
                    string prenom = (string)reader.GetValue(2);
                    string tel = (string)reader.GetValue(3);
                    string mail = (string)reader.GetValue(4);
                    string adresse = (string)reader.GetValue(5);

                    //Instanciation d'un Emplye
                    p = new Personne(numero, nom, prenom, tel, mail, adresse);

                    // Ajout de cet employe à la liste 
                    pn.Add(p);
                }
                reader.Close();

                maConnexionSql.closeConnection();

                // Envoi de la liste au Manager
                return (pn);
            }
            catch (Exception m)
            {
                throw (m);
            }
        }
    }
}
