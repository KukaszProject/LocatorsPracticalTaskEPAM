using Core.Utilities;
using Business.Pages;
using Reqnroll;

namespace Tests.Steps
{
    [Binding]
    public class AboutPageSteps
    {
        private readonly AboutPage aboutPage;
        private  FileHelper fileHelper = new FileHelper();

        AboutPageSteps(DriverContext context)
        {
            aboutPage = new AboutPage(context.Driver);
        }

        [When("I click the download button")]
        public void WhenIClickTheDownloadButton()
        {
            aboutPage.DownloadButtonClicked();
        }

        [Then("the file should be downloaded")]
        public void ThenTheFileShouldBeDownloaded()
        {
            Assert.That(fileHelper
                    .WaitForFileDownload(Path.Combine(Directory.GetCurrentDirectory(),
                    "Downloads"), "EPAM_Corporate_Overview*.pdf", 10), "File was not downloaded successfully.", true);
        }
    }
}
