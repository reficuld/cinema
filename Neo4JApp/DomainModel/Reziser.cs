using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4JApp.DomainModel
{
    public class Reziser
    {
        public String ime { get; set; }
        public String datumRodjenja { get; set; }
        public String mestoRodjenja { get; set; }
        public Reziser() { }
        public Reziser(String ime, String datumRodjenja, String mestoRodjenja)
        {
            this.ime = ime;
            this.datumRodjenja = datumRodjenja;
            this.mestoRodjenja = mestoRodjenja;
        }
    }
}
