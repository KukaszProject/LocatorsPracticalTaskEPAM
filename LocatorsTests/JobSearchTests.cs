using Core.Base;
using LocatorsPracticalTask.Pages;

namespace LocatorsTests
{
    public class JobSearchTests : TestBase
    {
        [TestCase(".NET", "All Locations")]
        [TestCase("JavaScript", "All Locations")]
        public void ValidateJobSearch(string keyword, string location)
        {
            var home = new HomePage(Driver);
            var jobDetailsPage = new JobDetailsPage(Driver);

            home.AcceptCookies()
                .GoToCareers()
                .SelectRemoteWorkOption()
                .EnterKeyword(keyword)
                .SelectLocation(location)
                .ClickFindButton()
                .SortByDate()
                .OpenLastJob();

            Assert.IsTrue(jobDetailsPage.ContainsKeyword(keyword), $"Job page should contain keyword: {keyword}");
        }
    }
}
