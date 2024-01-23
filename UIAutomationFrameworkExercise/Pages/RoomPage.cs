using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using UIAutomationFrameworkExercise.Helpers.Models;

namespace UIAutomationFrameworkExercise.Pages
{
    public class RoomPage : BasePage
    {
        #region Selectors

        private readonly By _createButton = By.CssSelector("#createRoom");
        private readonly By _roomIdInput = By.CssSelector("#roomName");
        private readonly By _roomTypeDropdown = By.CssSelector("#type");
        private readonly By _accessibleDropdown = By.CssSelector("#accessible");
        private readonly By _roomPriceInput = By.CssSelector("#roomPrice");
        private readonly By _roomDetailsLabels = By.CssSelector(".form-check-label");

        private readonly By _lastRoomDetails = By.CssSelector("#root div:nth-child(2) div:nth-last-child(2) .row.detail div");

        #endregion

        public void CreateRoom()
        {
            _createButton.ActionClick();
            WaitHelpers.ExplicitWait();
        }

        public void InsertRoomDetails(Room room)
        {
            _roomIdInput.ActionSendKeys(room.RoomName);
            _roomTypeDropdown.SelectFromDropdownByText(room.Type);
            _accessibleDropdown.SelectFromDropdownByText(room.Accessible);
            _roomPriceInput.ActionSendKeys(room.Price);
            if (string.IsNullOrEmpty(room.RoomDetails)) return;
            _roomDetailsLabels.GetElements().First(label => label.Text == room.RoomDetails).Click();
        }

        public Room GetLastRoomDetails()
        {
            var roomDetails = _lastRoomDetails.GetElements();

            return new Room
            {
                RoomName = roomDetails[0].Text,
                Type = roomDetails[1].Text,
                Accessible = roomDetails[2].Text,
                Price = roomDetails[3].Text,
                RoomDetails = roomDetails[4].Text
            };
        }
    }
}
