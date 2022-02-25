using ConsoleApp2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    internal class Program
    {
        internal static FileManager file;
        static void Main(string[] args)
        {
            file = new FileManager();

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
            File.WriteAllText(FileManager.GetPhisPath(), phisRecor);

            List<YurFace> yur = new List<YurFace>()
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

            string yurRecord = JsonConvert.SerializeObject(yur);
            File.WriteAllText(FileManager.GetYurPath(), yurRecord);

            //Сортировка ФИО

            SortPhis();
            Console.WriteLine("#\n#\n#\n");

            //Компании

            var companyData = file.GetYur()
                .Select(x => new CompanyView()
                {
                    Id = x.Id,
                    NameC = x.CorpName,
                    Bin = x.Biin,
                    agentsCount = file.GetPhis()
                        .Where(g => g.CompanyId == x.Id)
                        .Count()
                })
                .OrderByDescending(x => x.agentsCount)
                .Take(5);

            string outputEnt;
            foreach (var data in companyData)
            {
                var agents = file.GetPhis()
                    .Where(r => r.CompanyId == data.Id)
                    .OrderBy(r => r.SecondName)
                    .ThenBy(r => r.FirstName)
                    .ThenBy(r => r.MiddleName);
                outputEnt = string.Concat(data.NameC, " ", data.Bin, "\n", "Контрагенты:");
                string contrag = "\n";
                foreach (var agent in agents)
                {
                    contrag = $"{contrag} \t {agent.SecondName} {agent.FirstName} {agent.MiddleName} \n";
                }
                outputEnt = string.Concat(outputEnt, contrag);
                Console.WriteLine(outputEnt);
            }
        }

        public static void SortPhis()
        {
            var personData = file.GetPhis().OrderBy(c => c.SecondName).ThenBy(c => c.FirstName).ThenBy(c => c.MiddleName);
            var personOutput = "";
            foreach (var pd in personData)
            {
                personOutput = string.Concat(personOutput, pd.SecondName, " ", pd.FirstName, " ", pd.MiddleName, "\n");
            }
            Console.WriteLine(personOutput);
        }
    }
}