using OpenQA.Selenium;
using SauceDemoBDD.support;

namespace SauceDemoBDD.pages
{
    public class CheckoutPage
    {
        private IWebDriver driver;

        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By firstName = By.Id("first-name");
        private By lastName = By.Id("last-name");
        private By postalCode = By.Id("postal-code");
        private By continueBtn = By.Id("continue");
        private By finishBtn = By.Id("finish");
        private By confirmationText = By.ClassName("complete-header");

        public void FillDetails(string fName, string lName, string zip)
        {

            driver.FindElement(firstName).SendKeys(fName);
          //  WaitHelper.SlowDown();
            driver.FindElement(lastName).SendKeys(lName);
          //  WaitHelper.SlowDown();
            driver.FindElement(postalCode).SendKeys(zip);
          //  WaitHelper.SlowDown();
            driver.FindElement(continueBtn).Click();

            // WaitHelper.SlowDown();

        }

        public void FinishOrder()
        {
            driver.FindElement(finishBtn).Click();
          //  WaitHelper.SlowDown();
        }

        public string GetConfirmationText()
        {
            return driver.FindElement(confirmationText).Text;
        }
    }
}
