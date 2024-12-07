using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            driver.Url = url;
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(usernametxt).SendKeys(username);
            driver.FindElement(passwdtxt).SendKeys(password);
            driver.FindElement(loginbtn).Click();
        }
    }
}
