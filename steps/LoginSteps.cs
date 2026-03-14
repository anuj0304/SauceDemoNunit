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

        // ✅ Scenario 1 -- Invalid Credentials
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

            Assert.That(
                errorMessage,
                Does.Contain("Username and password do not match"),
                "Authentication error message not displayed!"
            );
        }

        // ✅ Scenario 2 -- Empty Credentials
        [Given(@"I attempt login with empty credentials")]
        public void GivenIAttemptLoginWithEmptyCredentials()
        {
            loginPage = new LoginPage(driver);
            loginPage.Login("", "");
        }

        [Then(@"I should see empty field error message")]
        public void ThenIShouldSeeEmptyFieldErrorMessage()
        {
            string errorMessage = loginPage!.GetErrorMessage();

            Assert.That(
                errorMessage,
                Does.Contain("Username is required"),
                "Empty field error message not displayed!"
            );
        }
    }
}