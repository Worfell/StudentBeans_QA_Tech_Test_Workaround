using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace Student_Beans_Selenium_Test.Pages
{
    class SimpleSearchPage
    {
        private IWebDriver _webDriver;
        public SimpleSearchPage(IWebDriver webDriver)
        {
            this._webDriver = webDriver;
        }

        public string SearchResults()
        {
            GetDriverWait(3000).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("_63p46ei")));
            IWebElement SearchResults = _webDriver.FindElement(By.ClassName("_63p46ei"));
            return SearchResults.Text;
        }

        protected WebDriverWait GetDriverWait(int seconds = 30)
        {
            return new WebDriverWait(_webDriver.SwitchTo().Window(_webDriver.WindowHandles.Last()), TimeSpan.FromSeconds(seconds));
        }

        public Boolean IsElementPresent(By locatorKey)
        {
            try
            {
                _webDriver.FindElement(locatorKey);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
