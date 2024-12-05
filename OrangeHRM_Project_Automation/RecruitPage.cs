using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace OrangeHRM_Project_Automation
{
    class RecruitPage : CorePage
    {
        public void NavigateToRecruitmentPage()
        {
            driver.FindElement(By.XPath("//span[text()='Recruitment']")).Click();
        }

        public void AddJobVacancy()
        {
        }

        public void SearchCandidate()
        { }

        public void ApproveOrRejectCandidate()
        {
        }
    }
}
