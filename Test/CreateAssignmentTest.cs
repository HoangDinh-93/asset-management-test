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
    public class CreateAssignmentTest : BaseTest
    {
        private LoginPage _loginPage;
        private ManageAssignmentPage _manageAssignmentPage;
        private CreateAssignmentPage _createAssignmentPage;
        private Dictionary<string, Assignment> _assignmentData;

        [SetUp]
        public void Setup()
        {
            _loginPage = new LoginPage();
            _manageAssignmentPage = new ManageAssignmentPage();
            _createAssignmentPage = new CreateAssignmentPage();
            _assignmentData = JsonFileUtility.ReadAndParse<Dictionary<string, Assignment>>(
                FileConstants.AssignmentFilePath.GetAbsolutePath()
            );
        }

        [Test]
        [TestCase("assignment001")]
        public void TestCreateNewAssignment(string assignment)
        {
            _loginPage.GoToUrl(loginUrl);
            _loginPage.Login(adminUsername, adminPassword);
            _manageAssignmentPage.GoToManageAssignmentPage();
            _manageAssignmentPage.GoToCreateAssignmentPage();
            _createAssignmentPage.CreateAssignment(_assignmentData[assignment]);
            _manageAssignmentPage.VerifyCreateResult(_assignmentData[assignment]);
        }
    }
}
