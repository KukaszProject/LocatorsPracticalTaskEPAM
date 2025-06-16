//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
//using System;

//namespace LocatorsPracticalTask.Pages
//{
//    public class JobDetailsPage
//    {
//        private IWebDriver _driver;
//        private WebDriverWait _wait;

//        public JobDetailsPage(IWebDriver driver)
//        {
//            _driver = driver;
//            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//        }

//        public bool ContainsKeyword(string keyword)
//        {
//            var element = _wait.Until(d =>
//                d.FindElement(By.XPath($"//*[contains(text(), '{keyword}')]")));
//            return element.Displayed;
//        }
//    }
//}

using OpenQA.Selenium;

public class JobDetailsPage
{
    private readonly IWebDriver _driver;

    public JobDetailsPage(IWebDriver driver) => _driver = driver;

    public bool ContainsKeyword(string keyword)
    {
        return _driver.PageSource.ToLower().Contains(keyword.ToLower());
    }
}


