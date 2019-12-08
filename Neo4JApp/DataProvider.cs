using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;
using Neo4jClient.Cypher;
using Neo4JApp.DomainModel;

namespace Neo4JApp
{
    public class DataProvider
    {
        private GraphClient client;
   
        public int PoveziBazu()
        {
            
            client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "123");
            try
            {
                client.Connect();
            }
            catch (Exception exc)
            {
                return -1;
            }
            return 1;
        }


        public bool Isti(List<Glumac> g1, Glumac g2)
        {
            foreach(Glumac g in g1)
            {
                if (g.id == g2.id)
                    return true;
            }
            return false;

        }


        public List<Glumac> GetGlumci()
        {
            var query = new CypherQuery("match (n:Glumac) return n;", new Dictionary<string, object>(), CypherResultMode.Set);

            List<Glumac> glumci = ((IRawGraphClient)client).ExecuteGetCypherResults<Glumac>(query).ToList();
            return glumci;
        }


        public List<Glumac> GetGlumci(String imeOrGodRodj)
        {
            string imeGl = ".*" + imeOrGodRodj + ".*";
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("imeGod", imeGl);

            var query = new CypherQuery("match (n:Glumac) where exists(n.ime) and n.ime =~ {imeGod} return n;",
                                                            queryDict, CypherResultMode.Set);
            var query2 = new CypherQuery("match (n:Glumac) where exists(n.godinaRodjenja) and n.godinaRodjenja =~ {imeGod} return n;",
                                                            queryDict, CypherResultMode.Set);
            var query3 = new CypherQuery("match (n:Glumac) where exists(n.mestoRodjenja) and n.mestoRodjenja =~ {imeGod} return n;", 
                                                            queryDict, CypherResultMode.Set);

            List<Glumac> glumci = ((IRawGraphClient)client).ExecuteGetCypherResults<Glumac>(query).ToList();
            List<Glumac> glumci2 = ((IRawGraphClient)client).ExecuteGetCypherResults<Glumac>(query2).ToList();
            List<Glumac> glumci3 = ((IRawGraphClient)client).ExecuteGetCypherResults<Glumac>(query3).ToList();


            foreach (Glumac g in glumci2)
            {
                if(!Isti(glumci, g))
                    glumci.Add((Glumac)g);
            }
            foreach (Glumac gl in glumci3)
            {
                if (!Isti(glumci, gl))
                    glumci.Add((Glumac)gl);
            }
           
            return glumci;
            

        }


        public Gost GetGost(String user, String pass)
        {
            var query = new CypherQuery("match (n:Gost) where n.userName='" + user + "' and n.passWord = '" + pass + "' return n",
                                                new Dictionary<string, object>(), CypherResultMode.Set);

            
            try
            {
                Gost g = ((IRawGraphClient)client).ExecuteGetCypherResults<Gost>(query).SingleOrDefault();
                return g;
            }

            catch(Exception e)
            {
                return null;
            }

          
        }


       


