using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace SeleniumTests.Tests
{
    public abstract class BaseTests
    {
        public void Initialize()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("http://demoqa.com/");
        }
        public IWebDriver Driver { get; private set; }
    }
}
