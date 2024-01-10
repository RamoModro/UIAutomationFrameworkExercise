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
    RestClient client = RequestHelper.GetRestClient("https://automationintesting.online/");
    int roomId;

    [TestInitialize]
    public override void Before()
    {
        base.Before();
        
        client.AddDefaultHeader("cookie", "_ga=GA1.2.1704180846.1702022547; _gid=GA1.2.166679239.1704699523; banner=true; token=7nrOPBKOJkDMnzfK; _gat=1");
        var response = client.CreateRequest(ApiResource.Room, new CreateRoomInput(), Method.POST);
        roomId = JsonConvert.DeserializeObject<CreateRoomOutput>(response.Content).roomId;
    }

    [TestMethod]
    public void  WhenBookingARoomSuccessMessageShouldBeDisplayedTest()
    {
        Pages.HomePage.ClickBookThisRoomButton();
        Pages.HomePage.InsertBookingContactDetails("First Name", "Last Name", "email@email.com", "12345678999");
        Pages.HomePage.SelectDates();
        Pages.HomePage.ClickBookRoom();
        Pages.HomePage.IsSuccessBookingMessageDisplayed("Booking Successful!").Should().BeTrue();       
    }

    [TestCleanup]
    public override void After()
    {
        client.CreateRequest($"{ApiResource.Room}/{roomId}", Method.DELETE);
        base.After();
    }
}

