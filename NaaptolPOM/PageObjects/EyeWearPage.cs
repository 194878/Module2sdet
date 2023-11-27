using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaaptolPOM.PageObjects
{
    internal class EyeWearPage
    {
        IWebDriver driver;

        public EyeWearPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Reading Glasses with LED Lights (LRG4)']")]
        public IWebElement? EyeWearElement{ get; set; }

        public void ClickEyeWearElement()
        {
            EyeWearElement.Click();

        }
    }
}