        public bool AddGost(String user, String pass)
        {
            var query = new CypherQuery("create (n:Gost {userName:'" + user + "' , passWord:'" + pass + "'})", new Dictionary<string, object>(), CypherResultMode.Set);

            var queryProvera = new CypherQuery("match (n:Gost) where n.userName='" + user + "' return n;", new Dictionary<string, object>(), CypherResultMode.Set);
            Gost g = ((IRawGraphClient)client).ExecuteGetCypherResults<Gost>(queryProvera).SingleOrDefault();
            if (g!=null)
                return false;

            try
            {
                ((IRawGraphClient)client).ExecuteCypher(query);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }


        public bool AddBioskop(String naziv, String grad, String adresa, String brojSala)
        {
            var query = new CypherQuery("create (n:Bioskop {naziv:'" + naziv + "', adresa:'" + adresa + "', grad:'"+grad+"', brojSala:'"+brojSala+"'})", new Dictionary<string, object>(), CypherResultMode.Set);

            var queryProvera = new CypherQuery("match (n:Bioskop {adresa:'" + adresa + "'}) return n;", new Dictionary<string, object>(), CypherResultMode.Set);
            Bioskop g = ((IRawGraphClient)client).ExecuteGetCypherResults<Bioskop>(queryProvera).SingleOrDefault();
            if (g != null)
                return false;
            try
            {
                ((IRawGraphClient)client).ExecuteCypher(query);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }


        public List<Bioskop> GetBioskope()
        {
            var query = new CypherQuery("match (n:Bioskop) return n;", new Dictionary<string, object>(), CypherResultMode.Set);

            List<Bioskop> bioskopi = ((IRawGraphClient)client).ExecuteGetCypherResults<Bioskop>(query).ToList();
            return bioskopi;
        }


        public bool DeleteBioskop(String grad,String adresa)
        {
            var query = new CypherQuery("match (n:Bioskop {adresa:'" + adresa + "', grad:'"+grad+"'}) with n, n.adresa AS adresa detach delete n return adresa;", new Dictionary<string, object>(), CypherResultMode.Set);
            String adresa1 = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query).SingleOrDefault();
            if (adresa1 == null)
            {
                return false;
            }
            return true;
        }


        public bool AddFilm(String naziv, String godinaIzdavanja, String reziser, List<String> glumci)
        {
            var query1 = new CypherQuery("match (r:Reziser {ime:'"+reziser+"'}) return r;",new Dictionary<string, object>(), CypherResultMode.Set);
            Reziser rez = ((IRawGraphClient)client).ExecuteGetCypherResults<Reziser>(query1).SingleOrDefault();
            if (rez == null)
            {
                return false;
            }
            bool zaReturn = true;
            glumci.ForEach(el=> {
                var query2 = new CypherQuery("match (g:Glumac {ime:'" + el + "'}) return g;", new Dictionary<string, object>(), CypherResultMode.Set);
                Glumac gl = ((IRawGraphClient)client).ExecuteGetCypherResults<Glumac>(query2).SingleOrDefault();
                if (gl == null)
                {
                    zaReturn = false;
                }
            });
            if (!zaReturn)
            {
                return zaReturn;
            }
            var query = new CypherQuery("create (f:Film {naziv:'" + naziv + "', godinaIzdavanja: '" + godinaIzdavanja + "'})", new Dictionary<string, object>(), CypherResultMode.Set);
            try
            {
                ((IRawGraphClient)client).ExecuteCypher(query);
            }
            catch (Exception e)
            {
                return false;
            }
            var query3 = new CypherQuery("match (f:Film),(r:Reziser)"+
                "where f.naziv = '"+naziv+"' AND f.godinaIzdavanja = '"+godinaIzdavanja+"' AND r.ime = '"+reziser+
                "'create (r) -[:REZIRAO]->(f)", new Dictionary<string, object>(), CypherResultMode.Set);
            String a;
            try
            {
                ((IRawGraphClient)client).ExecuteCypher(query3);
            }
            catch (Exception e)
            {
                a = e.Message;
                return false;
            }
            glumci.ForEach(el => {
                var query4 = new CypherQuery("match (f:Film), (g:Glumac)"+
                   "where f.naziv = '" + naziv + "' AND f.godinaIzdavanja = '" + godinaIzdavanja + "' AND g.ime = '" + el +
                    "'create (g) -[:GLUMIO]->(f) return g;", new Dictionary<string, object>(), CypherResultMode.Set);
                Glumac gl = ((IRawGraphClient)client).ExecuteGetCypherResults<Glumac>(query4).SingleOrDefault();
                if (gl == null)
                {
                    zaReturn = false;
                }
            });
            if (!zaReturn)
            {
                return zaReturn;
            }
            return true;
        }


        public bool AddSala(String nazivBioskopa, String brojSale, String brojSedista, String brojRedova)
        {
            var query = new CypherQuery("match (b:Bioskop {naziv:'" + nazivBioskopa + "'}) return b;", new Dictionary<string, object>(), CypherResultMode.Set);
            Bioskop kino = ((IRawGraphClient)client).ExecuteGetCypherResults<Bioskop>(query).SingleOrDefault();
            if (kino == null)
            {
                return false;
            }
            var query1 = new CypherQuery("match (b:Bioskop {naziv:'" + nazivBioskopa + "'})"+
                    "create (s:Sala {brojSale:'" + brojSale+"', brojRedova: '"+brojRedova+ "', brojSedistaPoRedu:'"+brojSedista+"'})"+
                    "create (b)-[:POSEDUJE]->(s) return s", new Dictionary<string, object>(), CypherResultMode.Set);
            Sala sala = ((IRawGraphClient)client).ExecuteGetCypherResults<Sala>(query1).SingleOrDefault();
            if (sala == null)
            {
                return false;
            }
            return true;
        }


        public bool DeleteSala(String nazivBioskopa, String brojSale)
        {
            var query = new CypherQuery("match (b:Bioskop {naziv:'" + nazivBioskopa + "'}), (s:Sala {brojSale:'" + brojSale + "'}) with s, s.brojSale AS brojSale where (b)-[:POSEDUJE]->(s) detach delete s return brojSale;", new Dictionary<string, object>(), CypherResultMode.Set);
            String brojSale1 = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query).SingleOrDefault();
            if (brojSale1 == null)
            {
                return false;
            }
            return true;
        }


