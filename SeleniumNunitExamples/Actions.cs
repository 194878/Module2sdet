using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitExamples
{
    [TestFixture]
    internal class Actionsdg:CoreCodes
    {
        [Test]
        public void HomeLinkTest()
        {
            IWebElement homelink = driver.FindElement(By.LinkText("Home"));
            IWebElement tdhomelink = driver.FindElement(By.XPath("/html/body/div"+
                "/table/tbody/tr/td"
                +"/table/tbody/tr/td"+
                "/table/tbody/tr/td/"+
                "table/tbody/tr"));

            Actions actions = new Actions(driver);
            Action mouseOverAction = () => actions
            .MoveToElement(homelink).Build().Perform();

            Console.WriteLine("Before :"+ tdhomelink.GetCssValue("background-color"));
            mouseOverAction.Invoke();
            Console.WriteLine("After :" + tdhomelink.GetCssValue("background-color"));
            Thread.Sleep(3000);
        }
        [Test]
        public void MenuLinkTest()
        {
            driver.Navigate().GoToUrl("https://www.linkedin.com/home");
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchDriverException));
            fluentWait.Message = "no such element";

            IWebElement emailinput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
           
            Actions actions = new Actions(driver);

            Action upperCaseInput = () => actions
            .KeyDown(Keys.Shift).Click()
            .SendKeys(emailinput,"hello").KeyUp(Keys.Shift).Build()
            .Perform();
            Thread.Sleep (3000);




        }

    }
}
