using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string optiune;
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            AdministrarePersoane_FisierText administrarePersoane = new AdministrarePersoane_FisierText(numeFisier);
            int nrPersoane = 0;
            do
            {
                
                Console.WriteLine("A. Introducere date persoana");
                Console.WriteLine("B. Afisarea datelor persoanelor");
                Console.WriteLine("C. Salvare persoana in fisier");
                Console.WriteLine("D. Cauta persoana dupa nume");
                Console.WriteLine("E. Cauta persoana dupa numar de telefon");
                Console.WriteLine("F. Cauta persoana dupa email");
                Console.WriteLine("G. Afisarea persoanelor ce au ziua de nastere intr-o anumita luna");
                Console.WriteLine("H. Afisarea persoanelor dintr-un anumit grup");
                Console.WriteLine("X. Exit");
                Console.WriteLine("Alegeti o optiune: ");
                optiune = Console.ReadLine();

                switch (optiune.ToUpper())
                {
                    case "A":
                        int idPersoana = nrPersoane + 1;
                        Console.WriteLine($"Introduceti numele persoanei {idPersoana}: ");
                        string nume = Console.ReadLine();
                        Console.WriteLine($"Introduceti ziua de nastere a persoanei {idPersoana}: ");
                        string temp = Console.ReadLine();
                        DateTime ziDeNastere = Convert.ToDateTime(temp);
                        Console.WriteLine($"Introduceti numarul de telefon al persoanei {idPersoana}: ");
                        int numarDeTelefon = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine($"Introduceti adresa de email a persoanei {idPersoana}: ");
                        string email = Console.ReadLine();
                        Console.WriteLine($"Introduceti grupul caruia apartine persoana {idPersoana}: ");
                        string grup = Console.ReadLine();
                        Persoana persoana = new Persoana(idPersoana ,nume, email, grup, numarDeTelefon, ziDeNastere);
                        nrPersoane++;

                        break;

                    case "B":

                        break;

                    case "C":

                        break;

                    case "D":

                        break;

                    case "E":

                        break;

                    case "F":

                        break;

                    case "H":

                        break;

                    case "X":

                        return;

                    default:
                        break;
                }
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }
    }
}
