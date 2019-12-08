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
    public partial class NoviKorisnik : Form
    {
        public NoviKorisnik()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            DataProvider dp = new DataProvider();
            if (dp.PoveziBazu() > 0)
            {
                if (dp.AddGost(txtUser.Text, txtLoz.Text))
                    MessageBox.Show("Uspesno kreiran korisnik!");
                else MessageBox.Show("Nije moguce kreirati korisnika! Pokusajte sa drugacijim korisnickim imenom i sifrom");
            }
            else MessageBox.Show("Nije moguce povezati se sa bazom!");
        }
    }
}
