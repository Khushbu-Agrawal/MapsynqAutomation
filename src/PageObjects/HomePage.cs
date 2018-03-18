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
        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Sign in')]")]
        private IWebElement signin;

        // Constructor
        public HomePage(IWebDriver p_Driver)
        {
            driver = p_Driver;
            PageFactory.InitElements(driver, this);
        }

        public SignInPage GoToSignInPage()
        {
            try
            {
                signin.Click();
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
