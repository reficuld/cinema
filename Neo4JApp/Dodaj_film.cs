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
    public partial class Dodaj_film : Form
    {
        public List<String> glumci;
        public String reziser;
        public String godinaIzdavanja;
        public String imeFilma;
        public Dodaj_film()
        {
            this.glumci = new List<String>();
            InitializeComponent();
        }

        private void Dodaj_film_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Glumac1 gl = new Glumac1(this.glumci);
            gl.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataProvider dp = new DataProvider();
            dp.PoveziBazu();
            this.imeFilma = textBox1.Text;
            this.godinaIzdavanja = textBox2.Text;
            this.reziser = textBox3.Text;
            if(this.glumci==null || this.reziser=="" || this.godinaIzdavanja=="" || this.imeFilma == "")
            {
                MessageBox.Show("Unesite sve podatke o filmu.");
            }
            else if(!dp.AddFilm(this.imeFilma, this.godinaIzdavanja, this.reziser, this.glumci))
            {
                MessageBox.Show("Doslo je do greske prilikom unosa filma u bazu potaka.");
                return;
            }
            MessageBox.Show("Podaci o filmu su uspesno dodati u bazu podataka.");
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
