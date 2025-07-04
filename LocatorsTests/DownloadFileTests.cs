using LocatorsPracticalTask.Core;
using LocatorsPracticalTask.Pages;
using OpenQA.Selenium;

namespace LocatorsPracticalTask.Tests
{
    public class DownloadFileTests : TestBase
    {
        [Test]
        public void DownloadFileTest()
        {
            var home = new HomePage(Driver);
            var about = new AboutPage(Driver);

            home.AcceptCookies();
            home.GoToAbout();
            about.DownloadButtonClicked();

            Assert.True(about.WaitForFileDownload(
                Path.Combine(Directory.GetCurrentDirectory(), "Downloads"),
                "EPAM_Corporate_Overview*.pdf",
                10), "File was not downloaded successfully.");
        }
    }
}
