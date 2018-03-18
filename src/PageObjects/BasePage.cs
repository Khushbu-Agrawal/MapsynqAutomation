using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;

namespace MapsynQ.PageObjects
{
    // Base class to serve all derived page classes
    class BasePage
    {
        // Constants
        private const String ERROR_PREFIX_STR = "Error: ";

        // Class data
        protected IWebDriver driver;

        // Helper function to log error and return false (fast coding)
        protected bool LogError(String p_ErrorString)
        {
            // @todo - Add support for enable/disable error logging.
            Console.WriteLine(ERROR_PREFIX_STR + p_ErrorString);
            return false;
        }

        // Helper function to validate input string and log error if required
        protected bool Validate(String p_InputString)
        {
            if (String.IsNullOrEmpty(p_InputString))
            {
                return LogError("Input string is empty!");
            }
            return true;
        }

    }
}
