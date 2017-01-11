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
                    if (string.IsNullOrEmpty(imieN) || string.IsNullOrEmpty(specjalnosc))
                    {
                        Console.WriteLine("Puste!");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        przychodnia.UstawLekarza(imieN, specjalnosc);
                        Console.WriteLine("Ustawiono");
                        Console.ReadKey();
                        break;
                    }
                case ConsoleKey.Z:
                    if(!przychodnia.CzyLekarz())
                    {
                        Console.WriteLine("Najpierw dodaj lekarza!");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine("Podaj imię i nazwisko pacjenta");
                    string imieP = Console.ReadLine();
                    Console.WriteLine("Podaj wiek pacjenta");
                    string wiek = Console.ReadLine();
                    Console.WriteLine("Podaj chorobę");
                     string choroba = Console.ReadLine();
                     if (string.IsNullOrEmpty(imieP) || string.IsNullOrEmpty(wiek) || string.IsNullOrEmpty(choroba))
                    {
                        Console.WriteLine("Puste!");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        int wiekLiczba;
                        if (!int.TryParse(wiek, out wiekLiczba))
                        {
                            Console.WriteLine("Bład przy podawaniu wieku, nie podano liczby całkowitej, wracam do menu");
                            Console.ReadKey();
                            break;
                        }
                        if(wiekLiczba < 0 || wiekLiczba > 109)
                        {
                            Console.WriteLine("Niepoprawny wiek!");
                            Console.ReadKey();
                            break;
                        }
                        przychodnia.ZapiszDoLekarza(imieP, wiekLiczba, choroba);
                        break;
                    }
                case ConsoleKey.P:
                    if (!przychodnia.CzyLekarz())
                    {
                        Console.WriteLine("Najpierw dodaj lekarza!");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine(przychodnia.WykonajPorade());
                    Console.ReadKey();
                    break;
                case ConsoleKey.B:
                    if (!przychodnia.CzyLekarz())
                    {
                        Console.WriteLine("Najpierw dodaj lekarza!");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine(przychodnia.WykonajBadanie());
                    Console.ReadKey();
                    break;
                case ConsoleKey.C:
                    if (!przychodnia.CzyLekarz())
                    {
                        Console.WriteLine("Najpierw dodaj lekarza!");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine("Czas oczekiwania: " + przychodnia.CzasOczekiwania());
                    Console.ReadKey();
                    break;
                case ConsoleKey.R:
                    if (!przychodnia.CzyLekarz())
                    {
                        Console.WriteLine("Najpierw dodaj lekarza!");
                        Console.ReadKey();
                        break;
                    }
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
