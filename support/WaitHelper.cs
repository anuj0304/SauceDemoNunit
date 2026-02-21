using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

using SeleniumExtras.WaitHelpers;
using System;

namespace SauceDemoBDD.support
{
    public static class WaitHelper
    {
        private static int defaultTimeout = 20;

        public static IWebElement WaitForElementVisible(By locator)
        {
            WebDriverWait wait = new WebDriverWait(
                DriverFactory.GetDriver(),
                TimeSpan.FromSeconds(defaultTimeout)
            );

            return wait.Until(
                ExpectedConditions.ElementIsVisible(locator)
            );
        }

        public static void SlowDown(int milliseconds = 4000)
       {
         Thread.Sleep(milliseconds);
        }


        public static IWebElement WaitForElementClickable(By locator)
        {
            WebDriverWait wait = new WebDriverWait(
                DriverFactory.GetDriver(),
                TimeSpan.FromSeconds(defaultTimeout)
            );

            return wait.Until(
                ExpectedConditions.ElementToBeClickable(locator)
            );
        }
    }
}
