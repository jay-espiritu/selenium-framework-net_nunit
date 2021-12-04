using NUnit.Framework;

namespace SeleniumFramework.Tests
{
    [Parallelizable]
    [TestFixture]
    public class AlertTests : BaseConfig
    {
        [Test]
        public void TestAcceptAlert()
        {
            var alertsPage = _homePage.ClickJavaScriptAlerts("JavaScript Alerts");
            alertsPage.TriggerAlert();
            alertsPage.Alert_clickToAccept();
            Assert.AreEqual(alertsPage.GetResult(), "You successfully clicked an alert", "Results text incorrect");
        }

        [Test]
        public void TestGetTextFromAlert()
        {
            var alertsPage = _homePage.ClickJavaScriptAlerts("JavaScript Alerts");
            alertsPage.TriggerConfirm();

            var text = alertsPage.Alert_getText();
            alertsPage.alert_clickToDismiss();
            Assert.AreEqual(text, "I am a JS Confirm", "Alert text incorrect");
        }

        [Test]
        public void TestSetInputInAlert()
        {
            var alertsPage = _homePage.ClickJavaScriptAlerts("JavaScript Alerts");
            alertsPage.TriggerPrompt();

            var text = "SCREAM!";
            alertsPage.Alert_setInput(text);
            alertsPage.Alert_clickToAccept();
            Assert.AreEqual(alertsPage.GetResult(), $"You entered: '{text}'. Results text incorrect");
        }
    }
}
