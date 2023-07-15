using System;
using System.Diagnostics;
using NUnit.Framework;
using OpenQA.Selenium;


namespace Automation.Core
{
    public class BaseTest
    {

        protected T Page<T>(IWebDriver driver) where T : BasePage
        {
            Type pageType = typeof(T);
            if (pageType != null)
            {
                T ob = (T)Activator.CreateInstance(pageType, new object[] { driver });
                return ob;
            }
            else
            {
                return null;
            }
        }

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

        protected IWebDriver Driver;

        [OneTimeSetUp]
        public void SetUpOnce()
        {

            Driver = BrowserAppFactory.Instance.GetDriver();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {

            foreach (var process in Process.GetProcesses())
            {
                if (process.ProcessName.Contains("chromedriver.exe"))
                {
                    process.Kill();
                    //-force -  kill other running instances of Browser Local
                }
            }

        }

    }

}
