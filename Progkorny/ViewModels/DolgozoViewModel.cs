using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Progkorny.Models;

namespace Progkorny.ViewModels
{
    public class DolgozoViewModel
    {
        public DolgozoViewModel(IEnumerable<Dolgozo> dolgozok)
        {
            Dolgozok = new ObservableCollection<Dolgozo>(dolgozok);
        }

        public ObservableCollection<Dolgozo> Dolgozok {get;}
    }
}