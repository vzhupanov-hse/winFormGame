using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System;

namespace MyLib
{
    public class Parser
    {
        const string path = @"..\..\..\overwatch.csv";
        static string[] head = new string[6];
        public static string[] Head { get => head; }

        /// <summary>
        /// считывание данных из файла .csv
        /// </summary>
        /// <returns>листобъектов класса Heroes</returns>
        public List<Heroes> Parse()
        {
            try
            {
                List<Heroes> herospecs = new List<Heroes>();
                string stringlines;
                string[] specs;
                using (StreamReader sr = new StreamReader(path))
                {
                    //считывание заголовков столбцов таблицы файла .csv
                    string headline = sr.ReadLine();
                    head = headline.Split(';');
                    //считывание значений файла .csv
                    while ((stringlines = sr.ReadLine()) != null)
                    {
                        specs = stringlines.Split(';');
                        Heroes hero = new Heroes();
                        hero.Name = specs[0];
                        if (specs[1] == "") hero.Damage = 0;
                        else hero.Damage = double.Parse(specs[1], CultureInfo.InvariantCulture);
                        if (specs[2] == "") hero.HeadShot = 0;
                        else hero.HeadShot = double.Parse(specs[2], CultureInfo.InvariantCulture);
                        if (specs[3] == "") hero.Shoot = 0;
                        else hero.Shoot = double.Parse(specs[3], CultureInfo.InvariantCulture);
                        if (specs[4] == "") hero.Life = 0;
                        else hero.Life = double.Parse(specs[4], CultureInfo.InvariantCulture);
                        if (specs[5] == "") hero.Reload = 0;
                        else if (specs[5] == "infinity") hero.Reload = int.MaxValue;
                        else hero.Reload = double.Parse(specs[5], CultureInfo.InvariantCulture);
                        herospecs.Add(hero);
                    }
                }
                return herospecs;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

    }
}
