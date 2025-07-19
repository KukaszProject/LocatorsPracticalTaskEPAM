using Core.Utilities;
using Business.Pages;
using OpenQA.Selenium;
using Reqnroll;

namespace Tests.Steps
{
    [Binding]
    public class HomePageSteps
    {
        private readonly IWebDriver driver;
        private readonly HomePage homePage;

        HomePageSteps(DriverContext context)
        {
            driver = context.Driver ?? throw new ArgumentNullException(nameof(context.Driver));
            homePage = new HomePage(driver);
        }

        [Given(@"I am on the EPAM home page")]
        public void GivenIAmOnTheHomePage()
        {
            driver.Navigate().GoToUrl(ConfigHelper.Get("BaseUrl"));
            homePage.AcceptCookies();
        }

        [Given(@"I navigate to the About Page")]
        public void GivenINavigateToTheAboutPage()
        {
            homePage.GoToAbout();
        }

        [Given("I navigate to the Global Search")]
        public void GivenINavigateToTheGlobalSearch()
        {
            homePage.ClickSearchIcon();
        }

        [Given("I navigate to the Careers Page")]
        public void GivenINavigateToTheCareersPage()
        {
            homePage.GoToCareers();
        }

        [Given("I navigate to the Insights Page")]
        public void GivenINavigateToTheInsightsPage()
        {
            homePage.GoToInsights();
        }

        [Given("I open Services navigation bar")]
        public void GivenIOpenServicesNavigationBar()
        {
            homePage.OpenServicesNavigationBar();
        }

        [When(@"I click on the ""(.*)"" service category")]
        public void WhenIClickOnTheServiceCategory(string category)
        {
            homePage.NavigateToCategory(category);
        }
    }
}