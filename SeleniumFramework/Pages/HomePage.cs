using System;
using OpenQA.Selenium;
using SeleniumFramework.Helpers;

namespace SeleniumFramework.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        private readonly BaseMethods baseMethods;

        private readonly By FormAuthenticationLink = By.LinkText("Form Authentication");

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            baseMethods = new BaseMethods(driver);
        }

        public LoginPage ClickFormAuthentication()
        {
            baseMethods.Clicked(FormAuthenticationLink);
            return new LoginPage(driver);
        }

        public AlertPage ClickJavaScriptAlerts(string alertText)
        {
            ClickLink(alertText);
            Report.Log("Clicked on JS alert");
            return new AlertPage(driver);
        }

        private void ClickLink(string linkText)
        {
            baseMethods.Clicked(By.LinkText(linkText));
            Report.Log("Clicked on link" + linkText);
        }
    }
}
