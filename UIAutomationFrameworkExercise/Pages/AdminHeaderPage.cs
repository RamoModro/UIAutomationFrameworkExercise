using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using UIAutomationFrameworkExercise.Helpers.Models.Enum;

namespace UIAutomationFrameworkExercise.Pages;

public class AdminHeaderPage : BasePage
{
    private readonly By _menuItems = By.CssSelector(".mr-auto li a");
    private readonly By _logoutButton = By.CssSelector("[href='#/admin']");


    public void GoToMenu(Menu menu)
    {
        _menuItems.GetElements().First(item => item.Text.Equals(menu.ToString())).Click();
    }

    public bool IsLogoutButtonDisplayed() => _logoutButton.IsElementPresent();
}
