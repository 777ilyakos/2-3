using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using LibMas;
using Lib_2;
using Lib_3;

namespace pract_2_3_var_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int[] array;//Array
        int[,] matrix;
        private void ArrayData_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //Отчищаем textbox с результатом умножения
            ArrayResult.Clear();
            //Определяем номер столбца
            int columnIndex = e.Column.DisplayIndex;
            //Заносим  отредоктированое значение в соответствующую ячейку массива
            if (Int32.TryParse(((TextBox)e.EditingElement).Text, out array[columnIndex]))
            { }
            else MessageBox.Show("Неверные данные!", "Ошибка");
        }
        private void MatrixData_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //Определяем номер столбца
            int columnIndex = e.Column.DisplayIndex;
            //Определяем номер строки
            int rowIndex = e.Row.GetIndex();
            //Заносим полученное значение в массив
            if (Int32.TryParse(((TextBox)e.EditingElement).Text, out matrix[rowIndex, columnIndex]))
            { }
            else MessageBox.Show("Неверные данные!", "Ошибка");
        }

        private void ArrayFill_Click(object sender, RoutedEventArgs e)
        {
            //Проверка поля на корректность введенных данных
            if (Int32.TryParse(SizeArray.Text, out int count) && count > 0)
            {
                array = arrayHelper.Create(count);
                arrayHelper.Fill(array, -100, 100);
                masData.ItemsSource = VisualArray.ToDataTable(array).DefaultView;
                ArrayResult.Clear();
            }
            else MessageBox.Show("Неверные данные!", "Ошибка");
        }
        private void MatrixFill_Click(object sender, RoutedEventArgs e)
        {
            //Проверка поля на корректность введенных данных
            if ((Int32.TryParse(sizeMatrix1.Text, out int count1) && count1 > 0) && (Int32.TryParse(sizeMatrix2.Text, out int count2) && count2 > 0))
            {
                matrix = arrayHelper.Create(count1, count2);
                arrayHelper.Fill(matrix, 100);
                matrData.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
                //очищаем результат
                MatrixResult.Clear();
            }
            else MessageBox.Show("Неверные данные!", "Ошибка");
        }

        private void ArrayResult_Click(object sender, RoutedEventArgs e)
        {
            if (array == null || array.Length == 0)
            {
                MessageBox.Show("Вы не создали массив, укажите количество колонок, диапазон чисел и нажмите кнопку \"Заполнить", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //Выводим результат в textbox(предварительно вычеслив косинус)
            ArrayResult.Text = Convert.ToString(resh2.productSmaller3(array));
        }
        private void MatrixResult_Click(object sender, RoutedEventArgs e)
        {
            if (matrix != null && matrix.Length != 0)
            {

                MatrixResult.Text = resh3.task3(matrix).ToString();
            }
            else MessageBox.Show("Вы не создали матрицу нажмите кнопку \"Заполнить", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ArrayClear_Click(object sender, RoutedEventArgs e)
        {

            if (array == null || array.Length == 0)
            {
                MessageBox.Show("Вы не создали массив, укажите количество колонок, диапазон чисел и нажмите кнопку \"Заполнить", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            ArrayResult.Clear();
            //Заполняем массив нулями
            arrayHelper.Clear(array);
            //Выводим массив на форму
            masData.ItemsSource = VisualArray.ToDataTable(array).DefaultView;
        }
        private void MatrixClear_Click(object sender, RoutedEventArgs e)
        {
            if (matrix != null && matrix.Length != 0)
            {
                arrayHelper.Clear(matrix);
                //Выводим массив на форму
                matrData.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
                MatrixResult.Clear();
            }
            else MessageBox.Show("Вы не создали матрицу, укажите размеры матрицы и нажмите кнопку \"Заполнить", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow info = new InfoWindow();
            info.Show();
            //MessageBox.Show("Разработчик - Косоуров Илья \n\n ты обратился не туда","не инфо", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int val;
            if (!Int32.TryParse(e.Text, out val))
            {
                e.Handled = true; // отклоняем ввод
            }
        }
    }
}