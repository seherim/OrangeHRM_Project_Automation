using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM_Project_Automation
{
    class LogoutPage : CorePage
    {
        #region Locators
        By dropdown = By.XPath("//span[@class='oxd-userdropdown-tab']");
        By logoutbtn = By.XPath("//a[text()='Logout']");
        #endregion
        public void Logout()
        {
            driver.FindElement(dropdown).Click();
            
            driver.FindElement(logoutbtn).Click();
        }
    }
}
