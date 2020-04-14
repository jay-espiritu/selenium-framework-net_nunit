using System;
using OpenQA.Selenium;
using SeleniumFramework.Helpers;

namespace SeleniumFramework.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly BaseMethods _baseMethods;

        private readonly By UsernameField = By.Id("username");
        private readonly By PasswordField = By.Id("password");
        private readonly By LoginButton = By.CssSelector("button");

        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
            _baseMethods = new BaseMethods(driver);
        }

        public void SetUsername(string username)
        {
            _baseMethods.EnterText(username, UsernameField);
            Report.WriteLog("Entered username with " + username);
        }

        public void SetPassword(string password)
        {
            _baseMethods.EnterText(password, PasswordField);
            Report.WriteLog("Entered password with " + password);
        }

        public SecureAreaPage ClickLoginButton()
        {
            _baseMethods.Clicked(LoginButton);
            Report.WriteLog("Clicked on login button");
            return new SecureAreaPage(_driver);
        }
    }
}
