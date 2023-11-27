using Rediff.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.TestScripts
{
    [TestFixture]
    internal class UserManagementTest:CoreCodes
    {

        //Asserts
        [Test,Order(1),Category("Smoke Test")]
        public void CreateAccountLinkTest()
        {
            var homepage = new RediffHomePage(driver);
            driver.Navigate().GoToUrl("https://www.rediff.com");
            homepage.CreateAccountLinkClick();
            Thread.Sleep(2000);
            Assert.That(driver.Url.Contains("register"));

        }
       
        [Test,Order(2),Category("Smoke Test")]
        public void SignInLinkTest()
        {
            var homepage = new RediffHomePage(driver);
            driver.Navigate().GoToUrl("https://www.rediff.com");
            homepage.SignInLinkClick();
            Thread.Sleep(2000);
            Assert.That(driver.Url.Contains("login"));

        }
        [Test, Order(3), Category("Regression Test")]
        public void CreateAccountFunctionalityTest()
        {
            var homepage = new RediffHomePage(driver);
            if (!driver.Url.Equals("https://www.rediff.com"))
            {
                driver.Navigate().GoToUrl("https://www.rediff.com");
            }
           
            var createaccountpage= homepage.CreateAccountClick();
            Thread.Sleep(2000);
            createaccountpage.FullNameType("xxx");
            createaccountpage.RediffMailType("xxx");
            createaccountpage.CheckAvailBtnClick();
            createaccountpage.CreateMyAccntBtnClick();  



        }
        [Test, Order(4), Category("Regression Test")]
        public void SignInTest()
        {
            var homepage = new RediffHomePage(driver);
            if (!driver.Url.Equals("https://www.rediff.com"))
            {
                driver.Navigate().GoToUrl("https://www.rediff.com");
            }

            var signinpage = homepage.SignInClick();
            Thread.Sleep(2000);
            signinpage.UserNameType("xxx");
            signinpage.PasswordType("xxx");
            signinpage.ClickRememeberMeChechBx();
            Assert.False(signinpage?.RememberMeChkBx?.Selected);
            signinpage.ClickSignInBtn();



        }
    }
}
