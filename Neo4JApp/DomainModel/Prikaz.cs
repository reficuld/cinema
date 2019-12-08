using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4JApp.DomainModel
{
    public class Prikaz
    {
        public Sala sala { get; set; }
        public Film film { get; set; }
        public Bioskop bioskop { get; set; }
        public String datum { get; set; }
        public String vreme { get; set; }
        public String projekcija { get; set; }
        public String cena { get; set; }

        public Prikaz() { }
        public Prikaz(Sala sala, Film film, Bioskop bioskop, String datum, String vreme, String projekcija, String cena)
        {
            this.sala = sala;
            this.film = film;
            this.bioskop = bioskop;
            this.datum = datum;
            this.vreme = vreme;
            this.projekcija = projekcija;
            this.cena = cena;
        }
    }
}
