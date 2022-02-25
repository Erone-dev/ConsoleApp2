using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleApp2
{
    internal class Program
    {
        internal static FileManager file;
        static void Main(string[] args)
        {

            List<PhisicalFace> phis = new List<PhisicalFace>()
            {
                new PhisicalFace
                {
                    Name = "Кристофор",
                    SecondName = "Пукин",
                    MiddleName = "Колумбович",
                    Biin = "999888777666",
                    CreateDate = DateTime.Now.ToString(),
                    AuthorCreate = "Жека",
                    Id = 1,
                    CompanyId = 0
                },
                new PhisicalFace
                {
                    Name = "Джон",
                    SecondName = "Кинг",
                    MiddleName = "Александрович",
                    Biin = "88005553535",
                    CreateDate = DateTime.Now.ToString(),
                    AuthorCreate = "Жека",
                    Id = 2,
                    CompanyId = 0
                },
                new PhisicalFace
                {
                    Name = "Конг",
                    SecondName = "Кинг",
                    MiddleName = "Обезьянович",
                    Biin = "666",
                    CreateDate = DateTime.Now.ToString(),
                    AuthorCreate = "Жека",
                    Id = 3,
                    CompanyId = 1
                },
                new PhisicalFace
                {
                    Name = "Виктория",
                    SecondName = "Сосиска",
                    MiddleName = "Анатолиевна",
                    Biin = "8888",
                    CreateDate = DateTime.Now.ToString(),
                    AuthorCreate = "Жека",
                    Id = 4,
                    CompanyId = 2
                },
                new PhisicalFace
                {
                    Name = "Сергей",
                    SecondName = "Лазарев",
                    MiddleName = "Вячеславович",
                    Biin = "999999",
                    CreateDate = DateTime.Now.ToString(),
                    AuthorCreate = "Жека",
                    Id = 5,
                    CompanyId = 3
                },
                new PhisicalFace
                {
                    Name = "Арман",
                    SecondName = "Царукян",
                    MiddleName = "Наирович",
                    Biin = "4444444",
                    CreateDate = DateTime.Now.ToString(),
                    AuthorCreate = "Жека",
                    Id = 6,
                    CompanyId = 4
                },
                new PhisicalFace
                {
                    Name = "Арманнн",
                    SecondName = "Царукянннн",
                    MiddleName = "Наировиччччч",
                    Biin = "44444446767",
                    CreateDate = DateTime.Now.ToString(),
                    AuthorCreate = "Жека",
                    Id = 6,
                    CompanyId = 4
                }
            };

            string phisRecor = JsonConvert.SerializeObject(phis);
            File.WriteAllText(FileManager.individ, phisRecor);

            List<YurFace> ent = new List<YurFace>()
            {
                new YurFace
                {
                    CorpName = "Jusan Garant",
                    Biin = "123456789012",
                    CreateDate = DateTime.Now.ToString(),
                    AuthorCreate = "Жека",
                    Id = 0
                },
                new YurFace
                {
                    CorpName = "Costa Coffee",
                    Biin = "098765432109",
                    CreateDate = DateTime.Now.ToString(),
                    AuthorCreate = "Жека",
                    Id = 1
                },
                new YurFace
                {
                    CorpName = "Магнолия",
                    Biin = "232323444555",
                    CreateDate = DateTime.Now.ToString(),
                    AuthorCreate = "Жека",
                    Id = 2
                },
                new YurFace
                {
                    CorpName = "Sulpak",
                    Biin = "566778899034",
                    CreateDate = DateTime.Now.ToString(),
                    AuthorCreate = "Жека",
                    Id = 3
                },                
                new YurFace
                {
                    CorpName = "TechnoDom",
                    Biin = "897867564534",
                    CreateDate = DateTime.Now.ToString(),
                    AuthorCreate = "Жека",
                    Id = 4
                }
            };

            string json2 = JsonConvert.SerializeObject(ent);
            File.WriteAllText(FileManager.entity, json2);




            //Сортировка ФИО


            SortPhis("SecondName");

            Console.WriteLine("#\n#\n#");

            SortPhis("Name");
            
            Console.WriteLine("#\n#\n#");

            SortPhis("MiddleName");

            Console.WriteLine("#\n#\n#");




            //Компании


            var data = file.GetYur().Select(e => new Dictionary<string, dynamic> { { "NameC", e.CorpName }, 
                { "bin", e.Biin }, { "id", e.Id } }).Take(5).OrderByDescending(e => file.GetPhis().
                Where(g => g.CompanyId == e["id"]).Select(g => new List<long> {g.Id}).Count());
            StringBuilder sb3;
            foreach (var d in data)
            {
                var agents = file.GetPhis().Where(r => r.CompanyId == d["id"]).Select(r => new List<string> {r.SecondName, r.Name, r.MiddleName});
                sb3 = new StringBuilder(d["NameC"] + " " + d["bin"] + "\n");
                sb3.AppendLine("Контрагенты: ");
                foreach(var ag in agents)
                {
                    sb3.AppendLine("\t" + ag[0].ToString() + " " + ag[1].ToString() + " " + ag[2].ToString());
                }
                Console.WriteLine(sb3);
            }
        }

        public static void SortPhis(string option)
        {
            file = new FileManager();
            var resullt = file.GetPhis();
            var fam = resullt.Select(c => new Dictionary<string, string> { { "SecondName", c.SecondName }, { "Name", c.Name }, { "MiddleName", c.MiddleName } }).OrderBy(c => c[option]);
            StringBuilder sb;
            foreach (var p in fam)
            {
                sb = new StringBuilder(p["SecondName"] + " " + p["Name"] + " " + p["MiddleName"]);
                Console.WriteLine(sb.ToString());
            }
        }
    }
}