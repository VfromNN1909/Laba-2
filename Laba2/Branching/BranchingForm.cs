using System;
using System.Windows.Forms;

namespace Laba2
{
    public partial class BranchingForm : Form
    {
        public BranchingForm()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void inflect()
        {
            // ловим ошибку
            try
            {
                // получаем число из текстбокса
                int num = int.Parse(textBox1.Text);
                // остаток
                int x = num % 10;
                // склонения
                string[] inflects = { "рубль", "рубля", "рублей" };
                // если остаток = 1,тогда рубль
                if(x == 1)
                {
                    label3.Text = inflects[0];
                }
                // иначе если от 2 до 4, тогда рубля
                else if(x >= 2 && x <= 4)
                {
                    label3.Text = inflects[1];
                }
                // иначе рублей
                else
                {
                    label3.Text = inflects[2];
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Произошла ошибка!\nНеобходимо ввести число!",
                        "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            inflect();
        }

        // второе задание
        private void calculateOne(double x)
        {
            // нужно для обновления текста в лейбле
            label6.Text = "";
            // это нужно для вывода в конце
            double y = double.MinValue;
            if (x < -5)
            {
                y = -3;
            }
            if (x > -5 && x <= -3)
            {
                y = x + 3;
            }
            if (x > -3 && x < 3)
            {
                // радиус
                double r;
                // пытаемся конвертировать
                bool bR = double.TryParse(textBox3.Text, out r);
                // если конвертировали
                if (bR)
                {
                    // тогда считаем
                    y = Math.Sqrt(r * r - x * x);
                }
                // иначе выводим сообщение об ошибке
                else
                {
                    MessageBox.Show("Введите радиус правильно!",
                        "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
                }
            }
            if (x >= 3 && x < 3)
            {
                y = (3 * x - 9) / 5;
            }
            if (x >= 8)
            {
                y = 3;
            }
            // выводим результат
            if (y != Double.MinValue)
                label6.Text += $"Значение функции = {y}";
        }
        
        // третье задание
        private void calculateTwo(double x, double y, double r)
        {
            label12.Text = "";
            if ((x >= 0 && y >= 0 && x * x + y * y <= r * r) || 
                (x <= 0 && y <= 0 && x * x + y * y <= r * r) || 
                (x < 0 && y > 0 && x + -y >= -r))
            {
                label12.Text = "Точка попала";
            }
            else
            {
                label12.Text = "Точка не попала";
            }
        }

        private void BranchingForm_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            double x;
            bool bX = double.TryParse(textBox2.Text, out x);
            if (bX)
            {
                calculateOne(x);
            }
            else
            {
                MessageBox.Show("Введите аргумент правильно!",
                        "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
            }
            
        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            double x, y, r;
            var coords = textBox4.Text.Split(' ');
            if(coords.Length == 2)
            {
                bool bX = double.TryParse(coords[0], out x);
                bool bY = double.TryParse(coords[1], out y);
                bool bR = double.TryParse(textBox5.Text, out r);
                if (bX && bY && bR)
                {
                    calculateTwo(x, y, r);
                }
                else
                {
                    MessageBox.Show(
                        "Проверьте правильность введенных данных!",
                        "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
                }
            }
            else
            {
                MessageBox.Show("Введите 2 координаты!",
                        "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
            }
            
        }
    }
}
