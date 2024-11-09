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
    public class RespondAssignmentTest : BaseTest
    {
        private LoginPage _loginPage;
        private ManageAssignmentPage _manageAssignmentPage;
        private Dictionary<string, Account> _staffAccount;

        [SetUp]
        public void Setup()
        {
            _loginPage = new LoginPage();
            _manageAssignmentPage = new ManageAssignmentPage();
            _staffAccount = JsonFileUtility.ReadAndParse<Dictionary<string, Account>>(
                FileConstants.AccountFilePath.GetAbsolutePath()
            );
        }

        [Test]
        [TestCase("account_001", "MW000091")]
        public void TestRespondToAssignment(string key, string code)
        {
            _loginPage.GoToUrl(loginUrl);
            _loginPage.Login(_staffAccount[key].Username, _staffAccount[key].Password);
            _manageAssignmentPage.AcceptAssignment(code);
            _manageAssignmentPage.VerifyAssignmentAccepted(code);
        }
    }
}
