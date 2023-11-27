using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaaptolCaseStudy.PageObject
{
    internal class HomePage
    {
        IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "header_search_text")]
        public IWebElement? SearchBox { get; set; }

        public void SerachForProduct(string productName)
        {
            driver.Navigate().GoToUrl("https://www.naaptol.com/");
            SearchBox.SendKeys(productName);
        }
        public void ClickOnSearch()
        {
            SearchBox.SendKeys(Keys.Enter);
        }

    }
}
