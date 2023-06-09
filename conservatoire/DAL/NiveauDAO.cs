﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conservatoire.DAL
{
    public class NiveauDAO
    {
        // attributs de connexion statiques
        private static string provider = "localhost";
        private static string dataBase = "musique";
        private static string uid = "root";
        private static string mdp = "";
        private static ConnexionSql maConnexionSql;
        private static MySqlCommand Ocom;
        public static List<int> getNiveau()
        {
            List<int> Niveau = new List<int>();

            try
            {
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                maConnexionSql.openConnection();
                Ocom = maConnexionSql.reqExec("Select * from niveau");
                MySqlDataReader reader = Ocom.ExecuteReader();

                while (reader.Read())
                {
                    int i = (int)reader.GetValue(0);

                    // Ajout de ce niveau à la liste 
                    Niveau.Add(i);
                }
                reader.Close();

                maConnexionSql.closeConnection();

                // Envoi de la liste au Manager
                return (Niveau);
            }
            catch (Exception m)
            {
                throw (m);
            }
        }
    }
}
