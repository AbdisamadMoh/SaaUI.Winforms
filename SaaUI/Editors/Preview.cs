using System;
using System.Windows.Forms;

namespace SaaUI
{
    internal partial class Preview : Form
    {
        public Preview()
        {
            InitializeComponent();
        }
        public Control _Control
        {
            get; set;
        }
        private void Preview_Load(object sender, EventArgs e)
        {

            this.Controls.Add(_Control);
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //e.Cancel = true;
            base.OnFormClosing(e);
            //this.Controls.Remove(_Control);
            //this.Hide();
        }
    }
}
