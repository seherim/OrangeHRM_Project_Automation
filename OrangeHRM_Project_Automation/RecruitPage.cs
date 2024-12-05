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
        // Navigate to Recruitment Page
        public void NavigateToRecruitmentPage()
        {
            driver.FindElement(By.XPath("//span[text()='Recruitment']")).Click();
        }

        // Add Job Vacancy
        public void AddJobVacancy()
        {
        }

        // Search for a Candidate
        public void SearchCandidate()
        { }

        // Approve/Reject Candidate
        public void ApproveOrRejectCandidate()
        {
        }
    }
}
