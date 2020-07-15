using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SeleniumTests.Pages.DemoQA.WidgetsPages
{
    public class DatePickerPage : NavigationBar
    {
        public DatePickerPage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement SelectDateTable => Driver.FindElement(By.Id("datePickerMonthYearInput"));

        public IWebElement MonthPicker => Driver.FindElement(By.XPath("//*[@class='react-datepicker__month-select']"));

        public void ClearSelectDate()
        {
            for (int i = 0; i < 10; i++)
            {
                SelectDateTable.SendKeys(Keys.Backspace);
            }
        }

        public void SelecMonth(int month, int day)
        {
            List<IWebElement> yearList = Driver.FindElements(By.XPath("//*[@class='react-datepicker__year-select']//*")).ToList();
            yearList[120].Click();

            MonthPicker.Click();
            List<IWebElement> List = Driver.FindElements(By.XPath("//*[@class='react-datepicker__month-select']//*")).ToList();
            List[month-1].Click();

            List<IWebElement> ListDays = Driver.FindElements(By.XPath("//*[@class='react-datepicker__month']//*")).ToList();
            ListDays[day+1].Click();

        }
    }
}
