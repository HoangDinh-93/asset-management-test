using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Core;
using AssetManagement.Core.Utilities;
using AssetManagement.Model;
using NUnit.Framework;

namespace AssetManagement.Test
{
    public abstract class BaseTest
    {
        protected string loginUrl = ConfigurationHelper.GetConfig()["loginUrl"];
        protected string adminUsername = ConfigurationHelper.GetConfig()["adminUsername"];
        protected string adminPassword = ConfigurationHelper.GetConfig()["adminPassword"];
        protected string browserType = ConfigurationHelper.GetConfig()["browser"];
        protected bool isHeadless = bool.Parse(ConfigurationHelper.GetConfig()["headless"]);
        protected Staff _staffData;

        [SetUp]
        public void Setup()
        {
            DriverManager.GetDriver(isHeadless, browserType);
        }

        [TearDown]
        public void TearDown()
        {
            DriverManager.QuitDriver();
        }
    }
}
