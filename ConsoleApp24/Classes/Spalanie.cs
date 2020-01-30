using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24.Classes
{
    class Spalanie
    {
        int wybor; 
        public void WypiszMenuSpalanie()
        {
            while (wybor != 6)
            {
                Console.Clear();
                Console.WriteLine("Wybierz z listy aktywnosc fizyczna");

                Console.WriteLine("\n1. Bieganie");;
                Console.WriteLine("2. Jazda na rowerze");
                Console.WriteLine("3. Plywanie");
                Console.WriteLine("4. Siedzenie przed kompem");
                Console.WriteLine("5. Chodzenie");
                Console.WriteLine("6. Powrot");

                wybor = int.Parse(Console.ReadLine());

                switch (wybor)
                {
                    case 1:
                        Bieganie();
                        Console.ReadKey();
                        break;
                    case 2:
                        JazdaNaRowerze();
                        Console.ReadKey();
                        break;
                    case 3:
                        Plywanie();
                        Console.ReadKey();
                        break;
                    case 4:
                        Siedzenie();
                        Console.ReadKey();
                        break;
                    case 5:
                        Chodzenie();
                        Console.ReadKey();
                        break;
                    case 6:
                        break ;
                    default:
                        Console.WriteLine("Zly wybor");
                        break;
                }

             
            }
        }

        void Bieganie()
        {
            Console.Clear();
            Console.WriteLine("Ile czasu biegales? (podaj w minutach) :");
            int czas = int.Parse(Console.ReadLine());
            Console.WriteLine("Jaka dlugosc przebiegles? (Podaj w km) : ");
            int dlugosc = int.Parse(Console.ReadLine());

            int spalone_kcal = dlugosc * 62;

            Console.WriteLine("Wynika z tego ze spaliles okolo: " + spalone_kcal + " kalorii to bardzo dobry wynik!");


        }

        void JazdaNaRowerze()
        {
            Console.Clear();
            Console.WriteLine("Ile czasu jezdziles na rowerze? (podaj w godzinach) :");
            int czas = int.Parse(Console.ReadLine());
            Console.WriteLine("Jaka dlugosc przejechales? (Podaj w km) : ");
            int dlugosc = int.Parse(Console.ReadLine());

            int spalone_kcal = czas * 500;

            Console.WriteLine("Wynika z tego ze spaliles okolo: " + spalone_kcal + " kalorii w czasie" + czas + " godzin to bardzo dobry wynik!");


        }
        void Plywanie()
        {
            Console.Clear();
            Console.WriteLine("Ile czasu plywales? (podaj w minutach) :");
            int czas = int.Parse(Console.ReadLine());
            Console.WriteLine("Jaka dlugosc przeplynales? (Podaj w m) : ");
            int dlugosc = int.Parse(Console.ReadLine());

            int spalone_kcal = dlugosc * 17;

            Console.WriteLine("Wynika z tego ze spaliles okolo: " + spalone_kcal + " kalorii to bardzo dobry wynik!");


        }

        void Siedzenie()
        {
            Console.Clear();
            Console.WriteLine("Ile czasu siedziales przed kompem ? (podaj w godzinach) :");
            int czas = int.Parse(Console.ReadLine());

            int spalone_kcal = czas * 3 ;

            Console.WriteLine("Wynika z tego ze spaliles na oko: " + spalone_kcal + " czyli duzo sie nie zmienilo!");


        }

        void Chodzenie()
        {
            Console.Clear();
            Console.WriteLine("Ile czasu chodziles? (podaj w godzinach) :");
            int czas = int.Parse(Console.ReadLine());
            Console.WriteLine("Jaka dlugosc przeszedles? (Podaj w km) : ");
            int dlugosc = int.Parse(Console.ReadLine());

            int spalone_kcal = dlugosc * 30;

            Console.WriteLine("Wynika z tego ze spaliles okolo: " + spalone_kcal + " kalorii to bardzo dobry wynik!");


        }
    }
}
