using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp24.Classes;

namespace ConsoleApp24.Interfaces
{
    interface IMenu
    {
        int wybor { get; set; }
        List<Produkty> listaproduktow { get; set; }
        void WypiszMenuMain();
        int Wybierz(int wybornik);


    }
}
