using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4JApp.DomainModel
{
    public class Rezervacija
    {
        public Gost gost { get; set; }
        public List<Sediste> sedista { get; set;  }
        public Prikaz prikaz { get; set; }
        public String brojRezSedista { get; set; }

        
    }
}
