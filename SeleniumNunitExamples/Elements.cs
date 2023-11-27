using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitExamples
{
    [TestFixture]
    internal class Elements:CoreCodes
    {
        [Ignore("other")]
        [Test]
        public void TestCheckBox()
        {
            Thread.Sleep(2000);
         //IWebElement elements = driver.FindElement(By.XPath("//h5[text()='Element']"));
            //elements.Click();
            IWebElement cbmenu = driver.FindElement(By.XPath("//span[text()='Check Box']"));
            cbmenu.Click();
           List <IWebElement> expandcollapse = driver.FindElements(By.ClassName("rct-collapse__rct-collapse-btn")).ToList();
            foreach (IWebElement item in expandcollapse) {
            item.Click();
            
            }
            IWebElement commandscheckbox = driver.FindElement(By.XPath("//span[text()='Commands']"));
            commandscheckbox.Click();
            Assert.True(driver.FindElement(By.XPath("//input[contains(@id,'commands')]")).Selected);


        }
        [Ignore("other")]
        [Test]
        public void TestFormElements()
        {
            Thread.Sleep(1000);
            IWebElement firstNameField = driver.FindElement(By.Id("firstName"));
            firstNameField.SendKeys("John");
            Thread.Sleep(1000);

            Thread.Sleep(1000);
            IWebElement lastNameField = driver.FindElement(By.Id("lastName"));
            lastNameField.SendKeys("Doe");
            Thread.Sleep(1000);

            Thread.Sleep(1000);
            IWebElement emailField = driver.FindElement(By.XPath("//input[@id='userEmail']"));
            emailField.SendKeys("email123@gmail.com");
            Thread.Sleep(1000);

            Thread.Sleep(1000);
            IWebElement genderRadio = driver.FindElement(By.XPath("//label[text()='Male']"));
            genderRadio.Click();
            Thread.Sleep(1000);

            Thread.Sleep(1000);
            IWebElement dobField = driver.FindElement(By.Id("dateOfBirthInput"));
            dobField.Click();
            Thread.Sleep(1000);

            Thread.Sleep(1000);
            IWebElement dobMonthField = driver.FindElement(By.ClassName("react-datepicker__month-select"));
            SelectElement selectMonth = new SelectElement(dobMonthField);
            selectMonth.SelectByIndex(5);
            Thread.Sleep(1000);

            Thread.Sleep(1000);
            IWebElement dobYearField = driver.FindElement(By.ClassName("react-datepicker__year-select"));
            SelectElement selectYear= new SelectElement(dobYearField);
            selectYear.SelectByText("2000");
            Thread.Sleep(1000);

            Thread.Sleep(1000);
            IWebElement dobDayField = driver.FindElement(By.XPath("//div[text()='6']"));
            dobDayField.Click();
            Thread.Sleep(1000);

            Thread.Sleep(1000);
            IWebElement subjectField = driver.FindElement(By.Id("subjectsInput"));
            subjectField.SendKeys("Maths");
            subjectField.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            subjectField.SendKeys("Chemistry");
            subjectField.SendKeys(Keys.Enter);
            Thread.Sleep(1000);

            Thread.Sleep(1000);
            IWebElement hobbiesCheckBoxField = driver.FindElement(By.XPath("//label[text()='Sports']"));
            hobbiesCheckBoxField.Click();
            Thread.Sleep(1000);

            Thread.Sleep(1000);
            IWebElement uploadPictureField = driver.FindElement(By.Id("uploadPicture"));
            uploadPictureField.SendKeys("@C:\\Users\\Administrator\\Pictures\\CameraRoll.png");
            Thread.Sleep(1000);

            Thread.Sleep(1000);
            IWebElement currentAddressField = driver.FindElement(By.Id("currentAddress"));
            currentAddressField.SendKeys("123 street,city , Country");
            Thread.Sleep(1000);

            Thread.Sleep(1000);
            IWebElement submitButtonField = driver.FindElement(By.Id("submit"));
            submitButtonField.Click();
           
        }
        [Ignore("other")]
        [Test]
        public void TestWindows()
        {
            driver.Url = "https://demoqa.com/browser-windows";

            string parentWindowHandle = driver.CurrentWindowHandle;
            Console.WriteLine("Parent window's handle->"+parentWindowHandle) ;

            IWebElement clickElement = driver.FindElement(By.Id("tabButton"));
            for(int i= 0; i < 3; i++) { 
            clickElement.Click();
                Thread.Sleep(1000);
            }
            List<string> lsWindow=driver.WindowHandles.ToList();
            String lastWindowHandle = "";
            foreach(var handle in lsWindow) {

                Console.WriteLine("Swithing to window->"+handle);
                driver.SwitchTo().Window(handle);
                Thread.Sleep(1000);
                Console.WriteLine("Navigate to google.com" );
                driver.Navigate().GoToUrl("https://google.com");
                Thread.Sleep(1000);

            }
            driver.SwitchTo().Window(parentWindowHandle);
            driver.Quit();

        }
        [Test]
        public void TestAlerts() 
        
        {
            driver.Url = "https://demoqa.com/alerts";

            IWebElement element = driver.FindElement(By.Id("alertButton"));
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);

            IAlert simpleAlert = driver.SwitchTo().Alert();
            Console.WriteLine("Alert text is"+simpleAlert.Text);
            simpleAlert.Accept();
            Thread.Sleep(1000);

            element = driver.FindElement(By.Id("confirmButton"));
            Thread.Sleep(1000);
            element.Click();
            IAlert confirmationAlert = driver.SwitchTo().Alert();
            string alertText = confirmationAlert.Text;
            Console.WriteLine("Alert text is" + alertText); 
            confirmationAlert.Dismiss();

            element = driver.FindElement(By.Id("promtButton"));
            element.Click() ;
            Thread.Sleep(1000);
            IAlert promtAlert = driver.SwitchTo().Alert();
            alertText = promtAlert.Text;
            Console.WriteLine("Alert text is"+alertText );
            promtAlert.SendKeys("Accepting the alert");
            Thread.Sleep(1000);
            promtAlert.Accept();

        }


    }
}
