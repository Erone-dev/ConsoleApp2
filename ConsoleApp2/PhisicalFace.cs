using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ConsoleApp2
{
    public class PhisicalFace : Contragent
    {
        public string name { get; set; }
        public string family { get; set; }
        public string otchestvo { get; set; }
        public long company_id { get; set; }
    }
}
