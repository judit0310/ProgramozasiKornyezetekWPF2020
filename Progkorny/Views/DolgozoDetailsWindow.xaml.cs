using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Progkorny
{
    public class DolgozoDetailsWindow : Window
    {
        public DolgozoDetailsWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}