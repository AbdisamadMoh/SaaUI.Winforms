using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaaUI.Test
{
    public partial class button : UserControl
    {
        public button()
        {
            InitializeComponent();
            this.BackColor = Color.Transparent;
            webBrowser1.DocumentText = btn;
            
        }
        string btn = "<style>body,html{height:100%; width:100%; padding:0; margin:0; background-color:blue; border-radius:20px;}</style><div  style='width:100%; height:100%; color:red; background-color:yellow; border-radius:10px;'>this is text</div>";
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
