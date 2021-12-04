using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumFramework.Helpers;
using SeleniumFramework.Pages;
namespace SeleniumFramework
{
    [TestFixture]
    public class BaseConfig
    {
        private IWebDriver _driver;
        protected HomePage _homePage;

        [SetUp]
        public void Setup()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(new List<string>() { "no-sandbox", "headless", "disable-gpu" });

            _driver = new ChromeDriver(path, chromeOptions);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            Report.WriteLog("Initialize browser");

            _homePage = new HomePage(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            ScreenshotOnFailure();
            _driver.Quit();
            Report.WriteLog("Closed browser");
        }

        private void ScreenshotOnFailure()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
            {
                var folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var pathFolder = folderPath + "/Resources/Screenshots/";
                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                var filename = TestContext.CurrentContext.Test.MethodName + "(" + DateTime.Now.ToString("ddmmyyyyhhmmss") + ").png";
                var path = pathFolder + filename;
                screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
                TestContext.AddTestAttachment(path);
            }
        }
    }
}
