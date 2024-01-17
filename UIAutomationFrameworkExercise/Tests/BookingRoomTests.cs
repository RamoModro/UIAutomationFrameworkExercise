using FluentAssertions;
using NsTestFrameworkUI.Helpers;
using UIAutomationFrameworkExercise.Helpers;
using UIAutomationFrameworkExercise.Helpers.Models;
using UIAutomationFrameworkExercise.Helpers.Models.ApiModels;


namespace UIAutomationFrameworkExercise.Tests;

[TestClass]
public class BookingRoomTests : BaseTest
{
    private CreateRoomOutput _createRoomOutput;

    [TestInitialize]
    public override void Before()
    { 
        base.Before();

        _createRoomOutput = Client.CreateRoom();
    }

    [TestMethod]
    public void  WhenBookingARoomSuccessMessageShouldBeDisplayedTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.HomePage.BookThisRoom(_createRoomOutput.description);
        Pages.HomePage.InsertBookingDetails(new User());
        Pages.HomePage.BookRoom();
        Pages.HomePage.IsSuccessMessageDisplayed().Should().BeTrue();       
    }

    [TestMethod]

    public void WhenCancellingBookingFormShouldNotBeDisplayed()
    {

    }

    [TestCleanup]
    public override void After()
    { 
        base.After();

        //Client.DeleteRoom(_createRoomOutput.roomid.ToString());
    }
}

