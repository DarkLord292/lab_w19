using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfLab19_Var5
{
    public partial class MainWindow : Window
    {
        private readonly string[] styles = { "btnBlue", "btnGreen", "btnOrange", "btnPurple" };
        private readonly Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnGen_Click(object sender, RoutedEventArgs e)
        {
            int N = 12;
            try
            {
                N = int.Parse(txtN.Text.Trim());
                if (N < 1) N = 1;
                if (N > 50) N = 50;
            }
            catch
            {
                MessageBox.Show("Введите целое число");
                return;
            }

            MainCanvas.Children.Clear();
            double maxX = Math.Max(100, MainCanvas.ActualWidth - 110);
            double maxY = Math.Max(50, MainCanvas.ActualHeight - 50);

            for (int i = 0; i < N; i++)
            {
                var btn = new Button
                {
                    Content = "Btn " + (i + 1),
                    Style = (Style)FindResource(styles[rnd.Next(styles.Length)])
                };
                MainCanvas.Children.Add(btn);
                Canvas.SetLeft(btn, rnd.NextDouble() * maxX);
                Canvas.SetTop(btn, rnd.NextDouble() * maxY);
            }
            lblInfo.Text = $"Сгенерировано: {N} (4 стиля + триггеры)";
            Title = $"ЛР 19. Кнопок: {N}";
        }
    }
}