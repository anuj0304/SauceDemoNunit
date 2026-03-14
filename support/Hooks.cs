using TechTalk.SpecFlow;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using SauceDemoBDD.Utilities;
using System;

namespace SauceDemoBDD.support
{
    [Binding]
    public class Hooks
    {
        private static ExtentReports? extent;
        private ExtentTest? test;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            extent = ExtentReportManager.GetExtent();
        }

        [BeforeScenario]
        public void Setup(ScenarioContext scenarioContext)
        {
            DriverFactory.InitDriver();
            test = extent?.CreateTest(scenarioContext.ScenarioInfo.Title);
            ExtentReportManager.SetTest(test);
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            var stepText = scenarioContext.StepContext.StepInfo.Text;

            if (scenarioContext.TestError == null)
                test?.Log(Status.Pass, $"{stepType} {stepText}");
            else
                test?.Log(Status.Fail, $"{stepType} {stepText} — {scenarioContext.TestError.Message}");
        }

        [AfterScenario]
        public void TearDown(ScenarioContext context)
        {
            if (context.TestError != null)
            {
                try
                {
                    var screenshot = ((ITakesScreenshot)DriverFactory.GetDriver()).GetScreenshot();
                    string path = $"Failure_{DateTime.Now.Ticks}.png";
                    screenshot.SaveAsFile(path);
                    test?.AddScreenCaptureFromPath(path);
                    test?.Fail("Scenario failed — screenshot attached");
                }
                catch { }
            }
            else
            {
                test?.Pass("Scenario passed");
            }

            DriverFactory.QuitDriver();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            extent?.Flush();
        }
    }
}