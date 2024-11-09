using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Core;
using AssetManagement.Core.Utilities;
using AssetManagement.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V123.IndexedDB;

namespace AssetManagement.Pages
{
    public class ManageUserPage : BasePage
    {
        private Element _createUserBtn = new Element(
            By.XPath("//span[text()='Create new user']/..")
        );

        private Element _searchBox = new Element(
            By.XPath("//input[@placeholder='Input search text']")
        );
        private Element _searchBtn = new Element(By.CssSelector(".ant-input-search-button"));
        private Element _disableBtn = new Element(
            By.XPath("//tbody/tr[1]//span[@aria-label='close-circle']/ancestor::button")
        );
        private Element _confirmDisableBtn = new Element(By.XPath("//span[text()='Disable']/.."));
        private Element _confirmCancelBtn = new Element(By.XPath("//span[text()='Cancel']/.."));
        private Element _emptyDataText = new Element(By.XPath("//div[text()='No data']"));
        private Element _userInfoTitle = new Element(
            By.XPath("//span[text()='Detail User Information']")
        );
        private string _labelPattern = "//div[text()='{0}']/following-sibling::div[1]";
        private string _firstRowData = "//tr[1]/td/div[contains(text(), '{0}')]";

        public void GoToCreateUserPage()
        {
            _createUserBtn.ClickOnElement();
        }

        public void SearchStaff(string searchData)
        {
            _searchBox.ClearText();
            _searchBox.InputText(searchData);
            _searchBox.InputText(Keys.Enter);
        }

        public void VerifyCreateResult(Staff staff)
        {
            var fullName = new Element(By.XPath(String.Format(_labelPattern, "Full Name")));
            var dateOfBirth = new Element(By.XPath(String.Format(_labelPattern, "Date of Birth")));
            var gender = new Element(By.XPath(String.Format(_labelPattern, "Gender")));
            var joinedDate = new Element(By.XPath(String.Format(_labelPattern, "Joined Date")));
            var type = new Element(By.XPath(String.Format(_labelPattern, "Type")));
            var location = new Element(By.XPath(String.Format(_labelPattern, "Location")));
            var firstRowData = new Element(By.XPath(String.Format(_firstRowData, staff.FirstName)));

            firstRowData.ClickOnElement();
            StringAssert.Contains(staff.FirstName, fullName.GetTextFromElement());
            StringAssert.Contains(staff.LastName, fullName.GetTextFromElement());
            StringAssert.AreEqualIgnoringCase(staff.DateOfBirth, dateOfBirth.GetTextFromElement());
            StringAssert.AreEqualIgnoringCase(staff.Gender.ToString(), gender.GetTextFromElement());
            StringAssert.AreEqualIgnoringCase(staff.JoinedDate, joinedDate.GetTextFromElement());
            StringAssert.AreEqualIgnoringCase(staff.Type.ToString(), type.GetTextFromElement());
            if (staff.Type.ToString() == "Staff")
            {
                StringAssert.AreEqualIgnoringCase(
                    ConfigurationHelper.GetConfig()["adminLocation"],
                    location.GetTextFromElement()
                );
            }
            else
            {
                StringAssert.AreEqualIgnoringCase(
                    staff.Location.ToString(),
                    location.GetTextFromElement()
                );
            }
        }

        public string GetStaffCode()
        {
            var staffCode = new Element(By.XPath(String.Format(_labelPattern, "Staff Code")));
            return staffCode.GetTextFromElement();
        }

        public void DisableStaff()
        {
            _disableBtn.ClickOnElement();
            _confirmDisableBtn.ClickOnElement();
        }

        public bool IsSearchResultEmpty()
        {
            return _emptyDataText.IsElementDisplayed();
        }
    }
}
