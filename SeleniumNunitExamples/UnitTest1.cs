using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumNunitExamples
{
   class UnitTest1:CoreCodes
    {
       IWebDriver driver = new ChromeDriver();
     
        [Test]
       public void CheckForTitle()
        {
            Thread.Sleep(2000);
            string title= driver.Title;
            Assert.AreEqual("Google", title);

           
        }
      
        public void Close() 
        {
            driver.Close();
        }
        }
}