using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Automation.Core
{
    public enum Until
    {
        Visible,
        AllVisible,
        Exists
    }

    public static class ObjectRetrievalExtensions
    {
        private const int WaitTime = 15;

        public static void EnsureReadyState(this IWebDriver driver)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(WaitTime)).Until(
                d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

            driver.Css("a[id ='wt-cli-accept-btn']", Until.Visible).Click();
        }

        public static IWebElement GetNativeElement(this IWebDriver driver, By by, Until until = Until.Exists,
            int waitTime = WaitTime)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
            switch (until)
            {
                case Until.Visible:
                    return wait.Until(ExpectedConditions.ElementIsVisible(by));

                default:
                    return wait.Until(ExpectedConditions.ElementExists(by));
            }
        }

        public static IList<IWebElement> GetNativeElements(this IWebDriver driver, By by, Until until = Until.Exists, int waitTime = WaitTime)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
            switch (until)
            {

                case Until.AllVisible:
                    return wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));

                default:
                    return wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));

            }
        }

        public static IWebElement Css(this IWebDriver driver, string cssSelector, Until until = Until.Exists, int waitTime = WaitTime)
            => driver.GetNativeElement(By.CssSelector(cssSelector), until, waitTime);

        public static IList<IWebElement> AllCss(this IWebDriver driver, string cssSelector, Until until = Until.Exists, int waitTime = WaitTime)
            => driver.GetNativeElements(By.CssSelector(cssSelector), until, waitTime);

        public static IWebElement LinkText(this IWebDriver driver, string text, Until until = Until.Exists, int waitTime = WaitTime)
            => driver.GetNativeElement(By.LinkText(text), until, waitTime);

        public static IList<IWebElement> AllLinkText(this IWebDriver driver, string text, Until until = Until.Exists, int waitTime = WaitTime)
            => driver.GetNativeElements(By.LinkText(text), until, waitTime);

  
    }
}