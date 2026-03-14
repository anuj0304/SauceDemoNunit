using OpenQA.Selenium;
using SauceDemoBDD.support;

namespace SauceDemoBDD.pages
{
    public class ProductsPage
    {
        private IWebDriver driver;

        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Robust locator strategy
        private By backpackAddToCart =
            By.Id("add-to-cart-sauce-labs-backpack");

        private By cartBadge = By.ClassName("shopping_cart_badge");
        private By cartIcon = By.XPath("(//a[@class='shopping_cart_link'])[1]");

        public void AddBackpackToCart()
        {
            driver.FindElement(backpackAddToCart).Click();
            WaitHelper.SlowDown();

        }

        public string GetCartCount()
        {
           // WaitHelper.SlowDown();
            WaitHelper.WaitForElementVisible(cartBadge);
            return driver.FindElement(cartBadge).Text;
            
        }

        public void ClickCart()
        {
            driver.FindElement(cartIcon).Click();
            WaitHelper.SlowDown();
        }
    }
}
