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
        [FindsBy(How =How.Id, Using = "welcome")]
        private IWebElement lbl_Welcome { get; set; }
        [FindsBy(How =How.Id, Using = "aboutDisplayLink")]
        private IWebElement subMenu_About { get; set; }
        [FindsBy(How =How.XPath,Using = "//a[contains(text(),'Logout')]")]
        private IWebElement subMenu_LogOut { get; set; }
        [FindsBy(How = How.XPath, Using = "//h3[contains(text(),'About')]")]
        private IWebElement popupHeading_About { get; set; }

        public bool VerifyWelcomeMessage(string message)
        {
            if(lbl_Welcome.Displayed && lbl_Welcome.Text.Equals(message))
            {
                Console.WriteLine("Welcome message matched.");
                return true;
            }
            else
            {
                Console.WriteLine("Welcome message doesn't matched.");
                return false;
            }
        }

        public void ClickOnWelcomeText()
        {
            lbl_Welcome.Click();
        }
      
        /*
         * Verify the pop up menu About displayed or not
         * */
         public bool VerifyPopUpMenuAbout(string subMenu)
        {
            BasePage.TurnOnWait();
            string popUpMenu = subMenu_About.Text;
            if (subMenu_About.Text.Equals(subMenu))
            {
                Console.WriteLine("Pop up menu" + popUpMenu + "dispalyed");
                return true;
            }
            else
            {
                Console.WriteLine("Pop up menu" + popUpMenu + "doesn't dispalyed");
                return false;
            }
        }

        /*
         * Verify the pop up menu About displayed or not
         * */
        public bool VerifyPopUpMenuLogOut(string subMenu)
        {
            BasePage.TurnOnWait();
            string popUpMenu = subMenu_LogOut.Text;
            if (subMenu_LogOut.Text.Equals(subMenu))
            {
                Console.WriteLine("Pop up menu" + popUpMenu + "dispalyed");
                return true;
            }
            else
            {
                Console.WriteLine("Pop up menu" + popUpMenu + "doesn't dispalyed");
                return false;
            }
        }

        /*
         * Click on About from pop up
         * */
         public void ClickOnAboutMenu()
        {
            subMenu_About.Click();
        }

        public LoginPage ClickOnLogOutMenu()
        {
            subMenu_LogOut.Click();
            return new LoginPage();
        }

        public bool verifyPopUpTitle(string title)
        {
            if(popupHeading_About.Displayed && popupHeading_About.Text.Equals(title))
            {
                Console.WriteLine("About Pop up displayed");
                return true;
            }
            else
            {
                Console.WriteLine("About Pop up doesn't displayed");
                return false;
            }
        }

    }
}
