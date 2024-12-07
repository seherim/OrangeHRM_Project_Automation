using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace OrangeHRM_Project_Automation
{
    [TestClass]
    public class LoginExec
    {

        
        // Instantiate LoginPage class
        LoginPage loginPage = new LoginPage();
        
        [TestMethod]
public void Login_Valid_TC001()
{
    // Initialize WebDriver
    IWebDriver driver = CorePage.SeleniumInit();
    
    // Define the URL, username, and password
    string url = "https://opensource-demo.orangehrmlive.com/";
    string username = "Admin";
    string password = "admin123";

    try
    {
        // Attempt to log in with valid credentials
        loginPage.Login(url, username, password);

        // Verify that the Dashboard page is displayed after login
        string dashboardHeader = driver.FindElement(By.XPath("//h6[text()='Dashboard']")).Text;
        Assert.AreEqual("Dashboard", dashboardHeader, "Login failed, Dashboard not found!");
    }
    catch (Exception ex)
    {
        Assert.Fail($"Test failed with exception: {ex.Message}");
    }
    finally
    {
        // Allow time for the result to be observed before closing the browser
        Thread.Sleep(1000);
        driver.Quit(); // Close the browser after the test
    }
}

        // [TestMethod]
        // public void Login_Valid_TC001()
        // {
        //     // Initialize WebDriver
        //     IWebDriver driver = CorePage.SeleniumInit();

        //     // Define the URL, username, and password
        //     string url = "https://opensource-demo.orangehrmlive.com/";
        //     string username = "Admin";
        //     string password = "admin123";

        //     try
        //     {
        //         // Attempt to log in with valid credentials
        //         loginPage.Login(url, username, password);

        //         // Verify that the Dashboard page is displayed after login
        //         string dashboardHeader = driver.FindElement(By.XPath("//h6[text()='Dashboard']")).Text;
        //         Assert.AreEqual("Dashboard", dashboardHeader, "Login failed, Dashboard not found!");
        //     }
        //     catch (Exception ex)
        //     {
        //         Assert.Fail($"Test failed with exception: {ex.Message}");
        //     }
        //     finally
        //     {
        //         // Allow time for the result to be observed before closing the browser
        //         Thread.Sleep(1000);
        //         driver.Quit(); // Close the browser after the test
        //     }
        // }

        [TestMethod]
        public void Login_Invalid_TC002()
        {
            // Initialize WebDriver
            IWebDriver driver = CorePage.SeleniumInit();

            // Define the URL, invalid username, and password
            string url = "https://opensource-demo.orangehrmlive.com/";
            string username = "Admins";
            string password = "admin!23";

            try
            {
                // Attempt to log in with invalid credentials
                loginPage.Login(url, username, password);

                // Verify that the error message for invalid credentials is displayed
                string errorMessage = driver.FindElement(By.XPath("//p[text()='Invalid credentials']")).Text;
                Assert.AreEqual("Invalid credentials", errorMessage, "Login failed, error message not found!");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test failed with exception: {ex.Message}");
            }
            finally
            {
                // Allow time for the result to be observed before closing the browser
                Thread.Sleep(1000);
                driver.Quit(); // Close the browser after the test
            }
        }
    }
}


// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using OpenQA.Selenium;
// using OpenQA.Selenium.Chrome;
// using System;
// using System.Threading.Tasks;

// namespace OrangeHRM_Project_Automation
// {
//     [TestClass]
//     public class LoginExec
//     {
//         private LoginPage loginPage = new LoginPage();

//         [TestMethod]
//         public void Login_Valid_TC001()
//         {
//             // Initialize WebDriver from CorePage
//             IWebDriver driver = CorePage.SeleniumInit();
            
//             // Test data
//             string url = "https://opensource-demo.orangehrmlive.com/";
//             string username = "Admin";
//             string password = "admin123";
            
//             // Perform login
//             loginPage.Login(url, username, password);
            
//             // Validate login by checking for dashboard header
//             string dashboardHeader = driver.FindElement(By.XPath("//h6[text()='Dashboard']")).Text;
//             Assert.AreEqual("Dashboard", dashboardHeader, "Login failed, Dashboard not found!");

//             // Wait for a bit (optional)
//             Task.Delay(1000);
            
//             // Close the browser after the test
//             CorePage.Cleanup();
//         }

//         [TestMethod]
//         public void Login_Invalid_TC002()
//         {
//             // Initialize WebDriver from CorePage
//             IWebDriver driver = CorePage.SeleniumInit();

//             // Test data
//             string url = "https://opensource-demo.orangehrmlive.com/";
//             string username = "Admins";
//             string password = "admin!23";

//             // Perform login
//             loginPage.Login(url, username, password);

//             // Validate invalid login by checking for error message
//             string errorMessage = driver.FindElement(By.XPath("//p[text()='Invalid credentials']")).Text;
//             Assert.AreEqual("Invalid credentials", errorMessage, "Login failed, Error message not found!");

//             // Close the browser after the test
//             CorePage.Cleanup();
//         }
//     }
// }
