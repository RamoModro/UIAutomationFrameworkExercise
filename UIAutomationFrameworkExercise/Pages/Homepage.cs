using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace UIAutomationFrameworkExercise.Pages;

public class Homepage
{
    #region Selectors
    private readonly By _bookThisRoomButton = By.CssSelector(".openBooking");
    private readonly By _firstNameInput = By.CssSelector(".room-firstname");
    private readonly By _lastNameInput = By.CssSelector(".room-lastname");
    private readonly By _emailInput = By.CssSelector(".room-email");
    private readonly By _phoneInput = By.CssSelector(".room-phone");
    private readonly By _bookRoomButton = By.CssSelector(".btn-outline-primary.book-room");
    #endregion

    public void ClickBookThisRoomButton()
    {
        _bookThisRoomButton.ActionClick();
    }

    public void InsertBookingContactDetails(string firstName, string lastName, string email, string phone)
    {
        _firstNameInput.ActionSendKeys(firstName);
        _lastNameInput.ActionSendKeys(lastName);
        _emailInput.ActionSendKeys(email);
        _phoneInput.ActionSendKeys(phone);
    }

    public void ClickBookRoom()
    {
        _bookRoomButton.ActionClick();
    }
}