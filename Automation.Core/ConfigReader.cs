using System;
using System.Configuration;

namespace Automation.Core
{

    public class ConfigReader
    {
        public static string Url => ConfigurationManager.AppSettings["URL"];

    }
}