        public bool AddGlumac(String ime, String godinaRodjenja, String mestoRodjenja)
        {
            var query = new CypherQuery("create (g:Glumac {ime:'" + ime + "', mestoRodjenja: '"+mestoRodjenja+"', godinaRodjenja:'"+godinaRodjenja+"'})", new Dictionary<string, object>(), CypherResultMode.Set);
            try
            {
                ((IRawGraphClient)client).ExecuteCypher(query);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }


        public bool DeleteGlumac(String ime, String godinaRodjenja, String mestoRodjenja)
        {
            var query = new CypherQuery("match (g:Glumac {ime:'" + ime + "', mestoRodjenja: '" + mestoRodjenja + "', godinaRodjenja:'" + godinaRodjenja + "'}) with g, g.ime AS ime detach delete g return ime;", new Dictionary<string, object>(), CypherResultMode.Set);
            String glumac = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query).SingleOrDefault();
            if (glumac == null)
            {
                return false;
            }
            return true;
        }


        public bool AddReziser(String ime, String godinaRodjenja, String mestoRodjenja)
        {
            var query = new CypherQuery("create (r:Reziser {ime:'" + ime + "', mestoRodjenja: '" + mestoRodjenja + "', godinaRodjenja:'" + godinaRodjenja + "'})", new Dictionary<string, object>(), CypherResultMode.Set);
            try
            {
                ((IRawGraphClient)client).ExecuteCypher(query);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }


        public bool DeleteReziser(String ime, String godinaRodjenja, String mestoRodjenja)
        {
            var query = new CypherQuery("match (r:Reziser {ime:'" + ime + "', mestoRodjenja: '" + mestoRodjenja + "', godinaRodjenja:'" + godinaRodjenja + "'}) with r, r.ime AS ime detach delete r return ime;", new Dictionary<string, object>(), CypherResultMode.Set);
            String reziser = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query).SingleOrDefault();
            if (reziser == null)
            {
                return false;
            }
            return true;
        }


        public List<Prikaz> GetPrikazi()
        {
            var query = new CypherQuery("match (n:Prikaz) return n;", new Dictionary<string, object>(), CypherResultMode.Set);

            var query2 = new CypherQuery("match (f:Film)<-[:EMITUJE]-(p:Prikaz) return f;", new Dictionary<string, object>(), CypherResultMode.Set);





            List<Prikaz> prikazi = ((IRawGraphClient)client).ExecuteGetCypherResults<Prikaz>(query).ToList();

            foreach (Prikaz p in prikazi)
            {
                var quew = new CypherQuery("match (b:Bioskop)-[:PRIKAZUJE]->(p:Prikaz {}) return f;", new Dictionary<string, object>(), CypherResultMode.Set);
            }
            return prikazi;
        }


