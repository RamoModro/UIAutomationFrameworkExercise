using NsTestFrameworkUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UIAutomationFrameworkExercise.Helpers;

public class BaseTest
{
    [TestInitialize]
    public void Before()
    {
        Browser.InitializeDriver(new DriverOptions
        {
            ChromeDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
        });     
        Browser.GoTo("https://automationintesting.online/#/");
    }
}
