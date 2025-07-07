using LocatorsPracticalTask.Core.Utilities;
using LocatorsPracticalTask.Pages;
using Core.Utilities;

namespace LocatorsTests
{
    public class DownloadFileTests : TestBase
    {
        [TestCase("EPAM_Corporate_Overview*.pdf")]
        public void DownloadFileTest(string fileName)
        {
            var home = new HomePage(Driver);
            var about = new AboutPage(Driver);
            var utility = new FileHelper();

            home.AcceptCookies();
            home.GoToAbout();
            about.DownloadButtonClicked();

            Assert.That(utility.WaitForFileDownload(
                Path.Combine(Directory.GetCurrentDirectory(), "Downloads"),
                fileName, 10), "File was not downloaded successfully.", true);
        }
    }
}
