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
    public partial class Dodaj_salu : Form
    {
        public DataProvider dp;
        public Dodaj_salu()
        {
            dp = new DataProvider();
            dp.PoveziBazu();
            InitializeComponent();
        }

        private void Dodaj_salu_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                if (this.dp.AddSala(textBox1.Text, textBox2.Text, textBox3.Text, textBox6.Text))
                {
                    MessageBox.Show("Sala je uspesno dodata u bazu podataka.");
                }
                else
                {
                    MessageBox.Show("Sala nije uspesno dodata u bazu podataka.");
                }
            }
            else
            {
                MessageBox.Show("Popunite sva polja za unos sale u bazu podataka.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && textBox5.Text != "")
            {
                if (this.dp.DeleteSala(textBox4.Text, textBox5.Text))
                {
                    MessageBox.Show("Sala je uspesno izbrisana iz baze podataka.");
                }
                else
                {
                    MessageBox.Show("Sala nije uspesno izbrisana iz baze podataka. Neki od podataka je pogresno unesen ili sala ne postoji u bazi podataka.");
                }
            }
            else
            {
                MessageBox.Show("Unesite podatke u svim poljima kako bi ste obrisali salu iz baze podataka.");
            }
        }
    }
}