        public bool AddPrikaz(String nazivFilma, String nazivBioskopa, String brojSale, String datum, String vreme, String projekcija, String cena)
        {
            var query = new CypherQuery("match (f:Film {naziv:'"+nazivFilma+"'}), (b:Bioskop {naziv:'"+nazivBioskopa+"'}), (s:Sala {brojSale:'"+brojSale+"'}) where (b)-[:POSEDUJE]->(s)"+
                "create (p:Prikaz {datum:'" + datum + "', vreme: '" + vreme + "', projekcija: '"+ projekcija +"', cena: '"+ cena +"'})"+
                "create "+
                    "(p)-[:U_SALI]->(s), "+
                    "(b)-[:PRIKAZUJE]->(p), " +
                    "(p)-[:EMITUJE]->(f)" +
                    "return p;", new Dictionary<string, object>(), CypherResultMode.Set);
            var query1 = new CypherQuery("match (f:Film {naziv:\"" + nazivFilma + "\"}), (b:Bioskop {naziv:\"" + nazivBioskopa + "\"}), (s:Sala {brojSale:'" + brojSale + "'}) where (b)-[:POSEDUJE]->(s) return f;", new Dictionary<string, object>(), CypherResultMode.Set);
            Film result = ((IRawGraphClient)client).ExecuteGetCypherResults<Film>(query1).SingleOrDefault();
            if (result == null)
            {
                return false;
            }
            Prikaz p = ((IRawGraphClient)client).ExecuteGetCypherResults<Prikaz>(query).SingleOrDefault();
            if (p == null)
            {
                return false;
            }
            return true;
        }


        public bool DeletePrikaz(String nazivFilma, String nazivBioskopa, String brojSale, String datum, String vreme, String projekcija, String cena)
        {
            var query = new CypherQuery("match (p:Prikaz {datum:'" + datum + "', vreme: '" + vreme + "', projekcija: '"+ projekcija +"', cena: '"+cena+"'}), " +
                "                           (f:Film {naziv:\"" + nazivFilma + "\"}), (b:Bioskop {naziv:'" + nazivBioskopa + "'}), (s:Sala {brojSale:'" + brojSale + "'}) with p, p.datum AS datum " +
                "where (b)-[:POSEDUJE]->(s) and " +
                "(p)-[:U_SALI]->(s) and "+
                    "(b)-[:PRIKAZUJE]->(p) and " +
                    "(p)-[:EMITUJE]->(f)" + " detach delete p return datum;", new Dictionary<string, object>(), CypherResultMode.Set);
            String prikaz = ((IRawGraphClient)client).ExecuteGetCypherResults<String>(query).SingleOrDefault();
            if (prikaz == null)
            {
                return false;
            }
            return true;
        }

        public List<Bioskop> GetBioskops()
        {
            var query = new CypherQuery("start n=node(*) match (n:Bioskop) return n;", new Dictionary<string, object>(), CypherResultMode.Set);

            List<Bioskop> bioskops = new List<Bioskop>();
            bioskops = ((IRawGraphClient)client).ExecuteGetCypherResults<Bioskop>(query).ToList();
            return bioskops;
        }


        public List<Film> GetFilmovi()
        {
            var query = new CypherQuery("match (n:Film) return n;", new Dictionary<string, object>(), CypherResultMode.Set);

            List<Film> filmovi = ((IRawGraphClient)client).ExecuteGetCypherResults<Film>(query).ToList();
            return filmovi;
        }
        public List<Prikaz> getPrikazi(String z)
        {
            var query = new CypherQuery("match (n:Bioskop)-[:PRIKAZUJE]-(p:Prikaz) where n.naziv='" + z + "'  return p", new Dictionary<string, object>(), CypherResultMode.Set);

            List<Prikaz> prikaz = ((IRawGraphClient)client).ExecuteGetCypherResults<Prikaz>(query).ToList();

            return prikaz;
        }
        public Sala GetSala(String imeSale, String Bioskop)
        {
            var query = new CypherQuery("match (n:Sala)-[:POSEDUJE]-(b:Bioskop) where n.brojSale='" + imeSale + "' and b.naziv='" + Bioskop + "' return n", new Dictionary<string, object>(), CypherResultMode.Set);
            Sala sala = ((IRawGraphClient)client).ExecuteGetCypherResults<Sala>(query).Single();
            return sala;
        }
        public List<Film> getFilmovi(String a, String b, bool c)
        {
            String _3D;
            if (c)
                _3D = "3D";
            else
                _3D = "2D";
            var query = new CypherQuery("match (n:Film)-[:EMITUJE]-(p:Prikaz)-[:PRIKAZUJE]-(b:Bioskop) where p.datum='" + a + "' and b.naziv='" + b + "' and p.projekcija='" + _3D + "' return n", new Dictionary<string, object>(), CypherResultMode.Set);
            List<Film> filmovi = ((IRawGraphClient)client).ExecuteGetCypherResults<Film>(query).ToList();
            return filmovi;
        }
        //public List<Film> GetFilms(String s)
        //{

