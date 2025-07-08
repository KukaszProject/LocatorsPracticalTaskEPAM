using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LocatorsPracticalTask.Pages
{
    public class CareersPage : BasePage
    {
        private IWebElement KeywordInput => Driver.FindElement(By.Id("new_form_job_search-keyword"));
        private IWebElement LocationDropdown => Driver.FindElement(By.ClassName("select2-selection--single"));
        private IWebElement RemoteInput => Driver.FindElement(By.Name("remote"));
        private IWebElement RemoteLabel => RemoteInput.FindElement(By.XPath("following-sibling::label"));
        private IWebElement FindButton => Driver.FindElement(By.XPath("//form[@id='jobSearchFilterForm']//descendant::button[@type='submit']"));
        private IWebElement SortingList =>  Driver.FindElement(By.ClassName("search-result__sorting-list"));
        private IWebElement SortByDateButton => SortingList.FindElement(By.XPath(".//label[@for='sort-time']"));
        private IWebElement LatestJobResult => Driver.FindElement(By.PartialLinkText("APPLY"));

        public CareersPage(IWebDriver driver) : base(driver) { }
        public CareersPage EnterKeyword(string keyword)
        {
            LogAction($"Searching for jobs with keyword: {keyword} on the Careers page...");
            KeywordInput.SendKeys(keyword);
            return this;
        }
        public CareersPage SelectRemoteWorkOption()
        {
            LogAction("Selecting remote work option on the Careers page...");
            RemoteLabel.Click();
            return this;
        }
        public CareersPage SelectLocation(string location)
        {
            LogAction($"Selecting location: {location} on the Careers page...");
            LocationDropdown.Click();
            var optionToSelect = Wait.Until(driver =>
                driver.FindElement(By.XPath($"//li[contains(@class, 'select2-results__option') and contains(text(),'{location}')]")));

            optionToSelect.Click();
            return this;
        }
        public CareersPage ClickFindButton()
        {
            LogAction("Clicking the Find button on the Careers page...");
            FindButton.Click();
            return this;
        }
        public CareersPage SortByDate()
        {
            LogAction("Sorting job results by date on the Careers page...");
            Wait.Until(ExpectedConditions.ElementToBeClickable(SortByDateButton)).Click();
            return this;
        }
        public JobDetailsPage OpenLastJob()
        {
            LogAction("Opening the latest job result on the Careers page...");
            Wait.Until(ExpectedConditions.ElementToBeClickable(LatestJobResult)).Click();
            return new JobDetailsPage(Driver);
        }
    }
}