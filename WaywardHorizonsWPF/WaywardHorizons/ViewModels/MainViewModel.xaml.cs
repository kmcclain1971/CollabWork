using Microsoft.Extensions.Logging;
using System.Windows;
using System.Windows.Controls;
using WaywardHorizons.Helpers;
using WaywardHorizons.Interfaces;

namespace WaywardHorizons
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainViewModel : IMainViewModel
    {
        private readonly ILogger<MainViewModel> _logger;
        private readonly IUtilityService _utilityService;

        public MainViewModel(ILogger<MainViewModel> logger, IUtilityService utilityService)
        {
            _logger = logger;
            _utilityService = utilityService;

            _logger.LogInformation("Main window component has been intialized");

            // start up menu page
            _logger.LogInformation("Passing off to menu view");
        }

    }
}