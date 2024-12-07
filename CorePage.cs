using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OrangeHRM_Project_Automation
{
    class CorePage
    {
        // Mark driver as nullable
        public static IWebDriver? driver;

        public static IWebDriver SeleniumInit()
        {
            // Initialize the driver if it's null
            if (driver == null)
            {
                driver = new ChromeDriver();
            }
            return driver;
        }
    }
}
