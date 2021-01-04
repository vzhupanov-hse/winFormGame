using System;
using System.Collections.Generic;

namespace MyLib
{
    public class Choose
    {
        Parser parse = new Parser();
        Random rand = new Random();

        /// <summary>
        /// совершает выбор объекта класса Heroes из листа 
        /// </summary>
        /// <param name="player_hero">объект класса Heroes, выбранный пользователем</param>
        /// <returns>объект класса Heroes</returns>
        public Heroes Bot_choose(Heroes player_hero)
        {
            Heroes bot_player = new Heroes();
            try
            {
                List<Heroes> list_heroes = parse.Parse();
                //случайный выбор бота и сравнение его с выбором пользователя
                Heroes bot_choose = list_heroes[rand.Next(0, list_heroes.Count)];
                if (bot_choose.Name != player_hero.Name || bot_choose.Life != 0) bot_player = bot_choose;
                else Bot_choose(player_hero);
            }
            catch (Exception)
            {
                throw new Exception();
            }
            return bot_player;
        }
    }
}
