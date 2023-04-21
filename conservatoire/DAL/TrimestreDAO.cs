using conservatoire.Modele;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conservatoire.DAL
{
    public class TrimestreDAO
    {

        // attributs de connexion statiques
        private static string provider = "localhost";
        private static string dataBase = "musique";
        private static string uid = "root";
        private static string mdp = "";
        private static ConnexionSql maConnexionSql;
        private static MySqlCommand Ocom;

        public static List<Trimestre> getTrim()
        {
            List<Trimestre> trimestre = new List<Trimestre>();

            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();
                Ocom = maConnexionSql.reqExec("select libelle, datePaiement, paye from payer where idEleve= " + ideleve + "' and numseance= " + numseance + "");
                MySqlDataReader reader = Ocom.ExecuteReader();
                Trimestre t;

                while (reader.Read())
                {
                    string libelle = (string)reader.GetValue(0);
                    DateTime datePaie = (DateTime)reader.GetValue(1);
                    string paye = (string)reader.GetValue(2);

                    //Instanciation d'un Emplye
                    t = new Trimestre(libelle, datePaie, paye);

                    // Ajout de cet employe à la liste 
                    trimestre.Add(t);
                }
                reader.Close();

                maConnexionSql.closeConnection();

                // Envoi de la liste au Manager
                return (trimestre);
            }
            catch (Exception m)
            {
                throw (m);
            }
        }
    }
}
