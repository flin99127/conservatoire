using conservatoire.Controleur;
using conservatoire.Modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace conservatoire
{
    public partial class form4 : Form
    {
        Mgr monManager;
        Prof prof;
        public form4(Prof unProf)
        {
            InitializeComponent();
            monManager = new Mgr();
            this.prof = unProf;
        }
        private void form4_Load(object sender, EventArgs e)
        {
            
        }

        //ajouter le prof
        private void button1_Click(object sender, EventArgs e)
        {
            int id = 1;
            string nom = textBox1.Text;
            string prenom = textBox2.Text;
            string tel = textBox3.Text;
            string mail = textBox4.Text;
            string adresse = textBox5.Text;
            string instrument = textBox6.Text;
            double salaire = Convert.ToDouble(textBox7.Text);

            List<string> Instrument = monManager.chargementInstruBD();
            bool exist = false;

            foreach(string instru in Instrument)
            {
                if(instrument == instru)
                {
                    exist = true;
                    break;
                }
            }
            if (!exist)
            {
                MessageBox.Show("cet instrument n'existe pas");
            }
            else
            {
                Prof nProf = new Prof(id, nom, prenom, tel, mail, adresse, instrument, salaire);
                monManager.insertProf(nProf);
                MessageBox.Show("un prof a été ajouté");
            }
        }

        //supprimer
        private void button2_Click(object sender, EventArgs e)
        {
            monManager.suppProf(this.prof);
            MessageBox.Show("un prof a été supprimé");
        }
    }
}
