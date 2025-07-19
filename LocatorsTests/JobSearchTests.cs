using Tests.Base;
using Business.Pages;

namespace Tests.TAF
{
    public class JobSearchTests : TestBase
    {
        [TestCase(".NET", "All Locations")]
        [TestCase("JavaScript", "All Locations")]
        public void ValidateJobSearch(string keyword, string location)
        {
            var home = new HomePage(Driver);

            var isContainsKeyword = 
                home.AcceptCookies()
                .GoToCareers()
                .SelectRemoteWorkOption()
                .EnterKeyword(keyword)
                .SelectLocation(location)
                .ClickFindButton()
                .SortByDate()
                .OpenLastJob()
                .ContainsKeyword(keyword);

            Assert.IsTrue(isContainsKeyword, $"Job page should contain keyword: {keyword}");
        }
    }
}
