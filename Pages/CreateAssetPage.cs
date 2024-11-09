using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Core;
using AssetManagement.Model;
using OpenQA.Selenium;

namespace AssetManagement.Pages
{
    public class CreateAssetPage : BasePage
    {
        private Element _nameTxtBox = new Element(By.Id("assetName"));
        private Element _categoryDropdownList = new Element(By.CssSelector(".ant-select-selector"));
        private Element _addNewCategoryBtn = new Element(
            By.XPath("//span[text()='Add new category']/..")
        );
        private Element _specificationTxtArea = new Element(By.Id("specification"));
        private Element _installedDate = new Element(By.Id("installedDate"));
        private Element _saveBtn = new Element(By.Id("btn"));
        private string _statePattern = "//span[text()='{0}']";
        private string _categoryOption = "//div[@title='{0}']";

        public void CreateAsset(Asset asset)
        {
            var option = new Element(By.XPath(String.Format(_categoryOption, asset.Category)));
            var state = new Element(By.XPath(String.Format(_statePattern, asset.State)));

            _nameTxtBox.InputText(asset.Name);
            _categoryDropdownList.ClickOnElement();
            option.ClickOnElement();
            _specificationTxtArea.InputText(asset.Specification);
            _installedDate.InputText(asset.InstalledDate);
            state.ClickOnElement();
            _saveBtn.ClickOnElement();
        }
    }
}
