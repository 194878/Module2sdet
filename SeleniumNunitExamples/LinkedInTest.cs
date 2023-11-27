using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitExamples
{
    [TestFixture]
    internal class LinkedInTest :CoreCodes
    {
        [Test]
        [Author("Sha","sha123@gmail.com")]
        [Description("checked for Valid Login")]
        [Category("Regression Testing")]
        public void Login1Test()
        {
            Thread.Sleep(3000);
            WebDriverWait wait= new WebDriverWait(driver,TimeSpan.FromSeconds(10));
            // IWebElement emailinput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_key")));
            //IWebElement passwordinput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_password")));
           // IWebElement emailinput = wait.Until(d =>d.FindElement(By.Id("session_key")));
            //IWebElement passwordinput = wait.Until(driv =>driv.FindElement(By.Id("session_password")));

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchDriverException));
            fluentWait.Message = "no such element";

            IWebElement emailinput = wait.Until(d => d.FindElement(By.Id("session_key")));
            IWebElement passwordinput = wait.Until(driv => driv.FindElement(By.Id("session_password")));


            emailinput.SendKeys("abc@xyc.com");
            passwordinput.SendKeys("123456");
            Thread.Sleep(3000);
        }
        /*
        [Test]
        [Author("Shaaa", "shaaa123@gmail.com")]
        [Description("checked for InValid Login")]
        [Category("Smoke Testing")]
        public void LoginTestWithInvalidCred()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchDriverException));
            fluentWait.Message = "no such element";

            IWebElement emailinput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
            IWebElement passwordinput = fluentWait.Until(driv => driv.FindElement(By.Id("session_password")));


            emailinput.SendKeys("abc@xyc.com");
            passwordinput.SendKeys("123456");
            ClearForm(emailinput);
            ClearForm(passwordinput);



            emailinput.SendKeys("xyz@xyc.com");
            passwordinput.SendKeys("99999");
            ClearForm(emailinput);
            ClearForm(passwordinput);

            emailinput.SendKeys("mno@xyc.com");
            passwordinput.SendKeys("22222");
            Thread.Sleep(3000);
            ClearForm(emailinput);
            ClearForm(passwordinput);

        }
         */
        void ClearForm(IWebElement element)
        {
            element.Clear();
        }
        /*
         [Test]
         [Author("Shanu", "shanu123@gmail.com")]
         [Description("checked for InValid Login")]
         [Category("Regression Testing")]
         [TestCase("xyz@xyc.com", "123456")]
         [TestCase("abc@xyc.com", "99999")]
         [TestCase("mno@xyc.com", "22222")]
         public void LoginTestWithInvalidCred(string email,string pwd)
         {

             DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
             fluentWait.Timeout = TimeSpan.FromSeconds(5);
             fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
             fluentWait.IgnoreExceptionTypes(typeof(NoSuchDriverException));
             fluentWait.Message = "no such element";

             IWebElement emailinput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
             IWebElement passwordinput = fluentWait.Until(driv => driv.FindElement(By.Id("session_password")));

             emailinput.SendKeys(email);
             passwordinput.SendKeys(pwd);
             ClearForm(emailinput);
             ClearForm(passwordinput);
             Thread.Sleep(3000);



         }
        */
       
        [Test,Author("Shanu", "shanu123@gmail.com")]
        [Description("checked for InValid Login"),Category("Regression Testing")]
        [TestCaseSource(nameof(InvalidLoginData))]
       
        //[TestCase("xyz@xyc.com", "123456")]
       // [TestCase("abc@xyc.com", "99999")]
        //[TestCase("mno@xyc.com", "22222")]
        public void LoginTestWithInvalidCred(string email, string pwd)
        {

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchDriverException));
            fluentWait.Message = "no such element";

            IWebElement emailinput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
            IWebElement passwordinput = fluentWait.Until(driv => driv.FindElement(By.Id("session_password")));

            emailinput.SendKeys(email);
            passwordinput.SendKeys(pwd);
            Thread.Sleep(5000);
            TakeScreenshot();

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);",driver.FindElement(By.XPath("//button[@type='submit']")));
            Thread.Sleep(3000);
            js.ExecuteScript("arguments[0].click();", driver.FindElement(By.XPath("//button[@type='submit']")));
            

            ClearForm(emailinput);
            ClearForm(passwordinput);
            Thread.Sleep(TimeSpan.FromSeconds(2));



        }
        static object[] InvalidLoginData()
        {
            return new object[]
            {
                new object[]{ "abcxyccom34545656trfcfdbnvcnvndgfde5fjhhj", "12543434rddffd3456" },
                new object[]{"xyz5646tdy54r5tyd54ytdy5r6rtfcgxycgfgghc","99955465trdtfyr65tf565499"}
            };
        }
       
    }
}
