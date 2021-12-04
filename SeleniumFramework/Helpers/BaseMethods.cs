using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumFramework.Helpers
{
    public class BaseMethods
    {
        private readonly IWebDriver _driver;

        public BaseMethods(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement Find(By locator)
        {
            IWebElement element = null;
            try
            {
                element = _driver.FindElement(locator);
            }
            catch (NoSuchElementException e)
            {
                Assert.Fail($"Element cannot be found. Error: {e}");
            }
            return element;
        }

        public void Clicked(By locator)=>
            Find(locator).Click();

        public void EnterText(string inputText, By locator) =>
            Find(locator).SendKeys(inputText);

        public string GetElementText(By locator)=>
             Find(locator).Text;
        
    }
}
