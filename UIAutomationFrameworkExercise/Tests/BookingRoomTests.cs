using FluentAssertions;
using Newtonsoft.Json;
using NsTestFrameworkApi.RestSharp;
using RestSharp;
using UIAutomationFrameworkExercise.Helpers;
using UIAutomationFrameworkExercise.Helpers.Models;
using UIAutomationFrameworkExercise.Helpers.Models.ApiModels;


namespace UIAutomationFrameworkExercise.Tests;

[TestClass]
public class BookingRoomTests : BaseTest
{
    readonly RestClient _client = RequestHelper.GetRestClient(Constants.Url);
    int _roomId;

    [TestInitialize]
    public override void Before()
    {
        _client.AddDefaultHeader("cookie", Constants.CookieToken);
        var response = _client.CreateRequest(ApiResource.Room, new CreateRoomInput(), Method.POST);
        _roomId = JsonConvert.DeserializeObject<CreateRoomOutput>(response.Content).roomId;

        base.Before();
    }

    [TestMethod]
    public void  WhenBookingARoomSuccessMessageShouldBeDisplayedTest()
    {
        Pages.HomePage.ClickBookThisRoom();
        Pages.HomePage.CompleteBookingDetails(new UserModel());
        Pages.HomePage.ClickBookRoom();
        Pages.HomePage.IsSuccessBookingMessageDisplayed().Should().BeTrue();       
    }

    [TestCleanup]
    public override void After()
    {
        _client.CreateRequest($"{ApiResource.Room}{_roomId}", Method.DELETE);
        base.After();
    }
}

