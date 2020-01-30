
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp24.Classes
{
    class Menu
    {
        public static string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        private int _wybor;
        public List<Produkty> listaproduktow { get; set; }
        Produkty obj = new Produkty();

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



        private void DodajUsunMenu()
        {
            int opcja;
            do
            {
                Console.Clear();
                Console.WriteLine("Wybierz :");
                Console.WriteLine("1. Dodaj produkt");
                Console.WriteLine("2. Usun produkt");
                Console.WriteLine("3. Wyswietl aktualna liste produktow");
                Console.WriteLine("4. Powrot");

                opcja = int.Parse(Console.ReadLine());
                if (opcja == 1)
                {
                    Console.Write("Podaj nazwe produktu: ");
                    var nazwa = Console.ReadLine();

                    Console.Write("Podaj kcal produktu: ");
                    var kcal = int.Parse(Console.ReadLine());


                    if (DodajWpis(nazwa, kcal))
                    {
                        Console.WriteLine("Dodano produkt");
                    }
                }
                else if (opcja == 2)
                {
                    Console.Clear();
                    obj.WypiszListeProd();

                    Console.Write("Podaj Id produktu ktory chcesz usunac : ");
                    var Id = int.Parse(Console.ReadLine());
                    UsunWpis(Id);

                }
                else if (opcja==3)
                {
                    Console.Clear();
                    obj.WypiszListeProd();
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Zle wybranie menu ");
                }
            } while (opcja != 4);

        }
        public void ZliczKalorie()
        {
            int id_prod;
                Console.Clear();
                obj.WypiszListeProd();
                int suma_kcal = 0;
            do { 
                Console.WriteLine("Wybierz produkt co dzis zjadles : ");
                id_prod = int.Parse(Console.ReadLine());
                suma_kcal += obj.ZwrocKcal(id_prod);
                Console.WriteLine("Zjadles dzis: " + suma_kcal  +" kalorii, wpisz 0 zeby wyjsc \n");
            } while (id_prod != 0);


        }
        public void WypiszMenuMain()
        {
            Console.Clear();
            Console.WriteLine("Witaj, to jest program LICZNIK KALORII wybierz opcje ponizej: \n");
            Console.WriteLine("1.  Wyswietl liste produktow");
            Console.WriteLine("2. Dodaj/Usun produkt");
            Console.WriteLine("3. Wybierz co dzis zjadles");
            Console.WriteLine("4. Twoj profil");
            Console.WriteLine("5. Oblicz ile spaliles kalorii");
            Console.WriteLine("6. Oblicz ile potrzebujesz kalorii");
            Console.WriteLine("7. Wyjdz\n");
            Console.Write("Co wybierasz? :    ");
        }
        public int Wybierz(int wybornik)
        {

            Profil start2 = new Profil();
            Spalanie spal = new Spalanie();
            ileKalorii potrzeba = new ileKalorii();


            switch (wybornik)
            {
                case 1:
                    Console.Clear();
                    obj.WypiszListeProd();
                    Console.ReadKey();
                    return wybor;
                    break;
                case 2:

                    //Console.Clear();
                    //Console.WriteLine("Dodaj nazwe produktu");
                    //string nameProduct = Console.ReadLine();
                    //Console.WriteLine("Dodaj liczbe kalorii produktu");
                    //int liczbaKalorii = int.Parse(Console.ReadLine());

                    Console.Clear();
                    DodajUsunMenu();
                    return wybor;
                    break;
                case 3:
                    ZliczKalorie();
                    return wybor;
                    break;
                case 4:
                    Console.Clear();
                    start2.StworzProfil();
                    start2.WyswietlProfil();
                    return wybor;
                    break;
                case 5:
                    spal.WypiszMenuSpalanie();
                    return wybor;
                    break;
                case 6:
                    potrzeba.Potrzeba();
                    return wybor;
                    break;
                case 7:
                    Environment.Exit(0);
                    return wybor;
                    break;
                default:
                    return 0;
            }
        }

        private void UsunWpis(int Id)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection myCon = new SqlConnection(conn);

            try
            {
                command.CommandText = "DELETE FROM Produkty WHERE ID = @Id";
                command.Parameters.AddWithValue("@Id", Id);
                myCon.Open();

                command.Connection = myCon;
                int result = command.ExecuteNonQuery();
                myCon.Close();
                if (result == 1)
                {
                    Console.WriteLine("Usunieto produkt");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("blad" + e);
            }
        }
        private bool DodajWpis(string nazwa, int kcal)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection myCon = new SqlConnection(conn);

            try
            {
                command.CommandText = "INSERT INTO Produkty (nazwa,kcal) VALUES ( @nazwa, @kcal)";
                command.Parameters.AddWithValue("@nazwa", nazwa);
                command.Parameters.AddWithValue("@kcal", kcal);

                myCon.Open();
                command.Connection = myCon;

                int Result = command.ExecuteNonQuery();
                if (Result >= 0)
                {
                    return true;
                }
                else
                    return false;
                myCon.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("blad" + e);
                return false;
            }


        }
    }
}