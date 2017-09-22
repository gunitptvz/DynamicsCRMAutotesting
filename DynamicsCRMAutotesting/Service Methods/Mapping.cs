using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using DynamicsCRMAutotesting.Data;

namespace DynamicsCRMAutotesting.Service_Methods
{
    class Mapping
    {
        /// <summary>
        /// Static method for returning the DataModel type object with data properties
        /// </summary>
        /// <param name="jsonfile"></param>
        /// <returns></returns>
        public static DataModel MapJson(string jsonfile)
        {
            DataModel result = new DataModel();

            // Read all text from json file
            string configprep = File.ReadAllText(jsonfile);

            // Deserialize text to the Dictionary<string, object> config
            Dictionary<string, object> config = JsonConvert.DeserializeObject<Dictionary<string, object>>(configprep);

            result.Url = config["url"].ToString();
            result.Reporthost = config["reporthost"].ToString();
            result.Login = config["login"].ToString();
            result.Password = config["password"].ToString();
            result.Progname = config["programName"].ToString();
            result.Recalctype = config["recalculationType"].ToString();
            result.Filepath = config["filePath"].ToString();

            return result;
        }
    }
}
