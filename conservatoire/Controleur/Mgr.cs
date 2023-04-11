using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using conservatoire.Modele;
using conservatoire.DAL;

namespace conservatoire.Controleur
{
    public class Mgr
    {
        PersonneDAO PersonneDAO = new PersonneDAO();
        List<Personne> maListePersonne;
        
        ProfDAO ProfDAO = new ProfDAO();
        List<Prof> maListeProf;
        
        EleveDAO EleveDAO = new EleveDAO();
        List<Eleve> maListeEleve;

        SeanceDAO SeanceDAO = new SeanceDAO();
        List<Seance> maListeSeance;
        public Mgr()
        {
            maListePersonne = new List<Personne>();
            maListeProf = new List<Prof>();
            maListeEleve = new List<Eleve>();
            maListeSeance = new List<Seance>();
        }

        // Récupération de la liste des employés à partir de la DAL
        public List<Personne> chargementPersoBD()
        {
            maListePersonne = PersonneDAO.getPersonne();
            return (maListePersonne);
        }
        public List<Prof> chargementProfBD()
        {
            maListeProf = ProfDAO.getProf();
            return(maListeProf);
        }
        public List<Eleve> chargementEleveBD()
        {
            maListeEleve = EleveDAO.getEleve();
            return (maListeEleve);
        }
        public List<Eleve> chargementEleveInsciBD(int unNumSeance)
        {
            maListeEleve = EleveDAO.getEleveInsci(unNumSeance);
            return (maListeEleve);
        }
        public List<Seance> chargementSeanceBD()
        {
            maListeSeance = SeanceDAO.getSeance();
            return (maListeSeance);
        }
        public List<Seance> chargementSeanceProfBD(int unIdProf)
        {
            maListeSeance = SeanceDAO.getSeanceProf(unIdProf);
            return (maListeSeance);
        }

        //inserer, supprimer, modifier prof
        public void insertProf(Prof p)
        {
            ProfDAO.insertProf(p);
        }
    }
}
