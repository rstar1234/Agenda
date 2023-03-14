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
        private string nume, email, grup;
        private int numarDeTelefon;
        private DateTime ziDeNastere;
        public Persoana(string _nume, string _email, string _grup, int _numarDeTelefon, DateTime _ziDeNastere)
        {
            nume = _nume;
            email = _email;
            grup = _grup;
            numarDeTelefon = _numarDeTelefon;
            ziDeNastere = _ziDeNastere;
        }
    }
}
