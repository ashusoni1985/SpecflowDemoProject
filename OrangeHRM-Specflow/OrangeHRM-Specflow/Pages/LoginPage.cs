﻿using ALD_Belgium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM_Specflow.Pages
{
    class LoginPage : BasePage
    {
        public LoginPage()
        {
            PageFactory.InitElements(driver, this);
            Console.WriteLine("Page factory object initiated");
        }
        [FindsBy(How = How.Id, Using = "txtUsername")]
        private IWebElement txtUserName { get; set; }
        [FindsBy(How = How.Id, Using = "txtPassword")]
        private IWebElement txtPassword { get; set; }
        [FindsBy(How = How.Id, Using = "btnLogin")]
        private IWebElement btnLogIn { get; set; }
        [FindsBy(How =How.Id, Using = "spanMessage")]
        private IWebElement lblMessage { get; set; }
        [FindsBy(How = How.Id, Using = "logInPanelHeading")]
        private IWebElement lblLoginPanel { get; set; }

        public void EnterUserName(string userName)
        {
            txtUserName.SendKeys(userName);
        }
        public void EnterPassword(string password)
        {
            txtPassword.SendKeys(password);
        }
        public void ClickLoginButton()
        {
            btnLogIn.Click();
        }
        public void InvalidLogin(string userName , string password)
        {
            EnterUserName(userName);
            EnterPassword(password);
            ClickLoginButton();
        }
        public DashboardPage ValidLogin(string userName, string password)
        {
            EnterUserName(userName);
            EnterPassword(password);
            ClickLoginButton();
            return new DashboardPage();
        }
        public bool VerifyErrorMeesage(string message)
        {
            if(lblMessage.Displayed && lblMessage.Text.Equals(message))
            {
                Console.WriteLine("Error message displayed");
                return true;
            }
            else
            {
                Console.WriteLine("Error message displayed");
                return false;
            }
        }

        public bool verifyLoginPage(string labelMessage)
        {
            if(lblLoginPanel.Displayed && lblLoginPanel.Text.Equals(labelMessage))
            {
                Console.WriteLine("Label matched. User is at Kogin page");
                return true;
            }
            else
            {
                Console.WriteLine("Label doesn't matched. User is not at Login Page");
                return false;
            }
        }

        public bool VerifyPageLod()
        {
            if (lblLoginPanel.Displayed)
            {
                Console.WriteLine("Login page load successfully.");
                return true;
            }
            else
            {
                Console.WriteLine("Login page doesn't load successfully.");
                return false;
            }
        }
    }
}
