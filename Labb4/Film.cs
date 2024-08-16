using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Labb4
{
    public class Film : Product
    {
        public int PlayTime { get; set; }
        public string Format { get; set; }

        public Film(string name, int varuNr, int price, int playTime, string format) : base(name, varuNr, price)
        {
            PlayTime = playTime;
            Format = format;
        }

        public static void AddFilm(string name, int varuNr, int price, string format, int playtime, ObservableCollection<Film> filmLista)
        {
            // Skapa en ny film och lägg till den i listan
            Film newFilm = new Film(name, varuNr, price, playtime, format);
            filmLista.Add(newFilm);
        }

        public async Task ShowMessageDialog(ObservableCollection<Film> filmList)
        {
            MessageDialog msgOpen = new MessageDialog("Vill du radera produkten?");
            msgOpen.Commands.Add(new UICommand("Ja"));
            msgOpen.Commands.Add(new UICommand("Avbryt"));

            var msgResultOpen = await msgOpen.ShowAsync();

            if (msgResultOpen.Label == "Ja")
            {
                filmList.Remove(this);
            }
            else if (msgResultOpen.Label == "Avbryt")
            {
                return;
            }
        }
    }
}
