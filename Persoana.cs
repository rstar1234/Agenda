using System;
using System.Collections;
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
            None = 0,
            Familie = 1,
            Prieteni = 2,
            Serviciu = 4,
        };
        public int idPersoana { get; set; }
        public long numarDeTelefon { get; set; } = 0;
        public DateTime ziDeNastere { get; set; }
        public Grup _grup { get; set; }
        //public ArrayList grupuri { get; set; }
        public Persoana()
        {
            nume = email = String.Empty;
        }

        public string GrupAsString
        {
            get
            {
                return string.Join("", _grup.ToString().Split(','));
            }
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
            _grup = GetGrup(dateFisier[GRUP]);
            /*grupuri = new ArrayList();
            grupuri.AddRange(dateFisier[GRUP].Split(' '));*/
        }

        public Persoana(int _idPersoana, string _nume, string _email, Grup _grup, long _numarDeTelefon, DateTime _ziDeNastere)
        {
            idPersoana = _idPersoana;
            nume = _nume;
            email = _email;
            this._grup = _grup;
            numarDeTelefon = _numarDeTelefon;
            ziDeNastere = _ziDeNastere;
        }
        public Persoana(Persoana p)
        {
            idPersoana = p.idPersoana;
            nume = p.nume;
            email = p.email;
            this._grup = p._grup;
            numarDeTelefon = p.numarDeTelefon;
            ziDeNastere = p.ziDeNastere;
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
                GrupAsString);
            return obiectPersoanaPentruFisier;
        }

        public Grup GetGrup(string grup)
        {
            string[] grupuri = grup.Split(' ');
            Grup EnumGrup = Grup.None;
            foreach (string g in grupuri)
            {
                string temp = g.Replace(",", "");
                if (Enum.TryParse(temp, false, out Grup ParseGrup))
                {
                    EnumGrup |= (Grup)Enum.Parse(typeof(Grup), temp);
                }
                else
                {
                    Console.WriteLine("Nu exista acel grup!");
                }
            }
            return EnumGrup;
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
                GrupAsString ?? " NECUNOSCUT "
                );
            return info;
        }
    }
}
