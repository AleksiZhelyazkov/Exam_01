using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTests.Pages.Asserts;
using SeleniumTests.Pages.DemoQA.WidgetsPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SeleniumTests
{
    public class DemoQATests
    {
        private IWebDriver _driver;
        private Pages.DemoQA.HomePage _homePage;
        private AutoCompletePage _autoCompletePage;
        private DatePickerPage _datepickerPage;
        private DemoQAAsserts _demoQAAsserts;


        [SetUp]
        public void DemoQASetup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();

            _homePage = new Pages.DemoQA.HomePage(_driver);
            _autoCompletePage = new AutoCompletePage(_driver);
            _datepickerPage = new DatePickerPage(_driver);

            _demoQAAsserts = new DemoQAAsserts(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                screenshot.SaveAsFile($"{Directory.GetCurrentDirectory()}/{TestContext.CurrentContext.Test.Name}.png", ScreenshotImageFormat.Png);
            }
            _driver.Quit();
        }

        [Test]
        public void AutoCompleteRedColor()
        {
            _driver.Url = "http://demoqa.com/";
            _homePage.Widget.Click();

            _autoCompletePage.ScrollTo(_autoCompletePage.AutoCompleteButton).Click();
            _autoCompletePage.TypeColor();

            _demoQAAsserts.AssertAutoCompleteColors();
        }

        [Test]
        public void DatePicker()
        {
            _driver.Url = "http://demoqa.com/";
            _homePage.Widget.Click();
            _datepickerPage.ScrollTo(_datepickerPage.DatePickerButton).Click();

            _datepickerPage.ClearSelectDate();

            int day = 5;
            int month = 6;
            _datepickerPage.SelecMonth(month, day);

            var value = _datepickerPage.SelectDateTable.GetAttribute("value");
            Assert.AreEqual(value, "06/05/2020");
        }

    }
}