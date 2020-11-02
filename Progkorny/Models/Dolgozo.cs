using System;
using System.Text.RegularExpressions;

namespace Progkorny.Models
{
    public class Dolgozo
    {
        private string _nev;
        private DateTime _szuletesiDatum;
        private long _fizetes;
        private string _szemelyiszam;
        public string Nev
        {
            get { return _nev; }
            set
            {
                if (value.Trim().Length < 3)
                {
                    throw new ArgumentException(value + " név túl rövid");
                }

                _nev = value;
            }
        }

        public DateTime SzuletesiDatum
        {
            get { return _szuletesiDatum; }
            set
            {
                if (value > DateTime.Now || value.AddYears(18) > DateTime.Now)
                {
                    throw new ArgumentException(value + " nem jó születési dátum");
                }

                _szuletesiDatum = value;
            }
        }

        public long Fizetes
        {
            get { return _fizetes; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(value + " túl alacsony fizetés");
                }

                if (value > 99999999)
                {
                    throw new ArgumentException(value + " túl magas fizetés");
                }


                _fizetes = value;
            }
        }

        public string SzemelyiSzam
        {
            get { return _szemelyiszam; }
            set
            {
                Regex r = new Regex(@"^\d{6}\w{2}$");
                if (!r.Match(value).Success)
                {
                    throw new ArgumentException(value + " személyi szám nem jó formátumú");
                }

                _szemelyiszam = value;
            }
        }
    }
}