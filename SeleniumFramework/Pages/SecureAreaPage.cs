using System;
using OpenQA.Selenium;
using SeleniumFramework.Helpers;

namespace SeleniumFramework.Pages
{
    public class SecureAreaPage
    {
        private readonly IWebDriver _driver;
        private readonly BaseMethods _baseMethods;

        private readonly By StatusAlert = By.Id("flash");

        public SecureAreaPage(IWebDriver driver)
        {
            _driver = driver;
            _baseMethods = new BaseMethods(driver);
        }

        public string GetAlertText()
        {
            string text = _baseMethods.GetElementText(StatusAlert);
            Report.WriteLog("Alert text: " + text);
            return text;
        }
    }
}
