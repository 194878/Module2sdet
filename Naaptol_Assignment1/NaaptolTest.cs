using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace Naaptol_Assignment1
{
   
    internal class NaaptolTest:CoreCodes
    {
        [Test]
        [Order(0)]
        public void SearchProductTest()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchDriverException));
            fluentWait.Message = "no such element";

            IWebElement searchelement = fluentWait.Until(d => d.FindElement(By.XPath("//input[@id='header_search_text']")));

             searchelement.SendKeys("eyewears");
            searchelement.SendKeys(Keys.Enter);
        }
        [Test]
        [Order(1)]
        public void SelectProductTest()
        {

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchDriverException));
            fluentWait.Message = "no such element";

            IWebElement selectproduct = fluentWait.Until(d => d.FindElement(By.XPath("//a[normalize-space()='Reading Glasses with LED Lights (LRG4)']")));
            Actions action=new Actions(driver);
            Action perform=() =>
            action.MoveToElement(selectproduct).Build().Perform();
            perform.Invoke();
            selectproduct.Click();
            List<string> li = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(li[1]);


        }
        [Test]
        [Order(3)]
        public void AddToCartTest()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchDriverException));
            fluentWait.Message = "no such element";

            IWebElement sizeproduct = fluentWait.Until(d => d.FindElement(By.XPath("//a[text()='Black-3.00']")));
            sizeproduct.Click();
            IWebElement addtocart = fluentWait.Until(d => d.FindElement(By.XPath("//a[@title='Buy online']")));
            addtocart.Click();
            Thread.Sleep(3000);
            
            IWebElement closethecart = fluentWait.Until(d => d.FindElement(By.XPath("//a[@title='Close']")));
            closethecart.Click();
            Thread.Sleep(3000);

        }
    }
}
