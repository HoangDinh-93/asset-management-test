using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Pages;
using NUnit.Framework;

namespace AssetManagement.Test
{
    public class CreateReturningRequestTest : BaseTest
    {
        private LoginPage _loginPage;
        private ManageAssignmentPage _manageAssignmentPage;
        private RequestForReturningPage _requestForReturningPage;

        [SetUp]
        public void Setup()
        {
            _loginPage = new LoginPage();
            _manageAssignmentPage = new ManageAssignmentPage();
            _requestForReturningPage = new RequestForReturningPage();
        }

        [Test]
        [TestCase("MW000095")]
        public void TestRequestForReturningAdmin(string keyword)
        {
            _loginPage.GoToUrl(loginUrl);
            _loginPage.Login(adminUsername, adminPassword);
            _manageAssignmentPage.GoToManageAssignmentPage();
            _manageAssignmentPage.MakeRequestForReturning(keyword);
            _requestForReturningPage.GoToRequestForReturningPage();
            _requestForReturningPage.VerifyCreateReturningRequest(keyword);
        }
    }
}
