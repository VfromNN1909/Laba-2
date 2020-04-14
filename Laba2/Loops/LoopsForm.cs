using System;
using System.Windows.Forms;

namespace Laba2.Loops
{
    public partial class LoopsForm : Form
    {
        public LoopsForm()
        {
            InitializeComponent();
        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }
        // функция для вычисления значения функции,для задания 1 
        private void calculateOne(double xFirst, double xLast, double dx)
        {
            // выполняе пока не дойдем до xLast
            while (xFirst <= xLast)
            {
                // инициализируем у
                double y = double.MinValue;
                // блоки условий
                if (xFirst < -5)
                {
                    y = -3;
                }
                if (xFirst > -5 && xFirst <= -3)
                {
                    y = xFirst + 3;
                }
                if (xFirst > -3 && xFirst < 3)
                {
                    y = Math.Sqrt(9 - xFirst * xFirst);
                }
                if (xFirst >= 3 && xFirst < 3)
                {
                    y = (3 * xFirst - 9) / 5;
                }
                if (xFirst >= 8)
                {
                    y = 3;
                }
                // добавляем строку в dataGridView
                dataGridView1.Rows.Add(xFirst, y);
                // делаем шаг
                xFirst += dx;

                for(var i = 0;i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].HeaderCell.Value = 
                        string.Format((i + 1).ToString(), "0");
                }
                
            }
        }
        
        // задание 1
        private void Button1_Click(object sender, EventArgs e)
        {
            // объявляем переменные
            double xFirst, xLast, dx;
            // пытаемся запарсить
            bool bxFirst = double.TryParse(textBox1.Text, out xFirst);
            bool bxLast = double.TryParse(textBox2.Text, out xLast);
            bool bdx = double.TryParse(textBox3.Text, out dx);

            // если получилось
            if(bxFirst && bxLast && bdx)
            {
                // считаем
                calculateOne(xFirst, xLast, dx);
            }
            // если нет
            else
            {
                // выводим сообщение об ошибке
                MessageBox.Show("Проверьте правильность введенных данных!",
                        "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
            }
        }
        // задание 2
        private void Button2_Click(object sender, EventArgs e)
        {
            // счетчик
            int i = 0;
            // переменные
            double x, y, r;
            // количество выстрелов
            int shotCount = 10;
            // пытаемся запарсить
            bool bX = double.TryParse(textBox6.Text, out x);
            bool bY = double.TryParse(textBox5.Text, out y);
            bool bR = double.TryParse(textBox4.Text, out r);

            // если получилось
            if (bX && bY && bR)
            {
                // радиус вводится один раз
                textBox4.Enabled = false;
                // если выстрелов меньше 10, играем дальше
                if (i <= shotCount)
                {
                    // если в мишень попали
                    if ((x >= 0 && y >= 0 && x * x + y * y <= r * r)
                        || (x <= 0 && y <= 0 && x * x + y * y <= r * r)
                        || (x < 0 && y > 0 && x + -y >= -r))
                    {
                        // довавляем 
                        dataGridView2.Rows.Add(x, y, "Попадание!");
                    }
                    // если нет
                    else
                    {
                        // добавляем
                        dataGridView2.Rows.Add(x, y, "Мимо!");
                    }
                    // увеличиваем счетчик
                    i++;
                }
                // если запарсить не удалось
                else
                {
                    // выводим сообщение об ошибке
                    MessageBox.Show("Нельзя превышать количество выстрелов",
                        "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
                }
            }
            // если не получилось
            else
            {
                // выводим сообщение об ошибке
                MessageBox.Show("Проверьте правильность введенных данных!",
                        "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
            }
        }
        // задание 3
        private void Button3_Click(object sender, EventArgs e)
        {
            // переменные
            double xFirst, xLast, i, dx, accuracy, falseF, realF;
            // счетчик
            int count;
            // пытаемся запарсить
            bool bXFirst = double.TryParse(textBox9.Text, out xFirst);
            bool bXLast = double.TryParse(textBox8.Text, out xLast);
            bool bAccuracy = double.TryParse(textBox10.Text, out accuracy);
            bool bDx = double.TryParse(textBox7.Text, out dx);
            // если парсинг прошел успешно
            if(bXFirst && bXLast && bAccuracy && bDx)
            {
                // считаем
                if(xFirst >= -1 && xFirst <= xLast && xFirst < 1 && xLast < 1)
                {
                    for(i = xFirst; i < xLast; i += dx)
                    {
                        falseF = 0;
                        count = 0;
                        realF = Math.Log(1 - i);
                        while (Math.Abs(realF - falseF) > accuracy)
                        {
                            count++;
                            falseF -= (Math.Pow(i, count) / count);
                        }
                        dataGridView4.Rows.Add(i, falseF, realF, count);
                    }
                }
                // если условие не проходит 
                // выводим сообщение об ошибке
                else
                {
                    MessageBox.Show(" -1 <= X < 1 ; Xнач < Xкон ",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            }
            // если не получилось запарсить
            // выводим сообщение об ошибке
            else
            {
                MessageBox.Show("Проверьте правильность введенных данных!",
                        "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
            }
            
        }
    }
}
