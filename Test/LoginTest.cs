using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Constants;
using AssetManagement.Core.Utilities;
using AssetManagement.Extensions;
using AssetManagement.Model;
using AssetManagement.Pages;
using AssetManagement.Test;
using NUnit.Framework;

namespace AssetManagement.Test
{
    [TestFixture]
    public class LoginTest : BaseTest
    {
        private Dictionary<string, Account> _accountData;
        private Dictionary<string, string> _errorData;
        private LoginPage _loginPage;

        [SetUp]
        public void Setup()
        {
            _loginPage = new LoginPage();
            _accountData = JsonFileUtility.ReadAndParse<Dictionary<string, Account>>(
                FileConstants.AccountFilePath.GetAbsolutePath()
            );
            _errorData = JsonFileUtility.ReadAndParse<Dictionary<string, string>>(
                FileConstants.ErrorFilePath.GetAbsolutePath()
            );
        }

        [Test, Order(1)]
        [TestCase("account_valid")]
        [Description("Verify login successfully with valid Username and Password")]
        public void TestLoginWithValidUsernameAndPassword(string key)
        {
            _loginPage.GoToUrl(loginUrl);
            _loginPage.Login(_accountData[key].Username, _accountData[key].Password);
            StringAssert.AreEqualIgnoringCase(
                _accountData[key].Username,
                _loginPage.GetUsernameText()
            );
        }

        [Test, Order(4)]
        [TestCase("account_valid")]
        [Description("Verify login unsuccessfully when missing Username")]
        public void TestLoginWithMissingUsername(string key)
        {
            _loginPage.GoToUrl(loginUrl);
            _loginPage.InputPassword(_accountData[key].Password);
            Assert.IsFalse(_loginPage.IsButtonClickable());
        }

        [Test, Order(3)]
        [TestCase("account_valid")]
        [Description("Verify login unsuccessfully when missing Password")]
        public void TestLoginWithMissingPassword(string key)
        {
            _loginPage.GoToUrl(loginUrl);
            _loginPage.InputUsername(_accountData[key].Username);
            Assert.IsFalse(_loginPage.IsButtonClickable());
        }

        [Test, Order(2)]
        [TestCase("account_invalid")]
        [Description("Verify login unsuccessfully with invalid Username and Password")]
        public void TestLoginWithInvalidUsernameAndPassword(string key)
        {
            _loginPage.GoToUrl(loginUrl);
            _loginPage.Login(_accountData[key].Username, _accountData[key].Password);
            Assert.IsTrue(_loginPage.IsLoginFailed());
        }

        [Test, Order(5)]
        [TestCase("account_invalid_password_length", "error_invalid_password_length")]
        [Description(
            "Verify that error message is showed when entering Password less than 8 digits"
        )]
        public void TestLoginWithInvalidPasswordLength(string key, string err)
        {
            _loginPage.GoToUrl(loginUrl);
            _loginPage.Login(_accountData[key].Username, _accountData[key].Password);
            StringAssert.AreEqualIgnoringCase(_errorData[err], _loginPage.GetPasswordErrorText());
        }
    }
}
