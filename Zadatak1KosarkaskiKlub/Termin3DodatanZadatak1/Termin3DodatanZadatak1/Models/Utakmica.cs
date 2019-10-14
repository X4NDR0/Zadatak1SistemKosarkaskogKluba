using System;
using System.Collections.Generic;
using System.Text;

namespace Termin3DodatanZadatak1.Models
{
    public class Utakmica
    {
        public DateTime VremeUtakmice;
        public int BrojKosevaDomacina;
        public int BrojKosevaGostiju;
        public Sudija sdj;
        public Klub domaciKlub;
        public Klub gostujuciKlub;
        public int SifraUtakmice;

        public Utakmica()
        {
            sdj = new Sudija();
            domaciKlub = new Klub();
            gostujuciKlub = new Klub();
        }

    }
}
