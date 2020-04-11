using System;
using OpenQA.Selenium;
using SeleniumFramework.Helpers;

namespace SeleniumFramework.Pages
{
    public class SecureAreaPage
    {
        private readonly IWebDriver driver;
        private readonly BaseMethods baseMethods;

        private readonly By StatusAlert = By.Id("flash");

        public SecureAreaPage(IWebDriver driver)
        {
            this.driver = driver;
            baseMethods = new BaseMethods(driver);
        }

        public string GetAlertText()
        {
            string text = baseMethods.GetElementText(StatusAlert);
            Report.Log("Alert text: " + text);
            return text;
        }
    }
}
