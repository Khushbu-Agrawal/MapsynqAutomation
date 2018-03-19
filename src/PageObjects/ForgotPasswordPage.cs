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
    // Class provides all interactions with ForgotPassword page
    class ForgotPasswordPage : BasePage
    {
        // Constants
        private const String PAGE_TITLE = "Forgot your Password?";
        private const String FORGOT_PASSWORD_ERROR_MES = "Invalid email address";

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Forgot your Password?')]")]
        private IWebElement forgotPassword = null;

        [FindsBy(How = How.Id, Using = "name")]
        private IWebElement userName = null;

        [FindsBy(How = How.Name, Using = "commit")]
        private IWebElement resetPasswordButton = null;

        [FindsBy(How = How.Id, Using = "error")]
        private IWebElement forgotPasswordError = null;

        // Constructor
        public ForgotPasswordPage(IWebDriver p_Driver)
        {
            driver = p_Driver;
            PageFactory.InitElements(driver, this);
        }

        public bool VerifyPage()
        {
            try
            {
                return (forgotPassword.Text.ToUpper() == PAGE_TITLE.ToUpper());
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing VerifyPage(), error: " + ex.ToString());
            }
        }

        public bool SetEmailaddress(String p_UserName)
        {
            try
            {
                if (!userName.Enabled || !userName.Displayed)
                {
                    return LogError("Username text box is disabled or invisible!");
                }

                userName.SendKeys(Keys.Clear);
                userName.SendKeys(p_UserName);
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing SetUserName(), error: " + ex.ToString());
            }

            return true;
        }

        public String GetForgotPasswordError()
        {
            try
            {
                return forgotPasswordError.Text.ToUpper();
            }
            catch (Exception ex)
            {
                LogError("Exception caught while performing GetForgotPasswordError(), error: " + ex.ToString());
            }

            return null;
        }

        public bool VerifyForgotPasswordErrorMessage()
        {
            return (GetForgotPasswordError() == FORGOT_PASSWORD_ERROR_MES.ToUpper());
        }

        public SignInPage ClickResetPasswordButton()
        {
            try
            {
                if (!resetPasswordButton.Enabled || !resetPasswordButton.Displayed)
                {
                    LogError("Reset Password button is disabled or invisible");
                    return null;
                }

                resetPasswordButton.Click();
                if (VerifyForgotPasswordErrorMessage())
                {
                    return null;
                }
                return new SignInPage(driver);
            }
            catch (Exception ex)
            {
                LogError("Exception caught while performing ClickResetPasswordButton(), error: " + ex.ToString());
            }

            return null;
        }

    }
}
