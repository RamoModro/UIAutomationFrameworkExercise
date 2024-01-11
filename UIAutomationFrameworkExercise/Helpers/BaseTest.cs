using NsTestFrameworkUI.Helpers;
using System.Reflection;

namespace UIAutomationFrameworkExercise.Helpers;

public class BaseTest
{
    public TestContext TestContext { get; set; }

    [TestInitialize]
    public virtual void Before()
    {
        Browser.InitializeDriver(new DriverOptions
        {
            IsHeadless = false,
            ChromeDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
        });     
        Browser.GoTo(Constants.Url);
        Browser.WebDriver.Manage().Window.Maximize();
    }

    [TestCleanup]
    public virtual void After()
    {
        if (TestContext.CurrentTestOutcome.Equals(UnitTestOutcome.Failed))
        {
            var path = ScreenShot.GetScreenShotPath(TestContext.TestName);
            TestContext.AddResultFile(path);
        }
        Browser.Cleanup();
    }
}
