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
    // Class provides all interactions with SignIn SuccessPage
    class SignInSuccessPage : BasePage
    {
        private const String PAGE_TITLE = "mapSYNQ - Live Traffic Information Platform";

        // Constructor
        public SignInSuccessPage(IWebDriver p_Driver)
        {
            driver = p_Driver;
            PageFactory.InitElements(driver, this);
        }

        public bool VerifySignInHomePage(String p_UserName)
        {
            try
            {
                IWebElement signInUsername = driver.FindElement(By.LinkText(p_UserName));
                return (signInUsername.Text == p_UserName);
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing VerifySignInHomePage(), error: " + ex.ToString());
            }

            return false;
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

            return false;
        }

    }
}
