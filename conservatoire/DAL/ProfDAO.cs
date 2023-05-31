using conservatoire.Modele;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conservatoire.DAL
{
    public class ProfDAO
    {
        // attributs de connexion statiques
        private static string provider = "localhost";
        private static string dataBase = "musique";
        private static string uid = "root";
        private static string mdp = "";
        private static ConnexionSql maConnexionSql;
        private static MySqlCommand Ocom;
        private static string connectionString = "server=localhost;userid=root;password=;database=musique";
        public static List<Prof> getProf()
        {
            List<Prof> pro = new List<Prof>();

            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();
                Ocom = maConnexionSql.reqExec("Select id, nom, prenom, tel, mail, adresse, instrument, salaire from personne join prof on personne.ID = prof.IDPROF");
                MySqlDataReader reader = Ocom.ExecuteReader();
                Prof pr;

                while (reader.Read())
                {
                    int numero = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);
                    string prenom = (string)reader.GetValue(2);
                    string tel = (string)reader.GetValue(3);
                    string mail = (string)reader.GetValue(4);
                    string adresse = (string)reader.GetValue(5);
                    string instrument = (string)reader.GetValue(6);
                    double salaire = (double)reader.GetValue(7);

                    //Instanciation d'un prof
                    pr = new Prof(numero, nom, prenom, tel, mail, adresse, instrument, salaire);

                    // Ajout de ce prof à la liste 
                    pro.Add(pr);
                }
                reader.Close();

                maConnexionSql.closeConnection();

                // Envoi de la liste au Manager
                return (pro);
            }
            catch (Exception m)
            {
                throw (m);
            }
        }
        public static void insertProf(int unId, Prof p)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.Parameters.AddWithValue("@unId", unId);
                command.Parameters.AddWithValue("@instrument", p.Instrument);
                command.Parameters.AddWithValue("@salaire ", p.Salaire);
                command.CommandText = ("insert into prof (idprof, instrument, salaire) values( @unId, @instrument, @salaire)");
                int i = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception m)
            {
                throw (m);
            }
        }
        public static void suppProf(int unId)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.Parameters.AddWithValue("@unId", unId);
                command.CommandText = ("delete from prof where idprof = @unId");
                int i = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception emp)
            {
                throw (emp);
            }
        }
        public static void updateProf(int id, Prof pr)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@instrument", pr.Instrument);
                command.Parameters.AddWithValue("@salaire", pr.Salaire);
                command.CommandText = ("update prof set instrument = @instrument, salaire = @salaire where idProf = @id");
                int i = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception m)
            {
                throw (m);
            }
        }
        public static Prof getProf(int id)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.Parameters.AddWithValue("@id", id);
                command.CommandText = ("Select id, nom, prenom, tel, mail, adresse, instrument, salaire from personne join prof on personne.ID = prof.IDPROF where id = @id ");
                MySqlDataReader reader = command.ExecuteReader();
                Prof pr = new Prof(999, "", "", "", "", "", "", 999);

                while (reader.Read())
                {
                    int numero = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);
                    string prenom = (string)reader.GetValue(2);
                    string tel = (string)reader.GetValue(3);
                    string mail = (string)reader.GetValue(4);
                    string adresse = (string)reader.GetValue(5);
                    string instrument = (string)reader.GetValue(6);
                    double salaire = (double)reader.GetValue(7);

                    //Instanciation d'une personne
                    pr = new Prof(numero, nom, prenom, tel, mail, adresse, instrument, salaire);
                }
                reader.Close();

                connection.Close();

                // Envoi de la liste au Manager
                return (pr);
            }
            catch (Exception m)
            {
                throw (m);
            }
        }
    }
}
