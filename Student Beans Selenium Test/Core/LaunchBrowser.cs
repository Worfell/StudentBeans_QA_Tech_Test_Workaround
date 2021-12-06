using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace Student_Beans_Selenium_Test.Core
{
    class LaunchBrowser
    {
        public IWebDriver WebDriver;

        public IWebDriver Init(string browser)
        {
            if (WebDriver != null)
            {
                return WebDriver;
            }
            try
            {
                switch (browser.ToLower())
                {
                    case "chrome":
                        WebDriver = OpenChrome();

                        break;
                }
            }

            finally
            {
            }

            return WebDriver;
        }

        public IWebDriver OpenChrome()
        {
            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("headless");
            chromeOptions.AddArguments("disable-gpu");
            WebDriver = new ChromeDriver(chromeOptions);
            var cookieCount = WebDriver.Manage().Cookies.AllCookies.Count;
            WebDriver.Manage().Cookies.DeleteAllCookies();
            WebDriver.Manage().Window.Maximize();
            Thread.Sleep(5000);

            return WebDriver;
        }

        protected virtual void WaitForElementToBeClickable(By by)
        {
            GetDriverWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        protected virtual void WaitForElementToBeClickable(IWebElement element)
        {
            GetDriverWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }


        protected void WaitForElementIsVisible(By by)
        {
            GetDriverWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }
        protected WebDriverWait GetDriverWait(int seconds = 30)
        {
            return new WebDriverWait(WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last()), TimeSpan.FromSeconds(seconds));
        }

        public void Cleanup()
        {
            if (WebDriver != null)
            {
                WebDriver.Quit();
                WebDriver = null;
            }

        }
    }
}
