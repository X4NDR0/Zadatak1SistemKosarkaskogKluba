using System;
using System.Collections.Generic;
using System.Text;

namespace Termin3DodatanZadatak1.Models
{
    public class Klub
    {
        public int sifraKluba;
        public string nazivKluba;
        public List<Igrac> igrList;

        
        public Klub()
        {
            igrList = new List<Igrac>();
        }


    }
}
