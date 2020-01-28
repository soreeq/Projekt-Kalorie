using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using ConsoleApp24.Classes;

namespace ConsoleApp24
{
    class Program
    {
        public static string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        static void Main(string[] args)
        {
            
            DodajWpis("kurczak", 300);
            DodajWpis("kanapka z wedlina i serem", 250);
            DodajWpis("zupa pomidorowa", 200);
            DodajWpis("warzywa na patelnie", 300);
            DodajWpis("kebsik", 400);
            DodajWpis("pierogi 10szt", 500);
            DodajWpis("jajecznica", 150);

            Menu start = new Menu();
            while (true)
            {
                start.WypiszMenuMain();
                start.Wybierz(int.Parse(Console.ReadLine()));
            }
            Profil start2 = new Profil();
            start2.StworzProfil();
            start2.WyswietlProfil();
            //ZCzytajWpis(1);
            //ZCzytajWpis(2);
            //ZCzytajWpis(3);
            //ZCzytajWpis(4);
            //ZCzytajWpis(5);
            //ZCzytajWpis(6);
            //ZCzytajWpis(7);
            //ZCzytajWpis(8);
            Console.WriteLine("koniec");
            Console.ReadKey();
        }


        public static void DodajWpis(string nazwa, int kcal)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection myCon = new SqlConnection(conn);

            try
            {
                command.CommandText = "INSERT INTO Produkty (nazwa,kcal) VALUES (@nazwa, @kcal)";
                command.Parameters.AddWithValue("@nazwa", nazwa);
                command.Parameters.AddWithValue("@kcal", kcal);

                myCon.Open();
                command.Connection = myCon;

                int Result = command.ExecuteNonQuery();
                myCon.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("blad" + e);

            }


        }
    }

    class Profil
    {
        public string imie { get; set; }
        public int wiek { get; set; }
        public int wzrost { get; set; }
        public int waga { get; set; }

        public void StworzProfil()
        {
            Console.Clear();
            Console.Write("Podaj Swoje Imie: ");
            string imie = Console.ReadLine();

            Console.Clear();
            Console.Write("Podaj Swoje Wzrost: ");
            wzrost = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.Write("Podaj Swoje Wage: ");
            waga = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.Write("Podaj Swoje Wiek: ");
            wiek = int.Parse(Console.ReadLine());
        }

        public void WyswietlProfil()
        {
            Console.WriteLine("Imie: " + imie);
            Console.WriteLine("Wzrost: " + wzrost);
            Console.WriteLine("Waga: " + waga);
            Console.WriteLine("Wiek: " + wiek+ "\n");
            
            int BMI = waga / (wzrost * wzrost);

            Console.WriteLine("Twoj wskaznik BMi to: " + BMI);
            int wynikc = WskaznikBMI(BMI);
            string wynik;
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
            Console.WriteLine("Oznacza to w twoim przypadku: " + wynikc);
            Console.ReadKey();
            

        }

        int WskaznikBMI(int wynikBMI)
        {
            if (wynikBMI < 16)
            { return 0; }
            if (wynikBMI > 16 && wynikBMI<17)
            { return 1; }
            if (wynikBMI > 17 && wynikBMI<19)
            { return 2; }
            if (wynikBMI > 19 && wynikBMI<25)
            { return 3; }
            if (wynikBMI > 25 && wynikBMI <30)
            { return 4; }
            if (wynikBMI > 30 && wynikBMI < 35)
            { return 5; }
            if (wynikBMI < 40)
            { return 6; }
            else
            { return 7;  }

        }


    }

 

}

