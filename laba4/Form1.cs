using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MeinLib;

namespace laba4
{
    public partial class Form1 : Form
    {
        private Bitmap bitmap;
        private ComboBox cmbbx_plug;
        private Stack<Operator> operators = new Stack<Operator>();
        private Stack<Operand> operands = new Stack<Operand>();
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
        }

        private void textBoxInputString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                operators.Clear();
                operands.Clear();
                try
                {
                    string commandText = textBoxInputString.Text.Replace(" ", "");
                    for (int i = 0; i < commandText.Length; i++)
                    {
                        char symbol = commandText[i];
                        if (IsNotOperation(symbol))
                        {
                            if (!Char.IsDigit(symbol))
                            {
                                operands.Push(new Operand(symbol));
                                while (i < commandText.Length - 1 && IsNotOperation(commandText[i + 1]))
                                {
                                    string temp_str = operands.Pop().value.ToString() + commandText[i + 1].ToString();
                                    operands.Push(new Operand(temp_str));
                                    i++;
                                }
                            }
                            else if (Char.IsDigit(symbol))
                            {
                                operands.Push(new Operand(symbol.ToString()));
                                while (i < commandText.Length - 1 && Char.IsDigit(commandText[i + 1])
                                    && IsNotOperation(commandText[i + 1]))
                                {
                                    int temp_num = Convert.ToInt32(operands.Pop().value.ToString()) * 10 +
                                        (int)Char.GetNumericValue(commandText[i + 1]);
                                    operands.Push(new Operand(temp_num.ToString()));
                                    i++;
                                }
                            }
                        }

                        else if ((symbol == 'E') || (symbol == 'M') || (symbol == 'D'))
                        {
                            if (operators.Count == 0)
                            {
                                operators.Push(OperatorContainer.FindOperator(symbol));
                            }
                        }
                        else if (symbol == '(')
                        {
                            operators.Push(OperatorContainer.FindOperator(symbol));
                        }
                        else if (symbol == ')')
                        {
                            do
                            {
                                if (operators.Peek().symbolOperator == '(')
                                {
                                    operators.Pop();
                                    break;
                                }
                                if (operators.Count == 0)
                                {
                                    break;
                                }
                            }
                            while (operators.Peek().symbolOperator != '(');
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Аргументы введены некорректно.");
                    comboBox1.Items.Add("Аргументы введены некорректно.");
                }
                try
                {
                    SelectingPerformingOperation(operators.Peek());
                }
                catch
                {
                    MessageBox.Show("Введенной операции не существует.");
                    comboBox1.Items.Add("Введенной операции не существует.");
                }
            }
        }


        private void SelectingPerformingOperation(Operator op)
        {
            if (op.symbolOperator == 'E')
            {
                if (operands.Count == 4)
                {
                    
                    int w = Convert.ToInt32(operands.Pop().value.ToString());
                    int y = Convert.ToInt32(operands.Pop().value.ToString());
                    int x = Convert.ToInt32(operands.Pop().value.ToString());
                    string name = operands.Pop().value.ToString();
                    if (!((y < 0) || (y + w > pictureBox1.Height) || (x < 0) || (x + w > pictureBox1.Width)))
                    {
                        Square square = new Square(name, x, y, w, pictureBox1, bitmap, cmbbx_plug);
                        square.Draw();
                        comboBox1.Items.Add($"Нарисован квадрат {square.name}.");
                    }
                    else
                    {
                        MessageBox.Show("Фигура выходит за границы");
                        comboBox1.Items.Add("Фигура выходит за границы");
                    }
                }
                else
                {
                    MessageBox.Show("Оператор E принимает 4 аргумента.");
                    comboBox1.Items.Add("Неверное число аргументов для оператора E.");
                }
            }
            else if (op.symbolOperator == 'M')
            {
                if (operands.Count == 3)
                {
                    Square square = null;
                    int y = Convert.ToInt32(operands.Pop().value.ToString());
                    int x = Convert.ToInt32(operands.Pop().value.ToString());
                    string name = operands.Pop().value.ToString();
                    foreach (Square sq in Flist.figures)
                    {
                        if (sq.name == name)
                        {
                            square = sq;
                        }
                    }
                    if (square != null)
                    {
                        if (!((y < 0) || (y + square.height > pictureBox1.Height) || (x < 0) ||
                            (x + square.width > pictureBox1.Width)))
                        {
                            square.MoveTo(x, y);
                            comboBox1.Items.Add($"Квадрат {square.name} перемещен.");
                        }
                        else
                        {
                            MessageBox.Show("Фигура выходит за границы");
                            comboBox1.Items.Add("Фигура выходит за границы");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Такой фигуры не существует.");
                        comboBox1.Items.Add($"Фигуры {name} не существует.");
                    }
                }
                else
                {
                    MessageBox.Show("Оператор M принимает 3 аргумента.");
                    comboBox1.Items.Add("Неверное число аргументов для оператора M.");
                }
            }
            else if (op.symbolOperator == 'D')
            {
                if (operands.Count == 1)
                {
                    Square square = null;
                    string name = operands.Pop().value.ToString();
                    foreach (Square sq in Flist.figures)

                    {
                        if (sq.name == name)
                        {
                            square = sq;
                        }
                    }
                    if (square != null)
                    {
                        square.DeleteF(square, true);
                        comboBox1.Items.Add($"Квадрат {square.name} успешно удален.");
                    }
                    else
                    {
                        comboBox1.Items.Add($"Квадрат {name} не существует.");
                    }
                }
                else
                {
                    MessageBox.Show("Оператор D принимает 1 аргумента.");
                    comboBox1.Items.Add("Неверное число аргументов для оператора D.");
                }
            }
        }

        private bool IsNotOperation(char item)
        {
            if (!(item == 'D' || item == 'M' || item == 'E' || item == ',' || item == '(' || item == ')'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }

}