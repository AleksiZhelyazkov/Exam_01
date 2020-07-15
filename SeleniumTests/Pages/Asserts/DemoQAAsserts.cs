using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumTests.Pages.Asserts
{
    public class DemoQAAsserts :BasePage
    {
        public DemoQAAsserts(IWebDriver driver) : base(driver)
        {
        }
        public void AssertAutoCompleteColors()
        {
            List<IWebElement> resultList = 
                Driver.FindElements(By.XPath("//div[@class='col-12 mt-4 col-md-6']//div[@class='auto-complete__menu-list css-11unzgr']//*"))
                .ToList();
            List<String> Colors = new List<String>() { "Red", "Green" };

            IList<string> all = new List<string>();
            foreach (var item in resultList)
            {
                all.Add(item.Text);
            }

            for (int i = 0; i < all.Count; i++)
            {
                Assert.AreEqual(Colors[i], all[i]);
            }

        }

    }
}
