using System;
using NUnit.Framework;
using SeleniumFramework.Pages;

namespace SeleniumFramework.Tests
{
    public class LoginTests : BaseConfig
    {
        [Test]
        public void TestSuccessfulLogin()
        {
            LoginPage loginPage = homePage.ClickFormAuthentication();
            loginPage.SetUsername("tomsmith");
            loginPage.SetPassword("SuperSecretPassword!");
            SecureAreaPage secureAreaPage = loginPage.ClickLoginButton();
            secureAreaPage.GetAlertText();
            Assert.True(
                secureAreaPage.GetAlertText().Contains("You logged into a secure area!"),
                "Alert text does not match");
        }

        [Test]
        public void TestUnsuccessfulLogin()
        {
            LoginPage loginPage = homePage.ClickFormAuthentication();
            loginPage.SetUsername("tomsmith!");
            loginPage.SetPassword("SuperSecretPassword!");
            SecureAreaPage secureAreaPage = loginPage.ClickLoginButton();
            secureAreaPage.GetAlertText();
            Assert.AreEqual(
                    secureAreaPage.GetAlertText().Contains("You logged into a secure area!"),
                    "Alert text does not match");
        }
    }
}
