using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using conservatoire.Controleur;
using conservatoire.Modele;
using conservatoire.DAL;

namespace conservatoire
{
    public partial class form2 : Form
    {
        Mgr monManager;
        List<Prof> pro = new List<Prof>();
        public form2()
        {
            InitializeComponent();
            monManager = new Mgr();
        }

        private void consulter_Load(object sender, EventArgs e)
        {
            pro = monManager.chargementProfBD();
            //pro = ProfDAO.getProf();
            affiche();
        }
        public void affiche()
        {
            try
            {
                listBox1.DataSource = pro;
                listBox1.DisplayMember = "Description";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //consulter les cours
        private void button1_Click(object sender, EventArgs e)
        {
            int unIdProf = ((Personne)listBox1.SelectedItem).Id;
            int unNumSeance = ((Personne)listBox1.SelectedItem).Id;
            form3 form3 = new form3(unIdProf);
            form3.ShowDialog();
        }

        //gerer les prof
        private void button2_Click(object sender, EventArgs e)
        {
            Prof unProf = (Prof)listBox1.SelectedItem;
            form4 form4 = new form4(unProf);
            form4.ShowDialog();
        }

        //rafraichir
        private void button3_Click(object sender, EventArgs e)
        {
            pro = monManager.chargementProfBD();
            affiche();
        }

        //gerer les cours
        private void button4_Click(object sender, EventArgs e)
        {
            Prof unProf = (Prof)listBox1.SelectedItem;
            form5 form5 = new form5(unProf);
            form5.ShowDialog();
        }

        //liste des inscrits
        private void button5_Click(object sender, EventArgs e)
        {
            form6 form6 = new form6();
            form6.ShowDialog();
        }
    }
}
