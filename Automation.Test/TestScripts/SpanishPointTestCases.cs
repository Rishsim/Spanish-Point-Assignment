using Automation.Core;
using Automation.Repo;
using NUnit.Framework;
using System;

namespace Automation.Test.TestScripts
{
    public class SpanishPointTestCases : BaseTest
    {

        [Test]
        public void ValidateContentAndCollaborationHeaderAndParagraphText()
        {
            try
            {
                ExecuteStep("Navigate to URL", () => BrowserAppFactory.Instance.NavigateToUrl(ConfigReader.Url, Driver));
                var pgSpanishPoint = Page<SpanishPointMainPage>(Driver);
                ExecuteStep("Navigate To Content And Collaboration Text", () => pgSpanishPoint.ContentAndCollaborationText());
                ExecuteStep("Close Browser", () => BrowserAppFactory.Instance.CloseBrowser(Driver));
            }
            catch (Exception ex)
            {
                ExecuteStep("Close Browser", () => BrowserAppFactory.Instance.CloseBrowser(Driver));
                Assert.Fail(ex.StackTrace);
            }

        }

    }
}

