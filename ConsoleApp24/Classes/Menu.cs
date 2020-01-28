using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp24.Interfaces;

namespace ConsoleApp24.Classes
{
    class Menu : IMenu
    {
        private int _wybor;
        public List<Produkty> listaproduktow { get; set; }

        public int wybor
        {
            get
            {
                return _wybor;
            }
            set
            {
                _wybor = value;
            }
        }

        public void WypiszMenuMain()
        {
            Console.Clear();
            Console.WriteLine("Czesc, wybierz opcje ponizej");
            Console.WriteLine("1.  Wyswietl liste produktow");
            Console.WriteLine("2. Dodaj/Usun produkt");
            Console.WriteLine("3. Wybierz co dzis zjadles");
            Console.WriteLine("4. Twoj profil");
            Console.WriteLine("5. Wyjdz\n");
            Console.WriteLine("Co wybierasz? :    ");
        }
        public int Wybierz(int wybornik)
        {
            Produkty obj = new Produkty();
            Profil start2 = new Profil();
 
            switch (wybornik)
            {
                case 1:
                    Console.Clear();
                    obj.WypiszListeProd();
                    return wybor;
                    break;
                case 2:

                    Console.Clear();
                    Console.WriteLine("Dodaj nazwe produktu");
                    string nameProduct = Console.ReadLine();
                    Console.WriteLine("Dodaj liczbe kalorii produktu");
                    int liczbaKalorii = int.Parse(Console.ReadLine());

                    return wybor;
                    break;
                case 3:
                    return wybor;
                    break;
                case 4:
                    Console.Clear();
                    start2.StworzProfil();
                    start2.WyswietlProfil();
                    return wybor;
                    break;
                case 5:
                    return wybor;
                    break;
                case 6:
                    return wybor;
                    break;
                case 7:
                    return wybor;
                    break;
                default:
                    return 0;
            }
        }
    }
}
