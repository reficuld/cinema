using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4JApp.DomainModel
{
    public class Sala
    {
        public Bioskop bioskop { get; set; }
        public String brojSale { get; set; }
        public String brojSedista { get; set; }
        public String brojRedova { get; set; }
        public String brojSedistaPoRedu { get; set; }
        public Sala() { }
        public Sala(Bioskop bioskop, String brojSale, String brojSedista)
        {
            this.bioskop = bioskop;
            this.brojSale = brojSale;
            this.brojSedista = brojSedista;
        }
    }
}
