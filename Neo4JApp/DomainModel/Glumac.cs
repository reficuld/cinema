using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4JApp.DomainModel
{
    public class Glumac
    {
        public String id { get; set; }
        public String ime { get; set; }
        public String godinaRodjenja { get; set; }
        public String mestoRodjenja { get; set; }
        public Glumac() { }
        public Glumac(String id, String ime, String godinaRodjenja, String mestoRodjenja)
        {
            this.id = id;
            this.ime = ime;
            this.godinaRodjenja = godinaRodjenja;
            this.mestoRodjenja = mestoRodjenja;
        }
    }
}
