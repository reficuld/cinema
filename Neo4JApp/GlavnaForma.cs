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
    public partial class GlavnaForma : Form
    {
        private List<Prikaz> prikazi;
        private List<Bioskop> bioskops;
        private List<Sala> sala;
        private List<Film> filmovi;
        private List<Sediste> sedisteSala;
        private Rezervacija rezervacija;
        private List<Button> dugmici;
        private double cena;
        private bool _3D = false;
        private int brojRedova, brojSedisapoRedu;

        public GlavnaForma()
        {
            bioskops = new List<Bioskop>();
            prikazi = new List<Prikaz>();
            sedisteSala = new List<Sediste>();
            sala = new List<Sala>();
            dugmici = new List<Button>();
            filmovi = new List<Film>();
            rezervacija = new Rezervacija();
            cena = 0;
          //  label10.Text = cena.ToString();
            InitializeComponent();
            checkBox1.Checked = _3D;
        }
        public GlavnaForma(Gost gost)
            :this()
        {
            rezervacija.gost = gost;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GlavnaForma_Load(object sender, EventArgs e)
        {
            DataProvider dp = new DataProvider();
            if (dp.PoveziBazu() > 0)
            {
                bioskops = dp.GetBioskops();


                foreach (Bioskop b in bioskops)
                {
                    cbxBioskop.Items.Add(b.naziv);
                }
            }
            Button urlButton = new Button();
            urlButton.Name = "urlButton";
            urlButton.Text = "Open URL in Browser";
           // flowLayoutPanel1.Controls.Add(urlButton);
        }

        private void cbxBioskop_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxDatum.SelectedIndex = -1;
            DataProvider dp = new DataProvider();
            if (dp.PoveziBazu() > 0)
            {
                if (cbxBioskop.SelectedIndex == -1)
                    return;
                else
                {
                    flowLayoutPanel1.Controls.Clear();
                    cbxFilm.SelectedIndex = -1;
                    cbxFilm.Items.Clear();
                    cbxDatum.SelectedIndex = -1;
                    cbxDatum.Items.Clear();
                    cbxVreme.SelectedIndex = -1;
                    cbxVreme.Items.Clear();
                    cbxSala.SelectedIndex = -1;
                    cbxSala.Items.Clear();


                    prikazi = dp.getPrikazi(bioskops[cbxBioskop.SelectedIndex].naziv);
                    foreach (Prikaz p in prikazi)
                    {
                        if(!cbxDatum.Items.Contains(p.datum))
                            cbxDatum.Items.Add(p.datum);
                       
                        //ovde ubaciti cenu i projekciju
                    }
                }
            }
        }

        private void cbxDatum_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxVreme.SelectedIndex = -1;
            DataProvider dp = new DataProvider();
            if (dp.PoveziBazu() > 0)
            {
                if (cbxDatum.SelectedIndex == -1)
                    return;
                    
                else
                {
                    flowLayoutPanel1.Controls.Clear();
                    cbxFilm.SelectedIndex = -1;
                    cbxFilm.Items.Clear();
                    cbxVreme.SelectedIndex = -1;
                    cbxVreme.Items.Clear();
                    cbxSala.SelectedIndex = -1;
                    cbxSala.Items.Clear();
                    filmovi = dp.getFilmovi(cbxDatum.Text, cbxBioskop.Text, checkBox1.Checked);
                    foreach (Film f in filmovi)
                        if(!cbxFilm.Items.Contains(f.naziv))
                            cbxFilm.Items.Add(f.naziv);
                   
                }


            }

        }

        private void cbxVreme_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataProvider dp = new DataProvider();
            if (dp.PoveziBazu() > 0)
            { 
                if (cbxVreme.SelectedIndex == -1)
                    return;
                else
                {
                    flowLayoutPanel1.Controls.Clear();
                    cbxSala.SelectedIndex = -1;
                    cbxSala.Items.Clear();
                    sala = dp.getSala(cbxDatum.Text, cbxVreme.Text);
                    foreach (Sala s in sala)
                        cbxSala.Items.Add(s.brojSale);
                }

            }
        }

        private void cbxFilm_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataProvider dp = new DataProvider();
            if(dp.PoveziBazu()>0)
            {
                if (cbxFilm.SelectedIndex == -1)
                    return;
                else
                {
                    flowLayoutPanel1.Controls.Clear();
                    cbxVreme.SelectedIndex = -1;
                    cbxVreme.Items.Clear();
                    cbxSala.SelectedIndex = -1;
                    cbxSala.Items.Clear();
                    foreach (Prikaz p in prikazi)
                        if (p.datum == cbxDatum.Text && !cbxVreme.Items.Contains(p.vreme))
                            cbxVreme.Items.Add(p.vreme);
                }
            }
        }

        private void cbxSala_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataProvider dp = new DataProvider();
            Sala sala = new Sala();
            if (dp.PoveziBazu() > 0)
            {
                if (cbxSala.SelectedIndex == -1)
                    return;
                else
                {
                    Size q = new Size();
                    q.Width = 0;
                    flowLayoutPanel1.Controls.Clear();
                    flowLayoutPanel1.MaximumSize = q;
                    sala = dp.GetSala(cbxSala.Text, cbxBioskop.Text);
                    int.TryParse(sala.brojRedova, out brojRedova);
                    int.TryParse(sala.brojSedistaPoRedu, out brojSedisapoRedu);
                    Size s = new Size();
                    s.Width = 20;
                    s.Height = 20;
                    Size z = new Size();
                    int j;
                    Button b = new Button();
                    
                    for (int i = 0; i < brojRedova; i++)
                    {

                        for (j = 0; j < brojSedisapoRedu; j++)
                        {
                            b = new Button();
                            b.Click += (object sender2, EventArgs e2) =>
                            {
                                Button button = sender2 as Button;
                             //   MessageBox.Show(button.Name);
                                if (button.BackColor != Color.Blue)
                                {
                                    label10.Visible = true;
                                    String[] ime = button.Name.Split(',');
                                    Sediste sed = new Sediste();
                                    sed.red = ime[0];
                                    sed.brojSedista = ime[1];
                                    sed.zauzeto = true;
                                    sedisteSala.Add(sed);
                                    dugmici.Add(button);
                                    button.BackColor = Color.Blue;
                
                                    label10.Text = (cena * sedisteSala.Count).ToString()+" RSD";
                                    
                                }
                                else
                                {
                                    String[] ime = button.Name.Split(',');
                                    Sediste sed = new Sediste();
                                    sed.red = ime[0];
                                    sed.brojSedista = ime[1];
                                    sed.zauzeto = true;
                                    foreach(Sediste sedi in sedisteSala)
                                    {
                                        if (sedi.brojSedista == sed.brojSedista && sedi.red == sed.red)
                                        {
                                            sedisteSala.Remove(sedi);
                                            return;
                                        }
                                        
                                    }
                                    dugmici.Remove(button);
                                    button.BackColor = Color.LightGray;
                                    label10.Text = (cena * sedisteSala.Count).ToString()+" RSD";

                                }
                                
                            };
                            b.BackColor = Color.LightGray;
                            b.Name = i.ToString() + "," + j.ToString();
                            b.Text = j.ToString();
                            b.Size = s;
                            flowLayoutPanel1.Controls.Add(b);

                        }
                        z.Width = flowLayoutPanel1.Width;
                        flowLayoutPanel1.MaximumSize = z;


                    }

                    Prikaz p =dp.GetPrikazi2(cbxSala.Text, cbxDatum.Text, cbxVreme.Text, cbxBioskop.Text);
                    rezervacija.prikaz = p;
                    double.TryParse(p.cena, out cena);
                }
            }
                //OVDE UBACITI RACUNANJE CENE I SEDISTA
                //REDOVI SU VODORAVNO xD
              

        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btnRezervisi_Click(object sender, EventArgs e)
        {
            DataProvider dp = new DataProvider();
            if(dp.PoveziBazu()>0)
            {
                rezervacija.brojRezSedista = sedisteSala.Count.ToString();
                rezervacija.sedista = sedisteSala;
                if (dp.napraviSediste(rezervacija, cbxBioskop.Text, cbxSala.Text))
                    MessageBox.Show("Uspesno ste zakazali!");
                else
                    MessageBox.Show("Greska!");
                
            }
            foreach(Button b in dugmici)
            {
                b.Enabled = false;
                b.BackColor = Color.Red;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            cbxVreme.SelectedIndex = -1;
            DataProvider dp = new DataProvider();
            if (dp.PoveziBazu() > 0)
            {
                if (cbxDatum.SelectedIndex == -1)
                    return;

                else
                {
                    flowLayoutPanel1.Controls.Clear();
                    cbxFilm.SelectedIndex = -1;
                    cbxFilm.Items.Clear();
                    cbxVreme.SelectedIndex = -1;
                    cbxVreme.Items.Clear();
                    cbxSala.SelectedIndex = -1;
                    cbxSala.Items.Clear();
                    filmovi = dp.getFilmovi(cbxDatum.Text, cbxBioskop.Text, checkBox1.Checked);
                    foreach (Film f in filmovi)
                        if (!cbxFilm.Items.Contains(f.naziv))
                            cbxFilm.Items.Add(f.naziv);

                }


            }
        }
    }
}
