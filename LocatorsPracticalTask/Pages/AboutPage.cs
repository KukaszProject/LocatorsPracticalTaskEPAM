using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LocatorsPracticalTask.Pages
{
    public class AboutPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public AboutPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement EpamAtGlanceSection => driver.FindElement(By.Id("epam-at-glance"));
        private IWebElement DownloadButton => driver.FindElement(By.LinkText("DOWNLOAD"));

        public void DownloadButtonClicked() => wait.Until(ExpectedConditions.ElementToBeClickable(DownloadButton)).Click();


        public bool WaitForFileDownload(string directory, string expectedFileName, int timeoutSeconds = 10)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            while (watch.Elapsed.TotalSeconds < timeoutSeconds)
            {
                var files = Directory.GetFiles(directory, expectedFileName);
                if (files.Length > 0)
                {
                    // Optionally: ensure the file is not still being written
                    FileInfo fileInfo = new FileInfo(files[0]);
                    if (!IsFileLocked(fileInfo))
                        return true;
                }
                Thread.Sleep(500);
            }
            return false;
        }

        private bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None)) { }
            }
            catch (IOException)
            {
                return true;
            }
            return false;
        }

    }
}
