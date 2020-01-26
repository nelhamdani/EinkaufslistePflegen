using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Einkaufsliste
{
    public class Artikel
    {
        //Felder
        public string ArtikelNummer { get; set; }
        public string Bezeichnung { get; set; }
        public int Menge { get; set; } = 1;
        public bool erledigt { get; set; }

         public static List<Artikel> listAtrikeln = new List<Artikel>();

        //Mein Kontruktor
        public Artikel(string _ArtikelNummer, string _Bezeichnung, int _Menge,  bool _erledigt)
        {
            ArtikelNummer = _ArtikelNummer;
            Bezeichnung = _Bezeichnung;
            erledigt = _erledigt;
            Menge = _Menge;
           
        }

        public Artikel()
        {

        }
    }
}
