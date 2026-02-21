using OpenQA.Selenium;
using SauceDemoBDD.support;

namespace SauceDemoBDD.pages
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By username = By.Id("user-name");
        private By password = By.Id("password");
        private By loginBtn = By.Id("login-button");

        public void Login(string user, string pass)
        {
            driver.FindElement(username).SendKeys(user);
            driver.FindElement(password).SendKeys(pass);
            driver.FindElement(loginBtn).Click();
             WaitHelper.SlowDown();
        }


        private By errorMessage = By.CssSelector("h3[data-test='error']");

       public string GetErrorMessage()
      {
         return WaitHelper
        .WaitForElementVisible(errorMessage)
        .Text;
      }
       }
}
