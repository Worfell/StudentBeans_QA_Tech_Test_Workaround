using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Linq;
using NUnit.Framework;

namespace Student_Beans_Test.Core
{
    public class BasePage
    {
        public BasePage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        protected IWebDriver WebDriver { get; }

        public void WaitForElement(By by)
        {
            GetDriverWait().Until(ExpectedConditions.ElementIsVisible(by));
        }

        public void WaitForElement(By by, int seconds)
        {
            GetDriverWait(seconds).Until(ExpectedConditions.ElementIsVisible(by));
        }

        public T GetPage<T>(By by = null)
            where T : BasePage
        {
            if (by != null)
            {
                GetDriverWait().Until(ExpectedConditions.ElementIsVisible(by));
            }

            return (T)Activator.CreateInstance(typeof(T), WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last()));
        }

        protected WebDriverWait GetDriverWait(int seconds = 30)
        {
            return new WebDriverWait(WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last()), TimeSpan.FromSeconds(seconds));
        }

    }
}
