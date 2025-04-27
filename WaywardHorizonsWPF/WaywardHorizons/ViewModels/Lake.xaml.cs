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
        private int _eventCount;
        private int _currentEvent;
        private List<Event> _locationEvents;

        public LakeViewModel(Person player, int LocationId, IUtilityService utilityService)
        {
            _player = player;
            _locationId = LocationId;
            _utilityService = utilityService;
            _locationEvents = _utilityService.GenerateEvents(_locationId);
            _eventCount = _locationEvents.Count-1; // take off 1 to account for zero based array
            _currentEvent = 0;

            InitializeComponent();
            SetPlayerStats();
            ShowEvent(_currentEvent);
        }

        #region Handlers
        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            ShowHideControls("showEvent");
            ShowEvent(_currentEvent <= _eventCount ? _currentEvent : 6); 
        }

        private void btnContinue_ReturnToMap(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LocationsViewModel(_player, _utilityService));
        }

        /// <summary>
        /// This will get the selection into an instance of EventChoice and pass that to the ParseChoice method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbEvents.SelectedItems.Count > 0)
            {
                var choice = (EventChoice)lbEvents.SelectedItems[0]; // Actions are at [0]
                ParseChoice(choice);
            }
        }
        #endregion

        #region Methods
        private void ShowEvent(int eventId)
        {
            if (eventId < 6)
            {
                // show/hide stuff as necessary
                ShowHideControls("showEvent");

                // set the tbEvent text value to the first event description in the array to get started
                tbEvent.Text = _locationEvents[_currentEvent].Description.ToString();
                // give the list box our list of event actions
                lbEvents.ItemsSource = _locationEvents[_currentEvent].Choices;
            }
            else
            {
                // show the end of exploration details
                ShowHideControls("showConclusion");
                tbEvent.Text = "Congratulations \"" + _player.PlayerName + "\"! You have explored all there is of Lava Lake! Feel free to return to the map and select another location to explore! :)";
                btnContinue.Content = "Return to Map";
                btnContinue.Click += new RoutedEventHandler(btnContinue_ReturnToMap);
            }
        }

        private void ParseChoice(EventChoice eventChoice)
        {
            // show/hide stuff as necessary
            ShowHideControls("showResults");

            tbActionResults.Text = "You chose to \"" + eventChoice.ChoiceText.Replace("- ","") + "\" and the following happened:\n";
            tbActionResults.Text += eventChoice.ActionText.ToString();

            // update player object
            eventChoice.ActionToTake.Invoke(_player);
            SetPlayerStats();
            _currentEvent++;
        }

        private void SetPlayerStats()
        {
            var statsText = "Health: " + _player.Health + "\n";
            statsText += "Supplies: " + _player.Supplies;
            tbPlayerStats.Text = statsText;
        }

        private void ShowHideControls(string action)
        {
            switch (action)
            {
                case "showEvent":
                    spEventActions.Visibility = Visibility.Visible;
                    tbActionResults.Visibility = Visibility.Hidden;
                    btnContinue.Visibility = Visibility.Hidden;
                    break;
                case "showResults":
                    spEventActions.Visibility = Visibility.Hidden;
                    tbActionResults.Visibility = Visibility.Visible;
                    btnContinue.Visibility = Visibility.Visible;
                    break;
                case "showConclusion":
                    spEventActions.Visibility = Visibility.Visible;
                    lbEvents.Visibility = Visibility.Hidden;
                    tbActionResults.Visibility = Visibility.Hidden;
                    btnContinue.Visibility = Visibility.Visible;
                    break;
                default:
                    spEventActions.Visibility = Visibility.Visible;
                    tbActionResults.Visibility = Visibility.Hidden;
                    btnContinue.Visibility = Visibility.Hidden;
                    break;
            }
        }
        #endregion
    }
}
