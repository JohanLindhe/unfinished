using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Labb4
{
    public class Spel : Product
    {
        public string Plattform { get; set; }

        public Spel(string name, int varuNr, int price, string plattform) : base(name, varuNr, price)
        {
            Plattform = plattform;
        }

        public async Task ShowMessageDialog(ObservableCollection<Spel> spelList)
        {
            MessageDialog msgOpen = new MessageDialog("Vill du radera produkten?");
            msgOpen.Commands.Add(new UICommand("Ja"));
            msgOpen.Commands.Add(new UICommand("Avbryt"));

            var msgResultOpen = await msgOpen.ShowAsync();

            if (msgResultOpen.Label == "Ja")
            {
                // Ta bort produkten från listan
                spelList.Remove(this);
            }
            else if (msgResultOpen.Label == "Avbryt")
            {
                return;
            }
        }

        // Metod för att lägga till ett spel
        public static void AddSpel(string name, int varuNr, int price, string plattform, ObservableCollection<Spel> spelList)
        {
            // Skapa en ny spel och lägg till den i listan
            Spel newSpel = new Spel(name, varuNr, price, plattform);
            spelList.Add(newSpel);
        }
    }
}