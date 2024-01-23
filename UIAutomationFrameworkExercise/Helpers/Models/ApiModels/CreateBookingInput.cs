﻿using Faker;
using Boolean = Faker.Boolean;

namespace UIAutomationFrameworkExercise.Helpers.Models.ApiModels;

public class BookingDates
{
    public string checkin { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
    public string checkout { get; set; } = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
}

public class CreateBookingInput
{
    public BookingDates bookingDates { get; set; } = new();
    public bool depositpaid { get; set; } = Boolean.Random();
    public string firstname { get; set; } = Name.First();
    public string lastname { get; set; } = Name.Last();
    public int roomid { get; set; }
    public string email { get; set; } = Internet.Email();
    public string phone { get; set; } = "111111111111";
}
