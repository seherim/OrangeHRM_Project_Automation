using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace OrangeHRM_Project_Automation
{
    [TestClass]
    public class LoginExec
    {

        IWebDriver driver = new ChromeDriver();

        [TestMethod]
        public void Login_Valid_TC001()
        {
            string url = "https://opensource-demo.orangehrmlive.com/";
            string username = "Admin";
            string password = "admin123";
            Login(url, username, password);
            string dashboardHeader = driver.FindElement(By.XPath("//h6[text()='Dashboard']")).Text;
            Assert.AreEqual("Dashboard", dashboardHeader, "Login failed, Dashboard not found!");

            Task.Delay(1000);
            driver.Close();

        }

        [TestMethod]
        public void Login_Invalid_TC002()
        {
            string url = "https://opensource-demo.orangehrmlive.com/";
            string username = "Admins";
            string password = "admin!23";
            Login(url, username, password);
            string dashboardHeader = driver.FindElement(By.XPath("//p[text()='Invalid credentials']")).Text;
            Assert.AreEqual("Invalid credentials", dashboardHeader, "Login failed, Dashboard not found!");

            Task.Delay(1000);
            driver.Close();

        }

        public void Login(string url, string username, string password)
        {
            driver.Url = url;
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Name("username")).SendKeys(username);
            driver.FindElement(By.Name("password")).SendKeys(password);
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();            
        }
    }
}
