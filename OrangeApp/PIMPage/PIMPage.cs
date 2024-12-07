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
        #region Locators
        By navbtn = By.XPath("//span[text()='PIM']");
        By addbtn = By.XPath("//button[text()=' Add ']");
        By firstname = By.Name("firstName");
        By lastname = By.Name("lastName");
        By savebtn = By.XPath("//button[text()=' Save ']");
        By searchbar = By.XPath("//input[@placeholder='Type for hints...']");
        By searchbtn = By.XPath("//button[text()=' Search ']");
        #endregion

        public void NavigateToPIM()
        {
            driver.FindElement(navbtn).Click();
        }

        public void AddEmployee(string firstName, string lastName)
        {
            driver.FindElement(addbtn).Click();

            driver.FindElement(firstname).SendKeys(firstName);
            driver.FindElement(lastname).SendKeys(lastName);

            driver.FindElement(savebtn).Click();
        }

        public void SearchEmployee(string name)
        {

            driver.FindElement(searchbar).SendKeys(name);


            driver.FindElement(searchbtn).Click();
        }

    }
}
