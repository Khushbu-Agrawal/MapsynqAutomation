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
    // Class provides all interactions with register page
    class RegisterPage : BasePage
    {
        // Constants
        private const String PAGE_TITLE = "Create your mapSYNQ account";

        // Constructor
        public RegisterPage(IWebDriver p_Driver)
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
    }
}
