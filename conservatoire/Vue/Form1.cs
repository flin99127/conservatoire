﻿using System;
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

namespace conservatoire
{
    public partial class Form1 : Form
    {
        Mgr monManager;
        public Form1()
        {
            InitializeComponent();
            monManager = new Mgr();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(monManager.verifLogin(textBox1.Text, textBox2.Text))
            {
                this.Hide();
                form2 f2 = new form2();
                f2.ShowDialog();
            }
            else
            {
                MessageBox.Show("ERREUR, réesayez");
            }
        }
    }
}
