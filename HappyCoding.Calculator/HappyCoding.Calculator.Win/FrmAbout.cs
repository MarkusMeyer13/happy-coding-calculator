// Copyright (c) Markus Meyer. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace HappyCoding.Calculator.Win
{
    /// <summary>
    /// FrmAbout.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class FrmAbout : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmAbout"/> class.
        /// </summary>
        public FrmAbout()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the linkLabel1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void LinkLabel1_Click(object sender, EventArgs e)
        {
            // Does not work
            // https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/link-to-an-object-or-web-page-with-wf-linklabel-control?view=netframeworkdesktop-4.8&viewFallbackFrom=netdesktop-5.0
            // System.Diagnostics.Process.Start("http://www.microsoft.com");
            // System.Diagnostics.Process.Start(((LinkLabel)sender).Text);
        }
    }
}
