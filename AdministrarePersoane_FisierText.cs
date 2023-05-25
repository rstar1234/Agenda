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
            persoana.idPersoana = GetID();
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true)) 
            {
                streamWriterFisierText.WriteLine(persoana.ConversieLaSir_PentruFisier());
            }
        }

        private int GetID()
        {
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
            int nrPersoane = 0;
            string fisierTemp = Path.GetTempFileName();
            using (StreamWriter streamWriter = new StreamWriter(fisierTemp, true))
            {
                while (nrPersoane < persoane.Count-1 && nrPersoane != persoanaID)
                {
                    streamWriter.WriteLine(persoane[nrPersoane].ConversieLaSir_PentruFisier());
                    nrPersoane++;
                }

            }
            File.Delete(numeFisier);
            File.Move(fisierTemp, numeFisier);
            persoane.Remove(GetPersoanaDupaID(persoanaID));
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

