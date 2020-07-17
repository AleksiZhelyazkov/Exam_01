using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using SeleniumTests.Pages.DemoQA.WidgetsPages;
using SeleniumTests.Pages.DemoQAPages;
using System.IO;
using System.Threading;

namespace SeleniumTests.Tests.DemoQATests.WidgetsTests
{
    public class DatePickerTests : BaseTests
    {
        private HomePage _homePage;
        private DatePickerPage _datepickerPage;


        [SetUp]
        public void DemoQASetup()
        {
            Initialize();
            _homePage = new HomePage(Driver);
            _datepickerPage = new DatePickerPage(Driver);
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
        [TestCase("01", "17")]
        [TestCase("02", "17")]
        [TestCase("03", "17")]
        [TestCase("04", "17")]
        [TestCase("05", "17")]
        [TestCase("06", "17")]
        [TestCase("07", "17")]
        [TestCase("08", "17")]
        [TestCase("09", "17")]
        [TestCase("10", "17")]
        [TestCase("11", "17")]
        [TestCase("12", "17")]
        public void DatePicker(string month, string day)
        {
            _homePage.Widget.Click();
            _datepickerPage.ScrollTo(_datepickerPage.DatePickerButton).Click();

            _datepickerPage.ClearSelectDate();
            _datepickerPage.FillDate(month, day);

            string expectedDate = _datepickerPage.GetMonth(month) + " 2020";
            string actualDate = _datepickerPage.currentMonth.Text;
            string expectedDay = day;
            string actualDay = _datepickerPage.currentDay.Text;

            Assert.AreEqual(expectedDate, actualDate);
            Assert.AreEqual(expectedDay, actualDay);
        }

    }
}