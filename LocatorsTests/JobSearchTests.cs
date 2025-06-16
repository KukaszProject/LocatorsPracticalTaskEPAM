//////using OpenQA.Selenium;
//////using LocatorsPracticalTask.Drivers;
//////using LocatorsPracticalTask.Pages;

//////namespace LocatorsPracticalTask.Tests
//////{
//////    public class JobSearchTests
//////    {
//////        private IWebDriver? driver;
//////        private HomePage? home;
//////        private CareersPage? careers;
//////        private JobDetailsPage? details;

//////        [SetUp]
//////        public void SetUp()
//////        {
//////            driver = WebDriverFactory.CreateDriver();
//////            home = new HomePage(driver);
//////            careers = new CareersPage(driver);
//////            details = new JobDetailsPage(driver);
//////        }

//////        [TestCase(".NET", "All Locations")]
//////        [TestCase("Java", "All Locations")]
//////        [TestCase("Python", "All Locations")]
//////        public void SearchForRemoteJob(string keyword, string location)
//////        {
//////            home?.GoTo();
//////            //home?.AcceptCookies();
//////            home?.ClickCareers();

//////            var tabs = driver?.WindowHandles;
//////            if (tabs?.Count > 1) driver?.SwitchTo().Window(tabs.Last());

//////            //careers?.ClickKeywords();
//////            careers?.EnterKeyword(keyword);
//////            careers?.SelectLocation(location);
//////            careers?.CheckRemote();
//////            careers?.ClickFind();
//////            careers?.OpenLatestJobDetails();

//////            Assert.IsTrue(details?.ContainsKeyword(keyword),
//////                $"The keyword '{keyword}' was not found in the job description.");
//////        }

//////        [TearDown]
//////        public void TearDown()
//////        {
//////            driver?.Quit();
//////            driver?.Dispose();
//////        }
//////    }
//////}

////using NUnit.Framework;
////using OpenQA.Selenium;
////using OpenQA.Selenium.Chrome;
////using OpenQA.Selenium.Support.UI;
////using System;
////using System.Linq;

////[TestFixture]
////public class EpamJobSearchTests
////{
////    private IWebDriver driver;
////    private WebDriverWait wait;

////    [SetUp]
////    public void Setup()
////    {
////        driver = new ChromeDriver();
////        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
////        driver.Manage().Window.Maximize();
////    }

////    [TestCase("Java", "All Locations")]
////    public void TestJobSearch(string language, string location)
////    {
////        driver.Navigate().GoToUrl("https://www.epam.com/");

////        // Click Careers
////        driver.FindElement(By.LinkText("Careers")).Click();

////        // Switch to new tab if opened
////        var tabs = driver.WindowHandles;
////        if (tabs.Count > 1) driver.SwitchTo().Window(tabs.Last());

////        // Enter keywords
////        var keywordInput = wait.Until(driver =>
////            driver.FindElement(By.Id("new_form_job_search_1445745853_copy-keyword")));
////        keywordInput.SendKeys(language);

////        // Select location
////        var locationSelect = new SelectElement(driver.FindElement(
////            By.Name("new_form_job_search_1445745853_copy-location")));
////        locationSelect.SelectByText(location);

////        // Click Remote
////        driver.FindElement(By.ClassName("checkbox-custom-label")).Click();

////        // Click Find
////        driver.FindElement(By.CssSelector("button[class*='recruiting-search__submit']")).Click();

////        // Click latest job result
////        var latestResult = wait.Until(driver =>
////            driver.FindElement(By.XPath("(//li[contains(@class, 'search-result__item')])[last()]")));
////        latestResult.FindElement(By.XPath(".//a[text()='View and apply']")).Click();

////        // Verify language is on the page
////        var containsLanguage = wait.Until(driver =>
////            driver.FindElement(By.XPath($"//*[contains(text(), '{language}')]"))).Displayed;

////        Assert.IsTrue(containsLanguage, $"The job description should contain: {language}");
////    }

////    [TearDown]
////    public void Teardown()
////    {
////        driver.Quit();
////        driver.Dispose();
////    }
////}


//using LocatorsPracticalTask.Drivers;
//using LocatorsPracticalTask.Pages;
//using NUnit.Framework;
//using OpenQA.Selenium;

//namespace AutomationFramework.Tests
//{
//    public class JobSearchTests
//    {
//        private IWebDriver _driver;
//        private HomePage _homePage;
//        private CareersPage _careersPage;
//        private JobDetailsPage _jobDetailsPage;
//        private GlobalSearchPage _globalSearchPage;

//        [SetUp]
//        public void SetUp()
//        {
//            _driver = DriverFactory.GetDriver();
//            _driver.Navigate().GoToUrl("https://www.epam.com/");
//            _homePage = new HomePage(_driver);
//            _careersPage = new CareersPage(_driver);
//            _jobDetailsPage = new JobDetailsPage(_driver);
//            _globalSearchPage = new GlobalSearchPage(_driver);
//            _homePage.AcceptCookies();
//        }

//        [Test]
//        public void TestCase1_SearchAndApply()
//        {
//            string keyword = "Java";
//            _homePage.GoToCareers();
//            _careersPage.SearchJob(keyword);
//            _careersPage.OpenLatestJob();
//            Assert.IsTrue(_jobDetailsPage.ContainsKeyword(keyword));
//        }

//        [TestCase("Blockchain")]
//        [TestCase("Cloud")]
//        [TestCase("Automation")]
//        public void TestCase2_GlobalSearch(string keyword)
//        {
//            _homePage.OpenSearch();
//            _globalSearchPage.PerformSearch(keyword);
//            Assert.IsTrue(_globalSearchPage.AreResultsRelevant(keyword));
//        }

//        [TearDown]
//        public void TearDown()
//        {
//            _driver.Quit();
//            _driver.Dispose();
//        }
//    }
//}
