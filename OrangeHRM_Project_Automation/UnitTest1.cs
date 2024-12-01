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
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://opensource-demo.orangehrmlive.com/";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.Name("username")).SendKeys("Admin");
            driver.FindElement(By.Name("password")).SendKeys("admin123");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            string dashboardHeader = driver.FindElement(By.XPath("//h6[text()='Dashboard']")).Text;
            Assert.AreEqual("Dashboard", dashboardHeader, "Login failed, Dashboard not found!");

            Task.Delay(1000);
            driver.Close();

        }
    }
}
