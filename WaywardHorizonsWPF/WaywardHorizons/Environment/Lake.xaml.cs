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
using WaywardHorizons.Characters;
using WaywardHorizons.Environment;

namespace WaywardHorizons
{
    /// <summary>
    /// Interaction logic for Lake.xaml
    /// </summary>
    public partial class Lake : Page
    {
        private Person _player { get; set; }
        private int _locationId { get; set; }

        public Lake(Person player, int LocationId)
        {
            InitializeComponent();
            _player = player;
            _locationId = LocationId;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var location = new Location();
            location.LocationId = _locationId;
            location.Explore(_player);
        }


        private void GenerateLakeEvents()
        {

        }
    }
}
