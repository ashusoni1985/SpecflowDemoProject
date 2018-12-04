using ALD_Belgium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM_Specflow.Pages
{
    class AddUserPage : BasePage
    {
        public AddUserPage()
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "systemUser_userType")]
        private IWebElement drpn_UserRole { get; set; }
        [FindsBy(How = How.Id, Using = "systemUser_employeeName_empName")]
        private IWebElement txt_EmployeeName { get; set; }
        [FindsBy(How = How.Id, Using = "systemUser_userName")]
        private IWebElement txt_UserName { get; set; }
        [FindsBy(How = How.Id, Using = "systemUser_status")]
        private IWebElement drpn_Status { get; set; }
        [FindsBy(How = How.Id, Using = "systemUser_password")]
        private IWebElement txt_Password { get; set; }
        [FindsBy(How = How.Id, Using = "systemUser_confirmPassword")]
        private IWebElement txt_ConfirmPassword { get; set; }
        [FindsBy(How = How.Id, Using = "btnSave")]
        private IWebElement btn_Save { get; set; }
        [FindsBy(How = How.Id, Using = "btnCancel")]
        private IWebElement btn_Cancel { get; set; }
        [FindsBy(How = How.Id, Using = "UserHeading")]
        private IWebElement lbl_AddUser { get; set; }

        public UsersPage ClickOnCancelButton()
        {
            btn_Cancel.Click();
            return new UsersPage();
        }

        public void SelectUserRole(string userRole)
        {
            SelectElement userElement = new SelectElement(drpn_UserRole);
            userElement.SelectByText(userRole);
        }

        public void EnterEmployeeName(string employeeName)
        {
            txt_EmployeeName.SendKeys(employeeName);
        }
        public void EnterUserName(string userName)
        {
            txt_EmployeeName.SendKeys(userName);
        }
        public void SelectStatus(string status)
        {
            SelectElement userStatus = new SelectElement(drpn_Status);
            userStatus.SelectByText(status);
        }
        public void EnterPassword(string password)
        {
            txt_Password.SendKeys(password);
        }
        public void EnterConfirPassword(string confirmPassword)
        {
            txt_ConfirmPassword.SendKeys(confirmPassword);
        }

        public bool VerifyLableMessage(string lableMessage)
        {
            if (lbl_AddUser.Text.Equals(lableMessage))
            {
                Console.WriteLine("Label matched.");
                return true;
            }
            else
            {
                Console.WriteLine("Label doesn't matched.");
                return false;
            }
        }



    }
}
