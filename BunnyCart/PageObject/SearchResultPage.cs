using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObject
{
    internal class SearchResultPage
    {
        IWebDriver driver;
        public SearchResultPage(IWebDriver driver)
        { 
        this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
        PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/main[1]" +
            "/div[3]/div[1]/div[3]/div[1]/div[2]" +
            "/ol[1]/li[2]/div[1]/div[1]/a[1]")]
        private IWebElement? FirstProductLink { get;  }
        public string? GetFirstProductLink()
        {
            return FirstProductLink.Text;
        }
        public ProductPage ClickFirstProductLink()
        {
            FirstProductLink?.Click();
            return new ProductPage(driver);
        }
    }
}
