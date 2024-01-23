using Faker;
using UIAutomationFrameworkExercise.Helpers.Models.Enum;

namespace UIAutomationFrameworkExercise.Helpers.Models;

public class Room
{
    public string RoomName { get; set; } = RandomNumber.Next(1, 1000).ToString();
    public string Type { get; set; } = GetRoomType();
    public string Accessible { get; set; } = Faker.Boolean.Random().ToString().ToLower();
    public string Price { get; set; } = RandomNumber.Next(1, 999).ToString();
    public string RoomDetails { get; set; } = GetRoomDetails();


    private static string GetRoomType()
    {
        var roomType = new List<RoomType> { RoomType.Double, RoomType.Single, RoomType.Family, RoomType.Twin, RoomType.Suite };

        return roomType[RandomNumber.Next(roomType.Count - 1)].ToString();
    }

    private static string GetRoomDetails()
    {
        var roomDetails = new List<string> { "WiFi", "TV", "Radio", "Refreshments", "Safe", "Views" };

        return roomDetails[RandomNumber.Next(roomDetails.Count - 1)];
    }
}
