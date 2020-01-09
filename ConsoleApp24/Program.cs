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

            Console.ReadKey();
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

            }
            catch(Exception e)
            {
                Console.WriteLine("blad" + e);

            }
        }
    }
}
