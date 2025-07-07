using Core.Utilities;
using LocatorsPracticalTask.Pages;

namespace LocatorsTests
{
    public class JobSearchTests : TestBase
    {
        [TestCase(".NET")]
        [TestCase("JavaScript")]
        public void ValidateJobSearch(string keyword)
        {
            var home = new HomePage(Driver);
            var careers = new CareersPage(Driver);
            var job = new JobDetailsPage(Driver);

            home.AcceptCookies();
            home.GoToCareers();
            careers.SearchJobs(keyword);
            careers.SortByDate();
            careers.OpenLastJob();

            Assert.IsTrue(job.ContainsKeyword(keyword), $"Job page should contain keyword: {keyword}");
        }
    }
}