        //}

        public List<Sala> getSala(String a, String b)
        {
            var query = new CypherQuery("match (n:Sala)-[:U_SALI]-(p:Prikaz) where p.datum='" + a + "' and p.vreme='" + b + "' return n", new Dictionary<string, object>(), CypherResultMode.Set);
            List<Sala> s = ((IRawGraphClient)client).ExecuteGetCypherResults<Sala>(query).ToList();
            return s;
        }
        

        public bool napraviSediste(Rezervacija r, String bioskop, String sala)
        {
            var query2 = new CypherQuery("match (m:Prikaz)-[:PRIKAZUJE]-(b:Bioskop)-[:POSEDUJE]-(q:Sala)" +
                "where m.datum='" + r.prikaz.datum + "' and m.vreme='" + r.prikaz.vreme + "'" +
                "and b.naziv='" + bioskop + "' and q.brojSale='" + sala + "'" +
                "match (g:Gost) where g.userName='" + r.gost.userName + "'" +
                "create (n:Rezervacija {brojSedista:'" + r.brojRezSedista + "'})" +
                "create (n)-[:REZERVISAO]->(m),(g)-[:ZAKAZAO]->(n)", new Dictionary<string, object>(), CypherResultMode.Set);
            /*match (m:Prikaz)-[:PRIKAZUJE]-(b:Bioskop)-[:POSEDUJE]-(q:Sala) 
            where m.datum='18.01.2019' and m.vreme='18:00' and 
            b.naziv='Kupina' and q.brojSale='1'
            match (g:Gost) where g.userName='Darko'
            create (n:Rezervacija {brojSedista:'4'})
            create (n)-[:REZERVISAO]->(m),(g)-[:ZAKAZAO]->(n)*/
            try
            {
                ((IRawGraphClient)client).ExecuteCypher(query2);
            }
            catch (Exception e)
            {
                return false;
            }
            // return true;
            foreach (Sediste s in r.sedista)
            {
                var query = new CypherQuery("match (r:Rezervacija)-[:ZAKAZAO]-(b:Gost)" +
                    "where r.brojSedista='" + r.brojRezSedista + "' and b.userName='" + r.gost.userName + "'" +
                    "create (n:Sediste {red:'" + s.red + "', brojSedista:'" + s.brojSedista + "'})" +
                    "create (r)-[:ZAUZEO]->(n)", new Dictionary<string, object>(), CypherResultMode.Set);
                /*match (r:Rezervacija)-[:ZAKAZAO]-(b:Gost)
                where r.brojSedista='4' and b.userName='Darko
                create (n:Sediste {red:'2', brojSedista:'3'})
                create (r)-[:ZAUZEO]->(n)*/
                try
                {
                    ((IRawGraphClient)client).ExecuteCypher(query);
                }
                catch (Exception e)
                {
                    return false;
                }

            }
            return true;

        }


        public Prikaz GetPrikazi2(String sala, String datum, String vreme, String Bioskop)
        {
            var query = new CypherQuery("match (n:Prikaz)-[:U_SALI]-(a:Sala)-[:POSEDUJE]-(b:Bioskop) where n.datum='" + datum + "' and n.vreme='" + vreme + "' and a.brojSale='" + sala + "' and b.naziv='" + Bioskop + "' return n", new Dictionary<string, object>(), CypherResultMode.Set);
            Prikaz prikaz = ((IRawGraphClient)client).ExecuteGetCypherResults<Prikaz>(query).SingleOrDefault();
            return prikaz;
        }

    }
}
