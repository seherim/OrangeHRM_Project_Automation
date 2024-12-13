using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM_Project_Automation
{
    class ChangePassPage : CorePage
    {
        #region Locators
        By userDropdown = By.XPath("//span[@class='oxd-userdropdown-tab']");
        By changePasswordButton = By.XPath("//a[text()='Change Password']");
        By currentPasswordField = By.XPath("//label[text()='Current Password']/following::input[1]");
        By newPasswordField = By.XPath("//label[text()='Password']/following::input[1]");
        By confirmPasswordField = By.XPath("//label[text()='Confirm Password']/following::input[1]");
        By saveButton = By.XPath("//button[@type='submit']");
        //By successMessage = By.XPath("//div[contains(text(),'Password changed successfully')]");
        #endregion

        public void ChangePassword(string currentPassword, string newPassword)
        {
            // Open user dropdown menu
            driver.FindElement(userDropdown).Click();

            // Navigate to Change Password page
            driver.FindElement(changePasswordButton).Click();

            // Fill out the change password form
            driver.FindElement(currentPasswordField).SendKeys(currentPassword);
            driver.FindElement(newPasswordField).SendKeys(newPassword);
            driver.FindElement(confirmPasswordField).SendKeys(newPassword);

            // Submit the form
            driver.FindElement(saveButton).Click();

            // Validate the success message
            /*bool isPasswordChanged = driver.FindElement(successMessage).Displayed;
            if (!isPasswordChanged)
            {
                throw new Exception("Password change failed!");
            } */
        }
    }
}