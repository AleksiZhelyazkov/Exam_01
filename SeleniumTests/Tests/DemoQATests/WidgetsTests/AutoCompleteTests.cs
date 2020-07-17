using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using SeleniumTests.Pages.DemoQA.WidgetsPages;
using SeleniumTests.Pages.DemoQAPages;
using System.IO;

namespace SeleniumTests.Tests.DemoQATests.WidgetsTests
{
    public class AutoCompleteTests : BaseTests
    {
        private HomePage _homePage;
        private AutoCompletePage _autoCompletePage;


        [SetUp]
        public void DemoQASetup()
        {
            Initialize();
            _homePage = new HomePage(Driver);
            _autoCompletePage = new AutoCompletePage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                screenshot.SaveAsFile($"{Directory.GetCurrentDirectory()}/{TestContext.CurrentContext.Test.Name}.png", ScreenshotImageFormat.Png);
            }
            Driver.Quit();
        }

        [Test]
        public void AutoCompleteRedColor()
        {
            _homePage.Widget.Click();
            _autoCompletePage.ScrollTo(_autoCompletePage.AutoCompleteButton).Click();

            _autoCompletePage.Action
                .MoveToElement(_autoCompletePage.SingleColorField)
                .Click()
                .SendKeys("Re")
                .Perform();

            Assert.IsTrue(_autoCompletePage.RedColorOption.Displayed);
            Assert.IsTrue(_autoCompletePage.GreenColorOption.Displayed);
        }

    }
}