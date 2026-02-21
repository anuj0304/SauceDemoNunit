using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SauceDemoBDD.support
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario]
        public void Setup()
        {
            DriverFactory.InitDriver();
        }

        [AfterScenario]
        public void TearDown(ScenarioContext context)
        {
            if (context.TestError != null)
            {
                var screenshot = ((ITakesScreenshot)
                    DriverFactory.GetDriver())
                    .GetScreenshot();

                screenshot.SaveAsFile($"Failure_{DateTime.Now.Ticks}.png");
            }

            DriverFactory.QuitDriver();
        }
    }
}
