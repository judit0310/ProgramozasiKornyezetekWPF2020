using System;
using System.Collections;
using System.Collections.Generic;
using Progkorny.Models;

namespace Progkorny.Assets
{
    public class DolgozoManager
    {
        private ICollection<Dolgozo> dolgozolist;

        public DolgozoManager()
        {
            dolgozolist = new List<Dolgozo>();
            dolgozolist.Add(new Dolgozo
            {
                Nev = "Kiss Béla",
                Fizetes=522250,
                SzuletesiDatum = new DateTime(1987,5,6),
                SzemelyiSzam = "252412EZ"
            });
            dolgozolist.Add(new Dolgozo
            {
                Nev = "Nagy Rózsa",
                Fizetes=498250,
                SzuletesiDatum = new DateTime(1990,6,19),
                SzemelyiSzam = "258369AE"
            });
            dolgozolist.Add(new Dolgozo
            {
                Nev = "Szabó Márton",
                Fizetes=465950,
                SzuletesiDatum = new DateTime(1988,12,6),
                SzemelyiSzam = "185487EA"
            });
        }

        public IEnumerable<Dolgozo> dolgozok() => dolgozolist;
    }
}