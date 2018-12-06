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
    class LogOutSteps: Hooks
    {
        LoginPage loginPage;
        DashboardPage dashboardPage;

        [Given(@"I am at Dashboard page")]
        public void GivenIAmAtDashboardPage()
        {
            loginPage = new LoginPage();
            dashboardPage = loginPage.ValidLogin(Constants.ValidUserName, Constants.ValidPassword);
        }

        [When(@"I click on Welcome Text from the top right")]
        public void WhenIClickOnWelcomeTextFromTheTopRight()
        {
            dashboardPage.ClickOnWelcomeText();
        }

        [Then(@"Pop up sub menu displayed")]
        public void ThenPopUpSubMenuDisplayed()
        {
            Assert.IsTrue(dashboardPage.VerifyPopUpMenuAbout(Constants.PopUpMenuAbout));
            Assert.IsTrue(dashboardPage.VerifyPopUpMenuLogOut(Constants.PopUpMenuLogOut));
        }

        [When(@"select About from pop up sub menu")]
        public void WhenSelectAboutFromPopUpSubMenu()
        {
            dashboardPage.ClickOnAboutMenu();
        }

        [Then(@"About Pop up should be displayed")]
        public void ThenAboutPopUpShouldBeDisplayed()
        {
            Assert.IsTrue(dashboardPage.verifyPopUpTitle(Constants.PopUpMenuAbout));
        }

        [When(@"select Logout from pop up sub menu")]
        public void WhenSelectLogoutFromPopUpSubMenu()
        {
            loginPage = dashboardPage.ClickOnLogOutMenu();
        }

        [Then(@"user must navigate to Login screen")]
        public void ThenUserMustNavigateToLoginScreen()
        {
            loginPage.verifyLoginPage(Constants.LoginPanelHeading);
        }

        [Given(@"Dashboard Page load successfully")]
        public void GivenDashboardPageLoadSuccessfully()
        {
            dashboardPage.VerifyWelcomeMessage(Constants.WelcomeLabel);
        }


    }
}
