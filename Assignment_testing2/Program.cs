﻿using Assignment_testing2;
using NUnit.Framework;

BrowserSwitching browserSwitching = new BrowserSwitching();
browserSwitching.ChromeInitialize();
try {
    browserSwitching.GoogleSearchFind();
    Console.WriteLine("Google Search Test - Passed");
    browserSwitching.GoSwitch();
    browserSwitching.YahooSearch();
    Console.WriteLine("Yahoo Search Test - Passed");
    browserSwitching.GoSwitch();
    browserSwitching.GoogleSearchFind();
    Console.WriteLine("Google Search Test - Passed");
    browserSwitching.GoSwitch();
    browserSwitching.YahooSearch();
    Console.WriteLine("Yahoo Search Test - Passed");
    browserSwitching.GoSwitch();
<<<<<<< HEAD
    browserSwitching.GoogleSearchFind();
    Console.WriteLine("Google Search Test - Passed");
=======
     browserSwitching.GoogleSearchFind();
 Console.WriteLine("Google Search Test - Passed");
>>>>>>> dd1acb76f8f32278a2368e71a15cc08e95fa4504
    browserSwitching.DiwaliSearch();
    Console.WriteLine("Diwali test - passed");
    browserSwitching.RefreshTest();
    Console.WriteLine("Refresh test - passed");



}
catch (AssertionException)
{
    Console.WriteLine("Title test- failed");
}
browserSwitching.Destruct();
