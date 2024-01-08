using UIAutomationFrameworkExercise.Helpers;

namespace UIAutomationFrameworkExercise.Tests;

[TestClass]
public class BookingRoomTests : BaseTest
{
    [TestMethod]

    public void  WhenBookingARoomSuccessMessageShouldBeDisplayedTest()
    {
        Pages.HomePage.ClickBookThisRoomButton();
        Pages.HomePage.InsertBookingContactDetails("First Name", "Last Name", "email@email.com", "12345678999");
        Pages.HomePage.ClickBookRoom();

        Pages.HomePage.SelectDates();
    }

}

