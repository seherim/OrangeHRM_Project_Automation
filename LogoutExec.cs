using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM_Project_Automation
{
    [TestClass]
    public class LogoutExec
    {
        LoginPage loginPage = new LoginPage();
        LogoutPage logoutPage = new LogoutPage();

        [TestMethod]
        public void Logout_Valid_TC001()
        {
            CorePage.SeleniumInit();

            string url = "https://opensource-demo.orangehrmlive.com/";
            loginPage.Login(url, "Admin", "admin123");

            logoutPage.Logout();

            bool isLogoutSuccessful = CorePage.driver.FindElement(By.XPath("//h5[text()='Login']")).Displayed;
            Assert.IsTrue(isLogoutSuccessful, "Logout was not successful!");

            CorePage.driver.Quit();
        }
    }
}
