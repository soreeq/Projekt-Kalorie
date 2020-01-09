using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ConsoleApp24
{
    class Program
    {
        static string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        static void Main(string[] args)
        {
            DodajWpis("kurczak", 300);
            ZCzytajWpis(1);
            ZCzytajWpis(2);
            ZCzytajWpis(3);
            ZCzytajWpis(4);
            ZCzytajWpis(8);
            Console.ReadKey();
        }

        static private void ZCzytajWpis(int a)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection myCon = new SqlConnection(conn);


            try
            {
                command.CommandText = "SELECT nazwa, kcal FROM Produkty WHERE ID = @id";
                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = a;

                myCon.Open();
                command.Connection = myCon;
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        var nazwa = reader["nazwa"].ToString();
                        var kcal = Convert.ToInt32(reader["kcal"]);
                       
                        Console.WriteLine("Produkt " +nazwa+ "   Kalorycznosc:  "+kcal);
                        
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

        static private void DodajWpis(string nazwa, int kcal)
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

                Console.WriteLine(Result);
                myCon.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("blad" + e);

            }


        }
    }
}
