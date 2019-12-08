using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neo4JApp
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dodaj_film noviFilm = new Dodaj_film();
            noviFilm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dodaj_prikaz noviPrikaz = new Dodaj_prikaz();
            noviPrikaz.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dodaj_salu novaSala = new Dodaj_salu();
            novaSala.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dodaj_bioskop noviBioskop = new Dodaj_bioskop();
            noviBioskop.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Informacije_o_glumcima iof = new Informacije_o_glumcima();
            iof.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Informacije_o_reziserima ior = new Informacije_o_reziserima();
            ior.Show();
        }
    }
}
