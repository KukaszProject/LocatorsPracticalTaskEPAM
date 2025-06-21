using LocatorsPracticalTask.Drivers;
using LocatorsPracticalTask.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocatorsPracticalTask.Tests
{
    public class DownloadFileTests
    {
        private IWebDriver? driver;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.GetDriver();
            driver.Navigate().GoToUrl("https://www.epam.com/");
        }

        [Test]
        public void DownloadFileTest()
        {
            var home = new HomePage(driver);
            var about = new AboutPage(driver);

            home.AcceptCookies();
            home.GoToAbout();
            about.DownloadButtonClicked();

            Assert.True(about.WaitForFileDownload(
                Path.Combine(Directory.GetCurrentDirectory(), "Downloads"),
                "EPAM_Corporate_Overview*.pdf",
                10), "File was not downloaded successfully.");
        }

        [TearDown]
        public void TearDown()
        {
            DirectoryInfo di = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "Downloads"));
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            driver?.Quit();
            driver?.Dispose();
        }
    }
}
