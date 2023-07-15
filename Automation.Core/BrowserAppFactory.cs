using System;
using OpenQA.Selenium;


namespace Automation.Core
{
    public class BrowserAppFactory
    {


        private static BrowserAppFactory _instance;

        public static BrowserAppFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    if (_instance == null)
                    {
                        _instance = Activator.CreateInstance<BrowserAppFactory>();
                    }
                }
                return _instance;

            }
        }

        public IWebDriver GetDriver()
        {
            return ChromeBrowser.Instance.GetBrowser();
        }

        public void NavigateToUrl(string url, IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(12);
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Url = url;
        }

        public void CloseBrowser(IWebDriver driver)
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }

    }


}