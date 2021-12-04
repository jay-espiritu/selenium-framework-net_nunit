using System;
using OpenQA.Selenium;
using SeleniumFramework.Helpers;

namespace SeleniumFramework.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly BaseMethods _baseMethods;

        private readonly By _formAuthenticationLink = By.LinkText("Form Authentication");

        public HomePage(IWebDriver driver)
        {
            this._driver = driver;
            _baseMethods = new BaseMethods(driver);
        }

        public LoginPage ClickFormAuthentication()
        {
            _baseMethods.Clicked(_formAuthenticationLink);
            return new LoginPage(_driver);
        }

        public AlertPage ClickJavaScriptAlerts(string alertText)
        {
            ClickLink(alertText);
            Report.WriteLog("Clicked on JS alert");
            return new AlertPage(_driver);
        }

        private void ClickLink(string linkText)
        {
            _baseMethods.Clicked(By.LinkText(linkText));
            Report.WriteLog("Clicked on link" + linkText);
        }
    }
}
