using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using WaywardHorizons.Characters;

namespace WaywardHorizons
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class MenuViewModel : Page
    {
        public MenuViewModel()
        {
            InitializeComponent();
        }

        #region Handlers

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //process the input
                ProcessPlayerInput();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProcessPlayerInput();
        }

        #endregion

        #region Methods

        private void ProcessPlayerInput()
        {
            // take the user input and create the instance of the Person class for the player
            var player = new Person()
            {
                // The below is an example of using the ternary operator (https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator)
                // for creating succinct if/then logic
                PlayerName = !string.IsNullOrEmpty(txtName.Text) ? txtName.Text : "Generic Player"
            };

            // swap pages from menu to location
            // using new instance of page object instead of page Uri so we can pass items to page constructors
            NavigationService.Navigate(new LocationsViewModel(player));
        }

        #endregion

    }
}
