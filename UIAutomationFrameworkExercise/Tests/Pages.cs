using NsTestFrameworkUI.Pages;
using UIAutomationFrameworkExercise.Pages;

namespace UIAutomationFrameworkExercise.Tests
{
    public static class Pages
    {
        public static Homepage HomePage = PageHelpers.InitPage(new Homepage());
        public static CalendarPage CalendarPage = PageHelpers.InitPage(new CalendarPage());
    }
}
