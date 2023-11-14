using Assignment_testing1;
using NUnit.Framework;

AmazonTesting am=new AmazonTesting();
am.ChromeInitialize();
try {
    am.TitleTest();
    Console.WriteLine(" Title test - pass");
    am.UrlTest();
    Console.WriteLine(" Url test - pass");
}
catch (AssertionException)
{
    Console.WriteLine("Title test- failed");
}
am.Destruct();
