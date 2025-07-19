using OpenQA.Selenium;
using System.Text.RegularExpressions;
using log4net;

namespace LocatorsPracticalTask.Core.Utilities
{
    public static class ScreenshotMaker
    {
        private static ILog Log => Logger.Instance;

        public static string TakeScreenshot(IWebDriver driver, string testName)
        {
            var directory = ConfigHelper.Get("ScreenshotsFolder");
            try
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var timestamp = DateTime.Now.ToString("yyyy_MM_dd_HH-mm-ss");
                var safeTestName = Regex.Replace(testName, @"[^\w\-]", "_");
                var filePath = Path.Combine(directory, $"{safeTestName}_{timestamp}.png");

                Log.Info($"Capturing screenshot for test: {testName} at {filePath}...");
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(filePath);

                return filePath;
            }
            catch (Exception ex)
            {
                Log.Error($"Failed to capture screenshot for test: {testName}. Error: {ex.Message}");
                return $"Failed to capture screenshot: {ex.Message}";
            }
        }
    }
}

