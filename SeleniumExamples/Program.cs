
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExamples;

List<string> drivers = new List<string>();
drivers.Add("Edge");
drivers.Add("Chrome");
foreach (var d in drivers)
{
    AmazonTest az= new AmazonTest();    
    switch (d)
    {
        case "Edge":
            az.InitializeEdgeDriver();
            break;
        case "Chrome":
            az.InitializeChromeDriver();
            break;


    }
    try
    {
        //az.TitleTest();
        //Thread.Sleep(7000);
        //az.LogoClickTest();
        //az.SearchProductTest();
        //az.ReloadHomePage();
        //az.ClickTodaysDealsTest();
        //az.SignInAccountListTest();
        az.SearchAndFilterProductByBrand();
        az.SortBySelectTest();


    }
    catch (AssertionException)
    {
        Console.WriteLine("fail");

    }
    catch (NoSuchElementException nse)
    {
        Console.WriteLine(nse.Message);
    }
    az.Destruct();
}



/*

GHPTests gHPTests = new GHPTests();
List<string> drivers = new List<string>();
drivers.Add("Edge");
drivers.Add("Chrome");



Console.WriteLine("1.Edge   2.Chrome");

 int ch= Convert.ToInt32( Console.ReadLine());
switch (ch) {
    case 1:
        gHPTests.InitializeEdgeDriver(); 
        break;
        case 2:
        gHPTests.InitializeChromeDriver();
        break;


} 


//GHPTests gHPTests = new GHPTests();
//drivers.Add("Edge");
//drivers.Add("Chrome");
/*
foreach (var d in drivers)
{
    switch (d)
    {
        case "Edge":
            gHPTests.InitializeEdgeDriver();
            break;
        case "Chrome":
            gHPTests.InitializeChromeDriver();
            break;


    }

}*/
/*
    try
    {
       // gHPTests.TitleTest();
       // gHPTests.PageSourceandURLTest();
       // gHPTests.GSTest();
        //gHPTests.GmailLinkTest();
       // gHPTests.ImageLinkTest();
       // gHPTests.LocalizationTest();
        gHPTests.GAppYoutubeTest();

    }

    catch (AssertionException)
    {
        Console.WriteLine("Title test- failed");
    }

    gHPTests.Destruct();
*/