using ConsoleApp2.Models;
using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    internal class Initializtor
    {
        internal List<PhisicalFace> Phiisical()
        {
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
            return phis;
        }

        internal List<YurFace> Yuridical()
        {
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
            return yur;
        }
    }
}
