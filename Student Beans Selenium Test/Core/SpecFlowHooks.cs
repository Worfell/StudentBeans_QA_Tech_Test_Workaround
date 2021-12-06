using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;

namespace Student_Beans_Selenium_Test.Core
{
    [Binding]
    class SpecFlowHooks
    {
        //Extent calls to allow for Assertion checks
        private static ExtentTest _feature;
        private static ExtentTest _scenario;
        private static ExtentReports _extentReports;
        private ScenarioContext _scenarioContext;
        private ScenarioStepContext _scenarioStepContext;
        public IWebDriver _webDriver;

        LaunchBrowser launchBrowser = new LaunchBrowser();

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            //Open Chrome method
            _webDriver = launchBrowser.OpenChrome();
            objectContainer.RegisterInstanceAs<IWebDriver>(_webDriver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //Clear stored browser after run
            launchBrowser.Cleanup();
        }
    }
}
