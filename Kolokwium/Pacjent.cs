using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium
{
    class Pacjent :Osoba
    {
        private int wiek;
        private string choroba;
        public Pacjent(string ImieNazwisko, int Wiek, string Choroba)
            :base(ImieNazwisko)
        {
            wiek = Wiek;
            choroba = Choroba;
        }
        public override string ToString()
        {
            return string.Format("Pacjent, imię i nazwisko: {0}, wiek {1}, choroba: {2}",
                imieNazwisko, wiek, choroba);
        }
    }
}
