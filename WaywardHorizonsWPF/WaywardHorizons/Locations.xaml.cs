using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WaywardHorizons
{
    /// <summary>
    /// Interaction logic for Locations.xaml
    /// </summary>
    public partial class Locations : Page
    {
        public Locations()
        {
            InitializeComponent();
        }

        private void Lake_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Lake.xaml", UriKind.Relative));
        }

        private void Forest_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Forest.xaml", UriKind.Relative));
        }

        private void Swamp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Swamp.xaml", UriKind.Relative));
        }

        private void Grove_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Grove.xaml", UriKind.Relative));
        }

        private void Desert_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Desert.xaml", UriKind.Relative));
        }
    }
}
