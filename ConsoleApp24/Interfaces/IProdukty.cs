using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24.Interfaces
{
    interface IProdukty
    {
        string nazwaProduktu { get; set; }
        int kcal { get; set; }
        int liczbaProduktow { get; set; }
        void WypiszListeProd();
        void ZCzytajWpis(int a);
        int LiczbaProduktow();

    }
}
