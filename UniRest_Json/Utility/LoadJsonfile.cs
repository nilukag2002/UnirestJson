using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniRest_Json.Utility
{
    class LoadJsonfile
    {
        ReadExcel readExcelReader = new ReadExcel();
       

        //public JObject LoadJson()
        //{

        //    using (StreamReader file = File.OpenText(readExcelReader.getSolutionPath() + @"/Resources/Settings.json"))
        //    using (JsonTextReader reader = new JsonTextReader(file))
        //    {
        //        JObject jsonCreate = (JObject)JToken.ReadFrom(reader);

                
        //        return jsonCreate;
        //    }
        //}

        public String LoadJson()
        {
            using (StreamReader r = new StreamReader(readExcelReader.getSolutionPath() + @"/Resources/Settings.json"))
          
            {
                string json = r.ReadToEnd();
                // Item items = JsonConvert.DeserializeObject<Item>(json);
                
                
                return json;
               
            }
        }

        public class Item
        {
            public int id { get; set; }
            public string name { get; set; }
            public int year { get; set; }
            public string color { get; set; }
            public string pantone_value { get; set; }

        }

        public class RootObject
        {
            public List<Item> data { get; set; }
        }
    }
}
