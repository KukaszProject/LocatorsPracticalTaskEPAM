using Business.Pages;
using Reqnroll;

namespace Tests.Steps
{
    [Binding]
    public class ServicesPageSteps
    {
        private readonly ServicesPage servicesPage;

        ServicesPageSteps(DriverContext context)
        {
            servicesPage = new ServicesPage(context.Driver);
        }

        [Then(@"""(.*)"" should contain the expected text")]
        public void ThenShouldContainTheExpectedText(string category)
        {
            Assert.That(servicesPage.IsTitleMatchingCategory(category),
                "The article title does not match the expected title from the carousel.", true);
        }

        [Then("Our Related Expertise should be displayed")]
        public void ThenOurRelatedExpertiseShouldBeDisplayed()
        {
            Assert.That(servicesPage.IsRelatedExpertiseSectionVisible(),
                "The 'Our Related Expertise' section is not visible.", true);
        }
    }
}