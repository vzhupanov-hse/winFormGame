using System;
using MyLib;
using System.Windows.Forms;
using System.Globalization;

namespace KDZwin
{
    partial class Form1
    {
        Choose choose = new Choose();
        Filter filter = new Filter();
        string answer = "";
        string copy1 = "";
        string copy2 = "";
        string copy3 = "";

        /// <summary>
        /// переход на третий Layout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button5_Click(object sender, EventArgs e)
        {
            if (answer != "")
            {
                tableLayoutPanel2.Visible = false;
                tableLayoutPanel3.Visible = true;
            }
            //вывод MessageBox, в случае, если герой не был выбран
            if (textBox1.Text == "")
            {
                DialogResult window = MessageBox.Show(
                  "Для начала выберите героя",
                  "",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Warning,
                  MessageBoxDefaultButton.Button1
                  );
            }
            //вывод MessageBox, в случае, если выбранного героя не существует
            if (answer == "" && textBox1.Text != "")
            {
                DialogResult window = MessageBox.Show(
               "Такого героя не существует!",
               "",
               MessageBoxButtons.OK,
               MessageBoxIcon.Warning,
               MessageBoxDefaultButton.Button1
               );
                textBox1.Text = "";
            }
        }

        /// <summary>
        /// считывание выбора пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            //сравнение выбора пользователя с листом героев 
            foreach (var item in heroes)
            {
                if (textBox1.Text.ToLower() == item.Name.ToLower())
                {
                    answer = item.Name;
                    player_hero = item;
                    bot_hero = choose.Bot_choose(player_hero);
                    Output();
                    writer.ChangeXml(player_hero, bot_hero);
                    if (player_hero.Life == 0)
                        writer.RemoveNodes();
                }
            }
        }

        /// <summary>
        /// вывод MessageBox
        /// </summary>
        private void Error()
        {
            DialogResult window = MessageBox.Show(
              "Пожалуйста, введите целое или дробное число в формате: XXX,X",
              "",
              MessageBoxButtons.OK,
              MessageBoxIcon.Warning,
              MessageBoxDefaultButton.Button1
              );
        }

        /// <summary>
        /// изменяет лист объектов класса Heroes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button4_Click(object sender, EventArgs e)
        {
            int check = 0;
            if (textBox2.Text == "" && copy1 != textBox2.Text ||
                textBox3.Text == "" && copy2 != textBox3.Text ||
                textBox4.Text == "" && copy3 != textBox4.Text)
            {
                //изменение копии листа
                filter.ChangeList(heroes);
                //вывод первоначального листа
                filter.IntialList(ref heroes);
                dataGridView1.DataSource = heroes;
            }
            if (textBox2.Text != "")
            {
                try
                {
                    copy1 = textBox2.Text;
                    //изменение листа героев
                    filter.UniversalFilter(ref heroes, double.Parse(textBox2.Text, CultureInfo.InvariantCulture), "Damage");
                    dataGridView1.DataSource = heroes;
                }
                catch
                {
                    check++;
                    textBox2.Text = "";
                    //вывод первоначального листа
                    filter.ChangeList(heroes);
                    filter.IntialList(ref heroes);
                    dataGridView1.DataSource = heroes;
                }
            }
            if (textBox3.Text != "")
            {
                try
                {
                    copy2 = textBox3.Text;
                    //изменение листа героев
                    filter.UniversalFilter(ref heroes, double.Parse(textBox3.Text, CultureInfo.InvariantCulture), "Life");
                    dataGridView1.DataSource = heroes;
                }
                catch
                {
                    check++;
                    textBox3.Text = "";
                    //вывод первоначального листа
                    filter.ChangeList(heroes);
                    filter.IntialList(ref heroes);
                    dataGridView1.DataSource = heroes;
                }
            }
            if (textBox4.Text != "")
            {
                try
                {
                    copy3 = textBox4.Text;
                    //изменение листа героев
                    filter.UniversalFilter(ref heroes, double.Parse(textBox4.Text, CultureInfo.InvariantCulture), "Headshot");
                    dataGridView1.DataSource = heroes;
                }
                catch
                {
                    check++;
                    textBox4.Text = "";
                    //вывод первоначального листа
                    filter.ChangeList(heroes);
                    filter.IntialList(ref heroes);
                    dataGridView1.DataSource = heroes;
                }
            }
            if (check != 0) Error();
        }
    }
}
