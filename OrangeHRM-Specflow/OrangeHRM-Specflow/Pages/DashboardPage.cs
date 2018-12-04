using ALD_Belgium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM_Specflow.Pages
{
    class DashboardPage : BasePage
    {
        public DashboardPage()
        {
            PageFactory.InitElements(driver, this);
            Console.WriteLine("Page factory object initiated");
        }
        [FindsBy(How = How.Id, Using = "menu_dashboard_index")] 
        private IWebElement menu_Dahboard { get; set; }
        [FindsBy(How = How.Id, Using = "menu__Performance")]
        private IWebElement menu_Performance { get; set; }
        [FindsBy(How = How.Id, Using = "menu_recruitment_viewRecruitmentModule")]
        private IWebElement menu_Recruitment { get; set; }
        [FindsBy(How = How.Id, Using = "menu_time_viewTimeModule")]
        private IWebElement menu_Time { get; set; }
        [FindsBy(How =How.Id, Using = "menu_leave_viewLeaveModule")]
        private IWebElement menu_Leave { get; set; }
        [FindsBy(How =How.Id, Using = "menu_pim_viewPimModule")]
        private IWebElement menu_PIM { get; set; }
        [FindsBy(How = How.Id, Using = "menu_admin_viewAdminModule")]
        private IWebElement menu_Admin { get; set; }
        [FindsBy(How =How.Id, Using = "menu_admin_UserManagement")]
        private IWebElement subMenu_UserManagement { get; set; }



    }
}
