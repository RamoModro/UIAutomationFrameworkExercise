﻿using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace UIAutomationFrameworkExercise.Pages
{
    public class BasePage
    {
        private readonly By _errorMessages = By.CssSelector(".alert.alert-danger p");


        public List<string> GetErrorMessages()
        {
            WaitHelpers.ExplicitWait();
            return _errorMessages.GetElements().Select(message => message.Text).ToList();
        }

        public bool IsErrorMessageDisplayed() => _errorMessages.AreElementsPresent();
    }
}
