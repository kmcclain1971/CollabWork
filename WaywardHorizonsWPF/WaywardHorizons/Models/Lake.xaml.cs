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
    public partial class LakeViewModel : Page
    {
        private Person _player { get; set; }
        private int _locationId { get; set; }
        public List<Event> LocationEvents { get; set; }

        public LakeViewModel(Person player, int LocationId)
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
            // set the tbEvent text value to the first event description in the array to get started
            tbEvent.Text = LocationEvents[0].Description.ToString();
            // give the list box our list of event actions
            lbEvents.ItemsSource = LocationEvents[0].Choices;
        }


        private List<Event> GenerateLakeEvents()
        {
            var util = new Utility();
            return util.GenerateEvents(_locationId);
        }

        private void lbEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // this will perform the action and load new stuff
            tbEvent.Text = lbEvents.SelectedItem.ToString();
        }

        private void ChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            // this will perform the action and load new stuff
        }
    }
}
