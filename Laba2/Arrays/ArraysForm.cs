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
        // матрица
        private int[,] array;
        // имя файла
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
        // читаем массив с текстбокса
        private double[] ReadArray()
        {
            // массив
            double[] arr = null;
            // ловим ошибку
            try
            {
                // читаем массив с помощью LINQ
                arr = textBox1.Text.Split(' ')
                    .Select(num => double.Parse(num)).ToArray();
            }
            // если поймали ошибку
            catch
            {
                // тогда выводим её
                MessageBox.Show("Проверьте правильность введенных данных!",
                        "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
            }
            return arr;            
        }
        // функция считывания интервала
        private double[] GetInterval()
        {
            //интервал
            double[] interval = null;
            // ловим ошибку
            try
            {
                // с помощью LINQ читаем массив
                interval = textBox2.Text.Split(' ')
                    .Select(num => double.Parse(num)).ToArray();
            }
            // если поймали ошибку
            catch
            {
                // выводим сообщение
                MessageBox.Show("Проверьте правильность введенных данных!",
                        "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
            }
            // возвращаем интервал
            return interval;
        } 
        // задание 1 лабораторная работа про одномерные массивы
        private void Button1_Click(object sender, EventArgs e)
        {
            // результат
            String result = "";
            // читаем массив
            var arr = ReadArray();
            // получаем интервал
            var interval = GetInterval();
            // если они есть
            if(arr != null && result != null)
            {
                // считаем
                result += $"Максимальный элемент массива: {arr.Max()}\n";           
                result += $"Сумма элементов до последнего положительного: {SumUntilLastPositive(arr)}\n";
                arr = CleanArray(arr, interval[0], interval[1]);
                string arrString = string.Join(" ", arr);
                result += $"Массив после преобразований: " + arrString;
            }
            // выводим
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
       

       
        // рандомное заполнение матрицы
        // кнопка Рандом
        private void Button3_Click(object sender, EventArgs e)
        {
            /*
             Текстбокс в этом задании ReadOnly.
             Это сделано потому что не предусмотрен пользовательский ввод,
             а только автоматическое заполнение.
             Мне показалось очень скучным и долгим заполнение текстбокса вручную,
             поэтому я сделал всё таким образом
            */

            // размер
            int size;
            // пытаемся считать
            bool bSize = int.TryParse(textBox4.Text, out size);
            // если получилось
            if (bSize)
            {  
                // тогда рандомно заполняем
                // создаем объект рандом
                Random random = new Random();
                // матрица
                // её мы будем вставлять в текстбокс
                string matrix = "";
                // выделяем память под матрицу
                array = new int[size, size];
                // заполняем матрицу
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        // рандомный элемент
                        int element = random.Next(-5, 20);
                        // записываем в матрицу
                        array[i, j] = element;
                        // и в матрицу для текстбокса
                        matrix += element + "\t";
                    }
                    // добавляем новю строку
                    // чтобы матрица выглядела как матрица
                    matrix += Environment.NewLine;
                }
                // вставляем матрицу в текстбокс
                textBox3.Text = matrix;
            }
            // если считать размер не получилось
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
        // задание 1 последней лабораторной работы
        private void Button2_Click(object sender, EventArgs e)
        {
            // результат
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

        // функция для подсчета минимальной суммы модулей элементов диалгоналей
        // параллельной побочной диагонали
        private int minOfSumDiag(int[,] arr)
        {
            // размеры квадратной матрицы
            int size = (int)Math.Sqrt(arr.Length);
            // минимальная сумма
            int summin = 0;
            // левый верхний треугольник 
            for (int i = 0; i < size - 1; i++) 
            {
                // сумма
                int sum = 0;
                // идем в цикле
                for (int j = 0; j <= i; j++)
                {
                    // если не дошли до конца
                    if (j != size - 1)
                    {
                        // складываем
                        sum += Math.Abs(arr[i - j, j]);
                    }
                    // находим минимум
                    if ((i == 0) || (summin > sum))
                    {
                        summin = sum;
                    }
                    
                }
            }
            // правый нижний треугольник 
            // аналогично с левым верхним
            for (int i = 1; i < size - 1; i++) 
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

        // функция перестановки слов
        private string shuffleWords(string filePath)
        {
            // стрингбилдер
            // в него будем записывать измененную строку
            var sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(filePath))
            {
                // читать будем построчно
                string line; // собственно строка
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
            // возвращаем строку
            return sb.ToString();
        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        // кнопка Выбрать
        private void Button4_Click(object sender, EventArgs e)
        {
            // создаем объект OpenFileDialog
            var openFileDialog1 = new OpenFileDialog
            {
                // настройки
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
            // если файл выбран и нажата кнопка OK
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // запоминаем имя файла
                fileName = openFileDialog1.FileName;
            }
        }

        private void OpenFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        // задание 2 последней лабы
        // кнопка Поменять слова местами
        private void Button5_Click(object sender, EventArgs e)
        {
            // если файл выбран
            if(fileName != null)
            {
                // тогда меняем слова
                string shuffledText = shuffleWords(fileName);
                // выводим текст в textBox5
                textBox5.Text = shuffledText;
            }
            // если файл не был выбран
            else
            {
                // тогда выводим сообщение об ошибке
                MessageBox.Show("Выберите файл!",
                        "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
            }
            
        }
    }
}
