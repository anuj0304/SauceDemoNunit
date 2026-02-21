using NUnit.Framework;
using TechTalk.SpecFlow;
using SauceDemoBDD.pages;
using SauceDemoBDD.support;
using OpenQA.Selenium;

namespace SauceDemoBDD.steps
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver driver => DriverFactory.GetDriver();
        private LoginPage? loginPage;

        [Given(@"I attempt login with invalid credentials")]
        public void GivenIAttemptLoginWithInvalidCredentials()
        {
            loginPage = new LoginPage(driver);
            loginPage.Login("invalid_user", "wrong_password");
        }

        [Then(@"I should see an authentication error message")]
        public void ThenIShouldSeeAnAuthenticationErrorMessage()
        {
            string errorMessage = loginPage!.GetErrorMessage();

            Assert.Equals(
                errorMessage.Contains("Username and password do not match"),
                "Expected authentication error message not displayed."
            );
        }
    }
}