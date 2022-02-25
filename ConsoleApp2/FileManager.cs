using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleApp2
{

    internal  class FileManager
    {

        internal static string entity = @"entity.json";
        internal static string individ = @"individual.json";


        //Получение записей
        public  List<YurFace> GetYur()
        {
            List<YurFace> yur = JsonConvert.DeserializeObject<List<YurFace>>(File.ReadAllText(entity));
            return yur;
        }

        public List<PhisicalFace> GetPhis()
        {
            List<PhisicalFace> phis = JsonConvert.DeserializeObject<List<PhisicalFace>>(File.ReadAllText(individ));
            return phis;
        }

        ////Создание Текстовых файлов по id записи
        //internal static void createPhisFile(long faceId)
        //{
        //    string pth = individ;
        //    List<PhisicalFace> lst = JsonConvert.DeserializeObject<List<PhisicalFace>>(File.ReadAllText(pth));
        //    StringBuilder sb;
        //    StringBuilder filename;
        //    foreach (var l in lst)
        //    {
        //        if (l.Id == faceId)
        //        {
        //            sb = new StringBuilder("Имя: " + l.name + ";\r" + "Фамилия: "
        //            + l.family + ";\r" + "Отчество: " + l.otchestvo + ";\r" + "ИИН: "
        //            + l.biin + ";\r" + "Автор записи: " + l.author_create + ";\r" + "Дата: "
        //            + l.create_date);
        //            filename = new StringBuilder("Физическое лицо " + l.name);
        //            writeDocument(filename.ToString(), sb.ToString());
        //            break;
        //        }
        //        else
        //        {
        //            throw new Exception("Ошибка! Id не найден");
        //        }
        //    }
        //}

        //internal static void createYurFile(long faceId)
        //{
        //    string pth = entity;
        //    List<YurFace> lst = JsonConvert.DeserializeObject<List<YurFace>>(File.ReadAllText(pth));
        //    StringBuilder sb;
        //    StringBuilder filename;
        //    foreach (var e in lst)
        //    {
        //        if (e.Id == faceId)
        //        {
        //            StringBuilder ag = new StringBuilder();
        //            foreach (var a in e.agents)
        //            {
        //                if (a == e.agents.Count - 1)
        //                {
        //                    ag.Append(a);
        //                }
        //                else
        //                {
        //                    ag.Append(a + ", ");
        //                }
        //            }
        //            sb = new StringBuilder("Название компании: " + e.corp_name + ";\r" + "Контрагенты: "
        //            + ag.ToString() + ";\r" + "БИН: " + e.biin + ";\r" + "Автор записи: " + e.author_create + ";\r" + "Дата: "
        //            + e.create_date);
        //            filename = new StringBuilder("Юридическое лицо " + e.corp_name);
        //            writeDocument(filename.ToString(), sb.ToString());
        //            break;
        //        }
        //        else
        //        {
        //            throw new Exception("Ошибка! Id не найден");
        //        }
        //    }

        //}

        //private static void writeDocument(string fileName, string text)
        //{
        //    string path = new StringBuilder(FileManager.files + "\\" + fileName).ToString();
        //    StreamWriter str = new StreamWriter(path, false);
        //    str.WriteLine(text);
        //    str.Close();
        //}

        ////Чтение и вывод в консоль текстовых файлов

        //internal static string readDocument(string fileName)
        //{
        //    FileInfo fileInf = new FileInfo(fileName);
        //    string path = fileInf.FullName;
        //    StreamReader str = new StreamReader(path);
        //    string line;
        //    StringBuilder sb = new StringBuilder();
        //    while ((line = str.ReadLine()) != null)
        //    {
        //        sb.Append(line + "\n\n");
        //    }
        //    string text = sb.ToString();
        //    return text;
        //}

        ////Cоздать новую запись

        //internal static void createNewPhisRecord(PhisicalFace obj)
        //{
        //    string pth = individ;
        //    List<PhisicalFace> lst = JsonConvert.DeserializeObject<List<PhisicalFace>>(File.ReadAllText(pth));
        //    lst.Add(obj);
        //    string json = JsonConvert.SerializeObject(obj);
        //    File.WriteAllText(pth, json);
        //}

        //internal static void createNewYurRecord(YurFace obj)
        //{
        //    string pth = entity;
        //    List<YurFace> lst = JsonConvert.DeserializeObject<List<YurFace>>(File.ReadAllText(pth));
        //    lst.Add(obj);
        //    string json = JsonConvert.SerializeObject(obj);
        //    File.WriteAllText(pth, json);
        //}

        ////Для моделей

        //internal static long getId(string idName)
        //{
        //    Dictionary<string, dynamic> Id = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(File.ReadAllText(subdata));
        //    long IdRes = Id[idName];
        //    Id[idName]++;
        //    string json = JsonConvert.SerializeObject(Id);
        //    File.WriteAllText(subdata, json);
        //    return IdRes;
        //}

        //internal static string searchYurData(long id, string key)
        //{
        //    List<YurFace> lst = JsonConvert.DeserializeObject<List<YurFace>>(File.ReadAllText(pth));
        //    return "";
        //}

        //internal static string searchPhisData(long id, string key)
        //{

        //    return "";
        //}

        //private static string search<T>(long id, string key, List<T> lst)
        //{
        //    if()
        //    return "";
        //}
    }

}
