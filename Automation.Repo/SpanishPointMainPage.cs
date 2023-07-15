using System;
using Automation.Core;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;

namespace Automation.Repo
{

    public class SpanishPointMainPage : BasePage
    {

        readonly IWebDriver _driver = null;

        #region Constructors

        public SpanishPointMainPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        #endregion

        #region ObjectRepository

        private IList<IWebElement> SolutionAndServicesTab => _driver.AllCss("li[class ^='menu-item menu-item-type-custom']", Until.Visible);
        private IList<IWebElement> MordernWorkOption => _driver.AllLinkText("Modern Work", Until.Visible);
        private IWebElement ContentAndCollaborationTab => _driver.LinkText("Content & Collaboration", Until.Visible);
        private IWebElement ContentAndCollaborationHeaderText => _driver.Css("div[class ='vc_tta-panel vc_active'] h3", Until.Visible);
        private IWebElement ContentAndCollaborationParagraph => _driver.Css("div[class ='vc_tta-panel vc_active'] p", Until.Visible);

        #endregion

        #region Test Cases Functions

        public void ContentAndCollaborationText()
        {
            _driver.EnsureReadyState();

            ExecuteStep("Mouse Hover On Solution & Services Tab", () => MouseHover(SolutionAndServicesTab[0], _driver));

            ExecuteStep("Clicking on Modern Work Option", () => ClickOnElement(MordernWorkOption[0], _driver));

            ExecuteStep("Scroll Window To Focus on Content & Collaboration Tab Element", () => ScrollWindowDown(_driver));

            ExecuteStep("Clicking on Content & Collaboration Tab", () => ClickOnElement(ContentAndCollaborationTab, _driver));

            ExecuteStep("Scroll Window To Focus on Content And Collaboration Header Text Element", () => ScrollWindowDown(_driver));

            ExecuteStep("Validating the test case if Header Is Displayed Correctly",
                      () => AssertIsTrue(ContentAndCollaborationHeaderText.Text == "Content & Collaboration", "Text Not Correct"));

            ExecuteStep("Validating the test case if Paragraph Is Displayed Correctly",
                      () => AssertIsTrue(ContentAndCollaborationParagraph.Text.StartsWith("Spanish Point customers tell us that people are their most important asset"), "Text Not Correct"));

        }

        #endregion

    }
}




