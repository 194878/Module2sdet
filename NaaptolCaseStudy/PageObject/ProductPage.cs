using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaaptolCaseStudy.PageObject
{
    internal class ProductPage
    {
        IWebDriver driver;
        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//a[text()='Yellow-1.50']")]
        public IWebElement EyeWearSize { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[text()='Click here to Buy']")]
        public IWebElement AddToCartButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@title='Close']")]
        public IWebElement CLoseButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[@class='cartIcon']")]
        public IWebElement Cart { get; set; }

        public void SizeSelect()
        {
            EyeWearSize.Click();
        }
        public void AddToCart()
        {
            AddToCartButton.Click();
        }
        public void Closemodal()
        {
            /*DefaultWait<IWebDriver> defaultWait = new DefaultWait<IWebDriver>(driver);
            defaultWait.Timeout = TimeSpan.FromSeconds(5);
            defaultWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            defaultWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            defaultWait.Message = "no such element";

            IWebElement eyeWear = defaultWait.Until(d=>d.FindElement());*/
            Thread.Sleep(3000);
            CLoseButton.Click();
        }
        public void ViewCart()
        {
            Cart.Click();
        }
    }
}
