using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace OrangeHRM_Project_Automation
{
    [TestClass]
    public class LeaveExec
    {
        LeavePage leavePage = new LeavePage();
        LoginPage loginPage = new LoginPage();

        [TestMethod]
        public void ApplyForLeave_TC001()
        {
            CorePage.SeleniumInit("Chrome");
            string url = "https://opensource-demo.orangehrmlive.com/";

            // Log in with valid credentials
            loginPage.Login(url, "Admin", "admin123");

            // Navigate to the Leave page
            leavePage.NavigateToLeavePage();

            // Ensure we're on the Leave page (you can assert an element on the Leave page)
            bool isLeavePageVisible = CorePage.driver.FindElement(By.XPath("//h6[text()='Leave']")).Displayed;
            Assert.IsTrue(isLeavePageVisible, "Failed to navigate to Leave page");

            //apply for leave
            leavePage.ApplyForLeave("CAN - FMLA", "2024-12-10", "2024-12-15", "Vacation request");

            bool isLeaveApplied = CorePage.driver.FindElement(By.XPath("//div[contains(text(),'Successfully Submitted')]")).Displayed;
            Assert.IsTrue(isLeaveApplied, "Leave application was not successful!");
           
        }

        [TestMethod]
        public void SearchLeaveRecords_TC002()
        {
            //CorePage.SeleniumInit("Chrome");

            //string url = "https://opensource-demo.orangehrmlive.com/";
            //loginPage.Login(url, "Admin", "admin123");

            //leavePage.NavigateToLeavePage();

            //leavePage.SearchLeaveRecords("John Doe");

            //bool isRecordFound = CorePage.driver.FindElement(By.XPath("//div[contains(text(),'John Doe')]")).Displayed;
            //Assert.IsTrue(isRecordFound, "Leave records not found!");

            //CorePage.driver.Quit();
        }
    }
}
