using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Labb4
{
    public class Product
    {
        public string Name { get; set; }
        public int VaruNr { get; set; }
        public int Price { get; set; }

        // Lista över filmer för produkten
        public ObservableCollection<Film> Filmer { get; set; }

        // Lista över spel för produkten
        public ObservableCollection<Spel> DataSpel { get; set; }

        public ObservableCollection<Bok> bocker { get; set; }

        public Product(string name, int varuNr, int price)
        {
            Name = name;
            VaruNr = varuNr;
            Price = price;

            Filmer = new ObservableCollection<Film>();
            DataSpel = new ObservableCollection<Spel>();
            bocker = new ObservableCollection<Bok>();
        }

        }

    }

