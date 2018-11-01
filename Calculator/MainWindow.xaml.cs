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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double Result = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClearHistory()
        {
            textBox_calc.Text = "0";
            textBox_history.Text = "";
            Result = 0;
        }
        private void SetNum(char inp)
        {
            if (inp == 'd') // If deleting character
            {
                if (textBox_calc.Text.Length > 1) // textBox must contain something to delete
                {
                    textBox_calc.Text = textBox_calc.Text.Remove(textBox_calc.Text.Length - 1);
                }
                else if (textBox_calc.Text.Length == 1)
                {
                    textBox_calc.Text = "0";
                }
            }
            else if (textBox_calc.Text == "0")
            {
                textBox_calc.Text = "" + inp; // Put number to textBox
            }
            else if (!textBox_calc.Text.Contains(",") && inp == ',')
            {
                textBox_calc.Text += inp; // Add comma to textBox
            }
            else if (inp != ',')
            {
                textBox_calc.Text += inp; // Add number to textBox
            }
        }

        private void SetOp(char inp)
        {
            if (textBox_calc.Text.Length > 0) // textBox must contain something
            {
                switch (inp) // Do operation
                {
                    case '/':
                        if (textBox_calc.Text != "0")
                        {
                            textBox_history.Text += Result + "/" + textBox_calc.Text;
                            Result /= float.Parse(textBox_calc.Text);
                            textBox_calc.Text = "" + Result;
                        }
                        break;
                    case '*': break;
                    case '-': break;
                    case '+': break;
                    case '=':
                        if (textBox_calc.Text != "0")
                        {
                            Result = float.Parse(textBox_calc.Text);
                            textBox_history.Text += textBox_calc.Text + "\r\n=" + Result + "\r\n----------\r\n";
                            textBox_calc.Text = "0";
                        }
                        break;
                }
            }
            else if (inp == '-')
            {
                textBox_calc.Text += inp; // Add minus to textBox
            }
        }

        private void B_num0_Click(object sender, RoutedEventArgs e) { SetNum('0'); }
        private void B_num1_Click(object sender, RoutedEventArgs e) { SetNum('1'); }
        private void B_num2_Click(object sender, RoutedEventArgs e) { SetNum('2'); }
        private void B_num3_Click(object sender, RoutedEventArgs e) { SetNum('3'); }
        private void B_num4_Click(object sender, RoutedEventArgs e) { SetNum('4'); }
        private void B_num5_Click(object sender, RoutedEventArgs e) { SetNum('5'); }
        private void B_num6_Click(object sender, RoutedEventArgs e) { SetNum('6'); }
        private void B_num7_Click(object sender, RoutedEventArgs e) { SetNum('7'); }
        private void B_num8_Click(object sender, RoutedEventArgs e) { SetNum('8'); }
        private void B_num9_Click(object sender, RoutedEventArgs e) { SetNum('9'); }
        private void B_numDec_Click(object sender, RoutedEventArgs e) { SetNum(','); }

        private void B_numDiv_Click(object sender, RoutedEventArgs e) { SetOp('/'); }
        private void B_numMul_Click(object sender, RoutedEventArgs e) { SetOp('*'); }
        private void B_numPlus_Click(object sender, RoutedEventArgs e) { SetOp('+'); }
        private void B_numMin_Click(object sender, RoutedEventArgs e) { SetOp('-'); }
        private void B_numSum_Click(object sender, RoutedEventArgs e) { SetOp('='); }

        private void B_clear_Click(object sender, RoutedEventArgs e) { ClearHistory(); }

        private void B_del_Click(object sender, RoutedEventArgs e) { SetNum('d'); }

        private void textBox_calc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.D0 || e.Key > Key.D9 ||
                (e.Key < Key.NumPad0 || e.Key > Key.NumPad9) ||
                e.Key != Key.Back)
            {
                char key = 'b';
                SetNum(key);
            }
        }
    }
}