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
    public partial class Informacije_o_reziserima : Form
    {
        public DataProvider dp;
        public Informacije_o_reziserima()
        {
            this.dp = new DataProvider();
            this.dp.PoveziBazu();
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ProveriPolja())
            {
                if (this.dp.AddReziser(textBox1.Text, textBox2.Text, textBox3.Text))
                {
                    MessageBox.Show("Reziser je uspesno dodat u bazu podataka.");
                }
                else
                {
                    MessageBox.Show("Doslo je do greske prilikom dodavanja rezisera u bazu podataka.");
                }
            }
            else
            {
                MessageBox.Show("Unesite podatke u sva polja.");
            }
        }
        private bool ProveriPolja()
        {
            return textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" ? true : false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.ProveriPolja())
            {
                if (this.dp.DeleteReziser(textBox1.Text, textBox2.Text, textBox3.Text))
                {
                    MessageBox.Show("Reziser je uspesno izbrisan iz baze podataka.");
                }
                else
                {
                    MessageBox.Show("Doslo je do greske prilikom brisanja rezisera iz baze podataka. Neki od podataka je pogresno unesen ili reziser ne postoji u bazi podataka.");
                }
            }
            else
            {
                MessageBox.Show("Unesite podatke u sva polja.");
            }
        }
    }
}
