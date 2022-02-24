using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleApp2
{
    internal class Program
    {
        internal static string indId = "IdPhis";
        internal static string entId = "IdEnt";
        internal static FileManager file;
        static void Main(string[] args)
        {

            List<PhisicalFace> phis = new List<PhisicalFace>()
            {
                new PhisicalFace
                {
                    name = "Кристофор",
                    family = "Пукин",
                    otchestvo = "Колумбович",
                    biin = "999888777666",
                    create_date = DateTime.Now.ToString(),
                    author_create = "Жека",
                    Id = 1,
                    company_id = 0
                },
                new PhisicalFace
                {
                    name = "Джон",
                    family = "Кинг",
                    otchestvo = "Александрович",
                    biin = "88005553535",
                    create_date = DateTime.Now.ToString(),
                    author_create = "Жека",
                    Id = 2,
                    company_id = 0
                },
                new PhisicalFace
                {
                    name = "Конг",
                    family = "Кинг",
                    otchestvo = "Обезьянович",
                    biin = "666",
                    create_date = DateTime.Now.ToString(),
                    author_create = "Жека",
                    Id = 3,
                    company_id = 1
                },
                new PhisicalFace
                {
                    name = "Виктория",
                    family = "Сосиска",
                    otchestvo = "Анатолиевна",
                    biin = "8888",
                    create_date = DateTime.Now.ToString(),
                    author_create = "Жека",
                    Id = 4,
                    company_id = 2
                },
                new PhisicalFace
                {
                    name = "Сергей",
                    family = "Лазарев",
                    otchestvo = "Вячеславович",
                    biin = "999999",
                    create_date = DateTime.Now.ToString(),
                    author_create = "Жека",
                    Id = 5,
                    company_id = 3
                },
                new PhisicalFace
                {
                    name = "Арман",
                    family = "Царукян",
                    otchestvo = "Наирович",
                    biin = "4444444",
                    create_date = DateTime.Now.ToString(),
                    author_create = "Жека",
                    Id = 6,
                    company_id = 4
                },
                new PhisicalFace
                {
                    name = "Арманнн",
                    family = "Царукянннн",
                    otchestvo = "Наировиччччч",
                    biin = "44444446767",
                    create_date = DateTime.Now.ToString(),
                    author_create = "Жека",
                    Id = 6,
                    company_id = 4
                }
            };

            string json1 = JsonConvert.SerializeObject(phis);
            File.WriteAllText(FileManager.individ, json1);

            List<YurFace> ent = new List<YurFace>()
            {
                new YurFace
                {
                    corp_name = "Jusan Garant",
                    biin = "123456789012",
                    create_date = DateTime.Now.ToString(),
                    author_create = "Жека",
                    Id = 0
                },
                new YurFace
                {
                    corp_name = "Costa Coffee",
                    biin = "098765432109",
                    create_date = DateTime.Now.ToString(),
                    author_create = "Жека",
                    Id = 1
                },
                new YurFace
                {
                    corp_name = "Магнолия",
                    biin = "232323444555",
                    create_date = DateTime.Now.ToString(),
                    author_create = "Жека",
                    Id = 2
                },
                new YurFace
                {
                    corp_name = "Sulpak",
                    biin = "566778899034",
                    create_date = DateTime.Now.ToString(),
                    author_create = "Жека",
                    Id = 3
                },                
                new YurFace
                {
                    corp_name = "TechnoDom",
                    biin = "897867564534",
                    create_date = DateTime.Now.ToString(),
                    author_create = "Жека",
                    Id = 4
                }
            };

            string json2 = JsonConvert.SerializeObject(ent);
            File.WriteAllText(FileManager.entity, json2);




            //Сортировка ФИО


            sortPhis("family");

            Console.WriteLine("#\n#\n#");

            sortPhis("name");
            
            Console.WriteLine("#\n#\n#");

            sortPhis("otchestvo");

            Console.WriteLine("#\n#\n#");




            //Компании


            var data = file.GetYur().Select(e => new Dictionary<string, dynamic> { { "nameC", e.corp_name }, 
                { "bin", e.biin }, { "id", e.Id } }).Take(5).OrderByDescending(e => file.GetPhis().
                Where(g => g.company_id == e["id"]).Select(g => new List<long> {g.Id}).Count());
            StringBuilder sb3;
            foreach (var d in data)
            {
                var agents = file.GetPhis().Where(r => r.company_id == d["id"]).Select(r => new List<string> {r.family, r.name, r.otchestvo});
                sb3 = new StringBuilder(d["nameC"] + " " + d["bin"] + "\n");
                sb3.AppendLine("Контрагенты: ");
                foreach(var ag in agents)
                {
                    sb3.AppendLine("\t" + ag[0].ToString() + " " + ag[1].ToString() + " " + ag[2].ToString());
                }
                Console.WriteLine(sb3);
            }
        }

        public static void sortPhis(string option)
        {
            file = new FileManager();
            var resullt = file.GetPhis();
            var fam = resullt.Select(c => new Dictionary<string, string> { { "family", c.family }, { "name", c.name }, { "otchestvo", c.otchestvo } }).OrderBy(c => c[option]);
            StringBuilder sb;
            foreach (var p in fam)
            {
                sb = new StringBuilder(p["family"] + " " + p["name"] + " " + p["otchestvo"]);
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
