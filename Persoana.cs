using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    public class Persoana
    {
        //constante
        private const char SEPARATOR_PRINCIPAL_FISIER = ',';

        private const int ID = 0;
        private const int NUME = 1;
        private const int ZI_DE_NASTERE = 2;
        private const int NUMAR_DE_TELEFON = 3;
        private const int EMAIL = 4;
        private const int GRUP = 5;

        public string nume { get; set; }
        public string email { get; set; }
        [Flags]
        public enum Grup
        { 
            Familie = 1,
            Prieteni = 2,
            Serviciu = 4
        };
        public int idPersoana { get; set; }
        public long numarDeTelefon { get; set; } = 0;
        public DateTime ziDeNastere { get; set; }
        public Grup _grup { get; set; }
        public Persoana()
        {
            nume = email = String.Empty;
        }

        public Persoana(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            idPersoana = Convert.ToInt32(dateFisier[ID]);
            nume = dateFisier[NUME];
            ziDeNastere = DateTime.Parse(dateFisier[ZI_DE_NASTERE]);
            numarDeTelefon = Convert.ToInt32(dateFisier[NUMAR_DE_TELEFON]);
            email = dateFisier[EMAIL];
            _grup = (Grup)Enum.Parse(typeof(Grup), dateFisier[GRUP]);
        }

        public Persoana(int _idPersoana, string _nume, string _email, Grup _grup, int _numarDeTelefon, DateTime _ziDeNastere)
        {
            idPersoana = _idPersoana;
            nume = _nume;
            email = _email;
            this._grup = _grup;
            numarDeTelefon = _numarDeTelefon;
            ziDeNastere = _ziDeNastere;
        }
        public string ConversieLaSir_PentruFisier()
        {
            string obiectPersoanaPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                idPersoana.ToString(),
                nume,
                ziDeNastere.ToString(),
                numarDeTelefon.ToString(),
                email,
                _grup.ToString());
            return obiectPersoanaPentruFisier;
        }

        public string Info()
        {
            //string grupuri = String.Join(" ", );
            string info = string.Format("Id: {0} Nume: {1} Zi de nastere: {2} Numar de telefon: {3} Email: {4} Grup: {5}",
                idPersoana.ToString(),
                nume ?? " NECUNOSCUT ",
                ziDeNastere.ToString() ?? " NECUNOSCUT ",
                numarDeTelefon.ToString() ?? " NECUNOSCUT ",
                email ?? " NECUNOSCUT ",
                _grup.ToString() ?? " NECUNOSCUT "
                );
            return info;
        }
    }
}
