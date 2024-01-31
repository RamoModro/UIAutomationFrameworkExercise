using CsvHelper;
using CsvHelper.Configuration;
using FluentAssertions;
using NsTestFrameworkUI.Helpers;
using System.Globalization;
using System.Reflection;
using UIAutomationFrameworkExercise.Helpers;
using UIAutomationFrameworkExercise.Helpers.Models.Enum;

namespace UIAutomationFrameworkExercise.Tests.Admin;

[TestClass]
public class LoginTests : BaseTest
{
    [DataRow("admin", "password", true)]
    [DataRow("invalidUser", "invalidPassword", false)]
    [TestMethod]
    public void LoginAsAdmin(string username, string password, bool isLoggedIn)
    {
        Browser.GoTo(Constants.AdminUrl);

        Pages.LoginPage.Login(username, password);

        Pages.AdminHeaderPage.IsLogoutButtonDisplayed().Should().Be(isLoggedIn);
    }

    [DynamicData(nameof(GetLoginScenarios), DynamicDataSourceType.Method)]
    [TestMethod]
    public void LoginAsAdmin(LoginData loginData)
    {
        Browser.GoTo(Constants.AdminUrl);

        Pages.LoginPage.Login(loginData.Username, loginData.Password);

        Pages.AdminHeaderPage.IsLogoutButtonDisplayed().Should().Be(loginData.IsLoggedIn);
    }

    private static IEnumerable<object[]> GetLoginScenarios()
    {
        var dataFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Helpers\Data\LoginData.csv";
        using var stream = new StreamReader(dataFilePath);
        using var reader = new CsvReader(stream, new CsvConfiguration(CultureInfo.CurrentCulture));
        var rows = reader.GetRecords<LoginData>();

        foreach (var row in rows)
        {
            yield return new object[] { row };
        }
    }
}
