using FluentAssertions;
using NsTestFrameworkUI.Helpers;
using UIAutomationFrameworkExercise.Helpers;
using UIAutomationFrameworkExercise.Helpers.Models.ApiModels;
using UIAutomationFrameworkExercise.Helpers.Models.Enum;

namespace UIAutomationFrameworkExercise.Tests.Admin;

[TestClass]
public class ReportTest : BaseTest
{
    private CreateRoomOutput _createRoomOutput;
    private CreateBookingInput _bookingInput;

    [TestInitialize]
    public override void Before()
    {
        base.Before();

        _createRoomOutput = Client.CreateRoom();

        _bookingInput = new CreateBookingInput
        {
            roomid = _createRoomOutput.roomid
        };
        Client.CreateBooking(_bookingInput);
    }

    [TestMethod]
    public void WhenViewingReports_BookedRoomsShouldBeDisplayedTest()
    {
        Browser.GoTo(Constants.AdminUrl);

        Pages.LoginPage.Login();
        Pages.AdminHeaderPage.GoToMenu(Menu.Report);

        var bookingName = $"{_bookingInput.firstname} {_bookingInput.lastname}";
        Pages.ReportPage.IsBookingDisplayed(bookingName, _createRoomOutput.roomName).Should().BeTrue();
    }


    [TestCleanup]
    public override void After()
    {
        base.After();

        Client.DeleteRoom(_createRoomOutput.roomid);
    }
}
