using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTests.Pages
{
    public class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            Actions = new Actions(driver);

            var Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
        }
        protected Actions Builder { get; set; }
        public IWebDriver Driver { get; private set; }
        public WebDriverWait Wait { get; set; }
        public Actions Actions { get; set; }
        public void WaitForLoad(int timeoutSec = 15)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(0, 0, timeoutSec));
            wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }

        public IWebElement ScrollTo(IWebElement element)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            return element;
        }
        public void Scroll(int offset)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript($"window.scrollBy(0, -{offset});");
        }
    }
}
