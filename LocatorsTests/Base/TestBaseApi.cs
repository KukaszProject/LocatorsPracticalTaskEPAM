using Core.Client;
using Core.Utilities;
using log4net;

public abstract class TestBaseApi
{
    protected ApiClient _apiClient;
    protected ILog _logger;

    [OneTimeSetUp]
    public void GlobalSetUp()
    {
        _logger = LogManager.GetLogger(GetType());
        _logger.Info("=== Starting API tests ===");
        _apiClient = new ApiClient(ConfigHelper.Get("BaseUrlApi"), _logger);
    }

    [OneTimeTearDown]
    public void GlobalTearDown()
    {
        _logger.Info("=== Finished API tests ===");
    }
}
