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
           // CorePage.SeleniumInit();

           // string url = "https://opensource-demo.orangehrmlive.com/";
           // loginPage.Login(url, "Admin", "admin123");

           // leavePage.NavigateToLeavePage();

           // leavePage.ApplyForLeave("Annual Leave", "2024-12-10", "2024-12-15", "Vacation request");

           //bool isLeaveApplied = CorePage.driver.FindElement(By.XPath("//div[contains(text(),'Successfully Submitted')]")).Displayed;
           //Assert.IsTrue(isLeaveApplied, "Leave application was not successful!");

           // CorePage.driver.Quit();
        }

        [TestMethod]
        public void SearchLeaveRecords_TC002()
        {
            //CorePage.SeleniumInit();

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
