using System;
using System.ComponentModel;
using System.Windows.Forms;
using MyLib;

namespace KDZwin
{
    public partial class Form1 : Form
    {
        XmlWriter writer = new XmlWriter();
        Heroes player_hero = new Heroes();
        Heroes bot_hero = new Heroes();
        BindingList<Heroes> heroes = new BindingList<Heroes>(new Parser().Parse());

        /// <summary>
        /// инициализация всех компонентов
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            tableLayoutPanel2.Visible = false;
            tableLayoutPanel3.Visible = false;
            dataGridView1.DataSource = heroes;
            dataGridView1.Columns["Name"].ReadOnly = true;
        }

        /// <summary>
        /// переход на следующий Layout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = false;
            tableLayoutPanel2.Visible = true;
        }

        /// <summary>
        /// переход на третий Layout в случае сохранения игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, EventArgs e)
        {
            XmlWriter check = new XmlWriter();
            //проверка, была ли игра не закончена
            if (check.HasnotGameFinished())
            {
                //переход на третий Layout и инициализация нужных компонентов
                Heroes hero = new Heroes();
                player_hero = writer.ReadXmlHeroes(out hero);
                bot_hero = hero;
                Output();
                tableLayoutPanel1.Visible = false;
                tableLayoutPanel3.Visible = true;
            }
            else
            {
                //вывод MessageBox, с выбором начать новую игру или закрыть приложение
                DialogResult window = MessageBox.Show(
                "Соxраненной игры нет! Хотите начать новую?",
                "",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1
                );
                if (window == DialogResult.OK)
                {
                    tableLayoutPanel1.Visible = false;
                    tableLayoutPanel2.Visible = true;

                }
                if (window == DialogResult.Cancel) Application.Exit();
            }
        }

        /// <summary>
        /// завершение работы приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            MessageBox.Show("Введите числовое значение!");
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

