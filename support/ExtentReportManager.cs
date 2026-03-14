using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;


namespace SauceDemoBDD.Utilities
{
    public class ExtentReportManager
    {
        private static ExtentReports? extent;

        public static ExtentReports GetExtent()
        {
            if (extent == null)
            {
                string reportPath =
                    AppDomain.CurrentDomain.BaseDirectory + "ExtentReports.html";

                var reporter = new ExtentSparkReporter(reportPath);

                extent = new ExtentReports();
                extent.AttachReporter(reporter);

                extent.AddSystemInfo("Tester", "Anuj Nagaich");
                extent.AddSystemInfo("Framework", "Selenium + SpecFlow");
            }

            return extent;
        }
    }
}