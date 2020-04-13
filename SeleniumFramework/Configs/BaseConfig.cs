using System;
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
        private IWebDriver driver;
        protected HomePage homePage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            Report.WriteLog("Initialize browser");

            homePage = new HomePage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            ScreeshotOnFailure();
            driver.Quit();
            Report.WriteLog("Closed browser");
        }

        private void ScreeshotOnFailure()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
            {
                string folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var pathFolder = folderPath + "/Resources/Screenshots/";
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var filename = TestContext.CurrentContext.Test.MethodName + "(" + DateTime.Now.ToString("ddmmyyyyhhmmss") + ").png";
                var path = pathFolder + filename;
                screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
                TestContext.AddTestAttachment(path);
            }
        }
    }
}