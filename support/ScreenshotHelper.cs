using OpenQA.Selenium;
using System;
using System.IO;

namespace SauceDemoBDD.Utilities
{
    public class ScreenshotHelper
    {
        public static string Capture(IWebDriver driver, string name)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            string folder = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Screenshotss");

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string path =
                Path.Combine(folder, name + "_" +
                DateTime.Now.Ticks + ".png");

            screenshot.SaveAsFile(path);

            return path;
        }
    }
}