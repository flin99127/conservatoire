using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conservatoire.Modele
{
    internal class Co
    {
        private int id;
        private string login;
        private string mdp;
        public Co(string login, string mdp)
        {
            this.login = login;
            this.mdp = mdp;
        }
        public int Id { get; set; }
    }
}
