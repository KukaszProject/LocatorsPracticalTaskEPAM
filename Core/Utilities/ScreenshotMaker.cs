using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace LocatorsPracticalTask.Core.Utilities
{
    public static class ScreenshotMaker
    {
        public static string TakeScreenshot(IWebDriver driver, string testName, string directory = "Screenshots")
        {
            try
            {
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var timestamp = DateTime.Now.ToString("yyyy_MM_dd_HH-mm-ss");
                var safeTestName = Regex.Replace(testName, @"[^\w\-]", "_");
                var filePath = Path.Combine(directory, $"{safeTestName}_{timestamp}.png");

                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(filePath);

                return filePath;
            }
            catch (Exception ex)
            {
                return $"Failed to capture screenshot: {ex.Message}";
            }
        }
    }
}

