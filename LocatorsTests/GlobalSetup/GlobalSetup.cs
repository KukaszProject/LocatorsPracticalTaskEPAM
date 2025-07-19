using LocatorsPracticalTask.Core.Utilities;

namespace LocatorsTests
{
    [SetUpFixture]
    public class GlobalSetup
    {
        [OneTimeSetUp]
        public void RunBeforeAllTests()
        {
            CleanFolder(ConfigHelper.Get("DownloadFolder"));
            CleanFolder(ConfigHelper.Get("ScreenshotsFolder"));
            CleanFolder(ConfigHelper.Get("LogsFolder"));
        }

        private void CleanFolder(string folderName)
        {
            var folderPath = Path.Combine(TestContext.CurrentContext.WorkDirectory, folderName);
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
            }
        }
    }
}
