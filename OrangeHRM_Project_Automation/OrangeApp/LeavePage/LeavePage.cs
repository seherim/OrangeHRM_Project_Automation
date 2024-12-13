using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading.Tasks;

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

            IWebElement leaveTypeOption = wait.Until(driver => driver.FindElement(By.XPath("//span[text()='CAN - FMLA']")));
            leaveTypeOption.Click();

            Console.WriteLine("Setting From Date...");

            // Wait for the From Date input field to be visible
            IWebElement fromDateInput = wait.Until(driver => 
                driver.FindElement(By.XPath("//label[contains(text(),'From Date')]/parent::div/following-sibling::div//input"))
            );
            fromDateInput.Click();
            // Clear the field and set the date
            Task.Delay(1000);
            fromDateInput.Clear();
            fromDateInput.SendKeys(fromDate); // Replace 'fromDate' with the actual date value
            fromDateInput.SendKeys(Keys.Enter); // Optional: to confirm the input
            
            // Wait for the To Date input field to be visible
            IWebElement toDateInput = wait.Until(driver =>
                driver.FindElement(By.XPath("//label[contains(text(),'To Date')]/parent::div/following-sibling::div//input"))
            );
            toDateInput.Clear();
            // Clear the field and set the date
            toDateInput.Click();
            toDateInput.Clear();
            toDateInput.SendKeys(toDate); // Replace 'toDate' with the actual date value
            toDateInput.SendKeys(Keys.Enter); // Optional: to confirm the input

            Console.WriteLine("Entering Comments...");
            driver.FindElement(By.XPath("//textarea[@placeholder='Type your comment here']")).SendKeys(comments);

            Console.WriteLine("Submitting Leave Application...");
            driver.FindElement(By.XPath("//button[contains(text(),'Submit')]")).Click();
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
