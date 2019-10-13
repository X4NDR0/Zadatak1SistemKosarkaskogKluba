using System;
using System.Collections.Generic;
using System.Text;

namespace Termin3DodatanZadatak1.Models
{
    public class Utakmica
    {
        public DateTime VremeUtakcime;
        public int BrojKosevaDomacina;
        public int BrojKosevaGostiju;
        public Sudija sdj = new Sudija();
        public int SifraUtakmice;

    }
}
