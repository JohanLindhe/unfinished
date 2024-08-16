using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Labb4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class KassaVy : Page
    {
        public KassaVy()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is Tuple<
                ObservableCollection<Film>,
                ObservableCollection<Spel>,
                ObservableCollection<Bok>> tuple)
            {
                var allFilmer = tuple.Item1;
                var allSpel = tuple.Item2;
                var allBocker = tuple.Item3;

             
           
                FilmLista.ItemsSource = allFilmer;
                SpelLista.ItemsSource = allSpel;
                BokLista.ItemsSource = allBocker;
            }
        }
        private void FilmLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
        private void SpelLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
        private void BokLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
        private void ToLager_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
