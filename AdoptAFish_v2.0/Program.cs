using AdoptAFish_v2.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace AdoptAFish_v2;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
        // Keep this main method pretty lean and mean - logic should be avoided here if possible just get things needed for starting and running the app
 
        // In general, if you have more than 5 or 6 lines of code doing one thing,
        // put that into a method so it's easier to maintain and easier to test (referencing the console properties setup of original code)
        SetConsoleProperties();

        // Make use of //TODO: comments - they can be very handy for keeping track of where you leave off in code
        // To see your list of TODOs for an application, go to top menu View > TaskList
        //TODO: Start application from here - application class will hold the main logic components
        

        var host = CreateHostBuilder();
        await host.RunConsoleAsync();
        return Environment.ExitCode;

    }

    private static IHostBuilder CreateHostBuilder()
    {
        // Use this area for setting up the things the application needs to run, like dependency injection, database connections, logging, etc.
        return Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    // set the configuration file - this file is used to store values that are needed to be accessed from anywhere in the application
                    var settingsFile = "appsettings.json";
                    var configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile(settingsFile, false)
                            .Build();

                    //setup our DI
                    services.AddSingleton(configuration);
                    services.AddSingleton<ILoggerFactory, LoggerFactory>();
                    services.AddSingleton<ILibrary, Library>();

                    // add the application logic to our hosted service so this starts running
                    services.AddHostedService<Application>();
                });
    }

    /// <summary>
    /// Best practice is to clearly name your methods so you and anyone else
    /// looking at the code will intuitively know what the method is doing
    /// </summary>
    private static void SetConsoleProperties()
    {
        Console.Title = "Adopt A Fish App";
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
    }
}
