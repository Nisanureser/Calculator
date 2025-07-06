using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private double _firstNumber = 0;
        private string _operation = "";
        private bool _isNewEntry = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (_isNewEntry || ScreenLabel.Text == "0")
            {
                ScreenLabel.Text = btn.Text;
                _isNewEntry = false;
            }
            else
            {
                ScreenLabel.Text += btn.Text;
            }
        }

        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            _firstNumber = double.Parse(ScreenLabel.Text);
            _operation = btn.Text;
            _isNewEntry = true;
        }

        private void BtnEquals_Click(object sender, EventArgs e)
        {
            try
            {
                double secondNumber = double.Parse(ScreenLabel.Text);
                double result = 0;

                switch (_operation)
                {
                    case "+":
                        result = _firstNumber + secondNumber;
                        break;
                    case "-":
                        result = _firstNumber - secondNumber;
                        break;
                    case "*":
                        result = _firstNumber * secondNumber;
                        break;
                    case "/":
                        if (secondNumber == 0)
                        {
                            MessageBox.Show("Sıfıra bölme hatası!");
                            return;
                        }
                        result = _firstNumber / secondNumber;
                        break;
                    case "%":
                        result = _firstNumber % secondNumber;
                        break;
                    default:
                        MessageBox.Show("Lütfen işlem seçiniz!");
                        return;
                }

                ScreenLabel.Text = result.ToString();
                _isNewEntry = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ScreenLabel.Text = "0";
            _firstNumber = 0;
            _operation = "";
            _isNewEntry = true;
        }

        private void BtnDot_Click(object sender, EventArgs e)
        {
            if (_isNewEntry)
            {
                ScreenLabel.Text = "0,";
                _isNewEntry = false;
            }
            else if (!ScreenLabel.Text.Contains(","))
            {
                ScreenLabel.Text += ",";
            }
        }
    }
}
