using FluentAssertions;
using NsTestFrameworkUI.Helpers;
using UIAutomationFrameworkExercise.Helpers;
using UIAutomationFrameworkExercise.Helpers.Models;
using UIAutomationFrameworkExercise.Helpers.Models.ApiModels;
using UIAutomationFrameworkExercise.Helpers.Models.Enum;

namespace UIAutomationFrameworkExercise.Tests.Admin;

[TestClass]
public class CreateBookingTests : BaseTest
{
    private CreateRoomOutput _createRoomOutput;
    private readonly User _user = new();
    private Helpers.Models.Room _room = new();

    [TestInitialize]

    public override void Before()
    { 
        base.Before();

        _createRoomOutput = Client.CreateRoom();

        _room = new Helpers.Models.Room
        {
            RoomName = _createRoomOutput.roomName.ToString()
        };
    }

    [TestMethod]
    public void WhenBookingARoom_BookingShouldBeDisplayedTest()
    {
        Browser.GoTo(Constants.AdminUrl);

        Pages.LoginPage.Login();
        Pages.AdminHeaderPage.GoToMenu(Menu.Report);

        Pages.ReportPage.SelectDates();
        Pages.ReportPage.Book();
        Pages.ReportPage.IsErrorMessageDisplayed().Should().BeTrue();

        Pages.ReportPage.InsertBookingDetails(_user, _room);
        Pages.ReportPage.Book();

        var bookingName = $"{_user.FirstName} {_user.LastName}";
        Pages.ReportPage.IsBookingDisplayed(bookingName, _createRoomOutput.roomName).Should().BeTrue();
    }

    [TestCleanup]
    public override void After()
    {
        base.After();

        Client.DeleteRoom(_createRoomOutput.roomid);
    }
}
