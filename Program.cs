using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace OrangeHRM_Project_Automation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize WebDriver through CorePage
            IWebDriver driver = CorePage.SeleniumInit();

            // Run the tests
            RunTests(driver);
            
            // Quit the driver after the task
            driver.Quit();
        }

        static void RunTests(IWebDriver driver)
        {
            // Create an instance of LoginExec
            LoginExec loginExec = new LoginExec();

            // Run Valid login test
            Console.WriteLine("Running Valid Login Test...");
            try
            {
                loginExec.Login_Valid_TC001();
                Console.WriteLine("Valid Login Test passed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Valid Login Test failed: {ex.Message}");
            }

            // Run Invalid login test
            Console.WriteLine("Running Invalid Login Test...");
            try
            {
                loginExec.Login_Invalid_TC002();
                Console.WriteLine("Invalid Login Test passed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid Login Test failed: {ex.Message}");
            }
        }
    }
}
