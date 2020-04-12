using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Laba2.Arrays
{
    public partial class ArraysForm : Form
    {

        private int[,] array;
        private string fileName;

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
                    if (j == size - 1)
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
                Random random = new Random();
                string matrix = "";
                array = new int[size, size];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        int element = random.Next(-5, 20);
                        array[i, j] = element;
                        matrix += element + "\t";
                    }
                    matrix += Environment.NewLine;
                }
                textBox3.Text = matrix;
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
                var results = sumInColumnWithoutNegatives(array, 
                    (int)Math.Sqrt(array.Length));
                foreach (String result in results)
                {
                    resultLabel2.Text += result + "\n";
                }
                resultLabel2.Text += $"Минимум среди сумм модулей элементов диагоналей,\n" +
                    $"параллельных побочной диагонали матрицы: {minOfSumDiag(array)}";
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

        private int minOfSumDiag(int[,] arr)
        {
            int size = (int)Math.Sqrt(arr.Length);
            int summin = 0;
            for (int i = 0; i < size - 1; i++) //левый верхний треугольник 
            {
                int sum = 0;
                for (int j = 0; j <= i; j++)
                {
                    if (j != size - 1)
                    {
                        sum += Math.Abs(arr[i - j, j]);
                    }
                    if ((i == 0) || (summin > sum))
                    {
                        summin = sum;
                    }
                    
                }
            }
            for (int i = 1; i < size - 1; i++) //правый нижний треугольник 
            {
                int sum = 0;
                for (int j = 0; j < size - i; j++)
                {
                    sum += Math.Abs(arr[i + j, size - i - j]);
                }
                if (summin > sum)
                {
                    summin = sum;
                }
            }
            if (Math.Abs(array[size - 1, size - 1]) < summin)
            {
                summin = Math.Abs(arr[size - 1, size - 1]);
            }
            return summin;
        }

        private string shuffleWords(string filePath)
        {
            var sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(filePath))
            {
                // читать будем построчно
                string line; // собсно строка
                // если не дошли до конца
                while ((line = sr.ReadLine()) != null)
                {
                    // то делим строку на слова
                    string[] words = line.Split(new char[] { ' ', ',', '.' });
                    // проходимся по ним
                    for (int i = 0; i < words.Length - 1; i += 2)
                    {
                        // и меняем местами
                        sb.Append(words[i + 1] + " " + words[i] + " ");
                    }
                    // на случай, если количество слов в строке нечетное
                    if (words.Length % 2 != 0)
                    {
                        // просто выводим в конце последнее слово
                        sb.Append(words[words.Length - 1]);
                    }
                }
            }
            return sb.ToString();
        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"E:\",
                Title = "Выберите текстовый файл",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
            }
        }

        private void OpenFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if(fileName != null)
            {
                string shuffledText = shuffleWords(fileName);
                textBox5.Text = shuffledText;
            }
            else
            {
                MessageBox.Show("Выберите файл!",
                        "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
            }
            
        }
    }
}
