using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumExamples
{
    internal class AmazonTest
    {
        IWebDriver? driver;

        public void InitializeEdgeDriver()
        {

            driver = new EdgeDriver();

            driver.Url = "https://www.amazon.com";
            driver.Manage().Window.FullScreen();

        }
        public void InitializeChromeDriver()
        {

            driver = new ChromeDriver();

            driver.Url = "https://www.amazon.com";
            driver.Manage().Window.FullScreen();
        }

            public void TitleTest()
            {

              Thread.Sleep(2000);

                Assert.AreEqual("Amazon.com. Spend less. Smile more.", driver.Title);
            Console.WriteLine("Title test - passed");

        }
        public void LogoClickTest()
        {


            driver.FindElement(By.Id("nav-logo-sprites")).Click();
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", driver.Title);
            Console.WriteLine("Logo Click test - passed");


        }
        public void SearchProductTest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobiles");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            Assert.That(("Amazon.com : mobiles".Equals(driver.Title)) && (driver.Url.Contains("mobiles")));
            Console.WriteLine("search product test -passed");
        }
        public void ReloadHomePage() {

            driver.Navigate().GoToUrl("https://www.amazon.com");
            Thread.Sleep(2000);
                  
        }
        public void ClickTodaysDealsTest()
        {
           IWebElement todaysdeal= driver.FindElement(By.LinkText("Today's Deals"));
            if (todaysdeal == null) {
                throw new NoSuchElementException("Today's Deals Link not present");
            }
           todaysdeal.Click();
            driver.FindElement(By.TagName("h1")).Text.Equals("Today's Deals");
            Console.WriteLine("Today's Deal test-passed");
        }
        public void SignInAccountListTest()
        {
            IWebElement hellosignin = driver.FindElement(By.Id("nav-link-accountList-nav-line-1"));
            if (hellosignin == null) {
                throw new NoSuchElementException("Hello, Signin is not present");

            }
            IWebElement accountsandlist = driver.FindElement(By.XPath("//*[@id=\"nav-link-accountList\"]/span"));
            if (accountsandlist == null)
            {
                throw new NoSuchElementException("Hello, Accounts and Lists is not present");

            }
            Assert.That(hellosignin.Text.Equals("Hello, sign in"));
            Console.WriteLine("Hello,Sign in is present -passed");
            Assert.That(accountsandlist.Text.Equals("Account & Lists"));
            Console.WriteLine("Hello, Accounts and Lists is  present -passed");

        }
        public void SearchAndFilterProductByBrand()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobile phones");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            IWebElement nokiacheckbox= driver.FindElement(By.XPath("//*[@id=\"p_89/Motorola\"]/span/a/div/label/i"));
            Thread.Sleep(3000);
            nokiacheckbox.Click();
            Assert.True(driver.FindElement(By.XPath("//*[@id=\"p_89/Motorola\"]/span/a/div/label/input")).Selected);
            Console.WriteLine("Motorola is selected");


            //driver.FindElement(By.ClassName("a-expander-prompt")).Click();
            IWebElement motorolacheckbox=driver.FindElement(By.XPath("//*[@id=\"p_89/Nokia\"]/span/a/div/label/i"));
            Thread.Sleep(3000); 
            motorolacheckbox.Click();

            Assert.True(driver.FindElement(By.XPath("//*[@id=\"p_89/Nokia\"]/span/a/div/label/input")).Selected);
            Console.WriteLine("Nokia is selected");

        }
        public void SortBySelectTest()
        {
            IWebElement sortby = driver.FindElement(By.ClassName("a-native-dropdown a-declarative"));
            SelectElement sortbyselect = (SelectElement)sortby;
            sortbyselect.SelectByValue("1");
        }
        public void Destruct()
        {
            driver.Close();
        }
    }
}
