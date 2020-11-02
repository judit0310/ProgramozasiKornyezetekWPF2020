using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Progkorny.Models;
using Progkorny.ViewModels;
using Progkorny.Views;

namespace Progkorny
{
    public class DolgozoFormWindow : Window
    {
        public DolgozoFormWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void validateForm(object sender, RoutedEventArgs e)
        {
            TextBox nev = this.Find<TextBox>("nevmezo");
            TextBox fizetes = this.Find<TextBox>("fizetesmezo");
            TextBox szemelyiSzam = this.Find<TextBox>("szemelyiszammezo");
            DatePicker szuletesiDatum = this.Find<DatePicker>("szuletesidatummezo");
            nev.Background = null;
            fizetes.Background = null;
            szemelyiSzam.Background = null;
            szuletesiDatum.Background = null;
            bool validNev = this.validNev(nev.Text);
            bool validFizetes = this.validFizetes(fizetes.Text);
            bool validSzemelyi = this.validSzemelyiSzam(szemelyiSzam.Text);
            bool validszuletesidatum = this.validSzuletesiDatum(szuletesiDatum.Text);

            
            if (!validNev)
            {
                nev.Background = Brushes.Red;
            }
       

            if (!validFizetes)
            {
                fizetes.Background = Brushes.Red;
            }
            if (!validSzemelyi)
            {
                szemelyiSzam.Background = Brushes.Red;
            }
            if (!validszuletesidatum)
            {
                szuletesiDatum.Background = Brushes.Red;
            }

            if (validszuletesidatum && validFizetes && validNev && validSzemelyi)
            {
                Dolgozo dolgozo = new Dolgozo();
                dolgozo.Nev = nev.Text;
                dolgozo.Fizetes = Int64.Parse(fizetes.Text);
                dolgozo.SzemelyiSzam = szemelyiSzam.Text;
                dolgozo.SzuletesiDatum = DateTime.Parse(szuletesiDatum.Text);
                Console.WriteLine(dolgozo);
                MainWindowViewModel mvvm = (MainWindowViewModel) this.DataContext;
                mvvm.List.Dolgozok.Add(dolgozo);
            }
 
            
            
        }

        private bool validNev(string nev)
        {
            Dolgozo d = new Dolgozo();
            try
            {
                d.Nev = nev;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }

        private bool validFizetes(string fizetes)
        {
            Dolgozo d = new Dolgozo();
            try
            {
                d.Fizetes = Int64.Parse(fizetes);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }

        private bool validSzuletesiDatum(string szuletesidatum)
        {
            Dolgozo d = new Dolgozo();
            try
            {
                d.SzuletesiDatum = DateTime.Parse(szuletesidatum);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;

        }

        private bool validSzemelyiSzam(string szemelyiszam)
        {
            Dolgozo d = new Dolgozo();
            try
            {
                d.SzemelyiSzam = szemelyiszam;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }
    }
}