// See https://aka.ms/new-console-template for more information

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

class Program
{
    static void Main()
    {
        var options = new ChromeOptions();
        using (var driver = new ChromeDriver(options))
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            System.Console.WriteLine("Google opened successfully!");
            driver.Quit();
        }
    }
}
