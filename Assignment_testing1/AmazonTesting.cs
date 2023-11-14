using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_testing1
{
    internal class AmazonTesting
    {
        IWebDriver? driver;

        public void ChromeInitialize() { 

            driver=new ChromeDriver();
            driver.Url = "https://www.amazon.com";

        }
        public void TitleTest() {
           
          //  Console.WriteLine(driver.Title);

            Assert.AreEqual("Amazon.com. Spend less. Smile more.", driver.Title);
          

        }
        public void UrlTest()
        {
            Assert.AreEqual("https://www.amazon.com/", driver.Url);
        }
        public void Destruct()
        {
            driver.Close();
        }
    }
}
