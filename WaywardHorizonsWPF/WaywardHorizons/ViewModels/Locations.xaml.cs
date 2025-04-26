using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WaywardHorizons.Characters;
using WaywardHorizons.Interfaces;

namespace WaywardHorizons
{
    /// <summary>
    /// Interaction logic for Locations.xaml
    /// </summary>
    public partial class LocationsViewModel : Page
    {
        private readonly IUtilityService _utilityService;
        private Person _player { get; set; }

        public LocationsViewModel(Person player, IUtilityService utilityService)
        {
            InitializeComponent();
            _player = player;
            _utilityService = utilityService;
        }

        private void Lake_Click(object sender, RoutedEventArgs e)
        {
            int lakeId = 1;
            NavigationService.Navigate(new LakeViewModel(_player, lakeId, _utilityService));
        }

        private void Forest_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ForestViewModel());
        }

        private void Swamp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SwampViewModel());
        }

        private void Grove_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GroveViewModel());
        }

        private void Desert_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DesertViewModel());
        }
    }
}
