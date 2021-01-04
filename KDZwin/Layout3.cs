using System;
using System.Windows.Forms;
using MyLib;


namespace KDZwin
{
    partial class Form1
    {
        Fight battle = new Fight();

        private void Button6_Click(object sender, EventArgs e)
        {
            Battle(1);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Battle(2);
        }

        /// <summary>
        /// вывод сводки боя
        /// </summary>
        public void Output()
        {
            richTextBox1.Text = $"Name: {player_hero.Name}\nLife: {player_hero.Life}\nDamage: {player_hero.Damage}\nHeadshot: {player_hero.HeadShot}";
            richTextBox2.Text = $"Name: {bot_hero.Name}\n Life: {bot_hero.Life}\nDamage: {bot_hero.Damage}\nHeadshot: {bot_hero.HeadShot}";
        }

        /// <summary>
        /// вывод MessageBox
        /// </summary>
        private void Window()
        {
            DialogResult window = MessageBox.Show(
                 "Вы проиграли! Хотите сыграть еще раз?",
                 "",
                 MessageBoxButtons.OKCancel,
                 MessageBoxIcon.Question,
                 MessageBoxDefaultButton.Button1
                 );
            //закрытие программы
            if (window == DialogResult.Cancel)
            {
                Application.Exit();
            }
            //отчищение всех данных этой игры
            if (window == DialogResult.OK)
            {
                Cleaning();
            }
        }

        /// <summary>
        /// реализация боя
        /// </summary>
        /// <param name="player_choose">выбор вида атаки пользователя</param>
        private void Battle(int player_choose)
        {
            try
            {
                if (player_hero.Life > 0)
                {
                    battle.Battle(player_hero, bot_hero, player_choose);
                    Output();
                    if (player_hero.Life == 0)
                    {
                        writer.RemoveNodes();
                        Window();
                    }
                }
                else
                {
                    Output();
                    Window();
                }
            }
            //проверка на здоровье соперника
            catch (MyException)
            {
                Output();
                DialogResult window = MessageBox.Show(
                  "Вы выиграли! Хотите сыграть еще раз?",
                                 "",
                                 MessageBoxButtons.OKCancel,
                                 MessageBoxIcon.Question,
                                 MessageBoxDefaultButton.Button1
                                 );
                if (window == DialogResult.Cancel)
                {
                    Application.Exit();
                }
                if (window == DialogResult.OK)
                {
                    Cleaning();
                }
            }
        }

        /// <summary>
        /// отчищение всех данных данной игры
        /// </summary>
        public void Cleaning()
        {
            filter.ParseList(ref heroes);
            writer = new XmlWriter();
            choose = new Choose();
            filter = new Filter();
            player_hero = new Heroes();
            bot_hero = new Heroes();
            battle = new Fight();
            answer = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            //переход к первому  Layout
            tableLayoutPanel3.Visible = false;
            tableLayoutPanel1.Visible = true;
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void RichTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
