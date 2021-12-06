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
            //Initial Webdriver with Correct Browser
            //Can add additional code here to include more browsers
            if (WebDriver != null)
            {
                return WebDriver;
            }
            try
            {
                WebDriver = OpenChrome();
            }
            finally
            {
            }

            return WebDriver;
        }

        public IWebDriver OpenChrome()
        {
            //Initalise Chrome Settings
            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("headless");
            chromeOptions.AddArguments("disable-gpu");
            WebDriver = new ChromeDriver(chromeOptions);
            var cookieCount = WebDriver.Manage().Cookies.AllCookies.Count;
            WebDriver.Manage().Cookies.DeleteAllCookies();
            WebDriver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            return WebDriver;
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
