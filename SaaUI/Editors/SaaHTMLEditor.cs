using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Using
{
   internal  partial class SaaHTMLEditor : SaaUI.SaaRoundForm
    {
        public SaaHTMLEditor()
        {
            InitializeComponent();
        }
        protected override void OnMouseDownMoveForm(object sender, MouseEventArgs e)
        {
            base.OnMouseDownMoveForm(sender, e);
        }
        public string Value
        {
            get
            {
                return richTextBox1.Text;
            }
            set
            {
                richTextBox1.Text = value;
                saaRichTextBox1.Text = value;
            }
        }
        private void SaaHTMLiWin_Load(object sender, EventArgs e)
        {
           
        }
       
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                saaRichTextBox1.Text = richTextBox1.Text.Replace("\n","<br/>");
            }
            catch { }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //if(e.Shift && e.KeyValue == 188)
            //{
            //    e.Handled= true;
            //    MessageBox.Show("<");
            //}
        }

        private void SaaHTMLEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if(this.DialogResult != (DialogResult.Cancel | DialogResult.OK))
            //{
            //    e.Cancel = true;
            //}
            
        }

        private void saaButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
