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
using System.Xml.Linq;

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
            if (string.IsNullOrEmpty(txtName.Text))
            {
                window.ThePlayer.PlayerName = "Player";
            }
            else
            {
                //playerinput
                window.ThePlayer.PlayerName = txtName.Text;
            }

            //swap pages from menu to location
            //template:
            //NavigationService.Navigate(new Uri("", UriKind.Relative));
            NavigationService.Navigate(new Uri("Locations.xaml", UriKind.Relative));
        }
    }
}
