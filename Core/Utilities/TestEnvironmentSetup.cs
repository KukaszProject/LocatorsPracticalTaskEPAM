using NUnit.Framework;

namespace Core.Utilities
{
    public static class TestEnvironmentSetup
    {
        public static void RunBeforeAllTests()
        {
            CleanFolder(ConfigHelper.Get("DownloadFolder"));
            CleanFolder(ConfigHelper.Get("ScreenshotsFolder"));
            CleanFolder(ConfigHelper.Get("LogsFolder"));
        }

        private static void CleanFolder(string folderName)
        {
            var folderPath = Path.Combine(TestContext.CurrentContext.WorkDirectory, folderName);
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
            }
        }
    }
}
