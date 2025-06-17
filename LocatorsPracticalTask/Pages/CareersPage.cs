//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
//using System;
//using System.Linq;

//namespace LocatorsPracticalTask.Pages
//{
//    public class CareersPage
//    {
//        private IWebDriver driver;
//        private WebDriverWait wait;

//        public CareersPage(IWebDriver driver)
//        {
//            this.driver = driver;
//            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//        }

//        private IWebElement CookieAccept => wait.Until(d =>
//            d.FindElement(By.Id("onetrust-accept-btn-handler")));

//        private IWebElement KeywordInput => wait.Until(d =>
//            d.FindElement(By.Id("new_form_job_search-keyword")));

//        private IWebElement LocationDropdown => driver.FindElement(
//            By.ClassName("select2-selection--single"));

//        private IWebElement RemoteCheckbox => driver.FindElement(By.ClassName("checkbox-custom-label"));

//        private IWebElement FindButton => driver.FindElement(
//           By.XPath("//button[contains(text(),'Find')]/ancestor::form"));

//        private IWebElement SortByDateButton => wait.Until(d =>
//            d.FindElement(By.CssSelector(".search-result__sorting-label")));

//        private IWebElement LatestJobResult => wait.Until(d =>
//            d.FindElement(By.PartialLinkText("APPLY")));




//        public void ClickKeywords() => KeywordInput.Click();

//        public void EnterKeyword(string keyword) => KeywordInput.SendKeys(keyword);

//        public void SelectLocation(string location)
//        {
//            // Step 1: Click the fake dropdown to expand it
//            LocationDropdown.Click();

//            // Step 2: Wait for the dropdown options container (select2 results) to appear
//            var dropdownOptionsContainer = wait.Until(driver =>
//                driver.FindElement(By.CssSelector("ul.select2-results__options")));

//            //// Step 3: Find the specific option within the dropdown
//            var optionToSelect = wait.Until(driver =>
//                driver.FindElement(By.XPath($"//li[contains(@class, 'select2-results__option') and contains(text(),'{location}')]")));

//            // Step 4: Click the option
//            optionToSelect.Click();
//        }


//        public void CheckRemote() => RemoteCheckbox.Click();

//        public void ClickFind() => FindButton.Click();

//        public void OpenLatestJobDetails() {
//            SortByDateButton.Click();
//            LatestJobResult.Click();
//        }
//    }
//}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LocatorsPracticalTask.Pages
{
    public class CareersPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public CareersPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement KeywordInput => _driver.FindElement(By.Id("new_form_job_search-keyword"));
        private IWebElement LocationDropdown => _driver.FindElement(By.ClassName("select2-selection--single"));
        private IWebElement FormRemoteFilter => _driver.FindElement(By.ClassName("job-search__filter-items--remote"));
        private IWebElement RemoteInput => _driver.FindElement(By.Name("remote"));
        private IWebElement RemoteLabel => RemoteInput.FindElement(By.XPath("following-sibling::label"));

        //private IWebElement RemoteCheckbox => FormRemoteFilter.FindElement(By.XPath(".//label[contains(text(), 'Remote')]"));
        private IWebElement FindButton => _driver.FindElement(By.XPath("//form[@id='jobSearchFilterForm']//descendant::button[@type='submit']"));
        private IWebElement SortingList => _driver.FindElement(By.ClassName("search-result__sorting-list"));
        private IWebElement SortByDateButton => SortingList.FindElement(By.XPath(".//label[@for='sort-time']"));
        private IWebElement LatestJobResult => _wait.Until(d => d.FindElement(By.PartialLinkText("APPLY")));

        public void SearchJobs(string keyword)
        {
            CheckRemote();
            KeywordInput.SendKeys(keyword);
            SelectLocation("All Locations");
            FindButton.Click();
        }

        public void CheckRemote() => RemoteLabel.Click();
        public void SelectLocation(string location)
        {
            LocationDropdown.Click();
            var optionToSelect = _wait.Until(driver =>
                driver.FindElement(By.XPath($"//li[contains(@class, 'select2-results__option') and contains(text(),'{location}')]")));

            optionToSelect.Click();
        }

        public void SortByDate() => _wait.Until(ExpectedConditions.ElementToBeClickable(SortByDateButton)).Click();

        public void OpenLastJob() => _wait.Until(ExpectedConditions.ElementToBeClickable(LatestJobResult)).Click();
    }
}
