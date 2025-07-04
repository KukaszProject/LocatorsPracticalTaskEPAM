using NUnit.Framework;
using OpenQA.Selenium;
using log4net.Config;
using log4net;

namespace LocatorsPracticalTask.Core
{
    public abstract class TestBase
    {
        protected IWebDriver Driver = null!;
        protected ILog Log
        {
            get { return LogManager.GetLogger(this.GetType()); }
        }

        [SetUpFixture]
        public class SetUpFixture
        {
            [SetUp]
            public void BeforeAllTests()
            {
                XmlConfigurator.Configure(new FileInfo("Log.config"));
            }
        }

        [SetUp]
        public void SetUp()
        {
            Log.Info("Test setup started.");
            Driver = DriverFactory.GetDriver();
            Driver.Navigate().GoToUrl("https://www.epam.com/");
        }

        [TearDown]
        public void TearDown()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;
            if (outcome == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var path = Path.Combine("Screenshots", $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                Directory.CreateDirectory("Screenshots");
                ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile(path);
                Log.Error($"Test failed. Screenshot saved to {path}");
            }

            Log.Info("Test tear down.");
            DriverFactory.QuitDriver();
        }
    }
}