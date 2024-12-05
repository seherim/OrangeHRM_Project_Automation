using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace OrangeHRM_Project_Automation
{
    class PIMPage : CorePage
    {
        public void NavigateToPIM()
        {
            driver.FindElement(By.XPath("//span[text()='PIM']")).Click();
        }

        public void AddEmployee(string firstName, string lastName)
        {
            driver.FindElement(By.XPath("//button[text()=' Add ']")).Click();

            driver.FindElement(By.Name("firstName")).SendKeys(firstName);
            driver.FindElement(By.Name("lastName")).SendKeys(lastName);

            driver.FindElement(By.XPath("//button[text()=' Save ']")).Click();
        }

        public void SearchEmployee(string name)
        {

            driver.FindElement(By.XPath("//input[@placeholder='Type for hints...']")).SendKeys(name);


            driver.FindElement(By.XPath("//button[text()=' Search ']")).Click();
        }

    }
}
