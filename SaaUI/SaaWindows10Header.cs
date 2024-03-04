using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaaUI
{
    public partial class SaaWindows10Header : UserControl
    {
        public SaaWindows10Header()
        {
            InitializeComponent();
        }

        private void CloseIcon_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void Title_DragEnter(object sender, DragEventArgs e)
        {
            ((Control)sender).Cursor = Cursors.No;
           
        }
    }
}
