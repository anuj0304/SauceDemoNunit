using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;

namespace SauceDemoBDD.Utilities
{
    public class ExtentReportManager
    {
        private static ExtentReports? extent;
        private static ExtentTest? currentTest;

        public static ExtentReports GetExtent()
        {
            if (extent == null)
            {
                string reportPath =
                    AppDomain.CurrentDomain.BaseDirectory + "ExtentReports.html";

                var reporter = new ExtentSparkReporter(reportPath);
                reporter.Config.DocumentTitle = "SauceDemo Test Report";
                reporter.Config.ReportName = "Selenium BDD Automation";

                extent = new ExtentReports();
                extent.AttachReporter(reporter);

                extent.AddSystemInfo("Tester", "Anuj Nagaich");
                extent.AddSystemInfo("Framework", "Selenium + SpecFlow + NUnit");
                extent.AddSystemInfo("Environment", "SauceDemo");
            }

            return extent;
        }

        public static void SetTest(ExtentTest? test)
        {
            currentTest = test;
        }

        public static ExtentTest? GetTest() => currentTest;
    }
}