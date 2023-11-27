using BunnyCart.PageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.TestScripts
{
    internal class SearchTest:CoreCodes
    {
        [Test]
        [TestCase("Water")]
        public void SearchProductAndAddToCartTest(string searchtext)
        {
            BunnyCartHomePage bchp = new(driver);
            var searchrespage = bchp?.TypeSearchInput(searchtext);
            Assert.That(searchtext.Contains(searchrespage.GetFirstProductLink()));
            var productpage =searchrespage?.ClickFirstProductLink();
            Assert.That(searchtext.Equals(productpage?.GetProductTitleLabel()));
            productpage?.ClickIncQtyLink();
            productpage?.AddToCartBtnClick();
        }
    }
}
