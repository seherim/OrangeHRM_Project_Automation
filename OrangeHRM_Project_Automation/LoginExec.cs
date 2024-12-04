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
        LoginPage loginPage = new LoginPage();

        [TestMethod]
        public void Login_Valid_TC001()
        {
            CorePage.SeleniumInit();
            string url = "https://opensource-demo.orangehrmlive.com/";
            string username = "Admin";
            string password = "admin123";
            loginPage.Login(url, username, password);
            string dashboardHeader = CorePage.driver.FindElement(By.XPath("//h6[text()='Dashboard']")).Text;
            Assert.AreEqual("Dashboard", dashboardHeader, "Login failed, Dashboard not found!");

            Task.Delay(1000);
            CorePage.driver.Close();

        }

        [TestMethod]
        public void Login_Invalid_TC002()
        {
            CorePage.SeleniumInit();
            string url = "https://opensource-demo.orangehrmlive.com/";
            string username = "Admins";
            string password = "admin!23";
            loginPage.Login(url, username, password);
            string dashboardHeader = CorePage.driver.FindElement(By.XPath("//p[text()='Invalid credentials']")).Text;
            Assert.AreEqual("Invalid credentials", dashboardHeader, "Login failed, Dashboard not found!");
            CorePage.driver.Close();

        }



    }
}
