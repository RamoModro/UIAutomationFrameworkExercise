using FluentAssertions;
using NsTestFrameworkUI.Helpers;
using UIAutomationFrameworkExercise.Helpers;
using UIAutomationFrameworkExercise.Helpers.Models;
using UIAutomationFrameworkExercise.Helpers.Models.ApiModels;

namespace UIAutomationFrameworkExercise.Tests.Book;

[TestClass]
public class BookingFormTests : BaseTest
{
    private CreateRoomOutput _createRoomOutput;

    [TestInitialize]
    public override void Before()
    {
        base.Before();

        _createRoomOutput = Client.CreateRoom();

        var bookingInput = new CreateBookingInput
        {
            roomid = _createRoomOutput.roomid
        };
        Client.CreateBooking(bookingInput);
    }

    [TestMethod]
    public void WhenBookingRoom_ErrorMessageShouldBeDisplayedTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.HomePage.BookThisRoom(_createRoomOutput.description);
        Pages.HomePage.BookRoom();
        Pages.HomePage.GetErrorMessages().Should().BeEquivalentTo(Messages.FormErrorMessages);

        Pages.HomePage.InsertBookingDetails(new User());
        Pages.HomePage.BookRoom();
        Pages.HomePage.GetErrorMessages()[0].Should().Be(Messages.AlreadyBookedErrorMessage);
    }

    [TestCleanup]
    public override void After()
    {
        base.After();

        Client.DeleteRoom(_createRoomOutput.roomid);
    }
}
