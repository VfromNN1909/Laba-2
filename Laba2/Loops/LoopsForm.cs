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
        private void calculateOne(double xFirst, double xLast, double dx)
        {
            
            while(xFirst <= xLast)
            {
                double y = double.MinValue;
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
                dataGridView1.Rows.Add(xFirst, y);
                xFirst += dx;
                for(var i = 0;i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].HeaderCell.Value = 
                        string.Format((i + 1).ToString(), "0");
                }
                
            }
        }
        

        private void Button1_Click(object sender, EventArgs e)
        {
            double xFirst, xLast, dx;
            bool bxFirst = double.TryParse(textBox1.Text, out xFirst);
            bool bxLast = double.TryParse(textBox2.Text, out xLast);
            bool bdx = double.TryParse(textBox3.Text, out dx);

            if(bxFirst && bxLast && bdx)
            {
                calculateOne(xFirst, xLast, dx);
            }
            else
            {
                MessageBox.Show("Проверьте правильность введенных данных!",
                        "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            double x, y, r;
            int shotCount = 10;
            bool bX = double.TryParse(textBox6.Text, out x);
            bool bY = double.TryParse(textBox5.Text, out y);
            bool bR = double.TryParse(textBox4.Text, out r);

            if (bX && bY && bR)
            {
                textBox4.Enabled = false;

                if(i <= shotCount)
                {
                    if ((x >= 0 && y >= 0 && x * x + y * y <= r * r)
                        || (x <= 0 && y <= 0 && x * x + y * y <= r * r)
                        || (x < 0 && y > 0 && x + -y >= -r))
                    {
                        dataGridView2.Rows.Add(x, y, "Попадание!");
                    }
                    else
                    {
                        dataGridView2.Rows.Add(x, y, "Мимо!");
                    }
                    i++;
                }
                else
                {
                    MessageBox.Show("Нельзя превышать количество выстрелов",
                        "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
                }
            }
            else
            {
                MessageBox.Show("Проверьте правильность введенных данных!",
                        "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            double xFirst, xLast, i, dx, accuracy, falseF, realF;
            int count;
            bool bXFirst = double.TryParse(textBox9.Text, out xFirst);
            bool bXLast = double.TryParse(textBox8.Text, out xLast);
            bool bAccuracy = double.TryParse(textBox10.Text, out accuracy);
            bool bDx = double.TryParse(textBox7.Text, out dx);
            if(bXFirst && bXLast && bAccuracy && bDx)
            {
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
                else
                {
                    MessageBox.Show(" -1 <= X < 1 ; Xнач < Xкон ",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            }
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
