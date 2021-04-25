using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyCoding.Calculator.Win
{
    public partial class Form1 : Form
    {
        private AdvancedCalculator _calculator;

        public Form1()
        {
            InitializeComponent();
            _calculator = new AdvancedCalculator();
        }


        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            var lastCharacter = txtInput.Text.LastOrDefault<char>().ToString();
            var patternInput = @"[0-9/*\-+,()]";
            if (!string.IsNullOrEmpty(lastCharacter) && !Regex.IsMatch(lastCharacter, patternInput))
            {
                txtInput.Text = txtInput.Text.Substring(0, txtInput.Text.Length - 1);
                txtInput.SelectionStart = txtInput.Text.Length;
                txtInput.SelectionLength = 0;
            }
            else
            {
                //var patternCalculate = @"^([0-9+\-/*(),]+)$";
                var expression = txtInput.Text;
                //if (expression.Count(x => x == '(') == expression.Count(x => x == ')') && Regex.IsMatch(expression, patternCalculate) && Regex.IsMatch(expression, @"[\-+*/]") && Regex.IsMatch(expression, "[0-9)]$"))
                if(_calculator.IsValidExpression(expression))
                {
                    var result = _calculator.Calculate(expression);
                    textBox2.Text = result.ToString();
                }

            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(button.Text.Length > 1)
            {
                txtInput.Text = txtInput.Text.Substring(0, txtInput.Text.Length - 1);
                txtInput.SelectionStart = txtInput.Text.Length;
                txtInput.SelectionLength = 0;
            }
            else
            {
                txtInput.Text += button.Text;
            }
        }
    }
}
