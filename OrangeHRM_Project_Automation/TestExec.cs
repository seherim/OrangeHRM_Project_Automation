using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//execution flow - login, PIM, Leave, Recruit, ChangePass, Logout
namespace OrangeHRM_Project_Automation
{
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

        /*[ClassInitialize()]
        public static void ClassInit(TestContext context)
        {

        }
        [ClassCleanup()]
        public static void ClassCleanup(TestContext context)
        {

        }*/
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
        LoginPage loginPage = new LoginPage();
        PIMPage pimPage = new PIMPage();
        LogoutPage logoutPage = new LogoutPage();

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "Login_Valid_TC001",DataAccessMethod.Sequential)]
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
        public void Login_Invalid_TC002()
        {
            string url = "https://opensource-demo.orangehrmlive.com/";
            string username = "Admins";
            string password = "admin!23";
            loginPage.Login(url, username, password);
            string dashboardHeader = CorePage.driver.FindElement(By.XPath("//p[text()='Invalid credentials']")).Text;
            Assert.AreEqual("Invalid credentials", dashboardHeader, "Login failed, Dashboard not found!");
        }

        [TestMethod]
        public void AddEmployee_TC001()
        {
            CorePage.SeleniumInit("Chrome");

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
            CorePage.SeleniumInit("Chrome");

            string url = "https://opensource-demo.orangehrmlive.com/";
            loginPage.Login(url, "Admin", "admin123");

            pimPage.NavigateToPIM();

            pimPage.SearchEmployee("John");

            bool isEmployeeFound = CorePage.driver.FindElement(By.XPath("//div[contains(text(),'john')]")).Displayed;
            Assert.IsTrue(isEmployeeFound, "Employee was not found!");

            CorePage.driver.Close();
        }

        [TestMethod]
        public void Logout_Valid_TC001()
        {
            CorePage.SeleniumInit("Chrome");

            string url = "https://opensource-demo.orangehrmlive.com/";
            loginPage.Login(url, "Admin", "admin123");

            Task.Delay(2000);

            logoutPage.Logout();

            bool isLogoutSuccessful = CorePage.driver.FindElement(By.XPath("//h5[text()='Login']")).Displayed;
            Assert.IsTrue(isLogoutSuccessful, "Logout was not successful!");

            CorePage.driver.Quit();
        }
    }
}
