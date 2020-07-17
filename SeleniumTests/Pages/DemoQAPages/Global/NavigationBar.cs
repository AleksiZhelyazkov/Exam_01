using OpenQA.Selenium;

namespace SeleniumTests.Pages.DemoQA
{
   public class NavigationBar : BasePage
    {
        public NavigationBar(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement AccordianButton => 
            Driver.FindElement(By.XPath($"//*[normalize-space(text())='Accordian']"));
        public IWebElement AutoCompleteButton => 
            Driver.FindElement(By.XPath($"//*[normalize-space(text())='Auto Complete']"));
        public IWebElement DatePickerButton => 
            Driver.FindElement(By.XPath($"//*[normalize-space(text())='Date Picker']"));
        public IWebElement SliderButton => 
            Driver.FindElement(By.XPath($"//*[normalize-space(text())='Slider']"));
        public IWebElement ProgressBarButton => 
            Driver.FindElement(By.XPath($"//*[normalize-space(text())='Progress Bar']"));
        public IWebElement TabsButton => 
            Driver.FindElement(By.XPath($"//*[normalize-space(text())='Tabs']"));
        public IWebElement ToolTipButton => 
            Driver.FindElement(By.XPath($"//*[normalize-space(text())='Tool Tips']"));
        public IWebElement MenuButton => 
            Driver.FindElement(By.XPath($"//*[normalize-space(text())='Menu']"));
        public IWebElement SelectMenuButton => 
            Driver.FindElement(By.XPath($"//*[normalize-space(text())='Select Menu']"));

    }
}
