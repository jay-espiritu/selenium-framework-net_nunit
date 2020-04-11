using System;
using OpenQA.Selenium;
using SeleniumFramework.Helpers;

namespace SeleniumFramework.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        private readonly BaseMethods baseMethods;

        private readonly By usernameField = By.Id("username");
        private readonly By passwordField = By.Id("password");
        private readonly By loginButton = By.CssSelector("button");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            baseMethods = new BaseMethods(driver);
        }

        public void SetUsername(string username)
        {
            baseMethods.EnterText(username, usernameField);
            Report.Log("Entered username with " + username);
        }

        public void SetPassword(string password)
        {
            baseMethods.EnterText(password, passwordField);
            Report.Log("Entered password with " + password);
        }

        public SecureAreaPage ClickLoginButton()
        {
            baseMethods.Clicked(loginButton);
            Report.Log("Clicked on login button");
            return new SecureAreaPage(driver);
        }
    }
}
