using Progkorny.Models;

namespace Progkorny.ViewModels
{
    public class DolgozoView
    {
        public DolgozoView(Dolgozo dolgozo)
        {
            SelectedDolgozo = dolgozo;
        }

        public Dolgozo SelectedDolgozo { get; }
    }
}