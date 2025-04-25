using System.Windows;
using System.Windows.Controls;
using WaywardHorizons.Characters;
using WaywardHorizons.Environment;
using WaywardHorizons.Helpers;

namespace WaywardHorizons
{
    /// <summary>
    /// Interaction logic for Lake.xaml
    /// </summary>
    public partial class Lake : Page
    {
        private Person _player { get; set; }
        private int _locationId { get; set; }
        public List<Event> LocationEvents { get; set; }

        public Lake(Person player, int LocationId)
        {
            InitializeComponent();
            _player = player;
            _locationId = LocationId;
            LocationEvents = GenerateLakeEvents();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //var location = new Location();
            //location.LocationId = _locationId;
            //location.Explore(_player);
            lbEvents.ItemsSource = LocationEvents;
        }


        private List<Event> GenerateLakeEvents()
        {
            var util = new Utility();
            return util.GenerateEvents(_locationId);
        }
    }
}
