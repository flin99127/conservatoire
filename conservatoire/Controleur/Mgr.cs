﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using conservatoire.Modele;
using conservatoire.DAL;
using Mysqlx.Crud;

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

        InstrumentDAO InstrumentDAO = new InstrumentDAO();
        List<string> maListeInstrument;

        TrancheDAO TrancheDAO = new TrancheDAO();
        List<string> maListeTranche;

        JourDAO JourDAO = new JourDAO();
        List<string> maListeJour;

        NiveauDAO NiveauDAO = new NiveauDAO();
        List<int> maListeNiveau;

        InscriptionDAO InscriptionDAO = new InscriptionDAO();
        List<Inscription> maListeInscription;

        TrimestreDAO TrimestreDAO = new TrimestreDAO();
        List<Trimestre> maListeTrimestre;

        public Mgr()
        {

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
            return (maListeProf);
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
        public void updateProf(int id, Prof pr)
        {
            PersonneDAO.updatePersonne(id, pr);
            ProfDAO.updateProf(id, pr);
        }

        //inserer
        public void insertProf(Prof pr)
        {
            PersonneDAO.insertPersonne(pr);
            ProfDAO.insertProf(PersonneDAO.getLastId(), pr);

        }
        public Prof GetProf(int id)
        {
            Prof p = ProfDAO.getProf(id);
            return (p);
        }
        public List<string> chargementInstruBD()
        {
            maListeInstrument = InstrumentDAO.getInstrument();
            return (maListeInstrument);
        }

        //supp
        public void suppProf(Prof pr)
        {
            ProfDAO.suppProf(pr.Id);
            PersonneDAO.suppPersonne(pr.Id);
        }

        //gerer les cours
        public void insertSeance(int id, string tranche, string jour, int niv, int capacite)
        {
            SeanceDAO.insertSeance(id, tranche, jour, niv, capacite);
        }
        public List<string> chargementTrancheBD()
        {
            maListeTranche = TrancheDAO.getTranche();
            return (maListeTranche);
        }
        public List<string> chargementJourBD()
        {
            maListeJour = JourDAO.getJour();
            return (maListeJour);
        }
        public List<int> chargementNivBD()
        {
            maListeNiveau = NiveauDAO.getNiveau();
            return (maListeNiveau);
        }
        public void updateSeance(int numSeance, string tranche, string jour)
        {
            SeanceDAO.updateSeance(numSeance, tranche, jour);
        }
        public void suppSeance(int unNumSeance)
        {
            SeanceDAO.suppSeance(unNumSeance);
        }

        //mission 3
        public List<Inscription> getInscrit()
        {
            maListeInscription = InscriptionDAO.getInscrit();
            return (maListeInscription);
        }
        public List<Trimestre> getTrim(int ideleve, int numseance)
        {
            maListeTrimestre = TrimestreDAO.getTrim(ideleve, numseance);
            return (maListeTrimestre);
        }
        public void updatePayer(string date, int ideleve, int numseance, string libe)
        {
            PayerDAO.updatePayer(date, 1, ideleve, numseance, libe);
        }

        //Login
        public bool verifLogin(string login, string mdp)
        {
            return LoginDAO.verifLogin(login, mdp, LoginDAO.recupJson());
        }
    }
}
