using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    public class AdministrarePersoane_FisierText
    {
        private string numeFisier
        {
            get; set;
        }
        public AdministrarePersoane_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddPersoana(Persoana persoana)
        {
            //adauga persoana in fisier
            persoana.idPersoana = GetID();
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true)) 
            {
                streamWriterFisierText.WriteLine(persoana.ConversieLaSir_PentruFisier());
            }
        }

        private int GetID()
        {
            //asigura ca id-urile sun in ordine crescatoare si ca nu se repeta
            int IDPersoana = 1;
            using(StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                while((linieFisier = streamReader.ReadLine())!=null)
                {
                    Persoana persoana = new Persoana(linieFisier);
                    IDPersoana = persoana.idPersoana + 1;
                }
            }
            return IDPersoana;
        }

        public void StergePersoana(List<Persoana> persoane, int persoanaID)
        {   
            //sterge persoana mai intai din lista, apoi din fisier
            //controlul dataGridView nu se actualizeaza in cazul stergerii ultimului element decat dupa ce se redeschide aplicatia, chiar daca se sterge din fisier
            persoane.Remove(GetPersoanaDupaID(persoanaID));
            StergeLinieFisier(GetPersoanaDupaID(persoanaID).ConversieLaSir_PentruFisier());   
        }

        public void StergeLinieFisier(string persoanaLinieFisier)
        {
            //deoarece c# nu are o functie de stergere a unei linii din fisier predefinita am creat una
            string linieFisier;
            string fisierTemp = Path.GetTempFileName();
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                using (StreamWriter streamWriter = new StreamWriter(fisierTemp))
                {
                    while((linieFisier = streamReader.ReadLine()) != null)
                    {
                        if (String.Compare(linieFisier, persoanaLinieFisier) == 0)
                            continue;
                        streamWriter.WriteLine(linieFisier);
                    }
                }
            }
            File.Delete(numeFisier);
            File.Move(fisierTemp, numeFisier);
        }

        public List<Persoana> GetPersoane()
        {
            List<Persoana> persoane = new List<Persoana>();

            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;

                // citeste cate o linie si creaza un obiect de tip Student
                // pe baza datelor din linia citita
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    persoane.Add(new Persoana(linieFisier));
                }
            }

            return persoane;
        }
        public Persoana GetPersoanaDupaNume(string nume)
        {
            //preia o persoana dupa nume din fisier
            Persoana persoana = new Persoana();
            using (StreamReader streamReaderFisier = new StreamReader(numeFisier))
            {
                string linieFisier;
                while ((linieFisier = streamReaderFisier.ReadLine()) != null)
                {
                    persoana = new Persoana(linieFisier);
                    if (persoana.nume == nume)
                    {
                        return persoana;
                    }
                }
            }
            return new Persoana();
        }
        public Persoana GetPersoanaDupaNumarDeTelefon(long numarDeTelefon)
        {
            //preia o persoana dupa numarul de telefon din fisier
            Persoana persoana = new Persoana();
            using (StreamReader streamReaderFisier = new StreamReader(numeFisier))
            {
                string linieFisier;
                while ((linieFisier = streamReaderFisier.ReadLine()) != null)
                {
                    persoana = new Persoana(linieFisier);
                    if (persoana.numarDeTelefon == numarDeTelefon)
                    {
                        return persoana;
                    }
                }
            }
            return new Persoana();
        }
        public Persoana GetPersoanaDupaEmail(string email)
        {
            //preia o persoana dupa adresa de email din fisier
            Persoana persoana = new Persoana();
            using (StreamReader streamReaderFisier = new StreamReader(numeFisier))
            {
                string linieFisier;
                while ((linieFisier = streamReaderFisier.ReadLine()) != null)
                {
                    persoana = new Persoana(linieFisier);
                    if (persoana.email == email)
                    {
                        return persoana;
                    }
                }
            }
            return new Persoana();
        }
        public Persoana GetPersoanaDupaID(int id)
        {
            //preia o persoana dupa id din fisier
            Persoana persoana = new Persoana();
            using (StreamReader streamReaderFisier = new StreamReader(numeFisier))
            {
                string linieFisier;
                while ((linieFisier = streamReaderFisier.ReadLine()) != null)
                {
                    persoana = new Persoana(linieFisier);
                    if (persoana.idPersoana == id)
                    {
                        return persoana;
                    }
                }
            }
            return new Persoana();
        }
    }
}

