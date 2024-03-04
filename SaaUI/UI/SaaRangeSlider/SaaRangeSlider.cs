using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaaUI.UI.SaaRangeSlider
{
    public class SaaRangeSlider:Control
    {
        public SaaRangeSlider()
        {
            DoubleBuffered = true;
            SetStyle(SaaSetStyle.GetUserPaint, true);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawDown(e.Graphics);
            base.OnPaint(e);
        }
        private void Draw(Graphics ctx)
        {

        }

        private void DrawDown(Graphics ctx)
        {
            int min = this._Minimum;
            int max = this._Maximum;
            int width = this.Width-14;
            int height = this.Height-2;
            int lineWidth = width;
            int min_max = (max - min)+1;

            if (min_max > 0)
            {
                int _dotSpace = width / min_max;
                lineWidth = _dotSpace * min_max;
                int x = (this.Width - lineWidth) / 2;
                int y = 2;
              //  ctx.DrawString($"dp:{_dotSpace}, mm:{min_max},width:{this.Width}, linewidth:{lineWidth}", Font,Brushes.Red,x,5);

                 //ctx.DrawLine(Pens.Red, new PointF(x, y), new PointF(x , y+3));
                 //ctx.DrawLine(Pens.Red, new PointF(lineWidth, y), new PointF(lineWidth, y + 3));
                //ctx.DrawLine(Pens.Green,(_dotSpace*10) +x, y, (_dotSpace * 10) + x, y);
                for (int i = 0; min_max > i; i++) 
                {
                    int newX = (_dotSpace * i)+x;
                 //   ctx.DrawString($"Nx:{newX}, x:{x}", Font, Brushes.Red, newX, 15);
                    ctx.DrawLine(Pens.Red, new PointF(newX, y), new PointF(newX, y + 3));

                }
            }

        }
        int _Maximum = 10;
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                this.Minimum =  this.Minimum < value ? this.Minimum = value : _Maximum;
                _Maximum = value;
                Invalidate();
            }
        }

        int _Minimum = 0;
        public int Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                _Minimum = value;
                Invalidate();
            }
        }
    }
}
