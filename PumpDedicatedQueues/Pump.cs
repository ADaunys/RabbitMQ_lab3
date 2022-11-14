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
                    //test simple call
                    var left = rnd.Next(-100, 100);
                    var right = rnd.Next(-100, 100);

                    log.Info($"Before 'int Add(int, int)': left={left}, right={right}");
                    var sum = service.AddLiteral(left, right);
                    log.Info($"After 'int Add(int, int)': sum={sum}, left={left}, right={right}\n");

                    left = rnd.Next(-100, 100);
                    right = rnd.Next(-100, 100);
                    var leftAndRight = new ByValStruct() { Left = left, Right = right };

                    Thread.Sleep(2000);

                    //test passing structures by value
                    log.Info(
                        $"Before 'ByValStruct Add(ByValStruct)': leftAndRight=ByValStruct" +
                        $"(Left={leftAndRight.Left}, Right={leftAndRight.Right}, Sum={leftAndRight.Sum})"
                    );
                    var result = service.AddStruct(leftAndRight);
                    log.Info(
                        $"After 'ByValStruct Add(ByValStruct)': leftAndRight=ByValStruct" +
                        $"(Left={leftAndRight.Left}, Right={leftAndRight.Right}, Sum={leftAndRight.Sum})"
                    );
                    log.Info(
                        $"After 'ByValStruct Add(ByValStruct)': result=ByValStruct" +
                        $"(Left={result.Left}, Right={result.Right}, Sum={result.Sum})\n"
                    );

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
