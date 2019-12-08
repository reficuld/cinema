using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neo4JApp.DomainModel;


namespace Neo4JApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NoviKorisnik nk = new NoviKorisnik();
            nk.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataProvider dp = new DataProvider();
            if (dp.PoveziBazu() > 0)
            {
                List<Glumac> glum = dp.GetGlumci("s");
                foreach (Glumac g in glum)
                    MessageBox.Show(g.ime + " " + g.godinaRodjenja + " "+g.mestoRodjenja);
            }
            else return;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataProvider dp = new DataProvider();
            if (dp.PoveziBazu() > 0)
            {
                Gost g = dp.GetGost(textBox1.Text, textBox2.Text);
                if (g!=null)
                {
                    GlavnaForma gff = new GlavnaForma(g);
                    gff.Show();
                }

                else MessageBox.Show("Ne postoji korisnik sa tim imenom i sifrom, pokusajte ponovo ili napravite novi nalog!");
            }
            else MessageBox.Show("Neuspesno povezivanje sa bazom!");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*da se dodaje film,prikaz,sale, bioskop*/
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Mozete koristiti username:user i password:user");
        }
    }
}
