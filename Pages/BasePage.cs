using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Core;
using OpenQA.Selenium;

namespace AssetManagement.Pages
{
    public abstract class BasePage
    {
        protected Element Username = new Element(By.XPath("//div[@class='ant-space-item']"));
        protected Element logoutBtn = new Element(By.XPath("//button[text()='Logout']"));
        protected Element confirmOk = new Element(By.XPath("//button[text()='Log out']"));
        protected Element confirmCancel = new Element(By.XPath("//button[text()='Cancel']"));
        protected Element homeTab = new Element(By.XPath("//a/p[text()='Home']"));
        protected Element manageUserTab = new Element(By.XPath("//a/p[text()='Manage User']"));
        protected Element manageAssignmentTab = new Element(
            By.XPath("//a/p[text()='Manage Assignment']")
        );
        protected Element manageAssetTab = new Element(By.XPath("//a/p[text()='Manage Asset']"));
        protected Element requestForReturningTab = new Element(
            By.XPath("//p[text()='Request for Returning']")
        );

        // protected BasePage() { }

        public void GoToUrl(string url)
        {
            DriverManager.GetDriver().Url = url;
        }

        public void Logout()
        {
            Username.ClickOnElement();
            logoutBtn.ClickOnElement();
        }

        public void ConfirmLogout()
        {
            confirmOk.ClickOnElement();
        }

        public void CancelLogout()
        {
            confirmCancel.ClickOnElement();
        }

        public bool IsLoggedout()
        {
            return Username.IsElementDisplayed();
        }

        public void GoToManageUserPage()
        {
            manageUserTab.ClickOnElement();
        }

        public void GoToManageAssetPage()
        {
            manageAssetTab.ClickOnElement();
        }

        public void GoToManageAssignmentPage()
        {
            manageAssignmentTab.ClickOnElement();
        }

        public void GoToRequestForReturningPage()
        {
            requestForReturningTab.ClickOnElement();
        }
    }
}
