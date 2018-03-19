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
    // Class provides all interactions with SignIn page
    class SignInPage : BasePage
    {
        // Constants
        private const String PAGE_TITLE = "Sign In";
        private const String SIGN_IN_ERROR_MES = "Invalid user/password combination";
        private const String SIGN_IN_ERROR_MES_INACTIVE_USER = "Your account is not activated yet, contact support@mapsynq.com";
        private const String SIGN_IN_PASSWORD_RESET_MES = "A new password has been sent to your mail. <b>Please check your Spam folder and add our address to your Address Book</b>";

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Sign In')]")]
        private IWebElement signInText = null;

        [FindsBy(How = How.Id, Using = "name")]
        private IWebElement userName = null;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement password = null;

        [FindsBy(How = How.XPath, Using = "//input[@value='Sign In']")]
        private IWebElement signInButton = null;

        [FindsBy(How = How.Id, Using = "notice")]
        private IWebElement signInError = null;

        [FindsBy(How = How.XPath, Using = "//a[@href='forgot_password']")]
        private IWebElement forgotPassword = null;


        // Constructor
        public SignInPage(IWebDriver p_Driver)
        {
            driver = p_Driver;
            PageFactory.InitElements(driver, this);
        }

        public bool VerifyPage()
        {
            try
            {
                return (signInText.Text.ToUpper() == PAGE_TITLE.ToUpper());
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing VerifyPage(), error: " + ex.ToString());
            }
        }      

        public bool SetUserName(String p_UserName)
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

        public bool SetPassword(String p_Password)
        {
            try
            {
                if (!password.Enabled)
                {
                    return LogError("Password text box is disabled!");
                }

                password.SendKeys(Keys.Clear);
                password.SendKeys(p_Password);
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing SetPassword(), error: " + ex.ToString());
            }

            return true;
        }

        public bool ClickSignInButton()
        {
            try
            {
                if (!signInButton.Enabled || !signInButton.Displayed)
                {
                    return LogError("Sign In button is disabled or invisible");
                }

                signInButton.Click();
                return true;
            }
            catch (Exception ex)
            {
                LogError("Exception caught while performing ClickSignInButton(), error: " + ex.ToString());
            }

            return false;
        }

        public String GetSignInError()
        {
            try
            {
                return signInError.Text.ToUpper();
            }
            catch (Exception ex)
            {
                LogError("Exception caught while performing GetSignInError(), error: " + ex.ToString());
            }

            return null;
        }

        public bool VerifySignInErrorMessage()
        {
            return (GetSignInError()== SIGN_IN_ERROR_MES.ToUpper());
        }

        public bool VerifySignInErrorMessageInactiveUser()
        {
            return (GetSignInError() == SIGN_IN_ERROR_MES_INACTIVE_USER.ToUpper());
        }

        public bool VerifySignInPasswordResetMessage()
        {
            return (GetSignInError() == SIGN_IN_PASSWORD_RESET_MES.ToUpper());
        }

        public bool ClickSignOut()
        {
            try
            {
                //IList<IWebElement> listscollections = driver.FindElements(By.TagName("ul"));
                //IList<IWebElement> list1 = listscollections[5].FindElements(By.TagName("li"));
                IWebElement list = driver.FindElement(By.XPath("/html/body/ul[6]"));
                IWebElement item = list.FindElement(By.XPath("//*[contains(text(),'Sign out')]"));
                item.Click();
                IList<IWebElement> listitems = list.FindElements(By.TagName("li"));
                int count = listitems.Count;
                listitems[0].Click();
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing ClickSignOut(), error: " + ex.ToString());
            }

            return true;
        }


        public ForgotPasswordPage GoToForgotPasswordPage()
        {
            try
            {
                if (!forgotPassword.Enabled || !forgotPassword.Displayed)
                {
                    LogError("Forgot Password Link is disabled or invisible");
                    return null;
                }

                forgotPassword.Click();
                return new ForgotPasswordPage(driver);
            }
            catch (Exception ex)
            {
                LogError("Exception caught while performing GoToForgotPasswordPage(), error: " + ex.ToString());
            }

            return null;
        }
    }
}
