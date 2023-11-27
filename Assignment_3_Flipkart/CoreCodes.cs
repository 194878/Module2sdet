using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_Flipkart
{
    internal class CoreCodes
    {
        Dictionary<string, string>? properties;
        public IWebDriver driver;
        public bool CheckLinkStatus(string url)
        {
            try
            {
                var request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                request.Method = "HEAD";
                using (var response = request.GetResponse())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }
        public void ReadConfigSetting()
        {
            string currDir = Directory.GetParent(@"../../../").FullName;
            properties = new Dictionary<string, string>();
            string filename = currDir + "/cofigsettings/configuration.txt";
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains("="))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    properties[key] = value;
                }
            }
        }
        [OneTimeSetUp]
        public void InitializeBrowser()
        {
            ReadConfigSetting();
            
            
                if (properties["browser"].ToLower() == "chrome")
                {
                    driver = new ChromeDriver();
                }
                else if (properties["browser"].ToLower() == "edge")
                {
                    driver = new EdgeDriver();
                }
                driver.Url = properties["baseUrl"];
                driver.Manage().Window.Maximize();
            }
                [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
