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
    public partial class Glumac1 : Form
    {
        public List<String> glumci;
        public Glumac1(List<String> glumci)
        {
            this.glumci = glumci;
            InitializeComponent();
        }

        private void Glumac_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.glumci.Add(textBox1.Text);
            this.Close();
        }
    }
}
