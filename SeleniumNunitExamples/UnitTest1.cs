using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumNunitExamples
{
    public class Tests
    {
        IWebDriver driver = new ChromeDriver();
        [SetUp]
        public void Setup()
        {
            driver.Url = "https://www.google.com";
        }

        [Test]
        public void CheckForTitle()
        {
            Thread.Sleep(2000);
            string title= driver.Title;
            Assert.AreEqual("Google", title);

           
        }
        [TearDown]
        public void Close() 
        {
            driver.Close();
        }
        }
}