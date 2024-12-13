using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//execution flow - login, PIM, Leave, ChangePass, Logout
namespace OrangeHRM_Project_Automation
{
    //[AllureNUnit]
    [TestClass]
    public class TestExec
    {
        #region Setups and Cleanups 

        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        [TestInitialize()]
        public void TestInit()
        {
            CorePage.SeleniumInit(ConfigurationManager.AppSettings["Browser"].ToString());
        }
        [TestCleanup]
        public void TestCleanup()
        {
            Task.Delay(1000);
            CorePage.driver.Close();
        }
        #endregion

        #region Locators 
        #endregion
        LoginPage loginPage = new LoginPage();
        PIMPage pimPage = new PIMPage();
        LeavePage leavePage = new LeavePage();
        ChangePassPage changePassPage = new ChangePassPage();
        LogoutPage logoutPage = new LogoutPage();

        [TestMethod]
        [TestCategory("LoginOrange")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "Login_Valid_TC001",DataAccessMethod.Sequential)]
        //[AllureStep]
        public void Login_Valid_TC001()
        {
            string url = TestContext.DataRow["url"].ToString();
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string message = TestContext.DataRow["message"].ToString();
            loginPage.Login(url, username, password);
            string dashboardHeader = CorePage.driver.FindElement(By.XPath("//h6[text()='Dashboard']")).Text;
            Assert.AreEqual(message, dashboardHeader, "Login failed, Dashboard not found!");


        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "Login_Invalid_TC002", DataAccessMethod.Sequential)]
        public void Login_Invalid_TC002()
        {
            string url = TestContext.DataRow["url"].ToString();
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string message = TestContext.DataRow["message"].ToString();
            loginPage.Login(url, username, password);
            string dashboardHeader = CorePage.driver.FindElement(By.XPath("//p[text()='Invalid credentials']")).Text;
            Assert.AreEqual(message, dashboardHeader, "Login failed, Dashboard not found!");
        }

        [TestMethod]
        //[AllureStep]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddEmployee_TC001", DataAccessMethod.Sequential)]
        public void AddEmployee_TC001()
        {

            string url = "https://opensource-demo.orangehrmlive.com/";
            loginPage.Login(url, "Admin", "admin123");
            string firstName = TestContext.DataRow["firstName"].ToString();
            string lastName = TestContext.DataRow["lastName"].ToString();

            pimPage.NavigateToPIM();

            pimPage.AddEmployee(firstName, lastName);

            // bool isEmployeeAdded = CorePage.driver.FindElement(By.XPath("//div[contains(text(),'Successfully Saved')]")).Displayed;
            // Assert.IsTrue(isEmployeeAdded, "Employee was not added successfully!");

        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "SearchEmployee_TC001", DataAccessMethod.Sequential)]

        public void SearchEmployee_TC002()
        {

            string url = "https://opensource-demo.orangehrmlive.com/";
            loginPage.Login(url, "Admin", "admin123");
            string firstName = TestContext.DataRow["firstName"].ToString();
            pimPage.NavigateToPIM();

            pimPage.SearchEmployee("John");

            bool isEmployeeFound = CorePage.driver.FindElement(By.XPath("//div[contains(text(),'john')]")).Displayed;
            Assert.IsTrue(isEmployeeFound, "Employee was not found!");

        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "ApplyForLeave_TC001", DataAccessMethod.Sequential)]
        public void ApplyForLeave_TC001()
        {
            string url = "https://opensource-demo.orangehrmlive.com/";
            string fromDate = TestContext.DataRow["fromDate"].ToString();
            string toDate = TestContext.DataRow["toDate"].ToString();
            string comments = TestContext.DataRow["comments"].ToString();
            string message = TestContext.DataRow["message"].ToString();
            string leaveType = TestContext.DataRow["leaveType"].ToString();

            // Log in with valid credentials
            loginPage.Login(url, "Admin", "admin123");

            // Navigate to the Leave page
            leavePage.NavigateToLeavePage();

            // Ensure we're on the Leave page (you can assert an element on the Leave page)
            bool isLeavePageVisible = CorePage.driver.FindElement(By.XPath("//h6[text()='Leave']")).Displayed;
            Assert.IsTrue(isLeavePageVisible, "Failed to navigate to Leave page");

            //apply for leave
            leavePage.ApplyForLeave(leaveType, fromDate, toDate, comments);

            //bool isLeaveApplied = CorePage.driver.FindElement(By.XPath("//div[contains(text(),Successfully Submitted)]")).Displayed;
            //Assert.AreEqual(message, isLeaveApplied, "Leave application was not successful!");

        }

        [TestMethod]
        public void Logout_Valid_TC001()
        {
            string url = "https://opensource-demo.orangehrmlive.com/";
            loginPage.Login(url, "Admin", "admin123");

            Task.Delay(2000);

            logoutPage.Logout();

            bool isLogoutSuccessful = CorePage.driver.FindElement(By.XPath("//h5[text()='Login']")).Displayed;
            Assert.IsTrue(isLogoutSuccessful, "Logout was not successful!");

        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "SequentialExecution", DataAccessMethod.Sequential)]
        public void ExecuteLoginPIMLeaveLogout()
        {
            string url = TestContext.DataRow["url"].ToString();
            string username = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string firstName = TestContext.DataRow["firstName"].ToString();
            string lastName = TestContext.DataRow["lastName"].ToString();
            string leaveType = TestContext.DataRow["leaveType"].ToString();
            string fromDate = TestContext.DataRow["fromDate"].ToString();
            string toDate = TestContext.DataRow["toDate"].ToString();
            string comments = TestContext.DataRow["comments"].ToString();
            string currentPassword = TestContext.DataRow["currentPassword"].ToString();
            string newPassword = TestContext.DataRow["newPassword"].ToString();
            // Step 1: Login
            loginPage.Login(url, username, password);

            // Verify login success
            Assert.IsTrue(
                CorePage.driver.FindElement(By.XPath("//h6[text()='Dashboard']")).Displayed,
                "Login failed, Dashboard not found!"
            );

            // Step 2: Navigate to PIM and Add Employee
            pimPage.NavigateToPIM();
            pimPage.AddEmployee(firstName, lastName);

            // Step 3: Navigate to Leave and Apply for Leave
            leavePage.NavigateToLeavePage();
            leavePage.ApplyForLeave(leaveType, fromDate, toDate, comments);

            // Step 4: Change Password
            changePassPage.ChangePassword(currentPassword, newPassword);

            // Step 5: Logout
            logoutPage.Logout();

            // Verify logout success
            Assert.IsTrue(
                CorePage.driver.FindElement(By.XPath("//h5[text()='Login']")).Displayed,
                "Logout was not successful!"
            );
        }

        [TestMethod]
        public void ExecuteChangePasswordFlow()
        {
            string url = "https://opensource-demo.orangehrmlive.com/";
            string currentPassword = "admin123";
            string newPassword = "admin123";

            // Step 1: Login
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
            
        }

    }
}
