using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium
{
    interface IPrzychodnia
    {
        void UstawLekarza(string imieN, string specjalnosc);
        void ZapiszDoLekarza(string imieN, int wiek, string choroba);
        string WykonajPorade();
        string WykonajBadanie();
        int CzasOczekiwania();
        void GenerujRaport();
    }
}
