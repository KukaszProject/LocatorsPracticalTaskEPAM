using Business.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

public class HomePageActions
{
    private readonly IWebDriver Driver;
    private HomePage homePage;

    public HomePageActions(IWebDriver driver)
    {
        Driver = driver;
        homePage = new HomePage(driver);
    }

    public void OpenServicesNavigationBar()
    {
        var actions = new Actions(Driver);
        actions.MoveToElement(homePage.ServicesLink).Perform();
        actions.MoveToElement(homePage.ArtificialIntelligenceLink).Perform();
    }
}
