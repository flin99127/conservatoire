using conservatoire.Modele;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conservatoire.DAL
{
    public class InstrumentDAO
    {
        // attributs de connexion statiques
        private static string provider = "localhost";
        private static string dataBase = "musique";
        private static string uid = "root";
        private static string mdp = "";
        private static ConnexionSql maConnexionSql;
        private static MySqlCommand Ocom;
        public static List<string> getInstrument()
        {
            List<string> Instrument = new List<string>();

            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();
                Ocom = maConnexionSql.reqExec("Select * from instrument");
                MySqlDataReader reader = Ocom.ExecuteReader();

                while (reader.Read())
                {
                    string i = (string)reader.GetValue(0);

                    // Ajout de cet instrument à la liste 
                    Instrument.Add(i);
                }
                reader.Close();

                maConnexionSql.closeConnection();

                // Envoi de la liste au Manager
                return (Instrument);
            }
            catch (Exception m)
            {
                throw (m);
            }
        }
    }
}
