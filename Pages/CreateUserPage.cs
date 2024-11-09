using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Core;
using AssetManagement.Model;
using OpenQA.Selenium;

namespace AssetManagement.Pages
{
    public class CreateUserPage : BasePage
    {
        private Element _firstNameTxtBox = new Element(By.Id("firstName"));
        private Element _lastNameTxtBox = new Element(By.Id("lastName"));
        private Element _dateOfBirthTxtBox = new Element(By.Id("dateOfBirth"));
        private Element _joinedDateTxtBox = new Element(By.Id("joinedDate"));
        private Element _typeDropdownList = new Element(By.XPath("//div[@name='type']"));
        private Element _locationDropdownList = new Element(By.XPath("//div[@name='locationId']"));
        private Element _saveBtn = new Element(By.Id("btn"));
        private string _genderRadioPattern = "//span[text()='{0}']";
        private string _typePattern = "//div[@title='{0}']/div";
        private string _locationPattern = "//div[text()='{0}']";

        public void CreateStaff(Staff staff)
        {
            var gender = new Element(By.XPath(String.Format(_genderRadioPattern, staff.Gender)));
            var type = new Element(By.XPath(String.Format(_typePattern, staff.Type)));
            var location = new Element(By.XPath(String.Format(_locationPattern, staff.Location)));

            _firstNameTxtBox.InputText(staff.FirstName);
            _lastNameTxtBox.InputText(staff.LastName);
            _dateOfBirthTxtBox.InputText(staff.DateOfBirth);
            _dateOfBirthTxtBox.InputText(Keys.Enter);
            gender.ClickOnElement();
            _joinedDateTxtBox.InputText(staff.JoinedDate);
            _joinedDateTxtBox.InputText(Keys.Enter);
            _typeDropdownList.ClickOnElement();
            type.ClickOnElement();
            if (staff.Type == "Admin")
            {
                _locationDropdownList.ClickOnElement();
                location.ClickOnElement();
            }
            _saveBtn.ClickOnElement();
        }
    }
}
