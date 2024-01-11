using FluentAssertions;
using Newtonsoft.Json;
using NsTestFrameworkApi.RestSharp;
using RestSharp;
using UIAutomationFrameworkExercise.Helpers;
using UIAutomationFrameworkExercise.Helpers.ApiModels;
using UIAutomationFrameworkExercise.Helpers.Models;


namespace UIAutomationFrameworkExercise.Tests;

[TestClass]
public class BookingRoomTests : BaseTest
{
    RestClient client = RequestHelper.GetRestClient(Constants.Url);
    int roomId;

    [TestInitialize]
    public override void Before()
    {
        client.AddDefaultHeader("cookie", Constants.CookieToken);
        var response = client.CreateRequest(ApiResource.Room, new CreateRoomInput(), Method.POST);
        roomId = JsonConvert.DeserializeObject<CreateRoomOutput>(response.Content).roomId;

        base.Before();
    }

    [TestMethod]
    public void  WhenBookingARoomSuccessMessageShouldBeDisplayedTest()
    {
        Pages.HomePage.ClickBookThisRoomButton();
        Pages.HomePage.CompleteBookingDetails(new UserModel());
        Pages.HomePage.ClickBookRoom();
        Pages.HomePage.IsSuccessBookingMessageDisplayed().Should().BeTrue();       
    }

    [TestCleanup]
    public override void After()
    {
        client.CreateRequest($"{ApiResource.Room}{roomId}", Method.DELETE);
        base.After();
    }
}

