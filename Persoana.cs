using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    internal class Persoana
    {
        //constante
        private const char SEPARATOR_PRINCIPAL_FISIER = ',';

        private const int ID = 0;
        private const int NUME = 1;
        private const int ZI_DE_NASTERE = 2;
        private const int NUMAR_DE_TELEFON = 3;
        private const int EMAIL = 4;
        private const int GRUP = 5;

        private string nume, email, grup;
        private int idPersoana, numarDeTelefon;
        private DateTime ziDeNastere;
        private string linieFisier;

        public Persoana(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            idPersoana = Convert.ToInt32(dateFisier[ID]);
            nume = dateFisier[NUME];
            ziDeNastere = DateTime.Parse(dateFisier[ZI_DE_NASTERE]);
            numarDeTelefon = Convert.ToInt32(dateFisier[NUMAR_DE_TELEFON]);
            email = dateFisier[EMAIL];
            grup = dateFisier[GRUP];
        }

        public Persoana(int _idPersoana, string _nume, string _email, string _grup, int _numarDeTelefon, DateTime _ziDeNastere)
        {
            idPersoana = _idPersoana;
            nume = _nume;
            email = _email;
            grup = _grup;
            numarDeTelefon = _numarDeTelefon;
            ziDeNastere = _ziDeNastere;
        }
        public string ConversieLaSir_PentruFisier()
        {
            string obiectPersoanaPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                idPersoana.ToString(),
                ziDeNastere.ToString(),
                numarDeTelefon.ToString(),
                email,
                grup);
            return obiectPersoanaPentruFisier;
        }
    }
}
