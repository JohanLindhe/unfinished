using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Labb4
{
    public class Bok : Product
    {
        public string Forfattare { get; set; }
        public string Genre { get; set; }
        public string Format { get; set; }
        public string Sprak { get; set; }

        public Bok(string name, int varuNr, int price, string forfattare, string genre, string format, string sprak) : base(name, varuNr, price)
        {
            Forfattare = forfattare;
            Genre = genre;
            Format = format;
            Sprak = sprak;
        }

        public async Task ShowMessageDialog(ObservableCollection<Bok> bokLista)
        {
            MessageDialog msgOpen = new MessageDialog("Vill du radera produkten?");
            msgOpen.Commands.Add(new UICommand("Ja"));
            msgOpen.Commands.Add(new UICommand("Avbryt"));

            var msgResultOpen = await msgOpen.ShowAsync();

            if (msgResultOpen.Label == "Ja")
            {
                // Ta bort produkten från listan
                bokLista.Remove(this);
            }
            else if (msgResultOpen.Label == "Avbryt")
            {
                return;
            }
        }

        public static void AddBok(string name, int varuNrBok, int price, string forfattare, string genre, string sprak, string formatBok, ObservableCollection<Bok> boklista)
        {
            // Skapa en ny Bok och lägg till den i listan
            Bok newBok = new Bok(name, varuNrBok, price, forfattare, genre, formatBok, sprak);
            boklista.Add(newBok);
        }
    }
}
