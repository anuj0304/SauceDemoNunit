using NUnit.Framework;
using TechTalk.SpecFlow;
using SauceDemoBDD.pages;
using SauceDemoBDD.support;
using OpenQA.Selenium;

namespace SauceDemoBDD.steps
{
    [Binding]
    public class PurchaseSteps
    {
        private IWebDriver driver;
        private LoginPage? loginPage;
        private ProductsPage? productsPage;
        private CartPage? cartPage;
        private CheckoutPage? checkoutPage;

        public PurchaseSteps()
        {
            driver = DriverFactory.GetDriver();
        }

        [Given(@"I login as a standard user")]
        public void GivenILoginAsStandardUser()
        {
            loginPage = new LoginPage(driver);
            loginPage.Login("standard_user", "secret_sauce");
        }

        [When(@"I add ""(.*)"" to the cart")]
        public void WhenIAddToCart(string product)
        {
            productsPage = new ProductsPage(driver);
            productsPage.AddBackpackToCart();

            Assert.That("1", Is.EqualTo(productsPage.GetCartCount()));

            productsPage.ClickCart();
        }

        [When(@"I checkout with valid customer details")]
        public void WhenICheckoutWithValidCustomerDetails()
        {
            cartPage = new CartPage(driver);
            cartPage.ClickCheckout();

            checkoutPage = new CheckoutPage(driver);
            checkoutPage.FillDetails("Anuj", "Test", "12345");
            checkoutPage.FinishOrder();
        }

        [Then(@"I should see the order confirmation page")]
        public void ThenIShouldSeeConfirmation()
        {
            
          //  Assert.Equals("Thank you for your order!",
           //     checkoutPage!.GetConfirmationText()
          //  );

            Assert.That("Thank you for your order!", Is.EqualTo(checkoutPage!.GetConfirmationText()));
        }
    }
}
