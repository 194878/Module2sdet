using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_testing2
{
    internal class BrowserSwitching
    {
        IWebDriver? driver;

        public void ChromeInitialize()
        {

            driver = new ChromeDriver();

        }
        public void GoogleSearchFind()
        {
            Thread.Sleep(2000);
            driver.Url = "https://www.google.com/";
           
        }
        public void YahooSearch()
        {
            driver.Url = "https://www.yahoo.com/";
            
        }
        public void DiwaliSearch() {



            driver.FindElement(By.Id("APjFqb")).SendKeys("whats new for diwali 2023?");
            Thread.Sleep(3000);
            driver.FindElement(By.ClassName("gNO89b")).Click();
        }
        public void GoSwitch()
        { 
            driver.Navigate().Back();
            Thread.Sleep(1000);
        
        }
        public void RefreshTest()
        {
            driver.Navigate().Refresh();
            Thread.Sleep(3000);
        }

        public void Destruct()
        {
            driver.Close();
        }
    }
}
