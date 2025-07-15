using OpenQA.Selenium;
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
        private IWebElement SortingList => Driver.FindElement(By.ClassName("search-result__sorting-list"));
        private IWebElement SortByDateButton => SortingList.FindElement(By.XPath(".//label[@for='sort-time']"));
        private IWebElement LatestJobResult => Driver.FindElement(By.PartialLinkText("APPLY"));

        public CareersPage(IWebDriver driver) : base(driver) { }
        public CareersPage EnterKeyword(string keyword)
        {
            KeywordInput.SendKeys(keyword);
            return this;
        }
        public CareersPage SelectRemoteWorkOption()
        {
            RemoteLabel.Click();
            return this;
        }
        public CareersPage SelectLocation(string location)
        {
            LocationDropdown.Click();
            var optionToSelect = Wait.Until(driver =>
                driver.FindElement(By.XPath($"//li[contains(@class, 'select2-results__option') and contains(text(),'{location}')]")));

            optionToSelect.Click();
            return this;
        }
        public CareersPage ClickFindButton()
        {
            FindButton.Click();
            return this;
        }
        public CareersPage SortByDate()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(SortByDateButton)).Click();
            return this;
        }
        public JobDetailsPage OpenLastJob()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(LatestJobResult)).Click();
            return new JobDetailsPage(Driver);
        }
    }
}