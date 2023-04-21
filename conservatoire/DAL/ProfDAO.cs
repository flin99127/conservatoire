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

                    //Instanciation d'un Emplye
                    pr = new Prof(numero, nom, prenom, tel, mail, adresse, instrument, salaire);

                    // Ajout de cet employe à la liste 
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
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();
                Ocom = maConnexionSql.reqExec("insert into prof (idprof, instrument, salaire) values('" + unId + "' ,'" + p.Instrument + "', '" + p.Salaire + "')");
                int i = Ocom.ExecuteNonQuery();
                maConnexionSql.closeConnection();
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
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();
                Ocom = maConnexionSql.reqExec("delete from prof where idprof = " + unId);
                int i = Ocom.ExecuteNonQuery();
                maConnexionSql.closeConnection();
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
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();
                Ocom = maConnexionSql.reqExec("update prof set instrument = '" + pr.Instrument + "', salaire = " + pr.Salaire + " where idProf = " + id);
                int i = Ocom.ExecuteNonQuery();
                maConnexionSql.closeConnection();
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
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();
                Ocom = maConnexionSql.reqExec("Select id, nom, prenom, tel, mail, adresse, instrument, salaire from personne join prof on personne.ID = prof.IDPROF where id = " + id );
                MySqlDataReader reader = Ocom.ExecuteReader();
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

                    //Instanciation d'un Emplye
                    pr = new Prof(numero, nom, prenom, tel, mail, adresse, instrument, salaire);
                }
                reader.Close();

                maConnexionSql.closeConnection();

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
