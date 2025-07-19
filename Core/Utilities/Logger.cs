using log4net.Config;
using log4net;
public sealed class Logger
{
    private static readonly Lazy<ILog> instance = new(() =>
    {
        var logConfig = new FileInfo("Resources/Log.config");
        XmlConfigurator.Configure(logConfig);
        return LogManager.GetLogger(typeof(Logger));
    });

    public static ILog Instance => instance.Value;

    private Logger() { }
}
