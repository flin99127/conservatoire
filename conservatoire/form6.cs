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
    public partial class form6 : Form
    {
        Mgr monManager;
        List<Inscription> inscrit = new List<Inscription>();
        public form6()
        {
            InitializeComponent();
            monManager = new Mgr();
        }

        private void form6_Load(object sender, EventArgs e)
        {
            inscrit = monManager.getInscrit();
            affiche();
        }
        public void affiche()
        {
            try
            {
                listBox1.DataSource = inscrit;
                listBox1.DisplayMember = "Description";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
