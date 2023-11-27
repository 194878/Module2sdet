using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V116.DOM;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.PageObject
{
    internal class BunnyCartHomePage
    {

        IWebDriver driver;
        public BunnyCartHomePage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        [FindsBy(How = How.Id, Using = "search")]
        [CacheLookup]
        private IWebElement? SearchInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Create an Account']")]
        [CacheLookup]
        private IWebElement? CreateAccountLink { get; set; }

        [FindsBy(How = How.Id, Using = "firstname")]
        private IWebElement? FirstNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "lastname")]
        private IWebElement? LastNameInput { get; set; }

        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement? EmailInput { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement? PasswordInput { get; set; }

        [FindsBy(How = How.Name, Using = "password_confirmation")]
        private IWebElement? ConfirmPasswordInput { get; set; }

        [FindsBy(How = How.Id, Using = "mobilenumber")]
        private IWebElement? MobileNumberInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@title='Create an Account']")]
        private IWebElement? SignInButton { get; set; }

        //Act
        public void ClickCreateAnAccountLink()
        {
            CreateAccountLink?.Click();
        }

        public void SignUp(string firstname, string lastname, string email, string pwd, string conpwd, string mob)
        {
            IWebElement modal = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).
                Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//div[@class='modal-inner-wrap'])[position()=2]")));

            FirstNameInput?.SendKeys(firstname);
            LastNameInput?.SendKeys(lastname);
            EmailInput?.SendKeys(email);

            ScrollIntoView(driver, modal.FindElement(By.Id("password")));
            PasswordInput?.SendKeys(pwd);
            ConfirmPasswordInput?.SendKeys(conpwd);

            ScrollIntoView(driver, modal.FindElement(By.Id("mobilenumber")));
            MobileNumberInput?.SendKeys(mob);
            SignInButton?.Click();
        }
        static void ScrollIntoView(IWebDriver driver,IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        public SearchResultPage TypeSearchInput(string searchtext)
        {
            if(SearchInput==null)
                {
                throw new NoSuchElementException(nameof(SearchInput));
            }
            SearchInput.SendKeys(searchtext);   
            SearchInput.SendKeys(Keys.Enter);
            return new SearchResultPage(driver);
        }

    }
}
