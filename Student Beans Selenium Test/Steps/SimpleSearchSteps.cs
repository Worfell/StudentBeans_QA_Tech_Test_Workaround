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
        SimpleSearchPage searchResults, verifyHomePage;


        public SimpleSearchSteps(IWebDriver webDriver)
        {
            //Initiate Webdrivers
            this._webDriver = webDriver;
            searchResults = new SimpleSearchPage(webDriver);
            verifyHomePage = new SimpleSearchPage(webDriver);
        }

        [Given(@"I am on the studentbeans homepage")]
        public void GivenIAmOnTheStudentbeansHomepage()
        {
            //Open URL
            var reportUrl = "https://www.studentbeans.com/uk";
            _webDriver.Url = reportUrl; //home page
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            //Wait for accept cookies
            WaitForElementToBeClickable(By.Id("onetrust-accept-btn-handler"));
            //Confirm HomePage is Student Beans
            Assert.AreEqual("Student Beans", verifyHomePage.VerifyHomePage(), "You have not loaded up the correct page.");
        }

        [Given(@"I open the search bar")]
        public void GivenIOpenTheSearchBar()
        {
            //Click AcceptCookies
            IWebElement Cookies = _webDriver.FindElement(By.Id("onetrust-accept-btn-handler"));
            Cookies.Click();
            //Click on Search Bar
            IWebElement SearchBar = _webDriver.FindElement(By.ClassName("_tf5swf"));
            SearchBar.Click();
            //Wait until navigation search bar appears
            GetDriverWait(30).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("_1g5dvk1")));
        }

        [When(@"I enter '(.*)'")]
        public void WhenIEnter(string Samsung = "Samsung")
        {
            //Enter Samsung in Search Bar
            IWebElement FullSearchBar = _webDriver.FindElement(By.ClassName("_1g5dvk1"));
            FullSearchBar.SendKeys(Samsung);
            Thread.Sleep(1000);
        }

        [Then(@"I should be shown a search listing for '(.*)'")]
        public void ThenIShouldBeShownASearchListingFor(string Samsung = "Samsung")
        {
            //Verify that Samsung Results are visible
            Assert.AreEqual(Samsung, searchResults.SearchResults(), "Search result is different from expected");
        }

        private WebDriverWait GetDriverWait(int seconds = 30)
        {
            //Wait Driver to allow for time outs
            return new WebDriverWait(_webDriver.SwitchTo().Window(_webDriver.WindowHandles.Last()), TimeSpan.FromSeconds(seconds));
        }
        protected virtual void WaitForElementToBeClickable(By by)
        {
            //Wait Driver to wait for element to be clickable
            GetDriverWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }
    }
}
