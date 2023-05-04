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

        public static void updatePayer(string date, int payer, int ideleve, int numseance, string libe)
        {
            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();
                Ocom = maConnexionSql.reqExec("update payer set datepaiement = '" + date + "', paye = " + payer + " where idEleve = " + ideleve + " and numseance = " + numseance + " and libelle = '" + libe + "' ");
                int i = Ocom.ExecuteNonQuery();
                maConnexionSql.closeConnection();
            }
            catch (Exception m)
            {
                throw (m);
            }
        }
    }
}
