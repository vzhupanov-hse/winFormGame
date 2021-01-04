using System.Globalization;
using System.Xml;
using System.Xml.Linq;

namespace MyLib
{
    public class XmlWriter
    {
        string pathXML = @"..\..\..\xmlheroes.xml";
        XmlDocument Xdoc = new XmlDocument();

        /// <summary>
        /// проверка имеет ли XML файл дочерние узлы
        /// </summary>
        /// <returns>bool переменная</returns>
        public bool HasnotGameFinished()
        {
            Xdoc.Load(pathXML);
            return Xdoc.SelectSingleNode("heroes").HasChildNodes;
        }

        /// <summary>
        /// считывание данных из XML файла
        /// </summary>
        /// <param name="hero">герой бота</param>
        /// <returns>объект класса Heroes c измененными значениями полей</returns>
        public Heroes ReadXmlHeroes(out Heroes hero)
        {
            Heroes hero1 = new Heroes();
            hero = new Heroes();
            //загрузка XML документа
            Xdoc.Load(pathXML);
            //считывание данных и их запись в поля объектов класса Heroes
            hero1.Name = Xdoc.SelectSingleNode("heroes/hero1/name").InnerText;
            hero1.Damage = double.Parse(Xdoc.SelectSingleNode("heroes/hero1/damage").InnerText, CultureInfo.InvariantCulture);
            hero1.HeadShot = double.Parse(Xdoc.SelectSingleNode("heroes/hero1/headshot").InnerText, CultureInfo.InvariantCulture);
            hero1.Shoot = double.Parse(Xdoc.SelectSingleNode("heroes/hero1/shoot").InnerText, CultureInfo.InvariantCulture) ;
            hero1.Life = double.Parse(Xdoc.SelectSingleNode("heroes/hero1/life").InnerText, CultureInfo.InvariantCulture);
            hero1.Reload = double.Parse(Xdoc.SelectSingleNode("heroes/hero1/reload").InnerText, CultureInfo.InvariantCulture);
            hero.Name = Xdoc.SelectSingleNode("heroes/hero2/name").InnerText;
            hero.Damage = double.Parse(Xdoc.SelectSingleNode("heroes/hero2/damage").InnerText, CultureInfo.InvariantCulture);
            hero.HeadShot = double.Parse(Xdoc.SelectSingleNode("heroes/hero2/headshot").InnerText, CultureInfo.InvariantCulture);
            hero.Shoot = double.Parse(Xdoc.SelectSingleNode("heroes/hero2/shoot").InnerText, CultureInfo.InvariantCulture);
            hero.Life = double.Parse(Xdoc.SelectSingleNode("heroes/hero2/life").InnerText, CultureInfo.InvariantCulture);
            hero.Reload = double.Parse(Xdoc.SelectSingleNode("heroes/hero2/reload").InnerText, CultureInfo.InvariantCulture);
            return hero1;
        }

        /// <summary>
        /// изменение данных XML документа
        /// </summary>
        /// <param name="h1">объект класса Heroes, выбранный пользователем</param>
        /// <param name="h2">объект класса Heroes, выбранный ботом</param>
        public void ChangeXml(Heroes h1, Heroes h2)
        {
            //удаление всех дочерних узлов у документа XML
            RemoveNodes();
            //создание нового объекта класса XDocument и запись в него данных
            XDocument xdoc = new XDocument(new XElement("heroes",
                new XElement("hero1",
                    new XElement("name", h1.Name),
                    new XElement("damage", h1.Damage),
                    new XElement("headshot", h1.HeadShot),
                    new XElement("shoot", h1.Shoot),
                    new XElement("life", h1.Life),
                    new XElement("reload", h1.Reload)),
                new XElement("hero2",
                    new XElement("name", h2.Name),
                    new XElement("damage", h2.Damage),
                    new XElement("headshot", h2.HeadShot),
                    new XElement("shoot", h2.Shoot),
                    new XElement("life", h2.Life),
                    new XElement("reload", h2.Reload))));
            //загрузка созданного файла XML по заданному пути
            xdoc.Save(pathXML);
        }

        /// <summary>
        /// удаление дочерних узлов у документа XML
        /// </summary>
        public void RemoveNodes()
        {
            //загрузка XML документа
            Xdoc.Load(pathXML);
            //удаление дочерних узлов
            Xdoc.SelectSingleNode("heroes").RemoveAll();
            //загрузка измененного файла XML по заданному пути
            Xdoc.Save(pathXML);
        }
    }
}
