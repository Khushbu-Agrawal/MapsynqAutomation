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
    public class SignInData
    {
        public String userName;
        public String password;
    };

    public class SignInTestData : TestData
    {
        // Constants
        private const String TD_FILE_NAME = "SignIn.json";

        // Class data
        private Dictionary<String, SignInData> dataSet;

        // Constructor
        public SignInTestData()
        {
            Load(); // load test data
        }

        // Load TD for SignIn page test cases
        public override void Load()
        {
            if (isLoaded) return; // don't reload

            dataSet = new Dictionary<String, SignInData>();
            try
            {
                String jsonString = File.ReadAllText(GetFilePath(TD_FILE_NAME));
                dataSet = JsonConvert.DeserializeObject<Dictionary<String, SignInData>>(jsonString);
                if ((dataSet != null) && dataSet.Count() > 0)
                {
                    isLoaded = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught while loading test data for SignIn, error: " + ex.ToString());
            }
        }

        // Returns SignIndata for input test name
        public SignInData GetTestData(String p_TestName)
        {
            return dataSet[p_TestName];
        }

    }
}
