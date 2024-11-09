using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Constants;
using AssetManagement.Core.Utilities;
using AssetManagement.Extensions;
using AssetManagement.Model;
using AssetManagement.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace AssetManagement.Test
{
    [TestFixture]
    public class LogoutTest : BaseTest
    {
        private LoginPage _loginPage;
        private Dictionary<string, Account> _accountData;

        [SetUp]
        public void Setup()
        {
            _loginPage = new LoginPage();
            _accountData = JsonFileUtility.ReadAndParse<Dictionary<string, Account>>(
                FileConstants.AccountFilePath.GetAbsolutePath()
            );
        }

        [Test, Order(6)]
        [Description("Verify that User logout successfully")]
        public void TestLogoutSuccessfully()
        {
            _loginPage.GoToUrl(loginUrl);
            _loginPage.Login(
                _accountData["account_valid"].Username,
                _accountData["account_valid"].Password
            );
            _loginPage.Logout();
            _loginPage.ConfirmLogout();
            Assert.IsTrue(_loginPage.IsLogoutSuccessful());
        }

        [Test, Order(7)]
        [Description("Verify that User cancel logout successfully")]
        public void TestCancelLogoutSuccessfully()
        {
            _loginPage.GoToUrl(loginUrl);
            _loginPage.Login(
                _accountData["account_valid"].Username,
                _accountData["account_valid"].Password
            );
            _loginPage.Logout();
            _loginPage.CancelLogout();
            Assert.IsTrue(_loginPage.IsLoggedout());
        }
    }
}
