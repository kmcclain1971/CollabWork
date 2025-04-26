using System;
using System.Collections;
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
using System.Xml.Linq;
using WaywardHorizons.Characters;

namespace WaywardHorizons
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        MainWindow window = (MainWindow)Application.Current.MainWindow;
        public Menu()
        {
            InitializeComponent();
        }

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

        private void ProcessPlayerInput()
        {
            // take the user input and create the instance of the Person class for the player
            var player = new Person()
            {
                // The below is an example of using the ternary operator (https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator)
                // for creating succinct if/then logic
                PlayerName = !string.IsNullOrEmpty(txtName.Text) ? txtName.Text : "Generic Player"
            };

            //swap pages from menu to location
            NavigationService.Navigate(new Locations(player));
        }

    }
}
