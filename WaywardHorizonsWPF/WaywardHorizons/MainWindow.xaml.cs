using System.Windows;
using WaywardHorizons.Helpers;
using WaywardHorizons.Interfaces;

namespace WaywardHorizons
{
    public partial class MainWindow : Window
    {
        private readonly IUtilityService _utilityService;

        public MainWindow(IMainViewModel viewModel, IUtilityService utilityService)
        {
            InitializeComponent();
            DataContext = viewModel;
            _utilityService = utilityService;

            // load the menu view
            PageFrame.Navigate(new MenuViewModel(_utilityService));
        }
    }
}
