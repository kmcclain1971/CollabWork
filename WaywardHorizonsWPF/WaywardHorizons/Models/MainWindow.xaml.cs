using System.Windows;
using System.Windows.Controls;

namespace WaywardHorizons
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainViewModel : Window
    {
        public MainViewModel()
        {
            InitializeComponent();
            // start up menu page
            PageFrame.Navigate(new MenuViewModel());
        }

    }
}