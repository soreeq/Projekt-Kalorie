
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Sql;
using System.Data.SqlClient;

namespace ConsoleApp24.Classes
{
    class Produkty
    {
        public static string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        private string _nazwaProduktu;
        private int _kcal;
        private int _liczbaProduktow;

        public string nazwaProduktu
        {
            get
            {
                return _nazwaProduktu;
            }
            set
            {
                _nazwaProduktu = value;
            }
        }
        public int kcal
        {
            get
            {
                return _kcal;
            }
            set
            {
                _kcal = value;
            }
        }
        public int liczbaProduktow
        {
            get
            {
                return _liczbaProduktow;
            }
            set
            {
                _liczbaProduktow = value;
            }
        }
        public Produkty()
        {
            liczbaProduktow = LiczbaProduktow();
        }

        public void WypiszListeProd()
        {
            liczbaProduktow = LiczbaProduktow();
            for (int i = 1; i <= _liczbaProduktow; i++)
            {
                ZCzytajWpis(i);
            }
        }
        public int ZwrocKcal(int id)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection myCon = new SqlConnection(conn);
            var kcal = 0;

            try
            {
                command.CommandText = "SELECT kcal FROM Produkty WHERE ID = @id";
                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                myCon.Open();
                command.Connection = myCon;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        kcal = Convert.ToInt32(reader["kcal"]);
                        break;
                    }
                }
                myCon.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("problem " + e);
            }

            return kcal;
        }
        public void ZCzytajWpis(int a)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection myCon = new SqlConnection(conn);


            try
            {
                command.CommandText = "SELECT ID, nazwa, kcal FROM Produkty WHERE ID = @id";
                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = a;

                myCon.Open();
                command.Connection = myCon;
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var Id = Convert.ToInt32(reader["ID"]);
                        var nazwa = reader["nazwa"].ToString();
                        var kcal = Convert.ToInt32(reader["kcal"]);

                        Console.WriteLine("Id : " + Id + "\nProdukt: " + nazwa + "   /   Kalorycznosc:  " + kcal);

                    }
                }
                else
                {
                    Console.WriteLine("Brak wiersza");
                }
                myCon.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("problem " + e);
            }
        }
        public int LiczbaProduktow()
        {
            SqlCommand command = new SqlCommand();
            SqlConnection myCon = new SqlConnection(conn);
            int liczba_produktow = 0;

            try
            {
                command.CommandText = "SELECT * FROM Produkty";
                myCon.Open();
                command.Connection = myCon;
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        liczba_produktow++;
                    }
                }
                else
                {
                    liczba_produktow = 0;
                }
                myCon.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("problem " + e);
            }

            return liczba_produktow;
        }


    }
}