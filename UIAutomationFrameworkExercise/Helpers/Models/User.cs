﻿namespace UIAutomationFrameworkExercise.Helpers.Models
{
    public class User
    {
        public string FirstName { get; set; } = Faker.Name.First();
        public string LastName { get; set; } = Faker.Name.Last();
        public string Email { get; set; } = Faker.Internet.Email();
        public string Phone { get; set; } = "98765432123456";
    }
}
