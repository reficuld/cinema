using Neo4JApp.DomainModel;
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
    public partial class Dodaj_bioskop : Form
    {
        public BindingList<Bioskop> bioskopi;
        DataProvider dp = new DataProvider();

        public Dodaj_bioskop()
        {
            this.dp.PoveziBazu();
            this.bioskopi = new BindingList<Bioskop>(this.dp.GetBioskope());
            InitializeComponent();
            this.dataGridView1.DataSource = this.bioskopi;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                if (this.dp.AddBioskop(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text))
                {
                    MessageBox.Show("Bioskop uspesno dodat u bazu podataka.");
                }
                else
                {
                    MessageBox.Show("Doslo je do greske prilikom upisa informacija o bioskopu u bazu podataka.");
                }
            }
            else
            {
                MessageBox.Show("Nije uneta vrednost u svim poljima za dodavanje bioskopa!");
            }
        }

        private void Dodaj_bioskop_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null) {
                if (this.dp.DeleteBioskop(dataGridView1.CurrentRow.Cells[1].Value.ToString(), dataGridView1.CurrentRow.Cells[2].Value.ToString()))
                {
                    MessageBox.Show("Uspesno je obrisan selektovani bioskop iz baze podataka.");
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                }
                else
                {
                    MessageBox.Show("Doslo je do greske prilikom brisanja selektovanog bioskopa iz baze podataka.");
                }
            }
        }
    }
}
