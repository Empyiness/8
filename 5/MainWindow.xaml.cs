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
using Sets;

namespace _5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool handEnter;
        Pair pair1;
        Pair pair2;

        private void CheckedHandEnter(object sender, RoutedEventArgs e)
        {
            handEnter = true;
            FirstNumberBox.IsEnabled = true;
            SecondNumberBox.IsEnabled = true;
        }

        private void UncheckedHandEnter(object sender, RoutedEventArgs e)
        {
            handEnter = false;
            FirstNumberBox.IsEnabled = false;
            SecondNumberBox.IsEnabled = false;

        }

        private void CreatePair1(object sender, RoutedEventArgs e)
        {
            if (handEnter)
            {
                if (!int.TryParse(FirstNumberBox.Text, out int number1))
                {
                    MessageBox.Show("Некорректное 1 число!");
                    return;
                }
                if (!int.TryParse(SecondNumberBox.Text, out int number2))
                {
                    MessageBox.Show("Некорректное 2 число!");
                    return;
                }
                pair1 = new Pair(number1, number2);
                FirstPairBox.Text = pair1.ToString();
                FirstNumberBox.Clear();
                SecondNumberBox.Clear();
                Calculator();
                return;
            }
            pair1 = new Pair();
            FirstPairBox.Text = pair1.ToString();
            Calculator();
        }

        private void CreatePair2(object sender, RoutedEventArgs e)
        {
            if (handEnter)
            {
                if (!int.TryParse(FirstNumberBox.Text, out int number1))
                {
                    MessageBox.Show("Некорректное 1 число!");
                    return;
                }
                if (!int.TryParse(SecondNumberBox.Text, out int number2))
                {
                    MessageBox.Show("Некорректное 2 число!");
                    return;
                }
                pair2 = new Pair(number1, number2);
                SecondPairBox.Text = pair2.ToString();
                FirstNumberBox.Clear();
                SecondNumberBox.Clear();
                Calculator();
                return;
            }
            pair2 = new Pair();
            SecondPairBox.Text = pair2.ToString();
            Calculator();
        }

        private void ClonePair1(object sender, RoutedEventArgs e)
        {
            if(pair1 == null)
            {
                MessageBox.Show("Пара 1 не существует!");
                return;
            }
            pair2 = pair1;
            SecondPairBox.Text = pair2.ToString();
            Calculator();
        }

        private void Calculator()
        {
            if (pair1 != null && pair2 != null)
            {
                AdditionBox.Text = OperationString(pair1, pair2, '+') + pair1.Addition(pair2).ToString();
                SubtractionBox.Text = OperationString(pair1, pair2, '-') + pair1.Subtraction(pair2).ToString();
                MultiplicationBox.Text = OperationString(pair1, pair2, '*') + pair1.Multiplication(pair2).ToString();
                DevisionBox.Text = OperationString(pair1, pair2, '/') + pair1.Devision(pair2).ToString();
                if (pair1.CompareTo(pair2) > 0)
                {
                    CompareBox.Text = "Пара 1 больше пары 2";
                    return;
                }
                if (pair1.CompareTo(pair2) < 0)
                {
                    CompareBox.Text = "Пара 1 меньше пары 2";
                    return;
                }
                CompareBox.Text = "Пары равны";
            }
        }

        private string OperationString(Pair pair1, Pair pair2, char operation)
        {
            return "(" + pair1.ToString() + ")" + operation + "(" + pair2.ToString() + ") = ";
        }
        private void About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Митин ИСП-31 12. Создать интерфейс – арифметические операции (+, -, *, /). Создать класс пара чисел.Класс должен включать конструктор, функцию для формирования строки с арифметической операцией.Сравнение производить по парам чисел.");
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
