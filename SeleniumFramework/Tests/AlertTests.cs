using NUnit.Framework;
using SeleniumFramework.Pages;

namespace SeleniumFramework.Tests
{
    [Parallelizable]
    [TestFixture]
    public class AlertTests : BaseConfig
    {
        [Test]
        public void TestAcceptAlert()
        {
            AlertPage alertsPage = _homePage.ClickJavaScriptAlerts("JavaScript Alerts");
            alertsPage.TriggerAlert();
            alertsPage.Alert_clickToAccept();
            Assert.AreEqual(alertsPage.GetResult(), "You successfuly clicked an alert", "Results text incorrect");
        }

        [Test]
        public void TestGetTextFromAlert()
        {
            AlertPage alertsPage = _homePage.ClickJavaScriptAlerts("JavaScript Alerts");
            alertsPage.TriggerConfirm();

            string text = alertsPage.Alert_getText();
            alertsPage.alert_clickToDismiss();
            Assert.AreEqual(text, "I am a JS Confirm", "Alert text incorrect");
        }

        [Test]
        public void TestSetInputInAlert()
        {
            AlertPage alertsPage = _homePage.ClickJavaScriptAlerts("JavaScript Alerts");
            alertsPage.TriggerPrompt();

            string text = "SCREAM!";
            alertsPage.Alert_setInput(text);
            alertsPage.Alert_clickToAccept();
            Assert.AreEqual(alertsPage.GetResult(), $"You entered: '{text}'. Results text incorrect");
        }
    }
}
