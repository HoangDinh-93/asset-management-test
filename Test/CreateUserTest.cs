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
    public class CreateUserTest : BaseTest
    {
        private LoginPage _loginPage;
        private ManageUserPage _manageUserPage;
        private CreateUserPage _createUserPage;
        private Dictionary<string, Staff> _staffData;
        private Staff _fakeStaffData;

        [SetUp]
        public void Setup()
        {
            _loginPage = new LoginPage();
            _manageUserPage = new ManageUserPage();
            _createUserPage = new CreateUserPage();
            _staffData = JsonFileUtility.ReadAndParse<Dictionary<string, Staff>>(
                FileConstants.StaffFilePath.GetAbsolutePath()
            );
            _fakeStaffData = new Staff()
            {
                FirstName = Faker.NameFaker.FirstName(),
                LastName = Faker.NameFaker.LastName(),
                Gender = "Male",
                DateOfBirth = "09/03/2001",
                JoinedDate = "10/10/2024",
                Type = "Staff",
                Location = "HCM"
            };
        }

        [Test, Order(9)]
        [Description("Verify that Admin User creates new Staff User successfully")]
        public void TestCreateStaffSuccessfully()
        {
            _loginPage.GoToUrl(loginUrl);
            _loginPage.Login(adminUsername, adminPassword);
            _manageUserPage.GoToManageUserPage();
            _manageUserPage.GoToCreateUserPage();
            _createUserPage.CreateStaff(_fakeStaffData);
            _manageUserPage.VerifyCreateResult(_fakeStaffData);
        }

        [Test, Order(10)]
        [TestCase("admin001")]
        [Description("Verify that Admin User creates new Admin User successfully")]
        public void TestCreateAdminSuccessfully(string key)
        {
            _loginPage.GoToUrl(loginUrl);
            _loginPage.Login(adminUsername, adminPassword);
            _manageUserPage.GoToManageUserPage();
            _manageUserPage.GoToCreateUserPage();
            _createUserPage.CreateStaff(_staffData[key]);
            _manageUserPage.VerifyCreateResult(_staffData[key]);
        }
    }
}
