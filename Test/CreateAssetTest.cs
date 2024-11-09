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
    public class CreateAssetTest : BaseTest
    {
        private LoginPage _loginPage;
        private ManageAssetPage _manageAssetPage;
        private CreateAssetPage _createAssetPage;
        private Dictionary<string, Asset> _assetData;
        private Asset _fakeAssetData;

        [SetUp]
        public void Setup()
        {
            _loginPage = new LoginPage();
            _manageAssetPage = new ManageAssetPage();
            _createAssetPage = new CreateAssetPage();

            _assetData = JsonFileUtility.ReadAndParse<Dictionary<string, Asset>>(
                FileConstants.AssetFilePath.GetAbsolutePath()
            );
        }

        [Test]
        public void TestCreateAssetSuccessfully()
        {
            _loginPage.GoToUrl(loginUrl);
            _loginPage.Login(adminUsername, adminPassword);
            _manageAssetPage.GoToManageAssetPage();
            _manageAssetPage.GoToCreateAssetPage();
            _createAssetPage.CreateAsset(_assetData["asset001"]);
            _manageAssetPage.VerifyCreateResult(_assetData["asset001"]);
        }
    }
}
