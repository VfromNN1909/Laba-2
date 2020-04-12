using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Laba2.Arrays
{
    public partial class ArraysForm : Form
    {
        public ArraysForm()
        {
            InitializeComponent();
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        // функция удаляет числа из некоторого интервала
        // сдвигает массив и заполняет оставшуюся часть нулями
        private double[] CleanArray(double[] arr, double a, double b)
        {
            int end = arr.Length - 1; // конец массива
            // проходимся по массиву
            for (int i = 0; i <= end; i++)
                // если число в интервале
                if ((Math.Abs(arr[i]) >= a) && (Math.Abs(arr[i]) <= b))
                {
                    // тогда сдвигаем
                    for (int j = i; j < end; j++)
                    {
                        arr[j] = arr[j + 1];
                    }
                    // в конец добавляем ноль
                    arr[end] = 0;
                    end--;
                    i--;
                }
            // возвращаем массив
            return arr;
        }
        // функция складывает элементы массива, до последнего положительного
        private double SumUntilLastPositive(double[] arr)
        {
            double sum = 0;
            int len = arr.Length - 1;
            // идем с конца, находим последний положительный
            while (arr[len] < 0)
                len--;
            //  и складываем до него
            for (int i = 0; i < len; i++)
            {
                sum += arr[i];
            }
            // возвращаем сумму
            return sum;
        }
        // читаем массив с клавиатуры
        private double[] ReadArray()
        {
            double[] arr = null;
            try
            {
                arr = textBox1.Text.Split(' ').Select(num => double.Parse(num)).ToArray();
            }
            catch
            {
                MessageBox.Show("Проверьте правильность введенных данных!",
                        "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
            }
            return arr;            
        }
        private double[] GetInterval()
        {
            double[] interval = null;
            try
            {
                interval = textBox2.Text.Split(' ')
                    .Select(num => double.Parse(num)).ToArray();
            }
            catch
            {
                MessageBox.Show("Проверьте правильность введенных данных!",
                        "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
            }
            return interval;
        } 

        private void Button1_Click(object sender, EventArgs e)
        {
            String result = "";
            var arr = ReadArray();
            var interval = GetInterval();
            if(arr != null && result != null)
            {
                result += $"Максимальный элемент массива: {arr.Max()}\n";
                result += $"Сумма элементов до последнего положительного: {SumUntilLastPositive(arr)}\n";
                arr = CleanArray(arr, interval[0], interval[1]);
                string arrString = string.Join(" ", arr);
                result += $"Массив после преобразований: " + arrString;
            }
            resultLabel.Text = result;

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }


        // функция для счета суммы элементов столбца без отрицательных элементов
        private List<string> sumInColumnWithoutNegatives(int[,] arr, int size)
        {
            var result = new List<string>();
            int sum = 0; // сумма
            // проходимся по массиву
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    // если элемент отрицательный
                    if (arr[j, i] < 0)
                    {
                        // то прерываем итерацию цикла
                        break;
                    }
                    // складываем
                    sum += arr[j, i];
                    // выводим
                    if (j == size)
                    {
                        result.Add($"Сумма элементов столбца {i + 1} = {sum}\n");
                        
                    }
                }
                // обнуляем сумму для других столбцов
                sum = 0;
            }
            // если нужных столбцов нет,то выводим
            if (result.Count == 0)
            { 
                result.Add("Отсутствуют столбцы, соответствующие условию");
            }
            return result;
        }
        // заполняем массив рандомными элементами
        private String readRandomArray(int size)
        {
            Random random = new Random();
            string matrix = "";
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int element = random.Next(-5, 20);
                    matrix += element + "\t";
                }
                matrix += Environment.NewLine;
            }
            
            return matrix;
        }
       

       

        private void Button3_Click(object sender, EventArgs e)
        {
            int size;
            bool bSize = int.TryParse(textBox4.Text, out size);
            if (bSize)
            {
                textBox3.Text = readRandomArray(size);
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
            resultLabel2.Text = "";
            if(textBox3.Text != null)
            {
                int size = Convert.ToInt32(Math.Sqrt(textBox3.Text.Length));
                var strArr = textBox3.Text.Split(' ', '\n', '\t');
                var arr = new int[strArr.Length];
                int index = 0;
                var twoDimArr = new int[size, size];
                for(int i = 0;i < arr.Length; i++)
                {
                    int temp = int.Parse(strArr[i]);
                    arr[i] = temp;
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        twoDimArr[i, j] = arr[index];
                        index++;
                    }
                }
                var results = sumInColumnWithoutNegatives(twoDimArr, size);
                foreach (String result in results)
                {
                    resultLabel2.Text += result + "\n";
                }
                
            }
            else
            {
                MessageBox.Show("Введите матрицу!",
                        "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
            }
        }
    }
}
