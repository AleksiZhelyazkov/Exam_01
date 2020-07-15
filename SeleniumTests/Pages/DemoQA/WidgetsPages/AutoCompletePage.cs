using OpenQA.Selenium;
using System.Threading;

namespace SeleniumTests.Pages.DemoQA.WidgetsPages
{
    public class AutoCompletePage : NavigationBar
    {
        public AutoCompletePage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement SingleColorField => 
            Driver.FindElement(By.XPath("//div[@id='autoCompleteSingle']//div//div"));

        public void TypeColor()
        {
            Thread.Sleep(1000);
            Actions.MoveToElement(SingleColorField)
                .Click()
                .SendKeys("Re")
                .Perform();
        }

    }
}
