using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleApp2
{
    public class Contragent
    {
        public string biin { get; set; }
        public string create_date { get; set; }
        public string change_date { get; set; }
        public string author_create { get; set; }
        public string author_change { get; set; }
        public long Id { get; set; }


        //internal static Dictionary<string, string> getSubData(string idName)
        //{
        //    DateTime create_date = DateTime.Now;

        //    Dictionary<string, dynamic> docId = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(File.ReadAllText(FileManager.subdata));
        //    long Id = docId[idName];

        //    Dictionary<string, string> res = new Dictionary<string, string>();
        //    res.Add("create_data", create_date.ToString());
        //    res.Add("id", Id.ToString());
        //    return res;
        //}

        //internal static void saveData(Dictionary<dynamic, dynamic> dict, bool entity = false)
        //{

        //    if (entity)
        //    {

        //    } else
        //    {

        //    }
        //}
    }

}
          
