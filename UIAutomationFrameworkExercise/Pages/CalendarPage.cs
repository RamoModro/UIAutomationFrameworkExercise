using NsTestFrameworkUI.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Constants = UIAutomationFrameworkExercise.Helpers.Constants;

namespace UIAutomationFrameworkExercise.Pages
{
    public class CalendarPage
    {
        public void SelectDates()
        {
            var actions = new Actions(Browser.WebDriver);

            actions.ClickAndHold(Browser.WebDriver.FindElement(By.XPath($"//*[text()={Constants.BookingStartDay}] ")))
                    .MoveByOffset(10, 10)
                    .Release(Browser.WebDriver.FindElement(By.XPath($"//*[text()={Constants.BookingEndDay}] ")))
                    .Build()
                    .Perform();
        }
    }
}
