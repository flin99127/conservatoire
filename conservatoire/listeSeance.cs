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

namespace conservatoire
{
    public partial class form3 : Form
    {
        Mgr monManager;
        List<Seance> seances = new List<Seance>();
        List<Eleve> eleves = new List<Eleve>();

        private int idProf;
        public form3(int unIdProf)
        {
            InitializeComponent();
            monManager = new Mgr();
            this.idProf = unIdProf;
        }
        private void form3_Load(object sender, EventArgs e)
        {
            seances = monManager.chargementSeanceProfBD(this.idProf);
            affiche1();
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
        public void affiche2()
        {
            try
            {
                listBox2.DataSource = eleves;
                listBox2.DisplayMember = "Description";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            eleves = monManager.chargementEleveInsciBD(((Seance)listBox1.SelectedItem).NumSeance);
            affiche2();
        }
    }
}
