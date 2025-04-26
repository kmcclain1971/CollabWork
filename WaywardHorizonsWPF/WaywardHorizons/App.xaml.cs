using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WaywardHorizons.Helpers;
using WaywardHorizons.Interfaces;

namespace WaywardHorizons
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// <remarks>Read the information found in the URL in seealso for a good explanation of why you are choosing to use dependency injection (DI)</remarks>
    /// <seealso cref="https://medium.com/@shalahuddinshanto/dependency-injection-in-wpf-a-complete-implementation-guide-468abcf95337"/>
    public partial class App : Application
    {
        private IServiceProvider? _serviceProvider;

        // start up the application
        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            _serviceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        // this method allows us to get all services and objects setup for the application use
        private void ConfigureServices(IServiceCollection services)
        {
            // Configure Logging
            services.AddLogging();

            // Register Services
            services.AddSingleton<IUtilityService, UtilityService>();

            // Register ViewModels
            services.AddSingleton<IMainViewModel, MainViewModel>();

            // Register Views - start with just the Main Window
            services.AddSingleton<MainWindow>();
        }

        // clean up anything that has IDisposable implemented
        // This means clean up the garbage from the run, e,g: open database connections, memory used, file space, etc.
        private void OnExit(object sender, ExitEventArgs e)
        {
            // Dispose of services if needed
            if (_serviceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }

}
