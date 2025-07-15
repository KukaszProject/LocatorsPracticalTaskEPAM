using Drivers;
using LocatorsPracticalTask.Pages;
using OpenQA.Selenium;
using Reqnroll;

namespace LocatorsTests.Steps
{
    [Binding]
    public class ServicesNavigationFeatureStepDefinitions
    {
        private IWebDriver driver = DriverFactory.GetDriver();
        private HomePage? homePage;
        private ServicesPage? servicesPage;

        public ServicesNavigationFeatureStepDefinitions()
        {
            if (driver == null)
            {
                throw new ArgumentNullException(nameof(driver), "Driver cannot be null.");
            }
            homePage = new HomePage(driver);
            servicesPage = new ServicesPage(driver);
        }

        [Given("I navigate to the Services page")]
        public void GivenINavigateToTheServicesPage()
        {
            homePage?.GoToServices();
        }

        [When("I navigate to the Artificial Inteligence section")]
        public void WhenINavigateToTheArtificialInteligenceSection()
        {
            servicesPage?.ClickOnArtificialIntelligence();
        }

        [When(@"I click on the ""(.*)"" service category")]
        public void WhenIClickOnTheServiceCategory(string category)
        {
            servicesPage?.NavigateToCategory(category);
        }

        //[When(@"I click on the ""(.*)"" service category")]
        //public void WhenIClickOnTheServiceCategory(string category)
        //{
        //    servicesPage = homePage!.NavigateToService(category);
        //}



        [Then(@"""(.*)"" should contain the expected text")]
        public void ThenShouldContainTheExpectedText(string category)
        {
            Assert.NotNull(servicesPage, "Services page should be initialized.");
            Assert.That(servicesPage.IsTitleMatchingCategory(category),
                "The article title does not match the expected title from the carousel.", true);
        }

        [Then("Our Related Expertise should be displayed")]
        public void ThenOurRelatedExpertiseShouldBeDisplayed()
        {
            Assert.NotNull(servicesPage, "Services page should be initialized.");
            Assert.That(servicesPage.IsRelatedExpertiseSectionVisible(),
                "The 'Our Related Expertise' section is not visible.", true);
        }

    }
}
