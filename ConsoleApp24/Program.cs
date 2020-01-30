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

  


    }



