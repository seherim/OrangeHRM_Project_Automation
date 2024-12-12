using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;
using System.Configuration;

namespace OrangeHRM_Project_Automation
{
    class CorePage
    {
        public static IWebDriver driver;

        public static IWebDriver SeleniumInit(string browser)
        {
            bool isHeadless = bool.Parse(ConfigurationManager.AppSettings["Headless"]);

            
            if (browser == "Chrome")
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments("--start-maximized");
                chromeOptions.AddArguments("--incognito");
                IWebDriver chromeDriver = new ChromeDriver();
                driver = chromeDriver;
                if (isHeadless)
                {
                    chromeOptions.AddArgument("--headless");
                    chromeOptions.AddArgument("--disable-gpu");
                }
            }
            else if (browser == "FireFox")
            {
                FirefoxOptions options = new FirefoxOptions();
                options.AddArguments("--start-maximized");
                options.AddArguments("--incognito");
                IWebDriver firefoxDriver = new FirefoxDriver(options);
                driver = firefoxDriver;
            }
            else if (browser == "MicrosoftEdge")
            {
                var options = new EdgeOptions();
                var service = EdgeDriverService.CreateDefaultService(@"C: \Users\seher\source\repos\OrangeHRM_Project_Automation\OrangeHRM_Project_Automation\bin\Debug", @"C:\Program Files(x86)\Microsoft\Edge\Application\msedge.exe");
                service.Start();
                IWebDriver edgeDriver = new RemoteWebDriver(service.ServiceUrl, options);
                driver = edgeDriver;
            }
            return driver;
        }
    }
}
