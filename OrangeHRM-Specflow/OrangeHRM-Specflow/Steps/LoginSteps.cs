using NUnit.Framework;
using OrangeHRM_Specflow.Pages;
using OrangeHRM_Specflow.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace OrangeHRM_Specflow.Steps
{
    [Binding]
    class LoginSteps: Hooks
    {
        LoginPage loginPage;
        DashboardPage dashboardPage;

        [Given(@"I am at login page")]
        public void GivenIAmAtLoginPage()
        {
            loginPage = new LoginPage();
            Assert.IsTrue(loginPage.verifyLoginPage(Constants.LoginPanelHeading));
        }

        [Given(@"Page load successfully")]
        public void GivenPageLoadSuccessfully()
        {
            Assert.IsTrue(loginPage.VerifyPageLod());
        }

 
        [When(@"Click on Login button")]
        public void WhenClickOnLoginButton()
        {
            loginPage.ClickLoginButton();
        }

        [Then(@"Application shouuld display an error message")]
        public void ThenApplicationShouuldDisplayAnErrorMessage()
        {
            loginPage.VerifyErrorMeesage(Constants.LoginErrorMessage);
        }

        [Then(@"user must navigate to Dashboard")]
        public void ThenUserMustNavigateToDashboard()
        {
            dashboardPage.VerifyWelcomeMessage(Constants.WelcomeLabel);
        }


        [When(@"I enter invalid user name and password And Click on Login button")]
        public void WhenIEnterInvalidUserNameAndPasswordAndClickOnLoginButton()
        {
            loginPage.InvalidLogin(Constants.InvalidUserName, Constants.InvalidPassword);
        }

        [When(@"I enter valid user name and password And Click on Login button")]
        public void WhenIEnterValidUserNameAndPasswordAndClickOnLoginButton()
        {
            dashboardPage = loginPage.ValidLogin(Constants.ValidUserName, Constants.ValidPassword);
        }
        [When(@"I enter valid valid user name and invalid password")]
        public void WhenIEnterValidValidUserNameAndInvalidPassword()
        {
            loginPage.EnterUserName(Constants.ValidUserName);
            loginPage.EnterPassword(Constants.InvalidPassword);
        }


    }
}
