namespace Servers;

using NLog;

using Commons.Utils;


/// <summary>
/// Server
/// </summary>
class Server
{
    /// <summary>
    /// Logger for this class.
    /// </summary>
    private Logger log = LogManager.GetCurrentClassLogger();

    public static int capacity = new Random().Next(0, 100);
    public static int lowerBound = 0;
    public static int upperBound = 0;

    /// <summary>
    /// Program body.
    /// </summary>
    private void Run()
    {
        //configure logging
        LoggingUtil.ConfigureNLog();

        while (true)
        {
            try
            {
                //start service
                var service = new Service();

                //
                log.Info("Server has been started.");

                //hang main thread						
                while (true)
                {
                    lowerBound = new Random().Next(0, 50);
                    upperBound = new Random().Next(lowerBound + 1, 100);
                    log.Info("Bounds changed to: " + lowerBound + " " + upperBound);
                    Thread.Sleep(4000);
                }
            }
            catch (Exception e)
            {
                //log exception
                log.Error(e, "Unhandled exception caught. Server will now restart.");

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
        var self = new Server();
        self.Run();
    }
}