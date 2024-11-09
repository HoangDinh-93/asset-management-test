using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Core;
using FluentAssertions;
using OpenQA.Selenium;

namespace AssetManagement.Pages
{
    public class RequestForReturningPage : BasePage
    {
        private Element _searchBox = new Element(
            By.XPath("//input[@placeholder='Input search text']")
        );
        private Element _firstRowState = new Element(By.CssSelector("tr > td:nth-child(8)"));

        public void SearchForRequest(string keyword)
        {
            _searchBox.InputText(keyword);
            _searchBox.InputText(Keys.Enter);
        }

        public void VerifyCreateReturningRequest(string keyword)
        {
            SearchForRequest(keyword);
            _firstRowState.GetTextFromElement().Should().Be("Waiting for returning");
        }
    }
}
