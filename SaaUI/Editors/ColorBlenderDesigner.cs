using System;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace SaaUI.SaaUse
{
    internal partial class ColorBlenderDesigner : SaaRoundForm
    {
        public ColorBlenderDesigner()
        {
            InitializeComponent();
        }

        private void ColorBlenderDesigner_Load(object sender, EventArgs e)
        {
        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            if (e.Index >= 0)
            {
                string n = ((ComboBox)sender).Items[e.Index].ToString();
                Font f = new Font("Arial", 9, FontStyle.Regular);
                Color c = Color.FromName(n);
                Brush b = new SolidBrush(c);
                g.DrawString(n, f, Brushes.Black, rect.X, rect.Top);
                g.FillRectangle(b, rect.X + 110, rect.Y + 5, rect.Width - 10, rect.Height - 10);
            }
        }

        private void saaButton1_Click(object sender, EventArgs e)
        {

            ArrayList ColorList = new ArrayList();
            Type colorType = typeof(System.Drawing.Color);
            PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static |
                                          BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (PropertyInfo c in propInfoList)
            {
                this.comboBox1.Items.Add(c.Name);
            }
        }

        private void saaButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
