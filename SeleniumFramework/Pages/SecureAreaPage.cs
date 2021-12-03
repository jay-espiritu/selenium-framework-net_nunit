using System;
using OpenQA.Selenium;
using SeleniumFramework.Helpers;

namespace SeleniumFramework.Pages
{
    public class SecureAreaPage
    {
        private readonly IWebDriver _driver;
        private readonly BaseMethods _baseMethods;

        private readonly By _statusAlert = By.Id("flash");

        public SecureAreaPage(IWebDriver driver)
        {
            _driver = driver;
            _baseMethods = new BaseMethods(driver);
        }

        public string GetAlertText()
        {
            var text = _baseMethods.GetElementText(_statusAlert);
            Report.WriteLog("Alert text: " + text);
            return text;
        }
    }
}
