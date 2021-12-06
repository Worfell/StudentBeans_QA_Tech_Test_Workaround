using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using Student_Beans_Selenium_Test.Pages;

namespace Student_Beans_Test.Steps
{
    [Binding]
    public class SimpleSearchSteps
    {

        private IWebDriver _webDriver;
        SimpleSearchPage searchResults;

        public SimpleSearchSteps(IWebDriver webDriver)
        {
            this._webDriver = webDriver;
            searchResults = new SimpleSearchPage(webDriver);
        }

        [Given(@"I am on the studentbeans homepage")]
        public void GivenIAmOnTheStudentbeansHomepage()
        {
            var reportUrl = "https://www.studentbeans.com/uk";
            _webDriver.Url = reportUrl; //home page
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);

        }

        [Given(@"I open the search bar")]
        public void GivenIOpenTheSearchBar()
        {
            IWebElement Cookies = _webDriver.FindElement(By.Id("onetrust-accept-btn-handler"));
            Cookies.Click();

            IWebElement SearchBar = _webDriver.FindElement(By.ClassName("_tf5swf"));
            SearchBar.Click();
            GetDriverWait(30).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("_1g5dvk1")));
        }

        [When(@"I enter '(.*)'")]
        public void WhenIEnter(string p0)
        {
            IWebElement FullSearchBar = _webDriver.FindElement(By.ClassName("_1g5dvk1"));
            FullSearchBar.SendKeys("Samsung");
            Thread.Sleep(2000);
        }

        [Then(@"I should be shown a search listing for '(.*)'")]
        public void ThenIShouldBeShownASearchListingFor(string Samsung = "Samsung")
        {
            Assert.AreEqual("Samsung", searchResults.SearchResults(), "Search result is different from expected");
        }

        private WebDriverWait GetDriverWait(int seconds = 30)
        {
            return new WebDriverWait(_webDriver.SwitchTo().Window(_webDriver.WindowHandles.Last()), TimeSpan.FromSeconds(seconds));
        }
    }
}
