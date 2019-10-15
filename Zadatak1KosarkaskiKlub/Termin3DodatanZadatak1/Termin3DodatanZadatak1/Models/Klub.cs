using System.Collections.Generic;

namespace Termin3DodatanZadatak1.Models
{
    public class Klub
    {
        public int SifraKluba;
        public string NazivKluba;
        public List<Igrac> ListaIgraca;

        public Klub()
        {
            ListaIgraca = new List<Igrac>();
        }
    }
}
