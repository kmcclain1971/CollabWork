using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AdoptAFish_v2.Utilities;

namespace AdoptAFish_v2
{
    public class Application : IHostedService
    {
        //NOTE: set our contants and privates here
        private readonly IHostApplicationLifetime _hostLifetime;
        private readonly ILogger _logger;
        private readonly ILibrary _library;
        private int? _exitCode;

        //NOTE: if any public needed set them here

        public Application(IHostApplicationLifetime hostLifetime, ILoggerFactory logger, ILibrary library)
        {
            _hostLifetime = hostLifetime;
            _logger = logger.CreateLogger<Application>();
            _library = library;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Initiating the Adopt A Fish v2.0 application!");
            Console.WriteLine("Welcome to ¸.·´¯`·.´¯`·.¸¸.·´¯`·.¸><(((º> the Awesome Adopt A Fish Agency ¸.·´¯`·.´¯`·.¸¸.·´¯`·.¸<°))))><!!!\"");

            try
            {
                var player = _library.SetUpPlayer();
                if (player.PlayerName != null)
                {
                    Console.WriteLine($"Nice to meet you {player.PlayerName}! Let's get your free tank and fish setup :)");
                    //TODO: Set up free tank and fish using the detail randomizers for both
                }
                else {
                    throw new Exception("No player name supplied!");
                }

                //// this is freebie
                //// add fish to tank - give the new fish object to Tank
                //tank.Fishes.Add(SetFishProperties());

                //// display the tank information
                //Console.WriteLine(player.Information());
                //Console.WriteLine(tank.Information());

                ////
                //DisplayMenu();
            }
            catch (OperationCanceledException)
            {
                Console.Error.WriteLine("The job has been killed with CTRL+C");
                _logger?.LogInformation("The job has been killed with CTRL+C");
                _exitCode = -1;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("An error occurred: " + ex.ToString());
                _logger?.LogError("An error occurred: " + ex.ToString());
                _exitCode = 1;
            }
            finally
            {
                _hostLifetime.StopApplication();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Environment.ExitCode = _exitCode.GetValueOrDefault(-1);
            Console.WriteLine("Shutting down the service with code " + Environment.ExitCode);
            _logger?.LogInformation("Shutting down the service with code " + Environment.ExitCode);

            return Task.CompletedTask;
        }

        
    }
}
