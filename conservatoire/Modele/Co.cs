using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conservatoire.Modele
{
    public class Co
    {
        private string id;
        private string login;
        private string mdp;
        public Co(string login, string mdp)
        {
            this.login = login;
            this.mdp = mdp;
        }

        public string Login { get => login; set => login = value; }
        public string Mdp { get => mdp; set => mdp = value; }
        public string Id { get => id; set => id = value; }
    }
}
