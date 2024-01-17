using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using UIAutomationFrameworkExercise.Helpers.Models;

namespace UIAutomationFrameworkExercise.Pages;

public class Homepage : CalendarPage
{
    #region Selectors

    private readonly By _descriptions = By.CssSelector(".row.hotel-room-info p");

    private readonly By _bookThisRoomButtons = By.CssSelector(".openBooking");

    private readonly By _firstNameInput = By.CssSelector(".room-firstname");
    private readonly By _lastNameInput = By.CssSelector(".room-lastname");
    private readonly By _emailInput = By.CssSelector(".room-email");
    private readonly By _phoneInput = By.CssSelector(".room-phone");

    private readonly By _bookRoomButton = By.CssSelector(".btn-outline-primary.book-room");
    
    private readonly By _successBookingMessage = By.CssSelector(".form-row .text-center:nth-child(2)");

    #endregion

    public void BookThisRoom(string roomDescription)
    {
        var descriptions = _descriptions.GetElements();
        var index = descriptions.IndexOf(descriptions.First(x => x.Text == roomDescription));
        _bookThisRoomButtons.GetElements().Last().Click();
    }

    public void InsertBookingDetails(User user)
    {
        _firstNameInput.ActionSendKeys(user.FirstName);
        _lastNameInput.ActionSendKeys(user.LastName);
        _emailInput.ActionSendKeys(user.Email);
        _phoneInput.ActionSendKeys(user.Phone);

        SelectDates();
    }

    public void BookRoom() => _bookRoomButton.ActionClick();

    public bool IsSuccessMessageDisplayed()
    {
        _successBookingMessage.WaitUntilElementIsVisible();
        return _successBookingMessage.GetText().Contains("Booking Successful!");
    }
}