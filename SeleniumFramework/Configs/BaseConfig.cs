using System;
using System.IO;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumFramework.Helpers;
using SeleniumFramework.Pages;

namespace SeleniumFramework
{
    public class BaseConfig
    {
        private IWebDriver driver;
        protected HomePage homePage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            Report.Log("Initialize browser");

            homePage = new HomePage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            ScreeshotOnFailure();
            driver.Quit();
            Report.Log("Closed browser");
        }

        private void ScreeshotOnFailure()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
            {
                var pathFolder = "/Users/jayespiritu/dev/AutomationFrameworks/SeleniumFramework/SeleniumFramework/SeleniumFramework/Resources/Screenshots/";
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var filename = TestContext.CurrentContext.Test.MethodName + "_" + DateTime.Now.ToString("ddmmyyyyhhmmss") + ".png";
                var path = pathFolder + filename;
                screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
                TestContext.AddTestAttachment(path);
            }
        }
    }
}