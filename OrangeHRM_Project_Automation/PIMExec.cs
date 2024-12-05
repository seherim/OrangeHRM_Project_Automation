using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace OrangeHRM_Project_Automation
{
    [TestClass]
    public class PIMExec
    {
        PIMPage pimPage = new PIMPage();
        LoginPage loginPage = new LoginPage();

        [TestMethod]
        public void AddEmployee_TC001()
        {
            CorePage.SeleniumInit();

            string url = "https://opensource-demo.orangehrmlive.com/";
            loginPage.Login(url, "Admin", "admin123");

            pimPage.NavigateToPIM();

            pimPage.AddEmployee("John", "Doe");

           // bool isEmployeeAdded = CorePage.driver.FindElement(By.XPath("//div[contains(text(),'Successfully Saved')]")).Displayed;
           // Assert.IsTrue(isEmployeeAdded, "Employee was not added successfully!");

            CorePage.driver.Close();
        }

        [TestMethod]
        public void SearchEmployee_TC002()
        {
            CorePage.SeleniumInit();

            string url = "https://opensource-demo.orangehrmlive.com/";
            loginPage.Login(url, "Admin", "admin123");

            pimPage.NavigateToPIM();

            pimPage.SearchEmployee("John");

            bool isEmployeeFound = CorePage.driver.FindElement(By.XPath("//div[contains(text(),'john')]")).Displayed;
            Assert.IsTrue(isEmployeeFound, "Employee was not found!");

            CorePage.driver.Close();
        }
    }
}
