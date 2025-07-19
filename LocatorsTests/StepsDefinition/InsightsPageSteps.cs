using Business.Pages;
using Reqnroll;

namespace Tests.Steps
{
    [Binding]
    public class InsightsPageSteps
    {
        private readonly InsightsPage insightsPage;

        InsightsPageSteps(DriverContext context)
        {
            insightsPage = new InsightsPage(context.Driver);
        }

        [When(@"I click on the arrow {int} times")]
        public void WhenIClickOnTheArrowTimes(int number)
        {
            insightsPage.ClickOnArrow(number);
        }

        [When(@"I click on the read more button")]
        public void WhenIClickOnTheReadMoreButton()
        {
            insightsPage.ClickOnReadMore();
        }
    }
}
