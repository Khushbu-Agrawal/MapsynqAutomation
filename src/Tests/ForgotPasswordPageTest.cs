using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

using MapsynQ.PageObjects;
using MapsynQ.TestData;

namespace MapsynQ.Tests
{
    [TestClass]
    public class ForgotPasswordPageTest : TestBase
    {
        // Test data for this class
        private SignInTestData testData = new SignInTestData("ForgotPassword.json");
        private IWebDriver driver;

        //////////////////////////////////////////////////////////////////////

        [TestInitialize]
        public void TestInit()
        {
            driver = InitDriver(); // Setup driver
        }

        [TestCleanup]
        public void TestClean()
        {
            driver.Close(); // Cleanup driver
        }

        ////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void TestForgotPassswordWithValidEmailId()
        {
            // Verify TestData is loaded
            Assert.IsTrue(testData.isLoaded, "TestData load FAILED");

            // Verify test data
            SignInData signInData = testData.GetTestData("TestForgotPassswordWithValidEmailId");
            Assert.IsNotNull(testData, "TestData load FAILED");

            HomePage homePage = new HomePage(driver);
            bool isPageVerified = homePage.VerifyPage();
            Assert.IsTrue(isPageVerified, "VerifyPage() FAILED");

            SignInPage signInPage = homePage.GoToSignInPage();
            Assert.IsNotNull(signInPage, "GoToSignInPage() FAILED");

            isPageVerified = signInPage.VerifyPage();
            Assert.IsTrue(isPageVerified, "VerifyPage() FAILED");

            ForgotPasswordPage forgotPasswordPage = signInPage.GoToForgotPasswordPage();
            Assert.IsNotNull(forgotPasswordPage, "GoToForgotPasswordPage() FAILED");

            isPageVerified = forgotPasswordPage.VerifyPage();
            Assert.IsTrue(isPageVerified, "VerifyPage() FAILED");

            Assert.IsTrue(forgotPasswordPage.SetEmailaddress(signInData.userName), "SetEmailaddress() FAILED");
            signInPage = forgotPasswordPage.ClickResetPasswordButton();
            Assert.IsNotNull(signInPage, "ClickResetPasswordButton() FAILED");

            isPageVerified = signInPage.VerifyPage();
            Assert.IsTrue(isPageVerified, "VerifyPage() FAILED");

            isPageVerified = signInPage.VerifySignInPasswordResetMessage();
            Assert.IsTrue(isPageVerified, "VerifySignInPasswordResetMessage() FAILED");
        }

        public void TestForgotPassswordWithInvalidEmailId()
        {
            // Verify TestData is loaded
            Assert.IsTrue(testData.isLoaded, "TestData load FAILED");

            // Verify test data
            SignInData signInData = testData.GetTestData("TestForgotPassswordWithInvalidEmailId");
            Assert.IsNotNull(testData, "TestData load FAILED");

            HomePage homePage = new HomePage(driver);
            bool isPageVerified = homePage.VerifyPage();
            Assert.IsTrue(isPageVerified, "VerifyPage() FAILED");

            SignInPage signInPage = homePage.GoToSignInPage();
            Assert.IsNotNull(signInPage, "GoToSignInPage() FAILED");

            isPageVerified = signInPage.VerifyPage();
            Assert.IsTrue(isPageVerified, "VerifyPage() FAILED");

            ForgotPasswordPage forgotPasswordPage = signInPage.GoToForgotPasswordPage();
            Assert.IsNotNull(forgotPasswordPage, "GoToForgotPasswordPage() FAILED");

            isPageVerified = forgotPasswordPage.VerifyPage();
            Assert.IsTrue(isPageVerified, "VerifyPage() FAILED");

            Assert.IsTrue(forgotPasswordPage.SetEmailaddress(signInData.userName), "SetEmailaddress() FAILED");
            signInPage = forgotPasswordPage.ClickResetPasswordButton();
            Assert.IsNotNull(signInPage, "ClickResetPasswordButton() FAILED");

            isPageVerified = forgotPasswordPage.VerifyPage();
            Assert.IsTrue(isPageVerified, "VerifyPage() FAILED");

            isPageVerified = forgotPasswordPage.VerifyForgotPasswordErrorMessage();
            Assert.IsTrue(isPageVerified, "VerifyForgotPasswordErrorMessage() FAILED");
        }

    }
}
