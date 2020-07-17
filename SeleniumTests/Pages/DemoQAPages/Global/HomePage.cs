using OpenQA.Selenium;

namespace SeleniumTests.Pages.DemoQAPages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement Elements => 
            Driver.FindElement(By.XPath("//*[normalize-space(text())='Elements']/ancestor::div[contains(@class, 'top-card')]"));
        public IWebElement Forms => 
            Driver.FindElement(By.XPath("//*[normalize-space(text())='Forms']/ancestor::div[contains(@class, 'top-card')]"));
        public IWebElement AlertsFrameWindows => 
            Driver.FindElement(By.XPath("//*[normalize-space(text())='Alerts, Frame & Windows']/ancestor::div[contains(@class, 'top-card')]"));
        public IWebElement Widget => 
            Driver.FindElement(By.XPath("//*[normalize-space(text())='Widgets']/ancestor::div[contains(@class, 'top-card')]"));
        public IWebElement Interactions => 
            Driver.FindElement(By.XPath("//*[normalize-space(text())='Interactions']/ancestor::div[contains(@class, 'top-card')]"));
        public IWebElement BookStoreApp => 
            Driver.FindElement(By.XPath("//*[normalize-space(text())='Book Store Application']/ancestor::div[contains(@class, 'top-card')]"));
    }
}
