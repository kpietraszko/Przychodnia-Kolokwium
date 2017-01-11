using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium
{
    class Aplikacja
    {
        Przychodnia przychodnia = new Przychodnia();
        public void WczytajKlawisz()
        {
            Console.WriteLine(@"Przychodnia
L - ustaw lekarza
Z - zapisz nowego pacjenta do lekarza
P - wykonaj poradę
B - wykonaj badanie
C - sprawdz czas oczekiwania
R - generuj raport
W - wyjście");
            ConsoleKey wcisnietyKlawisz = Console.ReadKey().Key;
            Console.Clear();
            Wykonaj(wcisnietyKlawisz);
        }
        void Wykonaj(ConsoleKey klawisz)
        {
            switch(klawisz)
            {
                case ConsoleKey.L:
                    Console.WriteLine("Podaj imie i nazwisko lekarza");
                    string imieN = Console.ReadLine();
                    Console.WriteLine("Podaj specjalnosc");
                    string specjalnosc = Console.ReadLine();
                    przychodnia.UstawLekarza(imieN, specjalnosc);
                    Console.WriteLine("Ustawiono");
                    Console.ReadKey();
                    break;
                case ConsoleKey.Z:
                    Console.WriteLine("Podaj imię i nazwisko pacjenta");
                    string imieP = Console.ReadLine();
                    Console.WriteLine("Podaj wiek pacjenta");
                    string wiek = Console.ReadLine();
                    int wiekLiczba;
                    if(!int.TryParse(wiek, out wiekLiczba))
                    {
                        Console.WriteLine("Bład przy podawaniu wieku, nie podano liczby całkowitej, wracam do menu");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine("Podaj chorobę");
                    string choroba = Console.ReadLine();
                    przychodnia.ZapiszDoLekarza(imieP, wiekLiczba, choroba);
                    break;
                case ConsoleKey.P:
                    Console.WriteLine(przychodnia.WykonajPorade());
                    Console.ReadKey();
                    break;
                case ConsoleKey.B:
                    Console.WriteLine(przychodnia.WykonajBadanie());
                    Console.ReadKey();
                    break;
                case ConsoleKey.C:
                    Console.WriteLine("Czas oczekiwania: " + przychodnia.CzasOczekiwania());
                    Console.ReadKey();
                    break;
                case ConsoleKey.R:
                    przychodnia.GenerujRaport();
                    Console.WriteLine("Nacisnij enter by wrocic do menu");
                    Console.ReadKey();
                    break;         
                case ConsoleKey.W:
                    Environment.Exit(0);
                    break;
            }
            Console.Clear();
            WczytajKlawisz();
        }
    }
}
