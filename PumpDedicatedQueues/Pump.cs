namespace Clients;

using NLog;

using Commons.Utils;
using Clients.Services;


/// <summary>
/// Client
/// </summary>
class Pump
{
    /// <summary>
    /// Logger for this class.
    /// </summary>
    private Logger log = LogManager.GetCurrentClassLogger();

    /// <summary>
    /// Program body.
    /// </summary>
    private void Run()
    {
        LoggingUtil.ConfigureNLog();

        //main loop
        while (true)
        {
            try
            {
                //connect to server
                var service = new ServiceClient();
                log.Info($"Client ID is '{service.ClientId}'");

                //test service
                var rnd = new Random();

                while (true)
                {
                    var canPump = service.CanSubtract();

                    Thread.Sleep(2000);

                    var liquidToPump = rnd.Next(1, 20);

                    if (canPump)
                    {
                        log.Info($"Generated amount to pump out: {liquidToPump}");
                        var pumpedLiquid = service.Subtract(liquidToPump);
                        log.Info($"Amount of liquid pumped out: {pumpedLiquid}");
                        log.Info("\n");
                    }
                    else
                    {
                        log.Info("I cannot pump out the liquid");
                        log.Info("\n");
                    }
                    log.Info("---");

                    Thread.Sleep(2000);
                }
            }
            catch (Exception e)
            {
                //log exceptions
                log.Error(e, "Unhandled exception caught. Restarting.");

                //prevent console spamming
                Thread.Sleep(2000);
            }
        }
    }

    /// <summary>
    /// Program entry point.
    /// </summary>
    /// <param name="args">Command line arguments.</param>
    static void Main(string[] args)
    {
        var self = new Pump();
        self.Run();
    }
}
