using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Core.Utilities;
using Microsoft.Extensions.Configuration;

namespace AssetManagement.Test
{
    [SetUpFixture]
    public class Hooks
    {
        [OneTimeSetUp]
        public void MySetup()
        {
            TestContext.Progress.WriteLine("Global OnetimeSetUp");
            ConfigurationHelper.ReadConfiguration();
        }
    }
}
