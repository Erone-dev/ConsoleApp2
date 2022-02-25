using ConsoleApp2.Models;
using System;
using System.Linq;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var file = new FileManager();
            var init = new Initializtor();

            file.WritePhis(init.Phiisical());
            file.WriteYur(init.Yuridical());

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

            Console.WriteLine("#\n#\n#\n");

            //Компании

            var companyData = file.GetYur()
                .Select(x => new CompanyView()
                {
                    Id = x.Id,
                    NameC = x.CorpName,
                    Bin = x.Biin,
                    AgentsCount = file.GetPhis()
                        .Where(g => g.CompanyId == x.Id)
                        .Count()
                })
                .OrderByDescending(x => x.AgentsCount)
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
    }
}