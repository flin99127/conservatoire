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
            Form1 f1 = new Form1();
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
        private void button1_Click(object sender, EventArgs e)
        {
            int unIdProf = ((Personne)listBox1.SelectedItem).Id;
            int unNumSeance = ((Personne)listBox1.SelectedItem).Id;
            form3 form3 = new form3(unIdProf);
            form3.ShowDialog();
        }
    }
}
