using OpenQA.Selenium;

namespace OrangeHRM_Project_Automation
{
    class LeavePage : CorePage
    {
        public void NavigateToLeavePage()
        {
            //driver.FindElement(By.XPath("//span[text()='Leave']")).Click();
        }


        public void ApplyForLeave(string leaveType, string fromDate, string toDate, string comments)
        {
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
