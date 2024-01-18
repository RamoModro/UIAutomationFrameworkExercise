namespace UIAutomationFrameworkExercise.Helpers
{
    internal class Messages
    {
        public static string AlreadyBookedErrorMessage = "The room dates are either invalid or are already booked for one or more of the dates that you have selected.";

        public static List<string> FormErrorMessages = new()
        {
            "must not be null",
            "must not be empty",
            "size must be between 3 and 30",
            "must not be empty",
            "must not be null",  
            "size must be between 11 and 21",    
            "Firstname should not be blank", 
            "Lastname should not be blank",  
            "size must be between 3 and 18"
        };
    }
}
