using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocatorsPracticalTask.Pages
{
    public class ArticleDetailsPage
    {
        private readonly IWebDriver driver;
        public ArticleDetailsPage(IWebDriver driver) => this.driver = driver;
        public string GetCurrentArticleTitle() => driver.Title;
        public bool IsArticleTitleMatching(string expectedTitle) => GetCurrentArticleTitle().Contains(expectedTitle, StringComparison.OrdinalIgnoreCase);
    }
}
