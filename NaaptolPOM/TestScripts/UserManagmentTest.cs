using NaaptolPOM.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaaptolPOM.TestScripts
{
    internal class UserManagmentTest:CoreCodes
    {
        [Test]
        public void SearchBoxTest()
        {
            var homepage = new NaaptolHomePage(driver);
            var eyewearpage=new EyeWearPage(driver);
            homepage.SearchTextInSearchBox("eyewear");
            homepage.SearchTextInput();
            Thread.Sleep(5000);
            eyewearpage.ClickEyeWearElement();
            Thread.Sleep(5000);
        }
    }
}
