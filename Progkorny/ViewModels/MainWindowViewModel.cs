using System;
using System.Collections.Generic;
using System.Text;
using Progkorny.Assets;
using ReactiveUI;

namespace Progkorny.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _message = "Hello World";
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                ((IReactiveObject) this).RaisePropertyChanged(nameof(Message));
            }
        }

        public DolgozoViewModel List { get; }

        public MainWindowViewModel(DolgozoManager db)
        {
            List = new DolgozoViewModel(db.dolgozok());
        }

        public string Greeting => "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc at dolor tempus, dignissim massa ac, semper nisl. In vulputate placerat suscipit. Pellentesque blandit tellus nisl, eu maximus tellus tristique et. Nunc sollicitudin orci pulvinar vestibulum gravida. Pellentesque placerat interdum magna, in tincidunt diam varius nec. Curabitur sagittis metus eget turpis tempus, at pulvinar lectus pellentesque. Pellentesque gravida posuere tortor in ultrices. Ut accumsan erat massa, quis semper sem sollicitudin a. Etiam iaculis gravida fermentum. Nam vel quam ac orci posuere sagittis quis ac velit. Phasellus id justo vel odio molestie fringilla. Pellentesque pharetra dignissim magna. Ut condimentum pulvinar elementum. Pellentesque at nibh in nulla tristique tristique. Curabitur posuere euismod augue et malesuada. !";
    }
}