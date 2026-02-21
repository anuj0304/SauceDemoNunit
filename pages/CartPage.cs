using OpenQA.Selenium;

namespace SauceDemoBDD.pages
{
    public class CartPage
    {
        private IWebDriver driver;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By checkoutBtn = By.Id("checkout");

        public void ClickCheckout()
        {
            driver.FindElement(checkoutBtn).Click();
            
        }
    }
}
