using System;
using OpenQA.Selenium;
using SeleniumFramework.Helpers;

namespace SeleniumFramework.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly BaseMethods _baseMethods;

        private readonly By _usernameField = By.Id("username");
        private readonly By _passwordField = By.Id("password");
        private readonly By _loginButton = By.CssSelector("button");

        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
            _baseMethods = new BaseMethods(driver);
        }

        public void SetUsername(string username)
        {
            _baseMethods.EnterText(username, _usernameField);
            Report.WriteLog("Entered username with " + username);
        }

        public void SetPassword(string password)
        {
            _baseMethods.EnterText(password, _passwordField);
            Report.WriteLog("Entered password with " + password);
        }

        public SecureAreaPage ClickLoginButton()
        {
            _baseMethods.Clicked(_loginButton);
            Report.WriteLog("Clicked on login button");
            return new SecureAreaPage(_driver);
        }
    }
}
