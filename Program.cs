using System;
using System.Configuration;
using System.IO;

namespace Agenda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Persoana persoana = new Persoana();
            string optiune;
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie =
            Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // setare locatie fisier in directorul corespunzator solutiei
            // astfel incat datele din fisier sa poata fi utilizate si de alte proiecte
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            AdministrarePersoane_FisierText administrarePersoane = new
            Agenda.AdministrarePersoane_FisierText(caleCompletaFisier);
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
                Console.WriteLine("I. Stergere persoana");
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
                        long numarDeTelefon = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine($"Introduceti adresa de email a persoanei {idPersoana}: ");
                        string email = Console.ReadLine();
                        Console.WriteLine($"Introduceti grupul sau grupurile carora le apartine persoana {idPersoana}: ");
                        string grup = Console.ReadLine();
                        Persoana.Grup EnumGrup = persoana.GetGrup(grup);
                        Console.WriteLine(EnumGrup.ToString());
                        persoana = new Persoana(idPersoana, nume, email, EnumGrup, numarDeTelefon, ziDeNastere);
                        nrPersoane++;

                        break;

                    case "B":
                        Persoana[] persoane = administrarePersoane.GetPersoane(out nrPersoane);
                        Console.WriteLine(persoana._grup);
                        AfisarePersoane(persoane, nrPersoane);


                        break;

                    case "C":
                        idPersoana = nrPersoane + 1;
                        nrPersoane++;
                        administrarePersoane.AddPersoana(persoana);

                        break;

                    case "D":
                        Console.WriteLine("Introduceti numele persoanei de cautat: ");
                        nume = Console.ReadLine();
                        persoana = administrarePersoane.GetPersoanaDupaNume(nume);
                        if (persoana.nume == "")
                        {
                            Console.WriteLine("Nu s-a gasit acea persoana in fisier!");
                        }
                        else
                        {
                            Console.WriteLine($"Persoana cu numele {nume} a fost gasita in fisier!");
                        }

                        break;

                    case "E":
                        Console.WriteLine("Introduceti numarul de telefon al persoanei de cautat: ");
                        numarDeTelefon = Convert.ToInt32(Console.ReadLine());
                        persoana = administrarePersoane.GetPersoanaDupaNumarDeTelefon((int)numarDeTelefon);
                        if (persoana.numarDeTelefon == 0)
                        {
                            Console.WriteLine("Nu s-a gasit acea persoana in fisier!");
                        }
                        else
                        {
                            Console.WriteLine($"Persoana cu numarul de telefon {numarDeTelefon} a fost gasita in fisier!");
                        }

                        break;

                    case "F":
                        Console.WriteLine("Introduceti adresa de email a persoanei de cautat: ");
                        email = Console.ReadLine();
                        persoana = administrarePersoane.GetPersoanaDupaNume(email);
                        if (persoana.email == "")
                        {
                            Console.WriteLine("Nu s-a gasit acea persoana in fisier!");
                        }
                        else
                        {
                            Console.WriteLine($"Persoana cu adresa de email {email} a fost gasita in fisier!");
                        }

                        break;
                    case "G":

                        break;

                    case "H":

                        break;

                    case "I":

                        break;

                    case "X":

                        return;

                    default:
                        Console.WriteLine("Nu exista acea optiune!");
                        break;
                }
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }
        public static void AfisarePersoane(Persoana[] persoane, int nrPersoana)
        {
            Console.WriteLine("Persoanele din agenda sunt: ");
            for (int contor = 0; contor < nrPersoana; contor++)
            {
                string infoPersoana = String.Format("Persoana cu ID-ul {0} are numele {1}, ziua de nastere {2}, numarul de telefon {3}, adresa de email {4} si este in grupul {5}",
                    persoane[contor].idPersoana,
                    persoane[contor].nume ?? " NECUNOSCUT ",
                    persoane[contor].ziDeNastere.ToString("ddd, dd MMMM yyyy") ?? " NECUNOSCUT ",
                    persoane[contor].idPersoana,
                    persoane[contor].email ?? " NECUNOSCUT ",
                    persoane[contor]._grup.ToString());

                Console.WriteLine(infoPersoana);
            }
        }
    }
}
