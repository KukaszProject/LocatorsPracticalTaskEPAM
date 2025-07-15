using Drivers;
using LocatorsPracticalTask.Pages;
using LocatorsPracticalTask.Utilities;
using OpenQA.Selenium;
using Reqnroll;

[Binding]
public class DownloadFileSteps
{
    private static IWebDriver driver = DriverFactory.GetDriver();
    private HomePage? homePage;
    private AboutPage? aboutPage;
    private FileHelper fileHelper = new FileHelper();

    DownloadFileSteps()
    {
        if (driver == null)
        {
            throw new ArgumentNullException(nameof(driver), "Driver cannot be null.");
        }

        homePage = new HomePage(driver);
        aboutPage = new AboutPage(driver);
    }

    [Given(@"I navigate to the About Page")]
    public void GivenINavigateToTheAboutPage()
    {
        aboutPage = homePage?.GoToAbout();
    }

    [When("I click the download button")]
    public void WhenIClickTheDownloadButton()
    {
        aboutPage?.DownloadButtonClicked();
    }

    [Then("the file should be downloaded")]
    public void ThenTheFileShouldBeDownloaded()
    {
        Assert.That(fileHelper
                .WaitForFileDownload(Path.Combine(Directory.GetCurrentDirectory(),
                "Downloads"), "EPAM_Corporate_Overview*.pdf", 10), "File was not downloaded successfully.", true);
    }

}
