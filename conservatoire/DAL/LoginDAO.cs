using conservatoire.Modele;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace conservatoire.DAL
{
    public class LoginDAO
    {
        public static string recupJson()
        {
            WebClient web = new WebClient();

            string json;

            try
            {
                string url = string.Format("https://franck-lin.efrei.me/Api-Conservatoire/identifiants");

                json = web.DownloadString(url);

                return json;
            }
            catch (Exception execption)
            {
                throw (execption);
            }
        }
        public static bool verifLogin(string username, string motDePasse, string Json)
        {
            bool res = false;
            string hash = MD5Hash.Hash.Content(motDePasse);

            List<Co> cos = JsonConvert.DeserializeObject<List<Co>>(Json);

            foreach(Co co in cos)
            {
                if(co.Login == username && co.Mdp == hash)
                {
                    res = true;

                    break;
                }
            }
            return res;
        }
    }
}
