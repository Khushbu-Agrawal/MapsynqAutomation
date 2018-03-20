using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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

        public enum DirectionTypes {
            TRAFFIC_AWARE = 0,
            TOLL_AWARE,
            FASTEST,
            SHORTEST
        }; 

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

        [FindsBy(How = How.XPath, Using = "//a[@class='tab_button directions_tab sprite']")]
        private IWebElement directions;

        [FindsBy(How = How.ClassName, Using = "//*[contains(text(),'route_swap_button')]")]
        private IWebElement routeSwapButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='get_direction']")]
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

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Traffic Aware Route')]")]
        private IWebElement trafficAwareResult;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Toll aware')]")]
        private IWebElement tollAwareResult;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Fastest')]")]
        private IWebElement fastestResult;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Shortest')]")]
        private IWebElement shortestResult;

        [FindsBy(How = How.XPath, Using = "//span[@id='divTrafficRouteTravelTimeDistance']")]
        private IWebElement trafficAwareResultDetails;

        [FindsBy(How = How.XPath, Using = "//span[@id='divErpRouteTravelTimeDistance']")]
        private IWebElement tollAwareResultDetails;

        [FindsBy(How = How.XPath, Using = "//span[@id='divFastestRouteTravelTimeDistance']")]
        private IWebElement fastestResultDetails;

        [FindsBy(How = How.XPath, Using = "//span[@id='divShortestRouteTravelTimeDistance']")]
        private IWebElement shortestResultDetails;

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
            return (getDirectionsButton.GetAttribute("value") == "Get Directions");
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

               sourceLocation.Clear();
               sourceLocation.SendKeys(p_Source);

               WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));

               wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@title='BEDOK MALL']")));

               IList<IWebElement> divs = driver.FindElements(By.XPath("//div[@class='autocomplete-w1']"));
               IList<IWebElement> divsWithTitle = divs[1].FindElements(By.TagName("div"));

               for (int i = 0; i < divsWithTitle.Count - 1; i++)
               {
                   if (divsWithTitle[i].Text == p_Source)
                   {
                       divsWithTitle[i].Click();
                       break;
                   }
               }
       
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

                destination.Clear();
                destination.SendKeys(p_Destination);

                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));

                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@title='CHANGI AIRPORT']")));

                IList<IWebElement> divs = driver.FindElements(By.XPath("//div[@class='autocomplete-w1']"));
                IList<IWebElement> divsWithTitle = divs[2].FindElements(By.TagName("div"));

                for (int i = 0; i < divsWithTitle.Count - 1; i++)
                {
                    if (divsWithTitle[i].Text == p_Destination)
                    {
                        divsWithTitle[i].Click();
                        break;
                    }
                }
  
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

        public bool ClickGetDirection(DirectionTypes p_DirectionType)
        {
            try
            {
                if (!getDirectionsButton.Enabled || !getDirectionsButton.Displayed)
                {
                    return LogError("Get Directions button is disabled or invisible!");
                }
                
                getDirectionsButton.Click();

                // Wait for the response
                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
                switch(p_DirectionType)
                {
                    case DirectionTypes.TRAFFIC_AWARE:
                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(),'Traffic Aware Route')]")));
                        break;
                    case DirectionTypes.TOLL_AWARE:
                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(),'Toll aware')]")));
                        break;
                    case DirectionTypes.FASTEST:
                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(),'Fastest')]")));
                        break;
                    case DirectionTypes.SHORTEST:
                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(),'Shortest')]")));
                        break;
                }

                Thread.Sleep(1000); // hacky
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
                if (!tollAware.Enabled || !tollAware.Displayed)
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

        public bool VerifyAlertMessageWithEmptySourceDestination()
        {
            try
            {
                string message = "Please enter route Start and Destination";
                IAlert alert = driver.SwitchTo().Alert();
                if (alert.Text != message)
                {
                    return false;

                }
                alert.Accept();
                
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing VerifyAlertMessageWithEmptySourceDestination(), error: " + ex.ToString());
            }

            return true;
        }

        public bool VerifyAlertMessageWithInvalidSourceDestination()
        {
            try
            {
                string message = "We are unable to find the directions for given from/to. Please try again.";
                IAlert alert = driver.SwitchTo().Alert();
                if (alert.Text != message)
                {
                    return false;

                }

                alert.Accept();
            }

            catch (Exception ex)
            {
                return LogError("Exception caught while performing VerifyAlertMessageWithInvalidSourceDestination(), error: " + ex.ToString());
            }

            return true;
        }

        public bool VerifyAlertMessageForCurrentLocation()
        {
            try
            {
                string message = "Please grant permission to you use the location service on your browser to use your 'Current location'.";
                IAlert alert = driver.SwitchTo().Alert();
                if (alert.Text != message)
                {
                    return false;
                }

                alert.Accept();
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing VerifyAlertMessageForCurrentLocation(), error: " + ex.ToString());
            }

            return true;
        }

        private bool VerifyTrafficOutput(String p_TrafficString)
        {
            try
            {
                String[] result = p_TrafficString.Split('|');
                String[] distanceArr = result[0].Trim().Split(' ');
                String[] timeArr = result[1].Trim().Split(' ');
                String[] tollArr = result[2].Trim().Split('$');

                if ((Int32.Parse(distanceArr[0]) > 0) && (Int32.Parse(timeArr[0]) > 0) && (result[2].Trim().Contains("S$")))
                    return true;
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing VerifyTrafficOutput(), error: " + ex.ToString());
            }

            return false;
        }

        public bool VerifyTrafficAwareResults()
        {
            try
            {
                if (trafficAwareResult.Text != "Traffic Aware Route") return false;
                return VerifyTrafficOutput(trafficAwareResultDetails.Text);
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing VerifyTrafficAwareResults(), error: " + ex.ToString());
            }

            return false;
        }

        public bool VerifyTollAwareResults()
        {
            try
            {
                if (tollAwareResult.Text != "Toll aware") return false;
                return VerifyTrafficOutput(tollAwareResultDetails.Text);
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing VerifyTollAwareResults(), error: " + ex.ToString());
            }

            return false;
        }

        public bool VerifyFastestResults()
        {
            try
            {
                if (fastestResult.Text != "Fastest") return false;

                String res = fastestResultDetails.Text;
                return VerifyTrafficOutput(fastestResultDetails.Text);
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing VerifyFastestResults(), error: " + ex.ToString());
            }

            return false;
        }

        public bool VerifyShortestResults()
        {
            try
            {
                if (shortestResult.Text != "Shortest") return false;
                return VerifyTrafficOutput(shortestResultDetails.Text);
            }
            catch (Exception ex)
            {
                return LogError("Exception caught while performing VerifyShortestResults(), error: " + ex.ToString());
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
