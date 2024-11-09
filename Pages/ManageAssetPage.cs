using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Core;
using AssetManagement.Model;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AssetManagement.Pages
{
    public class ManageAssetPage : BasePage
    {
        private Element _createAssetBtn = new Element(
            By.XPath("//span[text()='Create new asset']/..")
        );
        private Element _firstRowData = new Element(By.XPath("//tr[1]/td[1]"));
        private string _dataPattern = "//div[text()='{0}']/following-sibling::div[1]";

        public void GoToCreateAssetPage()
        {
            _createAssetBtn.ClickOnElement();
        }

        public void VerifyCreateResult(Asset asset)
        {
            var assetName = new Element(By.XPath(String.Format(_dataPattern, "Asset Name")));
            var category = new Element(By.XPath(String.Format(_dataPattern, "Category")));
            var specification = new Element(By.XPath(String.Format(_dataPattern, "Specification")));
            var installedDate = new Element(By.XPath(String.Format(_dataPattern, "Install Date")));
            var state = new Element(By.XPath(String.Format(_dataPattern, "State")));

            _firstRowData.WaitForElementTextToChange();
            _firstRowData.ClickOnElement();

            var result = new Asset()
            {
                Name = assetName.GetTextFromElement(),
                Category = category.GetTextFromElement(),
                Specification = specification.GetTextFromElement(),
                InstalledDate = installedDate.GetTextFromElement(),
                State = state.GetTextFromElement()
            };

            result.Should().BeEquivalentTo(asset);
        }

        public string GetAssetCode()
        {
            var assetCode = new Element(By.XPath(String.Format(_dataPattern, "Asset Code")));
            return assetCode.GetTextFromElement();
        }
    }
}
