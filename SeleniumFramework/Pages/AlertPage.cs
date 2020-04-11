using System;
using OpenQA.Selenium;
using SeleniumFramework.Helpers;

namespace SeleniumFramework.Pages
{
    public class AlertPage
    {
        private readonly IWebDriver driver;
        private readonly BaseMethods baseMethods;

        private readonly By TriggerAlertButton = By.XPath(".//button[text()='Click for JS Alert']");
        private readonly By TriggerConfirmButton = By.XPath(".//button[text()='Click for JS Confirm']");
        private readonly By TriggerPromptButton = By.XPath(".//button[text()='Click for JS Prompt']");
        private readonly By Results = By.Id("result");

        public AlertPage(IWebDriver driver)
        {
            this.driver = driver;
            baseMethods = new BaseMethods(driver);
        }

        public void TriggerAlert()
        {
            baseMethods.Clicked(TriggerAlertButton);
            Report.Log("Clicked trigger alert button");
        }

        public void TriggerConfirm()
        {
            baseMethods.Clicked(TriggerConfirmButton);
            Report.Log("Confirmed trigger alert");
        }

        public void TriggerPrompt()
        {
            baseMethods.Clicked(TriggerPromptButton);
            Report.Log("Clicked trigger prompt button");
        }

        public void Alert_clickToAccept()
        {
            driver.SwitchTo().Alert().Accept();
            Report.Log("Accepted alert pop up");
        }

        public void alert_clickToDismiss()
        {
            driver.SwitchTo().Alert().Dismiss();
            Report.Log("Dismissed alert pop up");
        }

        public string Alert_getText()
        {
            var alertText = driver.SwitchTo().Alert().Text;
            Report.Log("Alert text: '" + alertText + "'");
            return alertText;
        }

        public void Alert_setInput(string text)
        {
            driver.SwitchTo().Alert().SendKeys(text);
            Report.Log("Entered text in alert text field");
        }

        public string GetResult()
        {
            string text = baseMethods.GetElementText(Results);
            Report.Log($"Alert text: '{text}'");
            return text;
        }
    }
}
