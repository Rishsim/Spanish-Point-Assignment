using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Automation.Core
{
    public class ChromeBrowser
    {
        private static ChromeBrowser _instance;

        public static ChromeBrowser Instance
        {
            get
            {
                if (_instance == null)
                {
                    if (_instance == null)
                    {
                        _instance = Activator.CreateInstance<ChromeBrowser>();
                    }

                }
                return _instance;

            }
        }

        public IWebDriver GetBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("credentials_enable_service", false);         
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-web-security");
            options.AddArguments("--allow-running-insecure-content");
            return new ChromeDriver(options);
        }


    }
}