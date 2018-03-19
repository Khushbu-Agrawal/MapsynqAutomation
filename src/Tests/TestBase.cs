using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using MapsynQ.PageObjects;

using MapsynqAutomation.src.Config;

namespace MapsynQ.Tests
{
    // Base class to serve all test classes
    public class TestBase
    {
        // Constants
        private const String CHROME = "Chrome";
        private const String FIREFOX = "Firefox";
        // @todo - add other supporting browsers.

        // Returns driver instance
        public IWebDriver InitDriver()
        {
            IWebDriver driver = null;
            switch(TestConfig.browser)
            {
                case CHROME:
                    driver = new ChromeDriver();
                    break;
                case FIREFOX:
                    driver = new FirefoxDriver();
                    break;
                default:
                    Console.WriteLine("Error: Unknown browser detected !!!");
                    return driver;
            }

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(TestConfig.url);

            return driver;
        }

    }
}
