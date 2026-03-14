using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using System;

namespace SauceDemoBDD.support
{
    public static class DriverFactory
    {
        private static IWebDriver? driver;

        public static IWebDriver InitDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            ChromeOptions options = new ChromeOptions();

            // 🔥 Force fresh clean profile
            options.AddArgument("--incognito");

            // Disable password + automation popups
            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-infobars");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--headless");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
           // options.AddArgument("--disable-blink-features=AutomationControlled");

           // These help with stability on Linux
            options.AddArgument("--disable-gpu");
            options.AddArgument("--window-size=1920,1080");

            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);

            driver = new ChromeDriver(options);

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            return driver;
        }

        public static IWebDriver GetDriver() => driver!;

        public static void QuitDriver()
        {
            driver?.Quit();
        }
    }
}