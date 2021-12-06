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

        public string VerifyHomePage()
        {
            //Find logo and get alt value
            GetDriverWait(3000).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//img[@alt='Student Beans']")));
            IWebElement VerifyLogo = _webDriver.FindElement(By.XPath("//img[@alt='Student Beans']"));
            return VerifyLogo.GetAttribute("alt");
        }

        public string SearchResults()
        {
            //Find Samsung Results and get value
            GetDriverWait(3000).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("_63p46ei")));
            IWebElement SearchResults = _webDriver.FindElement(By.ClassName("_63p46ei"));
            return SearchResults.Text;
        }

        protected WebDriverWait GetDriverWait(int seconds = 30)
        {
            //Wait driver
            return new WebDriverWait(_webDriver.SwitchTo().Window(_webDriver.WindowHandles.Last()), TimeSpan.FromSeconds(seconds));
        }
    }
}
