using OpenQA.Selenium;
using log4net;
using log4net.Config;
using LocatorsPracticalTask.Core.Utilities;
using Core.Drivers;
using System.Configuration;

namespace Core.Base
{
    public abstract class TestBase
    {
        protected IWebDriver Driver;
        protected ILog Log => LogManager.GetLogger(GetType());

        [OneTimeSetUp]
        public void GlobalSetUp()
        {
            var logConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.config");

            if (!File.Exists(logConfigPath))
            {
                Log.Error($"Log.config not found at: {logConfigPath}");
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
            if (Driver == null)
            {
                Log.Error("Driver initialization failed. Driver is null.");
                throw new InvalidOperationException("Driver initialization failed. Driver is null.");
            }

            var baseUrl = ConfigHelper.Get("BaseUrl");
            if (string.IsNullOrEmpty(baseUrl))
            {
                Log.Error("BaseUrl configuration is missing or null.");
                throw new ConfigurationErrorsException("BaseUrl configuration is missing or null.");
            }

            Driver.Navigate().GoToUrl(baseUrl);
            Log.Info("---Test setup complete.---");
        }

        [TearDown]
        public void TearDown()
        {
            Log.Info("---Test teardown started.---");
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;
            if (outcome == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var screenshotPath = ScreenshotMaker.TakeScreenshot(Driver, TestContext.CurrentContext.Test.Name);
                Log.Error($"Test failed. Screenshot saved to: {screenshotPath}");
            }

            DriverFactory.QuitDriver();
            Driver.Dispose();
            Log.Info("---Test teardown complete.---");
        }
    }
}
