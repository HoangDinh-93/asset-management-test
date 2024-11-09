using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AssetManagement.Core
{
    public class Element
    {
        private By _By;
        private WebDriverWait _wait;

        public Element(By by)
        {
            _By = by;
            _wait = new WebDriverWait(DriverManager.GetDriver(), TimeSpan.FromSeconds(20));
        }

        public static string GetElementByIndex(string pattern, int index) =>
            string.Format(pattern, index);

        public IWebElement WaitForElementToBeVisible()
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(_By));
        }

        public IWebElement WaitForElementToBeClickable()
        {
            return _wait.Until(ExpectedConditions.ElementToBeClickable(_By));
        }

        public void WaitForElementTextToChange()
        {
            string initialText = GetTextFromElement();
            _wait.Until(d =>
            {
                string currentText = GetTextFromElement();
                return !currentText.Equals(initialText);
            });
        }

        public bool WaitForElementDisappear()
        {
            return _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(_By));
        }

        public bool IsElementDisplayed()
        {
            return WaitForElementToBeVisible().Displayed;
        }

        public void ClickOnElement()
        {
            WaitForElementToBeClickable().Click();
        }

        public void ClearText()
        {
            WaitForElementToBeVisible().Clear();
        }

        public void InputText(String text)
        {
            WaitForElementToBeVisible().SendKeys(text);
        }

        public string GetTextFromElement()
        {
            return WaitForElementToBeVisible().Text;
        }

        public bool IsEnabled()
        {
            return WaitForElementToBeVisible().Enabled;
        }

        public IAlert WaitForAlert()
        {
            return _wait.Until(ExpectedConditions.AlertIsPresent());
        }
    }
}
