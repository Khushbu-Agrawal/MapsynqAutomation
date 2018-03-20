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
    public class HomePageTest : TestBase
    {
        // Test data for this class
        private HomeTestData testData = new HomeTestData("Home.json");
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
            driver.Quit(); // Cleanup driver
        }

        ////////////////////////////////////////////////////////////////////

        // Helper test function to perform common Direction routine
        private HomePage GetDirection(HomeData p_HomeData, HomePage.DirectionTypes p_DirectionType)
        {
            // Verify driver is initialized
            Assert.IsNotNull(driver, "Driver initialization FAILED");

            // Verify input SignInData
            Assert.IsNotNull(p_HomeData, "TestData load FAILED");

            // Verify Home page is loaded
            HomePage homePage = new HomePage(driver);
            Assert.IsTrue(homePage.VerifyPage(), "HomePage VerifyPage() FAILED");

            homePage.ClickDirection();
            Assert.IsTrue(homePage.VerifyDirection(), "HomePage VerifyDirection() FAILED");

            // Verify test data are set
            Assert.IsTrue(homePage.SetSourceLocation(p_HomeData.source), "SetSourceLocation() FAILED");
            Assert.IsTrue(homePage.SetDestination(p_HomeData.destination), "SetDestination() FAILED");
            Assert.IsTrue(homePage.SetTrafficAware(p_HomeData.trafficAware), "SetTrafficAware() FAILED");
            Assert.IsTrue(homePage.SetTollAware(p_HomeData.tollAware), "SetTollAware() FAILED");
            Assert.IsTrue(homePage.SetFastest(p_HomeData.fastest), "SetFastest() FAILED");
            Assert.IsTrue(homePage.SetShortest(p_HomeData.shortest), "SetShortest() FAILED");

            // Verify Get Directions button is clicked
            Assert.IsTrue(homePage.ClickGetDirection(p_DirectionType), "ClickGetDirection() FAILED");

            return homePage;
        }

        [TestMethod]
        public void TestDirectionWithTrafficAware()
        {
            // Verify TestData is loaded
            Assert.IsNotNull(testData, "TestData load FAILED");

            // Get Directions with Traffic Aware selected
            HomePage homePage = GetDirection(testData.GetTestData("TestDirectionWithTrafficAware"), HomePage.DirectionTypes.TRAFFIC_AWARE);
            Assert.IsTrue(homePage.VerifyTrafficAwareResults(), "VerifyTrafficAwareResults() FAILED");
        }


        [TestMethod]
        public void TestDirectionWithTollAware()
        {
            // Verify TestData is loaded
            Assert.IsNotNull(testData, "TestData load FAILED");

            // Get Directions with Traffic Aware selected
            HomePage homePage = GetDirection(testData.GetTestData("TestDirectionWithTollAware"), HomePage.DirectionTypes.TOLL_AWARE);
            Assert.IsTrue(homePage.VerifyTollAwareResults(), "VerifyTollAwareResults() FAILED");
        }
        
        [TestMethod]
        public void TestDirectionWithFastestRoute()
        {
            // Verify TestData is loaded
            Assert.IsNotNull(testData, "TestData load FAILED");

            // Get Directions with Fastest Route selected
            HomePage homePage = GetDirection(testData.GetTestData("TestDirectionWithFastestRoute"), HomePage.DirectionTypes.FASTEST);

            HomePage homePage1 = new HomePage(driver);
            Assert.IsTrue(homePage1.VerifyFastestResults(), "VerifyFastestResults() FAILED");
        }

        [TestMethod]
        public void TestDirectionWithShortestRoute()
        {
            // Verify TestData is loaded
            Assert.IsNotNull(testData, "TestData load FAILED");

            // Get Directions with Traffic Aware selected
            HomePage homePage = GetDirection(testData.GetTestData("TestDirectionWithShortestRoute"), HomePage.DirectionTypes.SHORTEST);
            Assert.IsTrue(homePage.VerifyShortestResults(), "VerifyShortestResults() FAILED");
        }

    }
}
