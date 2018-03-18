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
    public class SignInPageTest : BaseTest
    {
        // Test data for this class
        private SignInTestData testData = new SignInTestData();

        //////////////////////////////////////////////////////////////////////

        [TestInitialize]
        public void TestInit()
        {
            InitDriver(); // Setup driver
        }

        [TestCleanup]
        public void TestClean()
        {
            GetDriver().Close(); // Cleanup driver
        }

        ////////////////////////////////////////////////////////////////////

        [TestMethod]
        public void TestSignIn()
        {
            // Verify TestData is loaded properly
            Assert.IsTrue(testData.isLoaded, "TestData load FAILED");

            HomePage homePage = new HomePage(GetDriver());
            SignInPage signInPage = homePage.GoToSignInPage();
            Assert.IsNotNull(signInPage, "GoToSignInPage() FAILED");
            if (signInPage == null) return; // Test failed

            bool isPageVerified = signInPage.VerifyPage();
            Assert.IsTrue(isPageVerified, "VerifyPage() FAILED");
            if (!isPageVerified) return; // Test failed

            Assert.IsTrue(signInPage.SetUserName(testData.userName), "SetUserName() FAILED");
            Assert.IsTrue(signInPage.SetPassword(testData.password), "SetPassword() FAILED");
            Assert.IsNotNull(signInPage.ClickSignInButton(), "ClickSignInButton() FAILED");

            // @todo - check signin success
        }

        [TestMethod]
        public void TestInvalidSignIn()
        {
            // Verify TestData is loaded properly
            Assert.IsTrue(testData.isLoaded, "TestData load FAILED");

            HomePage homePage = new HomePage(GetDriver());
            SignInPage signInPage = homePage.GoToSignInPage();
            Assert.IsNotNull(signInPage, "GoToSignInPage() FAILED");
            if (signInPage == null) return; // Test failed

            bool isPageVerified = signInPage.VerifyPage();
            Assert.IsTrue(isPageVerified, "VerifyPage() FAILED");
            if (!isPageVerified) return; // Test failed

            Assert.IsTrue(signInPage.SetUserName("dummy_user_name"), "SetUserName() FAILED");
            Assert.IsTrue(signInPage.SetPassword("dummy_password"), "SetPassword() FAILED");
            Assert.IsNotNull(signInPage.ClickSignInButton(), "ClickSignInButton() FAILED");

            // @todo - check error
        }

    }
}
    

