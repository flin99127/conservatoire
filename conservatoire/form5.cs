using conservatoire.Controleur;
using conservatoire.Modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mysqlx.Notice.Warning.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace conservatoire
{
    public partial class form5 : Form
    {
        Mgr monManager;
        Prof prof;
        List<Seance> seances = new List<Seance>();
        public form5(Prof unProf)
        {
            InitializeComponent();
            monManager = new Mgr();
            this.prof = unProf;
        }

        private void form5_Load(object sender, EventArgs e)
        {
            seances = monManager.chargementSeanceProfBD(this.prof.Id);
            affiche1();
        }

        //ajouter la seance
        private void button1_Click(object sender, EventArgs e)
        {
            string tranche = textBox1.Text;
            string jour = textBox2.Text;
            int niveau = Convert.ToInt16(textBox3.Text);
            int capacite = Convert.ToInt16(textBox4.Text);

            List<string> Tranche = monManager.chargementTrancheBD();
            List<string> Jour = monManager.chargementJourBD();
            List<int> Niveau = monManager.chargementNivBD();
            int exist = 0;

            foreach (string tran in Tranche)
            {
                if (tranche == tran)
                {
                    exist = 0;
                    break;
                }
                exist = 1;
            }

            foreach (string J in Jour)
            {
                if (jour == J)
                {
                    exist = 0;
                    break;
                }
                exist = 2;
            }

            foreach (int Niv in Niveau)
            {
                if (niveau == Niv)
                {
                    exist = 0;
                    break;
                }
                exist = 3;
            }

            switch(exist)
            {
                case 0:
                    monManager.insertSeance(this.prof.Id, tranche, jour, niveau, capacite);
                    MessageBox.Show("un nouveau cours est ajouté");
                    break;

                case 1:
                    MessageBox.Show("cette tranche horaire n'existe pas");
                    break;

                case 2:
                    MessageBox.Show("ce jour n'est pas ouvert");
                    break;

                case 3:
                    MessageBox.Show("ce niveau n'existe pas");
                    break;

            }
        }

        //modifier la seance
        private void button2_Click(object sender, EventArgs e)
        {
            int numSeance = (((Seance)listBox1.SelectedItem).NumSeance);
            string tranche = textBox5.Text;
            string jour = textBox6.Text;

            List<string> Tranche = monManager.chargementTrancheBD();
            List<string> Jour = monManager.chargementJourBD();
            int exist = 0;

            foreach (string tran in Tranche)
            {
                if (tranche == tran)
                {
                    exist = 0;
                    break;
                }
                exist = 1;
            }

            foreach (string J in Jour)
            {
                if (jour == J)
                {
                    exist = 0;
                    break;
                }
                exist = 2;
            }

            switch (exist)
            {
                case 0:
                    monManager.updateSeance(numSeance, tranche, jour);
                    MessageBox.Show("un nouveau cours est ajouté");
                    break;

                case 1:
                    MessageBox.Show("cette tranche horaire n'existe pas");
                    break;

                case 2:
                    MessageBox.Show("ce jour n'est pas ouvert");
                    break;
            }
        }
        public void affiche1()
        {
            try
            {
                listBox1.DataSource = seances;
                listBox1.DisplayMember = "Sea";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //rafraichir
        private void button4_Click(object sender, EventArgs e)
        {
            seances = monManager.chargementSeanceProfBD(this.prof.Id);
            affiche1();
        }

        //supprimer
        private void button3_Click(object sender, EventArgs e)
        {
            monManager.suppSeance(((Seance)listBox1.SelectedItem).NumSeance);
            MessageBox.Show("la seance a été supprimé");
        }
    }
}
