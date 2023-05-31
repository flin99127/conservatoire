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
        private static string connectionString = "server=localhost;userid=root;password=;database=musique";

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

                    //Instanciation d'une personne
                    p = new Personne(numero, nom, prenom, tel, mail, adresse);

                    // Ajout de cette personne à la liste 
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
        public static void insertPersonne(Personne p)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.Parameters.AddWithValue("@nom", p.Nom);
                command.Parameters.AddWithValue("@prenom", p.Prenom);
                command.Parameters.AddWithValue("@tel", p.Tel);
                command.Parameters.AddWithValue("@mail", p.Mail);
                command.Parameters.AddWithValue("@adresse", p.Adresse);
                command.CommandText = ("insert into personne (nom, prenom, tel, mail, adresse) values(@nom, @prenom, @tel, @mail, @adresse)");
                int i = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception m)
            {
                throw (m);
            }
        }
        public static int getLastId()
        {
            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();
                //Ocom = maConnexionSql.reqExec("select last_insert_ID(ID) from personne order by last_insert_ID(ID) desc limit 1");
                Ocom = maConnexionSql.reqExec("select * from personne");
                MySqlDataReader reader = Ocom.ExecuteReader();
                int id = 0;

                while(reader.Read())
                {
                    id = (int)reader.GetValue(0);
                }
                reader.Close();

                maConnexionSql.closeConnection();

                return id;
            }
            catch (Exception m)
            {
                throw (m);
            }
        }
        public static void suppPersonne(int unId)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.Parameters.AddWithValue("@id", unId);
                command.CommandText = ("delete from personne where id = @unId");
                int i = command.ExecuteNonQuery();
                maConnexionSql.closeConnection();
            }
            catch (Exception m)
            {
                throw (m);
            }
        }
        public static void updatePersonne(int id, Personne p)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@nom", p.Nom);
                command.Parameters.AddWithValue("@prenom", p.Prenom);
                command.Parameters.AddWithValue("@tel", p.Tel);
                command.Parameters.AddWithValue("@mail", p.Mail);
                command.Parameters.AddWithValue("@adresse", p.Adresse);
                command.CommandText = ("update personne set nom = @nom, prenom = @prenom, tel = @tel, mail = @mail, adresse = @adresse where id = @id");
                int i = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception m)
            {
                throw (m);
            }
        }
    }
}
