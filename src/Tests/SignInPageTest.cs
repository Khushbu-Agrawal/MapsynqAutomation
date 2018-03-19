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
    public class SignInPageTest : TestBase
    {
        // Test data for this class
        private SignInTestData testData = new SignInTestData("SignIn.json");
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

        // Helper test function to perform common SignIn routine
        private SignInPage PerformSignIn(SignInData p_SignInData)
        {
            // Verify driver is initialized
            Assert.IsNotNull(driver, "Driver initialization FAILED");

            // Verify input SignInData
            Assert.IsNotNull(p_SignInData, "TestData load FAILED");

            // Verify Home page is loaded
            HomePage homePage = new HomePage(driver);
            Assert.IsTrue(homePage.VerifyPage(), "HomePage VerifyPage() FAILED");

            // Verify SignIn page is loaded
            SignInPage signInPage = homePage.GoToSignInPage();
            Assert.IsNotNull(signInPage, "GoToSignInPage() FAILED");
            Assert.IsTrue(signInPage.VerifyPage(), "SignInPage VerifyPage() FAILED");

            // Verify test data are set
            Assert.IsTrue(signInPage.SetUserName(p_SignInData.userName), "SetUserName() FAILED");
            Assert.IsTrue(signInPage.SetPassword(p_SignInData.password), "SetPassword() FAILED");

            // Verify SigIn button is clicked
            Assert.IsTrue(signInPage.ClickSignInButton(), "ClickSignInButton() FAILED");

            return signInPage;
        }

        [TestMethod]
        public void TestSignIn()
        {
            // Verify TestData is loaded
            Assert.IsNotNull(testData, "TestData load FAILED");

            // Perform SigIn
            SignInData signInData = testData.GetTestData("TestSignIn");
            PerformSignIn(signInData);

            // Verify SignInSuccessPage is loaded
            SignInSuccessPage signInSuccessPage = new SignInSuccessPage(driver);
            Assert.IsTrue(signInSuccessPage.VerifyPage(), "SignInSuccessPage VerifyPage() FAILED");
            Assert.IsTrue(signInSuccessPage.VerifySignInHomePage(signInData.userName), "VerifySignInHomePage() FAILED");
        }

        [TestMethod]
        public void TestInvalidSignIn()
        {
            // Verify TestData is loaded
            Assert.IsNotNull(testData, "TestData load FAILED");

            // Perform SigIn
            SignInPage signInPage = PerformSignIn(testData.GetTestData("TestInvalidSignIn"));

            // Verify error page is loaded
            Assert.IsTrue(signInPage.VerifySignInErrorMessage(), "VerifySignInErrorMessage() FAILED");
        }

        [TestMethod]
        public void TestSignInInActiveUser()
        {
            // Verify TestData is loaded
            Assert.IsNotNull(testData, "TestData load FAILED");

            // Perform SignIn
            SignInPage signInPage = PerformSignIn(testData.GetTestData("TestSignInInActiveUser"));

            // Verify inactive page is loaded
            Assert.IsTrue(signInPage.VerifySignInErrorMessageInactiveUser(), "VerifySignInErrorMessageInactiveUser() FAILED");
        }


        [TestMethod]
        public void TestSignInWithUserNameOnly()
        {
            // Verify TestData is loaded
            Assert.IsNotNull(testData, "TestData load FAILED");

            // Perform SignIn
            SignInPage signInPage = PerformSignIn(testData.GetTestData("TestSignInWithUserNameOnly"));

            // Verify error page is loaded
            Assert.IsTrue(signInPage.VerifySignInErrorMessage(), "VerifySignInErrorMessage() FAILED");
        }

        [TestMethod]
        public void TestSignInWithPasswordOnly()
        {
            // Verify TestData is loaded
            Assert.IsNotNull(testData, "TestData load FAILED");

            // Perform SignIn
            SignInPage signInPage = PerformSignIn(testData.GetTestData("TestSignInWithUserNameOnly"));

            // Verify error page is loaded
            Assert.IsTrue(signInPage.VerifySignInErrorMessage(), "VerifySignInErrorMessage() FAILED");
        }

        [TestMethod]
        public void TestSignInWithoutUserNameAndPassword()
        {
            // Verify TestData is loaded
            Assert.IsNotNull(testData, "TestData load FAILED");

            // Perform SignIn
            SignInPage signInPage = PerformSignIn(testData.GetTestData("TestSignInWithUserNameOnly"));

            // Verify error page is loaded
            Assert.IsTrue(signInPage.VerifySignInErrorMessage(), "VerifySignInErrorMessage() FAILED");
        }

        [TestMethod]
        public void TestSignInForgotPassword()
        {
            // Verify driver is initialized
            Assert.IsNotNull(driver, "Driver initialization FAILED");

            // Verify Home page is loaded
            HomePage homePage = new HomePage(driver);
            Assert.IsTrue(homePage.VerifyPage(), "HomePage VerifyPage() FAILED");

            // Verify SignIn page is loaded
            SignInPage signInPage = homePage.GoToSignInPage();
            Assert.IsNotNull(signInPage, "GoToSignInPage() FAILED");
            Assert.IsTrue(signInPage.VerifyPage(), "SignInPage VerifyPage() FAILED");

            // Navigate to forgot page
            ForgotPasswordPage forgotPasswordPage = signInPage.GoToForgotPasswordPage();
            Assert.IsNotNull(forgotPasswordPage, "GoToForgotPasswordPage() FAILED");

            // Verify navigate page is loaded
            Assert.IsTrue(forgotPasswordPage.VerifyPage(), "ForgotPasswordPage VerifyPage() FAILED");
        }

    }
}
