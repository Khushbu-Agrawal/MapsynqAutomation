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
    public class HomeData
    {
        public String source;
        public String destination;
        public bool trafficAware;
        public bool tollAware;
        public bool fastest;
        public bool shortest;
    };

    public class HomeTestData : TestData
    {
        // Class data
        private Dictionary<String, HomeData> dataSet;

        // Constructor
        public HomeTestData(String p_FileName)
        {
            Load(p_FileName); // load test data
        }

        // Load TD for Home page test cases
        public override void Load(String p_FileName)
        {
            if (isLoaded) return; // don't reload

            dataSet = new Dictionary<String, HomeData>();
            try
            {
                String jsonString = File.ReadAllText(GetFilePath(p_FileName));
                dataSet = JsonConvert.DeserializeObject<Dictionary<String, HomeData>>(jsonString);
                if ((dataSet != null) && dataSet.Count() > 0)
                {
                    isLoaded = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught while loading test data for Home, error: " + ex.ToString());
            }
        }

        // Returns Homedata for input test name
        public HomeData GetTestData(String p_TestName)
        {
            return dataSet[p_TestName];
        }

    }
}
