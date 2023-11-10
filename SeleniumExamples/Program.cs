
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

IWebDriver driver = new ChromeDriver();

    driver.Url = "https://www.google.com";
    Thread.Sleep(1000);
    string title = driver.Title;
try
{
    Assert.AreEqual("Gooogle", title);
    Console.WriteLine("test pass");
}

catch(AssertionException)
{
    Console.WriteLine("test failed");
}
driver.Close();