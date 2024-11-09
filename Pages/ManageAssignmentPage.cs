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
    public class ManageAssignmentPage : BasePage
    {
        private Element _searchBox = new Element(
            By.XPath("//input[@placeholder='Input search text']")
        );
        private Element _checkBtn = new Element(
            By.XPath("//span[@aria-label='check']/ancestor::button")
        );
        private Element _returnBtn = new Element(
            By.XPath("//span[@aria-label='undo']/ancestor::button")
        );
        private Element _confirmOkBtn = new Element(By.XPath("//span[text()='Yes']/.."));
        private Element _confirmAcceptBtn = new Element(By.XPath("//span[text()='Accept']/.."));
        private Element _firstRowData = new Element(By.XPath("//tr[1]/td[1]"));
        private string _dataPattern = "//div[text()='{0}']/following-sibling::div[1]";
        private Element _createAssignmentBtn = new Element(
            By.XPath("//span[text()='Create new assignment']/..")
        );
        private string _checkBtnPattern =
            "//td[text()='{0}']/..//span[@aria-label='check']/ancestor::button";
        private string _statePattern = "//td[text()='{0}']/../td[6]";

        public void GoToCreateAssignmentPage()
        {
            _createAssignmentBtn.ClickOnElement();
        }

        public void SearchForAssignment(string keyword)
        {
            _searchBox.InputText(keyword);
            _searchBox.InputText(Keys.Enter);
        }

        public void MakeRequestForReturning(string keyword)
        {
            SearchForAssignment(keyword);
            _returnBtn.ClickOnElement();
            _confirmOkBtn.ClickOnElement();
            _confirmOkBtn.WaitForElementDisappear();
        }

        public void AcceptAssignment(string key)
        {
            var checkBtn = new Element(By.XPath(String.Format(_checkBtnPattern, key)));
            checkBtn.ClickOnElement();
            _confirmAcceptBtn.ClickOnElement();
            _confirmAcceptBtn.WaitForElementDisappear();
        }

        public void VerifyCreateResult(Assignment assignment)
        {
            var assetCode = new Element(By.XPath(String.Format(_dataPattern, "Asset Code")));
            var userName = new Element(By.XPath(String.Format(_dataPattern, "Assigned To")));
            var assignedDate = new Element(By.XPath(String.Format(_dataPattern, "Assigned Date")));
            var note = new Element(By.XPath(String.Format(_dataPattern, "Note")));

            _firstRowData.WaitForElementTextToChange();
            _firstRowData.ClickOnElement();

            assetCode.GetTextFromElement().ToLower().Should().Be(assignment.Asset.ToLower());
            // userName.GetTextFromElement().ToLower().Should().Be(assignment.User.ToLower());
            note.GetTextFromElement().ToLower().Should().Be(assignment.Note.ToLower());
            assignedDate
                .GetTextFromElement()
                .ToLower()
                .Should()
                .Be(assignment.AssignedDate.ToLower());
        }

        public void VerifyAssignmentAccepted(string key)
        {
            var state = new Element(By.XPath(String.Format(_statePattern, key)));
            state.WaitForElementTextToChange();
            state.GetTextFromElement().Should().Be("Accepted");
        }
    }
}
