using ConsoleApp2.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp2
{
    internal class FileManager
    {
        readonly static string yurPath = @"entity.json";
        readonly static string phisPath = @"individual.json";

        //Получение записей
        public List<YurFace> GetYur()
        {
            var yur = JsonConvert.DeserializeObject<List<YurFace>>(File.ReadAllText(yurPath));
            return yur;
        }

        public List<PhisicalFace> GetPhis()
        {
            var phis = JsonConvert.DeserializeObject<List<PhisicalFace>>(File.ReadAllText(phisPath));
            return phis;
        }

        internal void WritePhis(List<PhisicalFace> agent)
        {
            var phisRecord = JsonConvert.SerializeObject(agent);
            File.WriteAllText(phisPath, phisRecord);
        }

        internal void WriteYur(List<YurFace> companies)
        {
            var yurRecord = JsonConvert.SerializeObject(companies);
            File.WriteAllText(yurPath, yurRecord);
        }
    }
}
