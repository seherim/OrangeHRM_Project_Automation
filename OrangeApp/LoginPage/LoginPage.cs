using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace OrangeHRM_Project_Automation
{
    class LoginPage : CorePage
    {
        #region Locators
        By usernametxt = By.Name("username");
        By passwdtxt = By.Name("password");
        By loginbtn = By.XPath("//button[@type='submit']");
        #endregion

 public void Login(string url, string username, string password)
{
    try
    {
        // Navigate to the URL and maximize the window
        Console.WriteLine("Navigating to URL...");
        driver.Navigate().GoToUrl(url);
        driver.Manage().Window.Maximize();

        // Use WebDriverWait for page elements to be ready
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        
        // Wait for username field to be present before interacting
        wait.Until(d => d.FindElement(usernametxt)).SendKeys(username);
        wait.Until(d => d.FindElement(passwdtxt)).SendKeys(password);

        // Click login button and wait for the Dashboard header to appear
        Console.WriteLine("Clicking login button...");
        IWebElement loginButton = wait.Until(d => d.FindElement(loginbtn));
        loginButton.Click();

        // Log the click event
        Console.WriteLine("Login button was clicked!");

        // Wait for the Dashboard page to load
        wait.Until(d => d.FindElement(By.XPath("//h6[text()='Dashboard']")));
        Console.WriteLine("Login successful! Dashboard should be visible.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

    }
}



// using OpenQA.Selenium;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

// namespace OrangeHRM_Project_Automation
// {
//     class LoginPage : CorePage
//     {
//         #region Locators
//         By usernametxt = By.Name("username");
//         By passwdtxt = By.Name("password");
//         By loginbtn = By.XPath("//button[@type='submit']");
//         #endregion

//         public void Login(string url, string username, string password)
//         {
//             driver.Url = url;
//             driver.Manage().Window.Maximize();
//             driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
//             driver.FindElement(usernametxt).SendKeys(username);
//             driver.FindElement(passwdtxt).SendKeys(password);
//             driver.FindElement(loginbtn).Click();
//         }
//     }
// }
