using System.Collections.Generic;
using System.ComponentModel;

namespace MyLib
{
    public class Filter
    {
        Parser parse = new Parser();
        List<Heroes> heroes_list = new List<Heroes>();
        List<Heroes> intial_list = new List<Heroes>();

        public Filter()
        {
            heroes_list = parse.Parse();
            intial_list = parse.Parse();
        }

        /// <summary>
        /// меняет копию листа героев
        /// </summary>
        /// <param name="heroes">лист объектов класса Heroes</param>
        public void ChangeList(BindingList<Heroes> heroes)
        {
            int flag = 0;
            for (int i = 0; i < heroes.Count; i++)
            {
                for (int j = flag; j < heroes_list.Count; j++)
                {
                    if (heroes[i].Name == heroes_list[j].Name && heroes[i].Damage != heroes_list[j].Damage)
                    {
                        heroes_list[i].Damage = heroes[i].Damage;
                        flag = i;
                    }
                    if (heroes[i].Name == heroes_list[j].Name && heroes[i].Life != heroes_list[j].Life)
                    {
                        heroes_list[i].Life = heroes[i].Life;
                        flag = i;
                    }
                    if (heroes[i].Name == heroes_list[j].Name && heroes[i].HeadShot != heroes_list[j].HeadShot)
                    {
                        heroes_list[i].HeadShot = heroes[i].HeadShot;
                        flag = i;
                    }
                }
            }
        }

        /// <summary>
        /// идает листу значения первоначального листа</summary>
        /// <param name="heroes">лист объектов класса Heroes</param>
        public void IntialList(ref BindingList<Heroes> heroes)
        {
            heroes.Clear();
            foreach (var item in intial_list)
            {
                heroes.Add(item);
            }
        }

        /// <summary>
        /// идает листу значения первоначального листа</summary>
        /// <param name="heroes">лист объектов класса Heroes</param>
        public void ParseList(ref BindingList<Heroes> heroes)
        {
            heroes.Clear();
            foreach (var item in heroes_list)
            {
                heroes.Add(item);
            }
        }

        /// <summary>
        /// удаляет элементы листа, которые не подходят под фильтр
        /// </summary>
        /// <param name="heroes">лист объектов класса Heroes</param>
        /// <param name="filter">переданное значение фильтра</param>
        /// <param name="param">переданное значение фильтруемой характеристики</param>
        public void UniversalFilter( ref BindingList<Heroes> heroes, double filter, string param)
        {
            //создание копии BindingList
            BindingList<Heroes> cur_list = new BindingList<Heroes>();
            foreach (var item in heroes)
            {
                cur_list.Add(item);
            }
            //удаление неподххлдящих объектов класса Heroes
            switch (param)
            {
                case "Damage":
                    foreach (var item in cur_list)
                    {
                        if (item.Damage != filter)
                            heroes.Remove(item);
                    }
                    break;
                case "Life":
                    foreach (var item in cur_list)
                    {
                        if (item.Life != filter)
                            heroes.Remove(item);
                    }
                    break;
                case "Headshot":
                    foreach (var item in cur_list)
                    {
                        if (item.HeadShot != filter)
                            heroes.Remove(item);
                    }
                    break;
            }
        }
    }
}
