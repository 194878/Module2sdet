using BunnyCart.PageObject;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.TestScripts
{



    internal class BunnyCartTest : CoreCodes
    {
        [Test,Order(1)]
       
        public void SignUpTest()
        {
            string currDir = Directory.GetParent(@"../../../").FullName;
            string logfilepath = currDir + "/Logs/log_"+DateTime.Now.ToString("yyyyMMdd_HHmmss")+".txt";

            Log.Logger=new LoggerConfiguration()
                .WriteTo.Console().
                WriteTo.File(logfilepath, rollingInterval );
            BunnyCartHomePage bchp = new(driver);
            bchp.ClickCreateAnAccountLink();
            Thread.Sleep(2000);
            try
            {
                Assert.That(driver.FindElement(By.XPath("//div[@class='modal-inner-wrap']//following::h1[2]")).Text,
                    Is.EqualTo("Create an Account"));
            }
            catch (AssertionException) {
                Console.WriteLine("Create Acc modal not present");
            }
            bchp.SignUp("John", "Doe", "jon.doew@example.com", "12345", "12345", "9995570118");
        }

    }
  
}
