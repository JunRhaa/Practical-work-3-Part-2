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
            if (string.IsNullOrWhiteSpace(txtDistance.Text) || string.IsNullOrWhiteSpace(txtTime.Text))
            {
                MessageBox.Show("Необходимо ввести расстояние и время.");
                return;
            }

            if (!rbMetersPerSecond.IsChecked.Value && !rbKilometersPerHour.IsChecked.Value)
            {
                MessageBox.Show("Необходимо выбрать единицу измерения.");
                return;
            }

            if (!Regex.IsMatch(txtDistance.Text, @"^\d+$") || !Regex.IsMatch(txtTime.Text, @"^\d+$"))
            {
                MessageBox.Show("Неверное значение. Повторите ввод.");
                return;
            }

            double distance = Convert.ToDouble(txtDistance.Text);
            double time = Convert.ToDouble(txtTime.Text);
            string resultUnit = "";
            double speed = 0;

            if (rbMetersPerSecond.IsChecked.Value)
            {
                speed = distance / time; 
                resultUnit = "м/с";
            }
            else if (rbKilometersPerHour.IsChecked.Value)
            {
                speed = (distance / time) * 3.6; 
                resultUnit = "км/ч";
            }

            lblResult.Content = $"Результат: {speed:F2} {resultUnit}";
        }
    }
}
