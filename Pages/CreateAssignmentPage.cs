using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Core;
using AssetManagement.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V123.IndexedDB;

namespace AssetManagement.Pages
{
    public class CreateAssignmentPage : BasePage
    {
        private Element _userSearchBtn = new Element(
            By.XPath("//input[@name='userId']/following-sibling::span")
        );
        private Element _assetSearchBox = new Element(
            By.XPath("//h2[text()='Select Asset']/following-sibling::form//input")
        );
        private Element _userSearchBox = new Element(
            By.XPath("//h2[text()='Select User']/following-sibling::form//input")
        );
        private Element _assetSearchBtn = new Element(
            By.XPath("//input[@name='assetId']/following-sibling::span")
        );
        private Element _assignedDate = new Element(By.XPath("//input[@name='assignedDate']"));
        private Element _noteTxtArea = new Element(By.XPath("//textarea[@name='note']"));
        private Element _userSaveBtn = new Element(
            By.XPath(
                "//h2[text()='Select User']/ancestor::div[@class='ant-modal-content']//button[@type='submit']"
            )
        );
        private Element _assetSaveBtn = new Element(
            By.XPath(
                "//h2[text()='Select Asset']/ancestor::div[@class='ant-modal-content']//button[@type='submit']"
            )
        );
        private Element _assignmentSaveBtn = new Element(By.Id("btn"));
        private string _dataPattern = "//td[text()='{0}']/preceding-sibling::td//input/..";

        public void CreateAssignment(Assignment assignment)
        {
            var userSelect = new Element(By.XPath(String.Format(_dataPattern, assignment.User)));
            var assetSelect = new Element(By.XPath(String.Format(_dataPattern, assignment.Asset)));

            _userSearchBtn.ClickOnElement();
            _userSearchBox.InputText(assignment.User);
            _userSearchBox.InputText(Keys.Enter);
            userSelect.ClickOnElement();
            _userSaveBtn.ClickOnElement();
            _assetSearchBtn.ClickOnElement();
            _assetSearchBox.InputText(assignment.Asset);
            _assetSearchBox.InputText(Keys.Enter);
            assetSelect.ClickOnElement();
            _assetSaveBtn.ClickOnElement();
            _assignedDate.InputText(assignment.AssignedDate);
            _assignedDate.InputText(Keys.Tab);
            _noteTxtArea.InputText(assignment.Note);
            _assignmentSaveBtn.ClickOnElement();
        }
    }
}
