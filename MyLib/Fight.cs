using System;

namespace MyLib
{
    public class Fight
    {
        Random rand = new Random();
        XmlWriter changes = new XmlWriter();

        /// <summary>
        /// реализует один ход игрока и бота
        /// </summary>
        /// <param name="h1">объект класса Heroes, которого выбрал пользователь</param>
        /// <param name="h2">объект класса Heroes, которого выбрал бот</param>
        /// <param name="choose">параметр, определяющий выбор типа хода пользователя</param>
        public void Battle(Heroes h1, Heroes h2, int choose)
        {
            double sum = 0;
            double rnd;
            switch (choose)
            {
                //реализуется ход героя пользователя, если его выбор был "обычной атакой"
                case 1:
                    //суммирование урона, нанесенного герою бота
                    for (int i = 0; i < 5; i++)
                    {
                        if (rand.NextDouble() < 0.7) sum += 0.1 * h1.Damage;
                    }
                    //нанесение урона герою бота
                    h2.Life -= sum;
                    if (h2.Life < 0) h2.Life = 0;
                    sum = 0;
                    break;
                //реализуется ход героя пользователя, если его выбор был "высттрел с прицелом"
                case 2:
                    //суммирование урона, нанесенного герою бота
                    for (int i = 0; i < 3; i++)
                    {
                        rnd = rand.NextDouble();
                        if (rnd < 0.2)
                        {
                            sum += h1.HeadShot;
                            continue;
                        }
                        if (rnd < 0.3) sum += 0.4 * h1.Damage;
                    }
                    //нанесение урона герою бота
                    h2.Life -= sum;
                    if (h2.Life < 0) h2.Life = 0;
                    sum = 0;
                    break;
            }
            //реализация хода бота
            if (h2.Life > 0)
            {
                //случайная генерация выбора ботом типа атаки 
                if (rand.NextDouble() <= 0.5)
                {
                    //суммирование урона, нанесенного герою пользоателя
                    for (int i = 0; i < 5; i++)
                    {
                        if (rand.NextDouble() < 0.7) sum += 0.1 * h2.Damage;
                    }
                    //нанесение урона герою пользователя
                    h1.Life -= sum;
                    if (h1.Life < 0) h1.Life = 0;
                }
                else
                {
                    //суммирование урона, нанесенного герою пользоателя
                    for (int i = 0; i < 3; i++)
                    {
                        rnd = rand.NextDouble();
                        if (rnd < 0.2)
                        {
                            sum += h1.HeadShot;
                            continue;
                        }
                        if (rnd < 0.3) sum += 0.4 * h1.Damage;
                    }
                    //нанесение урона герою бота
                    h1.Life -= sum;
                    if (h1.Life < 0) h1.Life = 0;
                }
                //сохранение изменений характеристик героев после хода в xml файл
                changes.ChangeXml(h1, h2);
            }
            else
            {
                changes.RemoveNodes();
                throw new MyException();
            }
        }
    }
}
