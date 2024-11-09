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

namespace AssetManagement.Test
{
    [TestFixture]
    public class DisableUserTest : BaseTest
    {
        private LoginPage _loginPage;
        private ManageUserPage _manageUserPage;
        private Dictionary<string, Account> _accountData;

        [SetUp]
        public void Setup()
        {
            _loginPage = new LoginPage();
            _manageUserPage = new ManageUserPage();
            _accountData = JsonFileUtility.ReadAndParse<Dictionary<string, Account>>(
                FileConstants.AccountFilePath.GetAbsolutePath()
            );
        }

        [Test, Order(8)]
        [TestCase("account_valid", "SD0104")]
        [Description("Verify that Admin User disables Staff User successfully")]
        public void TestDisableUserSuccessfully(string key, string searchData)
        {
            _loginPage.GoToUrl(loginUrl);
            _loginPage.Login(_accountData[key].Username, _accountData[key].Password);
            _manageUserPage.GoToManageUserPage();
            _manageUserPage.SearchStaff(searchData);
            _manageUserPage.DisableStaff();
            _manageUserPage.SearchStaff(searchData);
            Assert.IsTrue(_manageUserPage.IsSearchResultEmpty());
        }
    }
}
