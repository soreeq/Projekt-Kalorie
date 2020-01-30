using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24.Classes
{
    class Profil
    {
        public string imie { get; set; }
        public float wiek { get; set; }
        public float wzrost { get; set; }
        public float waga { get; set; }
        private float BMI { get; set; }

        public void StworzProfil()
        {
            Console.Clear();
            Console.Write("Podaj Swoje Imie: ");
            imie = Console.ReadLine();

            Console.Write("Podaj Swoje Wzrost: ");
            wzrost = float.Parse(Console.ReadLine());


            Console.Write("Podaj Swoje Wage: ");
            waga = float.Parse(Console.ReadLine());


            Console.Write("Podaj Swoje Wiek: ");
            wiek = float.Parse(Console.ReadLine());
        }

        public void WyswietlProfil()
        {
            Console.WriteLine("\n\n\nImie: " + imie);
            Console.WriteLine("Wzrost: " + wzrost);
            Console.WriteLine("Waga: " + waga);
            Console.WriteLine("Wiek: " + wiek + "\n");
            float tmp = (wzrost / 100) * (wzrost / 100);
            BMI = waga / tmp;
            Console.WriteLine("Twoj wskaznik BMi to: " + BMI);
            float wynikc = WskaznikBMI(BMI);
            string wynik = string.Empty;
            switch (wynikc)
            {
                case 1:
                    wynik = "wyglodzenie";
                    break;
                case 2:
                    wynik = "wychudzenie";
                    break;
                case 3:
                    wynik = "wartosc prawidlowa";
                    break;
                case 4:
                    wynik = "nadwaga";
                    break;
                case 5:
                    wynik = "pierwszy stopien otylosci";
                    break;
                case 6:
                    wynik = "drugi stopien otylosci";
                    break;
                case 7:
                    wynik = "otylosc skrajna";
                    break;
                default:
                    break;
            }
            Console.WriteLine("Oznacza to w twoim przypadku: " + wynik);
            Console.ReadKey();


        }

        float WskaznikBMI(float wynikBMI)
        {
            if (wynikBMI < 16)
            { return 0; }
            if (wynikBMI > 16 && wynikBMI < 17)
            { return 1; }
            if (wynikBMI > 17 && wynikBMI < 19)
            { return 2; }
            if (wynikBMI > 19 && wynikBMI < 25)
            { return 3; }
            if (wynikBMI > 25 && wynikBMI < 30)
            { return 4; }
            if (wynikBMI > 30 && wynikBMI < 35)
            { return 5; }
            if (wynikBMI < 40)
            { return 6; }
            else
            { return 7; }

        }
    }
}
