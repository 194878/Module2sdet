using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNunitExamples
{
    [TestFixture]
    internal class GoogleHPTests : CoreCodes
    {
        [Ignore("other")]
        [Test]
        [Order(1)]
        public void TitleTest()
        {
            Thread.Sleep(1000);
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine(" Title test - pass");
        }
        
        [Test]
        [Order(2)]
        public void GSTest()
        {
            string currDir = Directory.GetParent(@"../../../").FullName;
            string excelFilePath = currDir + "\\InputData.xlsx";
            Console.WriteLine(excelFilePath);

            List<ExcelData> excelDataList = ExcelUtils.ReadExcelData(excelFilePath);
            foreach (var exceldata in excelDataList)

            {
                Console.WriteLine($"Text: {exceldata.SearchText}");
                IWebElement searchinputtestbox = driver.FindElement(By.Id("APjFqb"));
                searchinputtestbox.SendKeys(exceldata.SearchText);
                Thread.Sleep(3000);
                IWebElement googlesearchbutton = driver.FindElement(By.ClassName("gNO89b"));   //    Name("btnK"));
                googlesearchbutton.Click();
                Assert.That(driver.Title, Is.EqualTo(exceldata.SearchText + " - Google Search"));
                Console.WriteLine("Google Search test-  pass");
               
            }
        }
        [Ignore("other")]
        [Test]
        [Order(3)]
        public void AllLinksStatusTest()
        {
            List<IWebElement> allLinks =driver.FindElements(By.TagName("a")).ToList();
            foreach (IWebElement link in allLinks)
            {
                string url=link.GetAttribute("href");
                if (url == null)
                {
                    Console.WriteLine("Url is null");
                    continue;
                }
                else
                {
                    bool isworking=CheckLinkStatus(url);
                    if (isworking)
                        Console.WriteLine(url + "is Working");
                    else
                        Console.WriteLine(url + "is NOT Working");

                }
            }
        }
    }
}
