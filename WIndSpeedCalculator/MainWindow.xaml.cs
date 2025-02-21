using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace WindSpeedCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            // Проверка, что оба текстовых поля заполнены
            if (string.IsNullOrWhiteSpace(txtDistance.Text) || string.IsNullOrWhiteSpace(txtTime.Text))
            {
                MessageBox.Show("Необходимо ввести расстояние и время.");
                return;
            }

            // Проверка, что выбран переключатель
            if (!rbMetersPerSecond.IsChecked.Value && !rbKilometersPerHour.IsChecked.Value)
            {
                MessageBox.Show("Необходимо выбрать единицу измерения.");
                return;
            }

            // Проверка на ввод нечисловых символов
            if (!Regex.IsMatch(txtDistance.Text, @"^\d+$") || !Regex.IsMatch(txtTime.Text, @"^\d+$"))
            {
                MessageBox.Show("Неверное значение. Повторите ввод.");
                return;
            }

            // Преобразование вводимых значений в числа
            double distance = Convert.ToDouble(txtDistance.Text);
            double time = Convert.ToDouble(txtTime.Text);
            string resultUnit = "";
            double speed = 0;

            // Выполнение вычислений
            if (rbMetersPerSecond.IsChecked.Value)
            {
                speed = distance / time; // Метры в секунду
                resultUnit = "м/с";
            }
            else if (rbKilometersPerHour.IsChecked.Value)
            {
                speed = (distance / time) * 3.6; // Метры в секунду в километры в час
                resultUnit = "км/ч";
            }

            lblResult.Content = $"Результат: {speed:F2} {resultUnit}";
        }
    }
}