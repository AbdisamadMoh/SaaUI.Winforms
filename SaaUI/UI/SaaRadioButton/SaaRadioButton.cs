using SaaUI.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace SaaUI
{
    internal class SaaRadioButton : Control
    {
        public SaaRadioButton()
        {
            Size = new Size(100, 24);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Draw(e.Graphics);
            base.OnPaint(e);

        }

        private void Draw(Graphics g)
        {
            var w = this.Width;
            var h = this.Height;
            var bh = this.Height - 2;
            var bw = bh;
            var r = new Radius(bh / 2, bh / 2, bh / 2, bh / 2);
            using (Brush b = new SolidBrush(Color.Red))
            using (var bx = new BorderPath(1, 1, bw, bh, r))
            {
                g.FillPath(b, bx.Path);
            }
        }
    }
}
