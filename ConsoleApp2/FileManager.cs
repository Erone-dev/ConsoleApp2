using ConsoleApp2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp2
{
    internal class FileManager
    {
        readonly static string entity = @"entity.json";
        readonly static string individ = @"individual.json";

        public static string GetPhisPath()
        {
            return individ;
        }

        public static string GetYurPath()
        {
            return entity;
        }

        //Получение записей
        public List<YurFace> GetYur()
        {
            List<YurFace> yur = JsonConvert.DeserializeObject<List<YurFace>>(File.ReadAllText(entity));
            return yur;
        }

        public List<PhisicalFace> GetPhis()
        {
            List<PhisicalFace> phis = JsonConvert.DeserializeObject<List<PhisicalFace>>(File.ReadAllText(individ));
            return phis;
        }

        internal void WritePhis(string phisRecor)
        {
            File.WriteAllText(individ, phisRecor);
        }
    }
}
