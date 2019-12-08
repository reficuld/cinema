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
    public partial class Dodaj_prikaz : Form
    {
        public DataProvider dp;
        public Dodaj_prikaz()
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
            String proj;
            if (checkBox1.Checked)
                proj = "3D";
            else proj = "2D";
            if (this.ProveriPolja())
            {
                if (this.dp.AddPrikaz(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, proj, textBox7.Text))
                {
                    MessageBox.Show("Prikaz je uspesno dodat u bazu podataka.");
                }
                else
                {
                    MessageBox.Show("Doslo je do greske prilikom dodavanja prikaza u bazu podataka.");
                }
            }
            else
            {
                MessageBox.Show("Unesite podatke u sva polja.");
            }
        }
        private bool ProveriPolja()
        {
            return textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" ? true : false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            String proj;
            if (checkBox1.Checked)
                proj = "3D";
            else proj = "2D";
            if (this.ProveriPolja())
            {
                if (this.dp.DeletePrikaz(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, proj, textBox7.Text))
                {
                    MessageBox.Show("Prikaz je uspesno izbrisan iz baze podataka.");
                }
                else
                {
                    MessageBox.Show("Doslo je do greske prilikom brisanja prikaza iz baze podataka. Neki od podataka je pogresno unesen ili prikaz ne postoji u bazi podataka.");
                }
            }
            else
            {
                MessageBox.Show("Unesite podatke u sva polja.");
            }
        }
    }
}
