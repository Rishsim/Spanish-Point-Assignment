using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Automation.Core
{
    public class BasePage
    {

        protected void ExecuteStep(string message, Action method)
        {
            TestContext.Write($"Step: {message}");
            try
            {
                method();
                TestContext.WriteLine(" - passed");

            }
            catch (Exception)
            {
                TestContext.WriteLine(" - failed");
                throw;
            }
        }
        protected void ClickOnElement(IWebElement webElement, IWebDriver driver) => new Actions(driver).MoveToElement(webElement).Click().Perform();
        protected void ScrollWindowDown(IWebDriver driver)
        {
            IJavaScriptExecutor jscript = driver as IJavaScriptExecutor;

            jscript.ExecuteScript("window.scrollTo(0, 1050);");
        }
        protected void MouseHover(IWebElement webElement, IWebDriver driver)
        {
            new Actions(driver).MoveToElement(webElement).Build().Perform();
            
        }
        protected static void AssertIsTrue(bool value, string message) => Assert.IsTrue(value, message);

    }
}
