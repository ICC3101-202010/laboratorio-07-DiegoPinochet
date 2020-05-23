using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7_POO_DiegoPinochet
{
    public partial class Form1 : Form
    {
        List<double> operationsResult;
        List<string> operations;

        public Form1(List<double> OperationResult, List<string> Operations)
        {
            InitializeComponent();
            this.operationsResult = OperationResult;
            this.operations = Operations;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalculatorInput.AppendText("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CalculatorInput.AppendText("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CalculatorInput.AppendText("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CalculatorInput.AppendText("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CalculatorInput.AppendText("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CalculatorInput.AppendText("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CalculatorInput.AppendText("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CalculatorInput.AppendText("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            CalculatorInput.AppendText("9");
        }

        private void button0_Click(object sender, EventArgs e)
        {
            CalculatorInput.AppendText("0");
        }

        private void Decimal_Click(object sender, EventArgs e)
        {
            CalculatorInput.AppendText(",");
        }

        private void multiplication_Click(object sender, EventArgs e)
        {
            CalculatorInput.AppendText("x");
        }

        private void divition_Click(object sender, EventArgs e)
        {
            CalculatorInput.AppendText("/");
        }

        private void sum_Click(object sender, EventArgs e)
        {
            CalculatorInput.AppendText("+");
        }
        private void substraction_Click(object sender, EventArgs e)
        {
            CalculatorInput.AppendText("-");
        }

        private void equal_Click(object sender, EventArgs e)
        {
            //Tengo que verificar que no se caiga la plataforma...
            string[] newInput = new string[2];
            string coma;
            string calcText = CalculatorInput.Text;
            operations.Add(calcText);
            if (CalculatorInput.Text.Contains("+") == true)
            {
                newInput = CalculatorInput.Text.Split('+');
                coma = FindComa(newInput);
                if (coma == null)
                {
                    double sum = double.Parse(newInput[0]) + double.Parse(newInput[1]);
                    CalculatorInput.Text = sum.ToString();
                    operationsResult.Add(sum);
                    
                }
                else
                {
                    CalculatorInput.Text = coma;
                    return;
                }

            }
            else if (CalculatorInput.Text.Contains("-") == true)
            {
                newInput = CalculatorInput.Text.Split('-');
                coma = FindComa(newInput);
                if (coma == null)
                {
                    double sub = double.Parse(newInput[0]) - double.Parse(newInput[1]);
                    CalculatorInput.Text = sub.ToString();
                    operationsResult.Add(sub);
                    
                }
                else
                {
                    CalculatorInput.Text = coma;
                    return;
                }
            }
            else if (CalculatorInput.Text.Contains("x") == true)
            {
                newInput = CalculatorInput.Text.Split('x');
                coma = FindComa(newInput);
                if (coma == null)
                {
                    double mult = double.Parse(newInput[0]) * double.Parse(newInput[1]);
                    CalculatorInput.Text = mult.ToString();
                    operationsResult.Add(mult);
                    
                }
                else
                {
                    CalculatorInput.Text = coma;
                    return;
                }
            }
            else if (CalculatorInput.Text.Contains("/") == true)
            {
                newInput = CalculatorInput.Text.Split('/');
                coma = FindComa(newInput);
                if (newInput[1] != "0")
                {
                    if (coma == null)
                    {
                        double div = double.Parse(newInput[0]) / double.Parse(newInput[1]);
                        CalculatorInput.Text = div.ToString(); //Necesito redondearlo a los x cant de decimales.
                        operationsResult.Add(div);
                        
                    }
                    else
                    {
                        CalculatorInput.Text = coma;
                        return;
                    }
                }
                else
                {
                    CalculatorInput.Text = "Math Error";
                    operations.Remove(calcText);
                    return;
                }
            }
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            CalculatorInput.Text = CalculatorInput.Text.Remove(CalculatorInput.Text.Length -1);
        }

        private void AC_Click(object sender, EventArgs e)
        {
            CalculatorInput.Clear();
        }

        private void answer_Click(object sender, EventArgs e)
        {
            CalculatorInput.Text = operationsResult[operationsResult.Count()-1].ToString();
        }

        private void Historial_Click(object sender, EventArgs e)
        {
            //Suponiendo que seria el hisyorial mientras se tiene encendida la calculadora...
            HistorialDisplay.BringToFront();
            string var = "";
            for(int i = 0; i < operations.Count(); i++)
            {
                var += (operations[i] + " = " + operationsResult[i] + "\n");
                
            }
            HistorialOutput.Text = var;

        }

        private void CalculatorInput_TextChanged(object sender, EventArgs e)
        {
            int cont = 0;
            if(CalculatorInput.Text.Contains(',') == true)
            {
                cont++;
            }
            if(cont > 1)
            {
                CalculatorInput.Text = "Syntax Error";
            }
        }
        public string FindComa(string[] newInput)
        {
            int cont0 = 0;
            int cont1 = 0;
            string var;
            for (int i = 0; i < newInput[0].Count(); i++)
            {
                if (newInput[0][i] == ',')
                {
                    cont0++;
                }
            }
            for (int i = 0; i < newInput[1].Count(); i++)
            {
                if (newInput[1][i] == ',')
                {
                    cont1++;
                }
            }
            if (cont0 > 1 || cont1 > 1)
            {
                var = CalculatorInput.Text = "Syntax Error";
            }
            else
            {
                var = null;
            }
            return var;
        }

        private void HistorialOut_Click_1(object sender, EventArgs e)
        {
            CalculatorView.BringToFront();
        }

        private void EraseHistorial_Click(object sender, EventArgs e)
        {
            HistorialOutput.ResetText();
            operationsResult.Clear();
            operations.Clear();

        }
    }
}
