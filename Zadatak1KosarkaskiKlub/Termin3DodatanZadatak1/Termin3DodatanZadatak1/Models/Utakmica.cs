using System;
using System.Collections.Generic;

namespace Termin3DodatanZadatak1.Models
{
    public class Utakmica
    {
        public int SifraUtakmice;
        public DateTime VremeUtakmice;
        public int BrojKosevaDomacina;
        public int BrojKosevaGostiju;
        public List<Sudija> ListaSudija;
        public Klub DomaciKlub;
        public Klub GostujuciKlub;

        public Utakmica()
        {
            ListaSudija = new List<Sudija>();
            DomaciKlub = new Klub();
            GostujuciKlub = new Klub();
        }
    }
}
