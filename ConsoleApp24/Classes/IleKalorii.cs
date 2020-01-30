using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24.Classes
{
    class ileKalorii
    {
        int wiek;
        int waga;
        int wzrost;
        int wynik;

        public void Potrzeba()
        {
            
            Console.WriteLine("\n\n\nChcesz: \n1. Przytyc\n2. Schudnac\n3.Wyjdz");
            int wybor = int.Parse(Console.ReadLine());

            while (wybor != 3)
            {
                if (wybor == 1)
                {
                    Console.Clear();
                    Przytyc();
                    Console.ReadKey();
                    wybor = 3;
                }
                else if (wybor == 2)
                {
                    Console.Clear();
                    Schudnac();
                    Console.ReadKey();
                    wybor = 3;
                }
                else
                {
                    Console.WriteLine("Zly wybor");
                }
            }
        }

        void Przytyc()
        {
            Console.Write("Podaj wzrost: ");
            int wzrost = int.Parse(Console.ReadLine());
            Console.Write("Podaj wage: ");
            int waga = int.Parse(Console.ReadLine());
            Console.Write("Podaj wiek: ");
            int wiek = int.Parse(Console.ReadLine());

            wynik = 66+(13 * waga) + (5* wzrost) - (6 * wiek);

            Console.WriteLine("Zeby przytyc potrzebujesz minimum " + wynik + "kalorii ");
        }
        
        void Schudnac()
        {
            Console.Write("Podaj wzrost: ");
            int wzrost = int.Parse(Console.ReadLine());
            Console.Write("Podaj wage: ");
            int waga = int.Parse(Console.ReadLine());
            Console.Write("Podaj wiek: ");
            int wiek = int.Parse(Console.ReadLine());

            wynik = 66 + (13 * waga) + (5 * wzrost) - (4 * wiek);

            Console.WriteLine("Zeby schudnac potrzebujesz dziennie dostarczac " + wynik + " kalorii");

        }

    }
}
