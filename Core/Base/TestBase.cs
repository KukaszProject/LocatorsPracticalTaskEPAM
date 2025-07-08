using NUnit.Framework;
using OpenQA.Selenium;
using log4net;
using log4net.Config;
using LocatorsPracticalTask.Core.Utilities;
using Core.Drivers;

namespace Core.Base
{
    public abstract class TestBase
    {
        protected IWebDriver Driver = null!;
        protected ILog Log => LogManager.GetLogger(GetType());


        [OneTimeSetUp]
        public void GlobalSetUp()
        {
            var logConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.config");

            if (!File.Exists(logConfigPath))
            {
                throw new FileNotFoundException($"Log.config not found at: {logConfigPath}");
            }

            XmlConfigurator.Configure(new FileInfo(logConfigPath));
            Log.Info("---Logger initialized successfully.---");
        }

        [SetUp]
        public void SetUp()
        {
            Log.Info("---Test setup started.---");
            Driver = DriverFactory.GetDriver();
            Driver.Navigate().GoToUrl("https://www.epam.com/");
        }

        [TearDown]
        public void TearDown()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;
            if (outcome == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var screenshotPath = ScreenshotMaker.TakeScreenshot(Driver, TestContext.CurrentContext.Test.Name);
                Log.Error($"Test failed. Screenshot saved to: {screenshotPath}");
            }

            Log.Info("---Test teardown complete.---");
            DriverFactory.QuitDriver();
        }
    }
}
