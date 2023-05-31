using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace conservatoire.DAL
{
    public class PayerDAO
    {
        // attributs de connexion statiques
        private static string provider = "localhost";
        private static string dataBase = "musique";
        private static string uid = "root";
        private static string mdp = "";
        private static ConnexionSql maConnexionSql;
        private static MySqlCommand Ocom;
        private static string connectionString = "server=localhost;userid=root;password=;database=musique";

        public static void updatePayer(string date, int payer, int ideleve, int numseance, string libe)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@payer", payer);
                command.Parameters.AddWithValue("@idEleve", ideleve);
                command.Parameters.AddWithValue("@numsenace", numseance);
                command.Parameters.AddWithValue("@libelle", libe);
                command.CommandText = ("update payer set datepaiement = @date, paye = @payer where idEleve = @idEleve and numseance = @numseance and libelle = @libe ");
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
