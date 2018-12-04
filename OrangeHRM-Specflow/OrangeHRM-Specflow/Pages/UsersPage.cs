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
    class UsersPage : BasePage
    {
        public UsersPage()
        {
            PageFactory.InitElements(driver, this);
            Console.WriteLine("Page factory object initiated");
        }
        [FindsBy(How = How.Id, Using = "searchBtn")]
        private IWebElement btn_Search { get; set; }
        [FindsBy(How = How.Id, Using = "resetBtn")]
        private IWebElement btn_Reset { get; set; }
        [FindsBy(How = How.Id, Using = "searchSystemUser_userName")]
        private IWebElement txt_UserName { get; set; }
        [FindsBy(How = How.Id, Using = "searchSystemUser_userType")]
        private IWebElement drpn_UserRole { get; set; }
        [FindsBy(How = How.Id, Using = "searchSystemUser_employeeName_empName")]
        private IWebElement txt_EmployeeName { get; set; }
        [FindsBy(How = How.Id, Using = "searchSystemUser_status")]
        private IWebElement drpn_Status { get; set; }
        [FindsBy(How =How.Id, Using = "btnAdd")]
        private IWebElement btn_Add { get; set; }

        public AddUserPage ClickOnAddButton()
        {
            btn_Add.Click();
            return new AddUserPage();
        }
    }
}
