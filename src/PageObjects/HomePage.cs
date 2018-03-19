using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using MapsynQ.PageObjects;

namespace MapsynQ.PageObjects
{
    // Class provides all interactions with home page of the application
    class HomePage : BasePage
    {
        private const String PAGE_TITLE = "mapSYNQ - Live Traffic Information Platform";

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Sign in')]")]
        private IWebElement signIn;

        // Constructor
        public HomePage(IWebDriver p_Driver)
        {
            driver = p_Driver;
            PageFactory.InitElements(driver, this);
        }

        public bool VerifyPage()
        {
            try
            {
                return (driver.Title.ToUpper() == PAGE_TITLE.ToUpper());
            }
               
            catch (Exception ex)
            {
                return LogError("Exception caught while performing VerifyPage(), error: " + ex.ToString());
            }
        }

        public SignInPage GoToSignInPage()
        {
            try
            {
                signIn.Click();
                return new SignInPage(driver);
            }
            catch (Exception ex)
            {
                LogError("Exception caught while performing GoToSignInPage, error: " + ex.ToString());
            }

            return null;
        }

    }
}
