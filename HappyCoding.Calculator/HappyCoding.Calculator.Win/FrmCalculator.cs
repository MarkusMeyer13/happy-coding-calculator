// Copyright (c) Markus Meyer. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HappyCoding.Calculator.Win
{
    /// <summary>
    /// FrmCalculator.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class FrmCalculator : Form
    {
        /// <summary>
        /// The calculator.
        /// </summary>
        private AdvancedCalculator calculator;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmCalculator"/> class.
        /// </summary>
        public FrmCalculator()
        {
            this.InitializeComponent();
            this.calculator = new AdvancedCalculator();

            this.toolStripMenuItemAbout.Click += this.ToolStripMenuItem1_Click;
        }

        /// <summary>
        /// Handles the Click event of the ToolStripMenuItem1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.ShowDialog();
        }

        /// <summary>
        /// Handles the TextChanged event of the txtInput control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:Element should begin with upper-case letter", Justification = "Internal naming")]
        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            var lastCharacter = this.txtInput.Text.LastOrDefault<char>().ToString();
            var patternInput = @"[0-9/*\-+,()]";
            if (!string.IsNullOrEmpty(lastCharacter) && !Regex.IsMatch(lastCharacter, patternInput))
            {
                if (this.txtInput.Text.Length > 0)
                {
                    this.txtInput.Text = this.txtInput.Text.Substring(0, this.txtInput.Text.Length - 1);
                    this.txtInput.SelectionStart = this.txtInput.Text.Length;
                    this.txtInput.SelectionLength = 0;
                }
            }
            else
            {
                var expression = this.txtInput.Text;
                if (this.calculator.IsValidExpression(expression))
                {
                    var result = this.calculator.Calculate(expression);
                    this.txtResult.Text = result.ToString();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
#pragma warning disable SA1300 // Element should begin with upper-case letter
        private void btn_Click(object sender, EventArgs e)
#pragma warning restore SA1300 // Element should begin with upper-case letter
        {
            Button button = (Button)sender;
            if (button.Text.Length > 1)
            {
                this.txtInput.Text = string.Empty;
                this.txtResult.Text = string.Empty;
                this.txtInput.SelectionLength = 0;
            }
            else
            {
                this.txtInput.Text += button.Text;
            }
        }
    }
}
