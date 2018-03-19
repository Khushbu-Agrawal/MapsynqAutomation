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
       // Constants
        private const String PAGE_TITLE = "mapSYNQ - Live Traffic Information Platform";

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Sign in')]")]
        private IWebElement signIn;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Register')]")]
        private IWebElement register;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Mobile App')]")]
        private IWebElement mobileApp;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Galactio')]")]
        private IWebElement galactio;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'SG GPS Navigation')]")]
        private IWebElement SGGPSNavigation;

        //Direction Tab

        [FindsBy(How = How.ClassName, Using = "//*[contains(text(),'directions_tab')]")]
        private IWebElement directions;

        [FindsBy(How = How.ClassName, Using = "//*[contains(text(),'route_swap_button')]")]
        private IWebElement routeSwapButton;

        [FindsBy(How = How.Id, Using = "get_direction")]
        private IWebElement getDirectionsButton;

        [FindsBy(How = How.Id, Using = "poi_from")]
        private IWebElement sourceLocation;

        [FindsBy(How = How.Id, Using = "poi_to")]
        private IWebElement destination;

        [FindsBy(How = How.Id, Using = "also_traffic")]
        private IWebElement trafficAware;

        [FindsBy(How = How.Id, Using = "also_erp")]
        private IWebElement tollAware;

        [FindsBy(How = How.Id, Using = "also_fastest")]
        private IWebElement fastest;

        [FindsBy(How = How.Id, Using = "also_shortest")]
        private IWebElement shortest;

        [FindsBy(How = How.Id, Using = "btnClear")]
        private IWebElement clearRouteButton;

        [FindsBy(How = How.Id, Using = "divTrafficRoute")]
        private IWebElement trafficAwareRouteTable;

        [FindsBy(How = How.Id, Using = "divTrafficRouteTravelTimeDistance")]
        private IWebElement trafficAwareDistance;

        [FindsBy(How = How.Id, Using = "spTrafficTt")]
        private IWebElement trafficAwareTime;

        [FindsBy(How = How.Id, Using = "divFastestRoute")]
        private IWebElement fastestRouteTable;

        [FindsBy(How = How.Id, Using = "divFastestRouteTravelTimeDistance")]
        private IWebElement fastestRouteDistance;

        [FindsBy(How = How.Id, Using = "spFastestTt")]
        private IWebElement fastestRouteTime;

        [FindsBy(How = How.Id, Using = "divErpRoute")]
        private IWebElement tollAwareRouteTable;

        [FindsBy(How = How.Id, Using = "divErpRouteTravelTimeDistance")]
        private IWebElement tollRouteDistance;

        [FindsBy(How = How.Id, Using = "spErpTt")]
        private IWebElement tollRouteTime;

        [FindsBy(How = How.Id, Using = "divShortestRoute")]
        private IWebElement shortestRouteTable;

        [FindsBy(How = How.Id, Using = "divShortestRouteTravelTimeDistance")]
        private IWebElement shortestRouteDistance;

        [FindsBy(How = How.Id, Using = "spShortestTt")]
        private IWebElement shortestRouteTime;

        [FindsBy(How = How.Id, Using = "traffic_route_ribbon")]
        private IWebElement trafficAwareRibbon;

        [FindsBy(How = How.Id, Using = "erp_route_ribbon")]
        private IWebElement tollAwareRibbon;

        [FindsBy(How = How.Id, Using = "fastest_route_ribbon")]
        private IWebElement fastestRibbon;

        [FindsBy(How = How.Id, Using = "shortest_route_ribbon")]
        private IWebElement shortestRibbon;


        //Live Tab
        [FindsBy(How = How.ClassName, Using = "//*[contains(text(),'live_tab')]")]
        private IWebElement live;

        [FindsBy(How = How.XPath, Using = "//*input[@id='rdIncidents']")]
        private IWebElement inccidents;

        [FindsBy(How = How.XPath, Using = "//*input[@id='rdCameras']")]
        private IWebElement cameras;

        [FindsBy(How = How.XPath, Using = "//*input[@id='rdErp']")]
        private IWebElement tolls;

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
                LogError("Exception caught while performing GoToSignInPage(), error: " + ex.ToString());
            }

            return null;
        }

        public RegisterPage GoToRegisterPage()
        {
            try
            {
                signIn.Click();
                return new RegisterPage(driver);
            }
            catch (Exception ex)
            {
                LogError("Exception caught while performing GoToRegisterPage(), error: " + ex.ToString());
            }

            return null;
        }

        public MobileAppPage GoToMobileAppPage()
        {
            try
            {
                mobileApp.Click();

                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
                wait.Until((d) => driver.WindowHandles.Count == 2);
                driver.SwitchTo().Window(driver.WindowHandles.Last());

                return new MobileAppPage(driver);

            }
            catch (Exception ex)
            {
                LogError("Exception caught while performing GoToMobileAppPage(), error: " + ex.ToString());
            }

            return null;
        }

        public GalactioPage GoToGalactioPage()
        {
            try
            {
                galactio.Click();

                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
                wait.Until((d) => driver.WindowHandles.Count == 2);
                driver.SwitchTo().Window(driver.WindowHandles.Last());

                return new GalactioPage(driver);

            }
            catch (Exception ex)
            {
                LogError("Exception caught while performing GoToGalactioPage(), error: " + ex.ToString());
            }

            return null;
        }

        public SGGPSNavigationPage GoToSGGPSNavigationPage()
        {
            try
            {
                SGGPSNavigation.Click();

                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
                wait.Until((d) => driver.WindowHandles.Count == 2);
                driver.SwitchTo().Window(driver.WindowHandles.Last());

                return new SGGPSNavigationPage(driver);

            }
            catch (Exception ex)
            {
                LogError("Exception caught while performing GoToSGGPSNavigationPage(), error: " + ex.ToString());
            }

            return null;
        }


        #region Direction Tab

        public void ClickDirection()
        {
            try
            {
                directions.Click();

            }
            catch (Exception ex)
            {
                LogError("Exception caught while performing ClickDirection(), error: " + ex.ToString());
            }
        }

        public bool VerifyDirection()
        {
            return (getDirectionsButton.Text == "Get Directions");
        }

        public bool SetSourceLocation(String p_Source)
        {
            if (!Validate(p_Source)) return false;

            try
            {
                if (!sourceLocation.Enabled || !sourceLocation.Displayed)
                {
                    return LogError("Source text box is disabled or invisible!");
                }

                sourceLocation.SendKeys(Keys.Clear);
                sourceLocation.SendKeys(p_Source);
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing SetSourceLocation(), error: " + ex.ToString());
            }

            return true;
        }

        public bool SetDestination(String p_Destination)
        {
            if (!Validate(p_Destination)) return false;

            try
            {
                if (!destination.Enabled || !destination.Displayed)
                {
                    return LogError("Destination text box is disabled or invisible!");
                }

                destination.SendKeys(Keys.Clear);
                destination.SendKeys(p_Destination);
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing SetDestination(), error: " + ex.ToString());
            }

            return true;
        }

        public string GetSourceLocation()
        {
            string source = null;
            try
            {
                if (sourceLocation.Enabled && sourceLocation.Displayed)
                {
                    source = sourceLocation.Text;
                    return source; 
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught while performing GetSourceLocation(), error: " + ex.ToString());
            }
            return source;

        }

        public string GetDestination()
        {
            string dest = null;
            try
            {
                if (destination.Enabled && destination.Displayed)
                {
                    dest = destination.Text;
                    return dest;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught while performing GetDestination(), error: " + ex.ToString());
            }
            return dest;

        }

        public bool ClickGetDirection()
        {
            try
            {
                if (!getDirectionsButton.Enabled || !getDirectionsButton.Displayed)
                {
                    return LogError("Source text box is disabled or invisible!");

                }

                getDirectionsButton.Click();
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing ClickGetDirection(), error: " + ex.ToString());
            }

            return true;

        }

        public bool SetTrafficAware(bool p_Status)
        {
            try
            {
                if (!trafficAware.Enabled || !trafficAware.Displayed)
                {
                    return LogError("Traffic Aware Checkbox is disabled or invisible!");
                }

                if (p_Status == true)
                {
                    if (!trafficAware.Selected)
                    {
                        trafficAware.Click();
                        return true;
                    }
                }

                if (p_Status == false)
                {
                    if (trafficAware.Selected)
                    {
                        trafficAware.Click();
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing SetDestination(), error: " + ex.ToString());
            }

            return true;
        }

        public bool SetTollAware(bool p_Status)
        {
            try
            {
                if (!trafficAware.Enabled || !trafficAware.Displayed)
                {
                    return LogError("Toll Aware Checkbox is disabled or invisible!");
                }

                if (p_Status == true)
                {
                    if (!tollAware.Selected)
                    {
                        tollAware.Click();
                        return true;
                    }
                }

                if (p_Status == false)
                {
                    if (tollAware.Selected)
                    {
                        tollAware.Click();
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing SetTollAware(), error: " + ex.ToString());
            }

            return true;
        }

        public bool SetFastest(bool p_Status)
        {
            try
            {
                if (!fastest.Enabled || !fastest.Displayed)
                {
                    return LogError("Fastest Checkbox is disabled or invisible!");
                }

                if (p_Status == true)
                {
                    if (!fastest.Selected)
                    {
                        fastest.Click();
                        return true;
                    }
                }

                if (p_Status == false)
                {
                    if (fastest.Selected)
                    {
                        fastest.Click();
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing SetFastest(), error: " + ex.ToString());
            }

            return true;
        }

        public bool SetShortest(bool p_Status)
        {
            try
            {
                if (!shortest.Enabled || !shortest.Displayed)
                {
                    return LogError("Shortest Checkbox is disabled or invisible!");
                }

                if (p_Status == true)
                {
                    if (!shortest.Selected)
                    {
                        shortest.Click();
                        return true;
                    }
                }

                if (p_Status == false)
                {
                    if (shortest.Selected)
                    {
                        shortest.Click();
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing SetShortest(), error: " + ex.ToString());
            }

            return true;
        }

        public bool ClickClearRoute()
        {
            try
            {
                if (!clearRouteButton.Enabled || !clearRouteButton.Displayed)
                {
                    return LogError("Clear Route button is disabled or invisible!");

                }

                clearRouteButton.Click();
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing ClickClearRoute(), error: " + ex.ToString());
            }

            return true;

        }

        public bool ClickRouteSwapButton()
        {
            try
            {
                if (!routeSwapButton.Enabled || !routeSwapButton.Displayed)
                {
                    return LogError("Route Swap button is disabled or invisible!");

                }

                routeSwapButton.Click();
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing ClickRouteSwapButton(), error: " + ex.ToString());
            }

            return true;

        }

        public bool VerifyTrafficAwareRoute()
        {
            bool ok = false;
            try
            {
                IList<IWebElement> trafficAwareRows = trafficAwareRouteTable.FindElements(By.TagName("tr"));
                foreach (var elemTr in trafficAwareRows)
                {

                    IList<IWebElement> columns = elemTr.FindElements(By.TagName("td"));
 
                    foreach (var elemTd in columns)
                    {
                        if (elemTd.Text == "Traffic Aware Route")
                        {
                            ok = true;
                            return ok;
                        }
                    }
                }

            }

            catch (Exception ex)
            {
                return LogError("Exception caught while performing VerifyTrafficAwareRoute(), error: " + ex.ToString());
            }

            return ok;
        }

        public bool VerifyTrafficAwareDistanceTimeCharges(int p_Distance, int p_Time, int p_Charges)
        {
            string values = null;
            string[] result = null;
            try
            {
                values = trafficAwareDistance.Text;
                result = values.Split('|');
                if (result[0] == p_Distance.ToString() && result[1] == p_Time.ToString() && result[2] == p_Charges.ToString())
                {
                }
            }

            catch (Exception ex)
            {
                return LogError("Exception caught while performing VerifyTrafficAwareRoute(), error: " + ex.ToString());
            }

            return false;

        }

        #endregion

        #region

        public void ClickLive()
        {
            try
            {
                live.Click();

            }
            catch (Exception ex)
            {
                LogError("Exception caught while performing ClickLive()(), error: " + ex.ToString());
            }
        }

        #endregion
    }
}
