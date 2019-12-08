using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4JApp.DomainModel
{
    public class Bioskop
    {
        public String naziv { get; set; }
        public String grad { get; set; }
        public String adresa { get; set; }
        public String brojSala { get; set; }
        public Bioskop() { }
        public Bioskop(String naziv, String grad, String adresa, String brojSala)
        {
            this.naziv = naziv;
            this.grad = grad;
            this.adresa = adresa;
            this.brojSala = brojSala;
        }
    }
}
