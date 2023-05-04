using conservatoire.Controleur;
using conservatoire.DAL;
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
        List<Trimestre> trim = new List<Trimestre>();
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
        public void afficheT()
        {
            try
            {
                listBox2.DataSource = trim;
                listBox2.DisplayMember = "Description";
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            trim = monManager.getTrim(((Inscription)listBox1.SelectedItem).IdEleve, ((Inscription)listBox1.SelectedItem).NumSeance);

            afficheT();
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = ((Trimestre)listBox2.SelectedItem).DatePaie.ToString("yyyy/MM/dd");
        }
        private void listBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            //ListBox listBox = (ListBox)sender;

            //ListBoxItem item = (ListBoxItem)listBox.Items[e.Index];

            e.DrawBackground();

            Brush brush = Brushes.Black; // seulement s'il y a un problème

            if (((Trimestre)listBox2.Items[e.Index]).Paye == "non")
            {
                brush = Brushes.Red; // si c'est pas encore payé
            }
            else
            {
                brush = Brushes.Green; // si c'est payé
            }

            //TextRenderer.DrawText(e.Graphics, (string)listBox2.Items[e.Index], listBox2.Font, e.Bounds, listBox1.ForeColor, TextFormatFlags.Left);
            e.Graphics.DrawString(((Trimestre)listBox2.Items[e.Index]).Description, e.Font, brush, e.Bounds, StringFormat.GenericDefault);
        }

        //confirmer
        private void button1_Click(object sender, EventArgs e)
        {
            string date = textBox1.Text;
            int idEleve = ((Inscription)listBox1.SelectedItem).IdEleve;
            int numSeance = ((Inscription)listBox1.SelectedItem).NumSeance;
            string libelle = ((Trimestre)listBox2.SelectedItem).Libelle;

            monManager.updatePayer(date, idEleve, numSeance, libelle);
        }

        //rafraichir
        private void button2_Click(object sender, EventArgs e)
        {
            /*inscrit = monManager
            trim = monManager.getTrim(int ideleve, int numseance);

            afficheT();*/
        }
    }
}
