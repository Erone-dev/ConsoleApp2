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
                    FirstName = "Кристофор",
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
                    FirstName = "Джон",
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
                    FirstName = "Конг",
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
                    FirstName = "Виктория",
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
                    FirstName = "Сергей",
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
                    FirstName = "Барман",
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
                    FirstName = "Арман",
                    SecondName = "Царукян",
                    MiddleName = "Наирович",
                    Biin = "44444446767",
                    CreateDate = DateTime.Now.ToString(),
                    AuthorCreate = "Жека",
                    Id = 6,
                    CompanyId = 4
                },
                new PhisicalFace
                {
                    FirstName = "Барман",
                    SecondName = "Царукян",
                    MiddleName = "Михайлович",
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

            string entityRecord = JsonConvert.SerializeObject(ent);
            File.WriteAllText(FileManager.entity, entityRecord);




            //Сортировка ФИО

            SortPhis();

            Console.WriteLine("#\n#\n#\n");


            //Компании



            //var companyData = file.GetYur()
            //    .Select(e => new Dictionary<string, dynamic> { { "NameC", e.CorpName }, { "bin", e.Biin }, { "id", e.Id } })
            //    .Take(5)
            //    .OrderByDescending(e => file.GetPhis()
            //    .Where(g => g.CompanyId == e["id"])
            //    .Select(g => new List<long> {g.Id})
            //    .Count());

            var companyData = file.GetYur()
                .Select(x => new CompanyView() { Id = x.Id, NameC = x.CorpName ,Bin = x.Biin, agentsCount = file.GetPhis()
                .Where(g => g.CompanyId == x.Id)
                .Count()})
                .OrderByDescending(x => x.agentsCount)
                .Take(5);


            string outputEnt;
            foreach (var data in companyData)
            {
                var agents = file.GetPhis()
                    .Where(r => r.CompanyId == data.Id)
                    .OrderBy(r => r.SecondName)
                    .ThenBy(r => r.FirstName)
                    .ThenBy(r => r.MiddleName)
                    .Select(r => new List<string> {r.SecondName, r.FirstName, r.MiddleName});
                outputEnt = String.Concat(data.NameC, " ", data.Bin, "\n", "Контрагенты:");
                string contrag = "\n";
                foreach(var agent in agents)
                {
                    contrag = String.Concat(contrag, "\t", agent[0].ToString(), " ", agent[1].ToString(), " ", agent[2].ToString(), "\n");
                }
                outputEnt = String.Concat(outputEnt, contrag);
                Console.WriteLine(outputEnt);
            }
        }

        public static void SortPhis()
        {
            file = new FileManager();
            var personData = file.GetPhis().OrderBy(c => c.SecondName).ThenBy(c => c.FirstName).ThenBy(c => c.MiddleName);
            var personOutput = "";
            foreach (var pd in personData)
            {
                personOutput = String.Concat(personOutput, pd.SecondName," ",pd.FirstName," ",pd.MiddleName, "\n");
            }
            Console.WriteLine(personOutput);
        }
    }
}