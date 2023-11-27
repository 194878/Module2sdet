using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Edge;

namespace SeleniumExamples
{
    internal class GHPTests
    {
        IWebDriver? driver;
        public void InitializeEdgeDriver() {

            driver = new EdgeDriver();

            driver.Url = "https://www.google.com";


        }
        public void InitializeChromeDriver()
        {

            driver = new ChromeDriver();

            driver.Url = "https://www.google.com";

        }
        public void TitleTest() {
            Thread.Sleep(1000);
//string title = driver.Title;
           // Console.WriteLine("Title :"+driver.Title);
           // Console.WriteLine("Title Length :" + driver.Title.Length);
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine(" Title test - pass");
            

        }
        public void PageSourceandURLTest()
        {
            //Console.WriteLine("PageSource:"+driver.PageSource);
           // Console.WriteLine("PageSource Length :"+driver.PageSource.Length);
            //Console.WriteLine(driver.Url);
            Assert.AreEqual("https://www.google.com/",driver.Url);
            Console.WriteLine(" url test-passed");
        }
        public void GSTest()
        {
            
            IWebElement searchinputtestbox = driver.FindElement(By.Id("APjFqb"));
            searchinputtestbox.SendKeys("hp laptop");
            Thread.Sleep(3000);
            IWebElement googlesearchbutton = driver.FindElement(By.ClassName("gNO89b"));   //    Name("btnK"));
            googlesearchbutton.Click();
            Assert.AreEqual("hp laptop - Google Search", driver.Title);
            Console.WriteLine("Google Search test-  pass");

        }
        public void GmailLinkTest()
        {
            driver.Navigate().Back();
            driver.FindElement(By.PartialLinkText("ma")).Click();
            Thread.Sleep(3000);
            // Assert.That(driver.Title.Contains("Gmail"));
            Assert.That(driver.Url.Contains("gmail")) ;
            Console.WriteLine("Gmail test- passed");
        }
        public void ImageLinkTest()
        {
            driver.Navigate().Back();
            driver.FindElement(By.PartialLinkText("mag")).Click();
            Thread.Sleep(3000);
         
            Assert.That(driver.Title.Contains("Images"));
            Console.WriteLine("Google Images link test- passed");
        }
        public void LocalizationTest()
        {
            driver.Navigate().Back();
            string location= driver.FindElement(By.XPath("/html/body/div[1]/div[6]/div[1]")).Text;
            Thread.Sleep(3000);

            Assert.That(location.Equals("India"));
            Console.WriteLine("location text test- passed");
        }
        public void GAppYoutubeTest()
        {
            driver.FindElement(By.ClassName("gb_d")).Click();
            Thread.Sleep(3000);
            //driver.FindElement(By.CssSelector(".u4RcUd>.j1ei8c:nth-child(4).MrEfLc")).Click();
            Thread.Sleep(3000);
        
        }
        public void Destruct() {
            driver.Close();
        }
    }
}
