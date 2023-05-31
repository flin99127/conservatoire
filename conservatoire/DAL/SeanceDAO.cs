using conservatoire.Modele;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Expect.Open.Types;

namespace conservatoire.DAL
{
    internal class SeanceDAO
    {
        // attributs de connexion statiques
        private static string provider = "localhost";
        private static string dataBase = "musique";
        private static string uid = "root";
        private static string mdp = "";
        private static ConnexionSql maConnexionSql;
        private static MySqlCommand Ocom;
        private static string connectionString = "server=localhost;userid=root;password=;database=musique";
        public static List<Seance> getSeance()
        {
            List<Seance> seances = new List<Seance>();

            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();
                Ocom = maConnexionSql.reqExec("Select * from seance");
                MySqlDataReader reader = Ocom.ExecuteReader();
                Seance s;

                while (reader.Read())
                {
                    int idProf = (int)reader.GetValue(0);
                    int numSeance = (int)reader.GetValue(1);
                    string tranche = (string)reader.GetValue(2);
                    string jour = (string)reader.GetValue(3);
                    int niv = (int)reader.GetValue(4);
                    int capacite = (int)reader.GetValue(5);

                    //Instanciation d'une seance
                    s = new Seance(idProf, numSeance, tranche, jour, niv, capacite);

                    // Ajout de cette seance à la liste 
                    seances.Add(s);
                }
                reader.Close();

                maConnexionSql.closeConnection();

                // Envoi de la liste au Manager
                return (seances);
            }
            catch (Exception m)
            {
                throw (m);
            }
        }
        public static List<Seance> getSeanceProf(int unIdProf)
        {
            List<Seance> seances = new List<Seance>();

            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.Parameters.AddWithValue("@unIdprof", unIdProf);
                command.CommandText = ("Select * from seance where idprof = @unIdProf");
                MySqlDataReader reader = command.ExecuteReader();
                /*Ocom.CommandText = ("SELECT * FROM seance WHERE idprof= @idProf");
                Ocom.Prepare();
                Ocom.Parameters.AddWithValue("@idProf", unIdProf);*/
                Seance s;

                while (reader.Read())
                {
                    int idProf = (int)reader.GetValue(0);
                    int numSeance = (int)reader.GetValue(1);
                    string tranche = (string)reader.GetValue(2);
                    string jour = (string)reader.GetValue(3);
                    int niv = (int)reader.GetValue(4);
                    int capacite = (int)reader.GetValue(5);


                    //Instanciation d'une seance
                    s = new Seance(idProf, numSeance, tranche, jour, niv, capacite);

                    // Ajout de cette seance à la liste 
                    seances.Add(s);
                }
                reader.Close();

                connection.Close();

                // Envoi de la liste au Manager
                return (seances);
            }
            catch (Exception m)
            {
                throw (m);
            }
        }
        public static void insertSeance(int unId, string uneTranche, string unJour, int UnNiv, int UneCapacite)
        {
            try
            {

                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.Parameters.AddWithValue("@id", unId);
                command.Parameters.AddWithValue("@uneTranche ", uneTranche);
                command.Parameters.AddWithValue("@unJour ", unJour);
                command.Parameters.AddWithValue("@UnNiv ", UnNiv);
                command.Parameters.AddWithValue("@UneCapacite ", UneCapacite);
                command.CommandText = ("insert into seance (idprof, tranche, jour, niveau, capacite) values(' @unId, @uneTranche, @unJour, @UnNiv, @UneCapacite)");
                int i = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception m)
            {
                throw (m);
            }
        }
        public static void updateSeance(int numSeance, string uneTranche, string unJour)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.Parameters.AddWithValue("@numSeance", numSeance);
                command.Parameters.AddWithValue("@uneTranche ", uneTranche);
                command.Parameters.AddWithValue("@unJour ", unJour);
                command.CommandText = ("UPDATE seance SET tranche = @uneTranche, jour = @unJour WHERE numseance = @numSeance '");
                int i = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception m)
            {
                throw (m);
            }
        }
        public static void suppSeance(int unNumSeance)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.Parameters.AddWithValue("@unNumSeance", unNumSeance);
                command.CommandText = ("delete from seance where numseance = @unNumSeance");
                int i = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception emp)
            {
                throw (emp);
            }
        }
    }
}
