using System.Windows;
using System.Windows.Controls;

namespace TK
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public bool Results(string module1Text, string module2Text, string module3Text, out int totalScore, out string grade)
        {
            totalScore = 0;
            grade = "2";

            if (!TryParseScore(module1Text, 22, out int score1) || !TryParseScore(module2Text, 38, out int score2) || !TryParseScore(module3Text, 20, out int score3))
            {
                return false;
            }

            totalScore = score1 + score2 + score3;
            grade = Grade(totalScore);
            return true;
        }

        private bool TryParseScore(string input, int maxScore, out int score)
        {
            score = 0;

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Поле не может быть пустым. Введите баллы.");
                return false;
            }

            if (!int.TryParse(input, out score))
            {
                MessageBox.Show("Баллы должны быть числом. Введите цифры.");
                return false;
            }

            if (score < 0)
            {
                MessageBox.Show("Баллы не могут быть отрицательными.");
                return false;
            }

            if (score > maxScore)
            {
                MessageBox.Show($"Баллы не могут быть больше {maxScore} для этого модуля.");
                return false;
            }

            return true;
        }

        private string Grade(int totalScore)
        {
            if (totalScore >= 56) return "5";
            if (totalScore >= 32) return "4";
            if (totalScore >= 16) return "3";
            return "2";
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Results(module1TextBox.Text, module2TextBox.Text, module3TextBox.Text, out int total, out string grade))
            {
                totalScoreText.Text = $"Всего баллов: {total}";
                gradeText.Text = $"Оценка: {grade}";
            }
        }
    }
}