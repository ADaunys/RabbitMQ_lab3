namespace Clients;

using NLog;

using Commons.Utils;
using Clients.Services;


/// <summary>
/// Client
/// </summary>
class Fill
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
                    var canAdd = service.CanAdd();

                    Thread.Sleep(2000);

                    var liquidToAdd = rnd.Next(1, 20);

                    if (canAdd)
                    {
                        log.Info($"Generated amount to add: {liquidToAdd}");
                        var addedLiquid = service.Add(liquidToAdd);
                        log.Info($"Amount of liquid added: {addedLiquid}");
                        log.Info("\n");
                    }
                    else
                    {
                        log.Info("I cannot add any more liquid");
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
        var self = new Fill();
        self.Run();
    }
}
