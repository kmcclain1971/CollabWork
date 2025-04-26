using System.Windows;
using System.Windows.Controls;
using WaywardHorizons.Characters;
using WaywardHorizons.Helpers;
using WaywardHorizons.Interfaces;

namespace WaywardHorizons
{
    /// <summary>
    /// Interaction logic for Lake.xaml
    /// </summary>
    public partial class LakeViewModel : Page
    {
        private readonly IUtilityService _utilityService;
        private Person _player;
        private int _locationId;
        private List<Event> _locationEvents;

        public LakeViewModel(Person player, int LocationId, IUtilityService utilityService)
        {
            _player = player;
            _locationId = LocationId;
            _utilityService = utilityService;
            _locationEvents = _utilityService.GenerateEvents(_locationId);

            InitializeComponent();
            ShowInitialEvent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void ShowInitialEvent()
        {
            // set the tbEvent text value to the first event description in the array to get started
            tbEvent.Text = _locationEvents[0].Description.ToString();
            // give the list box our list of event actions
            lbEvents.ItemsSource = _locationEvents[0].Choices;
        }

        /// <summary>
        /// This will get the selection into an instance of EventChoice and pass that to the ParseChoice method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var choice = (EventChoice)lbEvents.SelectedItems[0]; // Actions are at [0]
            ParseChoice(choice);
        }

        private void ParseChoice(EventChoice eventChoice)
        {
            // show/hide stuff as necessary
            spEventActions.Visibility = Visibility.Hidden;
            tbActionResults.Visibility = Visibility.Visible;
            btnContinue.Visibility = Visibility.Visible;

            tbActionResults.Text += "You chose " + eventChoice.ChoiceText.Replace("- ","") + " and the following happened:\n\n";
            tbActionResults.Text += eventChoice.ActionText.ToString();
        }
    }
}
