using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_Flipkart
{
    internal class FlipkartTest: CoreCodes
    {
        [Test]
        [Description("Test for searchbar")]

        public void SearchBarTest()
        {
            IWebElement searchbar = driver.FindElement(By.XPath("//input[@title='Search for Products, Brands and More']"));
            searchbar.SendKeys("laptop");
            searchbar.SendKeys(Keys.Enter);
            Thread.Sleep(1000);

        }

    }
}
