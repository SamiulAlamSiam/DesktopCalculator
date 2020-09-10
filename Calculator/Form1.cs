using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnAll_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (txtNum.Text == "Not Divisible By 0")
                txtNum.Text = "";
            txtNum.Text += btn.Text;
        }
        private void buttonOperationAll_Click(object sender, EventArgs e)
        {
            Button op = sender as Button;
            if (lblOperation.Text=="label2"||string.IsNullOrEmpty(lblOperation.Text))
            {
                lblFNum.Text = txtNum.Text;
                lblOperation.Text = op.Text; 
                txtNum.Text = "";
                return;
            }
            Calculate();
            lblOperation.Text = op.Text;
        }

        private double Calculate()
        {
            try
            {
                double firstNumber = double.Parse(lblFNum.Text);
                double secondNumber = double.Parse(txtNum.Text);
                
                switch (lblOperation.Text)
                {
                    case ("+"):
                        lblFNum.Text = firstNumber + secondNumber + "";
                        txtNum.Text = "";
                        //lblOperation.Text = "+";
                        break;
                    case ("-"):
                        lblFNum.Text = firstNumber - secondNumber + "";
                        txtNum.Text = "";
                        //lblOperation.Text = "-";
                        break;
                    case ("*"):
                        lblFNum.Text = firstNumber * secondNumber + "";
                        txtNum.Text = "";
                        //lblOperation.Text = "*";
                        break;
                    case ("/"):
                        lblFNum.Text = firstNumber / secondNumber + "";
                        txtNum.Text = "";
                        lblOperation.Text = "";
                        break;
                        //default:
                        //    Console.WriteLine("Invalid Input");
                        //    break;
                }
            }
            catch (Exception ex)
            {
                txtNum.Text = "";
                lblFNum.Text = "";
                lblOperation.Text = "";
                MessageBox.Show(ex.Message);
            }

            return 0.0;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            try
            {
                double firstNumber = double.Parse(lblFNum.Text);
                if (firstNumber == null)
                    firstNumber = 0;
                double secondNumber = double.Parse(txtNum.Text);
                switch (lblOperation.Text)
                {
                    case ("+"):
                        txtNum.Text = firstNumber + secondNumber + "";
                        lblFNum.Text = txtNum.Text;
                        lblOperation.Text = "";
                        lblFNum.Text = "";
                        break;
                    case ("-"):
                        txtNum.Text = firstNumber - secondNumber + "";
                        lblFNum.Text = txtNum.Text;
                        lblOperation.Text = "";
                        lblFNum.Text = "";
                        break;
                    case ("*"):
                        txtNum.Text = firstNumber * secondNumber + "";
                        lblFNum.Text = txtNum.Text;
                        lblOperation.Text = "";
                        lblFNum.Text = "";
                        break;
                    case ("/"):
                        if (secondNumber == 0)
                        {
                            txtNum.Text = "Not Divisible By 0";
                            return;
                        }
                        txtNum.Text = firstNumber / secondNumber + "";
                        lblFNum.Text = txtNum.Text;
                        lblOperation.Text = "";
                        lblFNum.Text = "";
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
            catch(Exception ex)
            {
                txtNum.Text = "";
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (txtNum.Text == "")
                return;
            double firstNumber = double.Parse(txtNum.Text);
            firstNumber /= 10;
            int result = (Int32)firstNumber;
            txtNum.Text = result.ToString();
        }

        private void btnAllClear_Click(object sender, EventArgs e)
        {
            txtNum.Text = "0";
            lblFNum.Text = "";
            lblOperation.Text = "";
        }

        private void btnSqure_Click(object sender, EventArgs e)
        {
            if (txtNum.Text == "")
            {
                MessageBox.Show("Please Input First");
                return;
            }
            txtNum.Text = double.Parse(txtNum.Text) * double.Parse(txtNum.Text) + "";
            lblFNum.Text = "";
        }

        private void BtnRoot_Click(object sender, EventArgs e)
        {
            if (txtNum.Text == "")
            {
                MessageBox.Show("Please Input First");
                return;
            }
            double result;
            double.TryParse(txtNum.Text, out result);
            txtNum.Text = Math.Sqrt(result)+""; //double.Parse(txtNum.Text) * double.Parse(txtNum.Text) + "";
            lblFNum.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtNum.Text = "0";
        }
    }
}
