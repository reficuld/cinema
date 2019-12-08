using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4JApp.DomainModel
{
    public class Film
    {
        public String naziv { get; set; }
        public String godinaIzdavanja { get; set; }
        public List<Glumac> glumci { get; set; }
        public Reziser reziser { get; set; }
        public Film() { }
        public Film(String naziv, String godinaIzdavanja,List<Glumac> glumci, Reziser reziser)
        {
            this.naziv = naziv;
            this.godinaIzdavanja = godinaIzdavanja;
            this.glumci = glumci;
            this.reziser=reziser;
        }
    }
}
