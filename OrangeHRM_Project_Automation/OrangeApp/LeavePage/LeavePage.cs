using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
namespace OrangeHRM_Project_Automation
{
    class LeavePage : CorePage
    {
        public void NavigateToLeavePage()
        {
            // Create a WebDriverWait instance
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Wait for the Leave element to be clickable
            IWebElement leaveButton = wait.Until(driver =>
            {
                return driver.FindElement(By.XPath("//span[text()='Leave']"));
            });

            // Click on the Leave button
            leaveButton.Click();
            //driver.FindElement(By.XPath("//span[text()='Leave']")).Click();
        }


        public void ApplyForLeave(string leaveType, string fromDate, string toDate, string comments)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Console.WriteLine("Clicking Apply button...");
            IWebElement applyButton = wait.Until(driver => driver.FindElement(By.XPath("//a[text()='Apply']")));
            applyButton.Click();

            Console.WriteLine("Selecting Leave Type...");
            IWebElement leaveTypeDropdown = wait.Until(driver =>driver.FindElement(By.XPath("//div[text()='-- Select --']")));
            leaveTypeDropdown.Click();

            IWebElement leaveTypeOption = wait.Until(driver => driver.FindElement(By.XPath($"//span[text()='{leaveType}']")));
            leaveTypeOption.Click();

            Console.WriteLine("Setting From Date...");
            var fromDateInput = driver.FindElement(By.XPath("//label[text()='From Date']/following-sibling::div//input"));
            fromDateInput.SendKeys(Keys.Control + "a");
            fromDateInput.SendKeys(Keys.Delete);
            fromDateInput.SendKeys(fromDate);

            Console.WriteLine("Setting To Date...");
            var toDateInput = driver.FindElement(By.XPath("//label[text()='To Date']/following-sibling::div//input"));
            toDateInput.SendKeys(Keys.Control + "a");
            toDateInput.SendKeys(Keys.Delete);
            toDateInput.SendKeys(toDate);

            Console.WriteLine("Entering Comments...");
            driver.FindElement(By.XPath("//textarea[@placeholder='Type your comment here']")).SendKeys(comments);

            Console.WriteLine("Submitting Leave Application...");
            driver.FindElement(By.XPath("//button[contains(text(),'Submit')]")).Click();

            //driver.FindElement(By.XPath("a[contains(text(),'Apply')]")).Click();
            //driver.FindElement(By.XPath("//a[text()='Apply']")).Click();


            //driver.FindElement(By.XPath("//label[text()='Leave Type']/following-sibling::div//input")).Click();
            //driver.FindElement(By.XPath($"//span[text()='{leaveType}']")).Click();


            //driver.FindElement(By.XPath("//label[text()='From Date']/following-sibling::div//input")).SendKeys(fromDate);


            //driver.FindElement(By.XPath("//label[text()='To Date']/following-sibling::div//input")).SendKeys(toDate);


            //driver.FindElement(By.XPath("//textarea[@placeholder='Type your comment here']")).SendKeys(comments);

            //driver.FindElement(By.XPath("//button[text()='Submit']")).Click();
        }


        public void SearchLeaveRecords(string employeeName)
        {

        //    driver.FindElement(By.XPath("//a[text()='Leave List']")).Click();

        //    driver.FindElement(By.XPath("//input[@placeholder='Type for hints...']")).SendKeys(employeeName);

        //    driver.FindElement(By.XPath("//button[text()=' Search ']")).Click();
        }

        public void ApproveOrRejectLeave(string employeeName, string action)
        {

            //driver.FindElement(By.XPath("//a[text()='Leave List']")).Click();

            //driver.FindElement(By.XPath("//input[@placeholder='Type for hints...']")).SendKeys(employeeName);
            //driver.FindElement(By.XPath("//button[text()=' Search ']")).Click();

            //if (action.Equals("Approve", System.StringComparison.OrdinalIgnoreCase))
            //{
            //    driver.FindElement(By.XPath("//button[text()=' Approve ']")).Click();
            //}
            //else if (action.Equals("Reject", System.StringComparison.OrdinalIgnoreCase))
            //{
            //    driver.FindElement(By.XPath("//button[text()=' Reject ']")).Click();
            //}
        }
    }
}
