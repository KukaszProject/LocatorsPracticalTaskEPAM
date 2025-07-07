using log4net;
using log4net.Core;
using OpenQA.Selenium;

namespace LocatorsPracticalTask.Pages
{
    public class JobDetailsPage
    {
        private readonly IWebDriver driver;
        private ILog Log => LogManager.GetLogger(GetType());

        public JobDetailsPage(IWebDriver driver) => this.driver = driver;

        public bool ContainsKeyword(string keyword)
        {
            Log.Info($"Checking if the job page contains the keyword: {keyword} ...");
            return driver.PageSource.ToLower().Contains(keyword.ToLower());
        }
    }
}
