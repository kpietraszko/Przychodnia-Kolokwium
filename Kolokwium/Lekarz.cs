using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium
{
    class Lekarz :Osoba
    {
        private string specjalnosc;
        public Lekarz(string ImieNazwisko, string Specjalnosc)
            :base(ImieNazwisko)
        {
            specjalnosc = Specjalnosc;
        }
        public override string ToString()
        {
            return string.Format("Lekarz, imię i nazwisko: {0}, specjalność: {1}",
                imieNazwisko, specjalnosc);
        }
    }
}
