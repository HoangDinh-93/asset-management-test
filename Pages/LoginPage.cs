using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Core;
using OpenQA.Selenium;

namespace AssetManagement.Pages
{
    public class LoginPage : BasePage
    {
        private Element _signinTitle = new Element(By.XPath("//h2[text()='Sign In']"));
        private Element _usernameTextBox = new Element(By.XPath("//input[@name='username']"));
        private Element _passwordTextBox = new Element(By.XPath("//input[@name='password']"));
        private Element _loginBtn = new Element(By.XPath("//button[text()='Sign In']"));
        private Element _errorToast = new Element(
            By.XPath("//div[text()='Username or password is incorrect. Please try again']")
        );
        private Element _logoutSuccessfulToast = new Element(
            By.XPath("//div[text()='Logout successful!']")
        );
        private Element _passwordErrorText = new Element(
            By.XPath("//input[@name='password']/../../following-sibling::div")
        );

        public void InputUsername(string username)
        {
            _usernameTextBox.ClearText();
            _usernameTextBox.InputText(username);
        }

        public void InputPassword(string password)
        {
            _passwordTextBox.ClearText();
            _passwordTextBox.InputText(password);
        }

        public void Login(string username, string password)
        {
            InputUsername(username);
            InputPassword(password);
            _loginBtn.ClickOnElement();
        }

        public string GetUsernameText()
        {
            return Username.GetTextFromElement();
        }

        public bool IsButtonClickable()
        {
            return _loginBtn.IsEnabled();
        }

        public bool IsLoginFailed()
        {
            return _errorToast.IsElementDisplayed();
        }

        public string GetPasswordErrorText()
        {
            return _passwordErrorText.GetTextFromElement();
        }

        public bool IsLogoutSuccessful()
        {
            _signinTitle.IsElementDisplayed();
            return _logoutSuccessfulToast.IsElementDisplayed();
        }
    }
}
