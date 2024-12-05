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
        public void Logout()
        {
            driver.FindElement(By.XPath("//span[@class='oxd-userdropdown-tab']")).Click();
            
            driver.FindElement(By.XPath("//a[text()='Logout']")).Click();
        }
    }
}
