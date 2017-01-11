using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kolokwium
{
    class Przychodnia :IPrzychodnia
    {
        private Lekarz lekarz;
        private Stack<Pacjent> pacjenci = new Stack<Pacjent>();
        public void UstawLekarza(string imieN, string specjalnosc)
        {
            lekarz = new Lekarz(imieN, specjalnosc);
        }
        public void ZapiszDoLekarza(string imieN, int wiek, string choroba)
        {
            pacjenci.Push(new Pacjent(imieN, wiek, choroba));
        }
        public string WykonajPorade()
        {
            if(!CzyLekarz())
            {
                return "Nie ma lekarza - nie ma kto dać porady";
            }
            try
            {
                Pacjent obecnyPacjent = pacjenci.Pop();
                return "Wykonano poradę! " + Environment.NewLine + obecnyPacjent.ToString();
            }
            catch
            {
                return "Brak pacjentów, nie można wykonać porady!";
            }
        }
        public string WykonajBadanie()
        {
            if (!CzyLekarz())
            {
                return "Nie ma lekarza - nie ma kto zbadać";
            }
            Pacjent obecnyPacjent;
            try
            {
                obecnyPacjent = pacjenci.Peek();
            }
            catch
            {
                return "Brak pacjentow!";
            }
            return "Wykonano badanie! " + Environment.NewLine + obecnyPacjent.ToString();
        }
        public int CzasOczekiwania()
        {
            return pacjenci.Count / 5; //dzielenie całkowite
        }
        public override string ToString()
        {
            string spis;
            if (CzyLekarz()) spis = lekarz.ToString() + Environment.NewLine;
            else spis = "Brak lekarza" + Environment.NewLine;
            foreach(var pacjent in pacjenci)
            {
                spis += pacjent.ToString() + Environment.NewLine;
            }
            spis += "Czas oczekiwania: " + CzasOczekiwania();
            return spis;
        }
        public void GenerujRaport()
        {
            string informacje = this.ToString();
            string nazwaPliku = "Raport" + DateTime.Now.ToString("ddMMyyyyHHmm") + ".txt";
            try
            {
                File.CreateText(nazwaPliku).Close();
                File.WriteAllText(nazwaPliku, informacje);
                Console.WriteLine("Zapisywanie pliku raportu powiodło się");
            }
            catch
            {
                Console.WriteLine("Zapisywanie pliku raportu nie powiodło się");
            }
        }
        public bool CzyLekarz()
        {
            return lekarz != null;
        }

    }
}
