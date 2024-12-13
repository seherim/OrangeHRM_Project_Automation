using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Threading.Tasks;

namespace OrangeHRM_Project_Automation
{
    [TestClass]
    public class ChangePassExec
    {
        LoginPage loginPage = new LoginPage();
        ChangePassPage changePassPage = new ChangePassPage();
        LogoutPage logoutPage = new LogoutPage();

        [TestMethod]
        public void ExecuteChangePasswordFlow()
        {
            string url = "https://opensource-demo.orangehrmlive.com/";
            string currentPassword = "admin123";
            string newPassword = "admin123";

            // Step 1: Login
            CorePage.SeleniumInit("Chrome");
            loginPage.Login(url, "Admin", currentPassword);

            // Step 2: Change Password
            changePassPage.ChangePassword(currentPassword, newPassword);

            // Step 3: Logout
            logoutPage.Logout();
            Assert.IsTrue(
                CorePage.driver.FindElement(By.XPath("//h5[text()='Login']")).Displayed,
                "Logout was not successful!"
            );

            // Step 4: Login with new password
            loginPage.Login(url, "Admin", newPassword);
            Assert.IsTrue(
                CorePage.driver.FindElement(By.XPath("//h6[text()='Dashboard']")).Displayed,
                "Login with new password failed!"
            );

            // Cleanup
            CorePage.driver.Quit();
        }
    }
}
