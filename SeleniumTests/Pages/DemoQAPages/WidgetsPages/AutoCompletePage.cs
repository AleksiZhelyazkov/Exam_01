using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests.Pages.DemoQA.WidgetsPages
{
    public class AutoCompletePage : NavigationBar
    {
        public AutoCompletePage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement SingleColorField => 
            Driver.FindElement(By.XPath("//div[@id = 'autoCompleteSingleContainer']"));
        public IWebElement RedColorOption => 
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='react-select-3-option-0\']")));
        public IWebElement GreenColorOption => 
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='react-select-3-option-1\']")));

    }
}
