using System;
using System.Data;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Progkorny.Models;
using Progkorny.ViewModels;
using ReactiveUI;

namespace Progkorny.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TextBlock block = new TextBlock();
            block.Text = "Lorem";
            StackPanel panel = new StackPanel();
            panel.Children.Add(block);

            Button b = new Button();
            b.Content = "Szia";
            b.Background = Brushes.LightSkyBlue;
            Button b2 = new Button();
            b2.Content = "Dolgozo Hozzáadása";
            b2.Name = "btn2";
            b2.Click += formMegnyitasa;

            Grid grid = new Grid();
            grid.Width = 500;
            grid.Background = Brushes.Beige;
            grid.Margin = Thickness.Parse("20,10,20,10");
            grid.ShowGridLines = true;
            ColumnDefinition column1 = new ColumnDefinition(GridLength.Parse("2*"));
            ColumnDefinition column2 = new ColumnDefinition(GridLength.Parse("*"));
            grid.ColumnDefinitions.Add(column1);
            grid.ColumnDefinitions.Add(column2);
            RowDefinition row = new RowDefinition();
            grid.RowDefinitions.Add(row);
            Grid.SetColumn(b, 0);
            Grid.SetColumn(b2, 1);
            grid.Children.Add(b);
            grid.Children.Add(b2);

            panel.Children.Add(grid);
            WrapPanel root = this.Find<WrapPanel>("wrappanel");
            root.Orientation = Orientation.Vertical;
            root.Children.Add(panel);
            NameScope scope = new NameScope();
            b2.RegisterInNameScope(scope);
            root.RegisterInNameScope(scope);
            Button sayhibutton = this.Find<Button>("sayhibutton");
            sayhibutton.RegisterInNameScope(scope);
            sayhibutton.Click += sayhi;
            NameScope.SetNameScope(this, scope);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void sayhi(object sender, RoutedEventArgs e)
        {
            if (this.Find<TextBlock>("hiblock") == null)
            {
                TextBlock block = new TextBlock();
                block.Text = "Köszöntem";
                block.Name = "hiblock";
                block.RegisterInNameScope(this.FindNameScope());
                WrapPanel panel = this.Find<WrapPanel>("wrappanel");
                panel.Children.Add(block);
            }

            ((MainWindowViewModel) DataContext).Message = "Hello Bello";
            ((MainWindowViewModel) DataContext).List.Dolgozok.Add(new Dolgozo
                {Nev = "Kovács Gergő", SzuletesiDatum = new DateTime(1992, 4, 30)});
        }

        private void enlargeBox(object sender, GotFocusEventArgs e)
        {
            TextBox senderbox = (TextBox) sender;
            senderbox.Width = 700;
            senderbox.FontSize = senderbox.FontSize * 2;
        }

        public void defaultFont(object sender, RoutedEventArgs e)
        {
            TextBox senderbox = (TextBox) sender;
            senderbox.FontSize = senderbox.FontSize / 2;
        }

        public void formMegnyitasa(object sender, RoutedEventArgs e)
        {
            DolgozoFormWindow window = new DolgozoFormWindow()
            {
                DataContext = this.DataContext
            };
            window.ShowDialog(this);
        }

        public void selectedDolgozo(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                ListBox senderbox = (ListBox) sender;
                Console.WriteLine("Selection changed");
                Console.WriteLine(senderbox.SelectedItem);
              
                
                DolgozoDetailsWindow details = new DolgozoDetailsWindow()
                {
                    DataContext = new DolgozoView( (Dolgozo) senderbox.SelectedItem )
                };
                senderbox.UnselectAll();
                details.ShowDialog(this);
            }
        }
    }
}