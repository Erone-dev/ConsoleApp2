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

            var phis = new List<PhisicalFace>()
            {
                new ()
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
                new ()
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
                new ()
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
                new ()
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
                new ()
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
                new ()
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
                new ()
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
                new ()
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
            var phisRecord = JsonConvert.SerializeObject(phis);
            file.WritePhis(phisRecord);

            var yur = new List<YurFace>()
            {
                new ()
                {
                    CorpName = "Jusan Garant",
                    Biin = "123456789012",
                    CreateDate = DateTime.Now.ToString(),
                    AuthorCreate = "Жека",
                    Id = 0
                },
                new ()
                {
                    CorpName = "Costa Coffee",
                    Biin = "098765432109",
                    CreateDate = DateTime.Now.ToString(),
                    AuthorCreate = "Жека",
                    Id = 1
                },
                new ()
                {
                    CorpName = "Магнолия",
                    Biin = "232323444555",
                    CreateDate = DateTime.Now.ToString(),
                    AuthorCreate = "Жека",
                    Id = 2
                },
                new ()
                {
                    CorpName = "Sulpak",
                    Biin = "566778899034",
                    CreateDate = DateTime.Now.ToString(),
                    AuthorCreate = "Жека",
                    Id = 3
                },
                new ()
                {
                    CorpName = "TechnoDom",
                    Biin = "897867564534",
                    CreateDate = DateTime.Now.ToString(),
                    AuthorCreate = "Жека",
                    Id = 4
                }
            };
            var yurRecord = JsonConvert.SerializeObject(yur);
            file.WriteYur(yurRecord);

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

            var outputEnt = "";
            foreach (var data in companyData)
            {
                var agents = file.GetPhis()
                    .Where(r => r.CompanyId == data.Id)
                    .OrderBy(r => r.SecondName)
                    .ThenBy(r => r.FirstName)
                    .ThenBy(r => r.MiddleName);
                outputEnt = $"{data.NameC} {data.Bin} \n Контрагенты: ";
                var contrag = "\n";
                foreach (var agent in agents)
                {
                    contrag = String.Concat(contrag, $"\t {agent.SecondName} {agent.FirstName} {agent.MiddleName} \n");
                }
                outputEnt = string.Concat(outputEnt, contrag);
                Console.WriteLine(outputEnt);
            }
        }

        public static void SortPhis()
        {
            var personData = file.GetPhis()
                .OrderBy(c => c.SecondName)
                .ThenBy(c => c.FirstName)
                .ThenBy(c => c.MiddleName);
            var personOutput = "";
            foreach (var pd in personData)
            {
                personOutput = string.Concat(personOutput, $"{pd.SecondName} {pd.FirstName} {pd.MiddleName} \n");
            }
            Console.WriteLine(personOutput);
        }
    }
}