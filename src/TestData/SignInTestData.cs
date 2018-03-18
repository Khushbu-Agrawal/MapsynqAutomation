using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MapsynQ.TestData
{
    class SignInTestData : TestData
    {
        // Constants
        private const String TD_FILE_NAME = "SignIn.json";

        // Class data
        public string testName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

        // Constructor
        public SignInTestData()
        {
            Load(); // load test data
        }

        // Load TD for SignIn page test cases
        public override void Load()
        {
            if (isLoaded) return; // don't reload

            try
            {
                var json = File.ReadAllText(GetFilePath(TD_FILE_NAME));
                var jObject = JObject.Parse(json);
                if (jObject == null) return;

                testName = jObject["TestName"].ToString();
                userName = jObject["UserName"].ToString();
                password = jObject["Password"].ToString();

                // Testing only
                Console.WriteLine("\tTestName: " + jObject["TestName"].ToString());
                Console.WriteLine("\tUserName: " + jObject["UserName"].ToString());
                Console.WriteLine("\tPassword: " + jObject["Password"].ToString());

                isLoaded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught while loading test data for SignIn, error: " + ex.ToString());
            }
        }
        
    }
}
