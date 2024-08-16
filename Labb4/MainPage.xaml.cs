using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static System.Net.Mime.MediaTypeNames;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Labb4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Spel> Spel { get; set; }
        public ObservableCollection<Film> Filmer { get; set; }
        public ObservableCollection<Bok> Bocker { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Spel = new ObservableCollection<Spel>();
            Filmer = new ObservableCollection<Film>();
            Bocker = new ObservableCollection<Bok>();

            // Lägg till filmer
            Filmer.Add(new Film("The Shawshank Redemption", 1, 10, 142, "DVD"));
            Filmer.Add(new Film("The Godfather", 2, 12, 175, "Blu-Ray"));

            // Lägg till spel
            Spel.Add(new Spel("The Witcher 3: Wild Hunt", 3, 50, "Playstation 4"));
            Spel.Add(new Spel("The Legend of Zelda: Breath of the Wild", 4, 45, "Nintendo Switch"));

            // Sätt datakällorna för listorna
            FilmLista.ItemsSource = Filmer;
            SpelLista.ItemsSource = Spel;
            BokLista.ItemsSource = Bocker;
        }

        private int GenerateUniqueVaruNr()
        {
            Random rnd = new Random();
            int varuNr;

            // Slumpa ett varunummer och kontrollera om det redan används
            do
            {
                varuNr = rnd.Next(1, 1000); // Slumpmässigt generera ett varunummer mellan 1 och 1000
            }
            //Do whilen är egen men det innanför parantesen i while är gtp. 
            while (Filmer.Any(film => film.VaruNr == varuNr) || Spel.Any(spel => spel.VaruNr == varuNr) || Bocker.Any(bok => bok.VaruNr == varuNr)); // Upprepa tills ett unikt nummer hittas

            return varuNr;
        }

        private void AddFilm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Hämta värden från inmatningsfälten
                string name = NameFilm.Text;
                string playTimeText = PlayTimeFilm.Text;
                string format = FormatFilm.Text;
                string priceFilm = PriceFilm.Text;

                if (string.IsNullOrWhiteSpace(name))
                {
                    messageFilm.Text = "Namn måste fyllas i.";
                    return;
                }

                if (string.IsNullOrWhiteSpace(priceFilm))
                {
                    messageFilm.Text = "Pris måste fyllas i.";
                    return;
                }

                if (!int.TryParse(priceFilm, out int pricefilm) || pricefilm <= 0)
                {
                    messageFilm.Text = "Priset måste vara ett heltal större än 0.";
                    return;
                }

                if (!int.TryParse(playTimeText, out int playTime) || playTime <= 0)
                {
                    messageFilm.Text = "Speltiden måste vara ett heltal större än 0.";
                    return;
                }

                if (format.Any(char.IsDigit))
                {
                    messageFilm.Text = "Format får inte innehålla siffror.";
                    return;
                }

                int varuNr = GenerateUniqueVaruNr();

                Filmer.Add(new Film(name, varuNr, pricefilm, playTime, format));
                ClearFilmFields();
                messageFilm.Text = "Film tillagd!";
            }
            catch (FormatException)
            {
                messageFilm.Text = "Felaktigt format i ett av inmatningsfälten.";
            }
        }

        private void AddSpel_Click(object sender, RoutedEventArgs e)
        {

            try 
            {
                string name = nameSpel.Text;
                string pricespel = priceSpel.Text;
                string plattform = plattformSpel.Text;

                if (string.IsNullOrWhiteSpace(name))
                {
                    messagespel.Text = "Namn måste fyllas i.";
                    return;
                }

                if (string.IsNullOrWhiteSpace(pricespel))
                {
                    messagespel.Text = "Pris måste fyllas i.";
                    return;
                }
                if (!int.TryParse(pricespel, out int pricespeL) || pricespeL <= 0)
                {
                    messagespel.Text = "Priset måste vara ett heltal större än 0.";
                    return;
                }
                if (plattform.Any(char.IsDigit))
                {
                    messagespel.Text = "Plattform får inte innehålla siffror.";
                    return;
                }

                int varuNr = GenerateUniqueVaruNr();

                Spel.Add(new Spel(name, varuNr, pricespeL, plattform));

                ClearSpelFields();
                messagespel.Text = "Film tillagd!";
            }
            catch(FormatException) 
            {
                messagespel.Text = "Något gick fel, kontrolera inmatning";
            }
        }

        // Metod för att lägga till en bok med ett unikt varunummer
        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                string name = nameBok.Text;
                string pricebok = priceBok.Text;
                string format = formatBok.Text;
                string sprak = sprakBok.Text;
                string forfattare = forfattareBok.Text;
                string genre = genreBok.Text;

                if (string.IsNullOrWhiteSpace(name))
                {
                    messageBok.Text = "Namn måste fyllas i.";
                    return;
                }

                if (string.IsNullOrWhiteSpace(pricebok))
                {
                    messageBok.Text = "Pris måste fyllas i.";
                    return;
                }
                if (!int.TryParse(pricebok, out int priceboK) || priceboK <= 0)
                {
                    messageBok.Text = "Priset måste vara ett heltal större än 0.";
                    return;
                }
                if (sprak.Any(char.IsDigit))
                {
                    messageBok.Text = "Språk får inte innehålla siffror.";
                    return;
                }
                if (forfattare.Any(char.IsDigit))
                {
                    messageBok.Text = "Författare får inte innehålla siffror.";
                    return;
                }
                if (genre.Any(char.IsDigit))
                {
                    messageBok.Text = "Genre får inte innehålla siffror.";
                    return;
                }
                if (format.Any(char.IsDigit))
                {
                    messageBok.Text = "Format får inte innehålla siffror.";
                    return;
                }

                int varuNr = GenerateUniqueVaruNr();
                Bocker.Add(new Bok(name, varuNr, priceboK, forfattare, genre, sprak, format));

                ClearBookFields();
                messageBok.Text = "Film tillagd!";
            }
            catch
            {

            }
        }

        // I MainPage.xaml.cs
        private async void FilmLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilmLista.SelectedItem != null)
            {
                Film selectedFilm = FilmLista.SelectedItem as Film;
                await selectedFilm.ShowMessageDialog(Filmer);
            }
        }
        private async void SpelLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SpelLista.SelectedItem != null)
            {
                Spel selectedSpel = SpelLista.SelectedItem as Spel;
                await selectedSpel.ShowMessageDialog(Spel);
            }
        }

        private async void BokLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BokLista.SelectedItem != null)
            {
                Bok selectedBok = BokLista.SelectedItem as Bok;
                await selectedBok.ShowMessageDialog(Bocker);
            }
        }

        // Metod för att rensa filmens inputfält
        private void ClearFilmFields()
        {
            NameFilm.Text = "";
            PlayTimeFilm.Text = "";
            FormatFilm.Text = "";
            PriceFilm.Text = "";
        }

        // Metod för att rensa spelens inputfält
        private void ClearSpelFields()
        {
            nameSpel.Text = "";

            priceSpel.Text = "";
            plattformSpel.Text = "";
        }

        // Metod för att rensa bokens inputfält
        private void ClearBookFields()
        {
            nameBok.Text = "";
            priceBok.Text = "";
            formatBok.Text = "";
            sprakBok.Text = "";
            genreBok.Text = "";
            forfattareBok.Text = "";
        }

        private void ToKassa_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(KassaVy), Tuple.Create(Filmer, Spel, Bocker));
        }
    }
}
