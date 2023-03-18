using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    internal class AdministrarePersoane_FisierText
    {
        private const int NR_MAX_PERSOANE = 60;
        private string numeFisier;
        public AdministrarePersoane_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddPersoana(Persoana persoana)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true)) 
            {
                streamWriterFisierText.WriteLine(persoana.ConversieLaSir_PentruFisier());
            }
        }

        public Persoana[] GetPersoane(out int nrPersoane)
        {
            Persoana[] persoane = new Persoana[NR_MAX_PERSOANE];

            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrPersoane = 0;

                // citeste cate o linie si creaza un obiect de tip Student
                // pe baza datelor din linia citita
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    persoane[nrPersoane++] = new Persoana(linieFisier);
                }
            }

            return persoane;
        }
    }
}
