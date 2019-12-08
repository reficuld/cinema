using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4JApp.DomainModel
{
    public class Uloga
    {
        public Film film { get; set; }
        public Glumac glumac { get; set; }
        public String uloga { get; set; }
        public Uloga(Film film, Glumac glumac, String uloga)
        {
            this.film = film;
            this.glumac = glumac;
            this.uloga = uloga;
        }
    }
}
