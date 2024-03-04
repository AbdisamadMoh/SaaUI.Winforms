using System;
using System.Drawing;
using System.Windows.Forms;

namespace SaaUI
{
    internal class SaaGraphics
    {
        public Bitmap GetTransparentBackground(Form form, Point? topOffset = null, Point? bottomOffset = null, Point? Location = null, Size? size = null)
        {
            if (form == null) throw new Exception("Form is null");
            Bitmap btm = null;
            var parent = form;
            if (parent != null)
            {
                Point p = Location == null ? parent.Location : Location.Value;
                Size s = size == null ? parent.Size : size.Value;
                var x1 = p.X + topOffset.GetValueOrDefault(Point.Empty).X;
                var y1 = p.Y + topOffset.GetValueOrDefault(Point.Empty).Y;
                var x2 = x1 + s.Width + bottomOffset.GetValueOrDefault(Point.Empty).X;
                var y2 = y1 + s.Height + bottomOffset.GetValueOrDefault(Point.Empty).Y;
                var h = s.Height + (-topOffset.GetValueOrDefault(Point.Empty).Y) + bottomOffset.GetValueOrDefault(Point.Empty).Y;
                var w = s.Height + (-topOffset.GetValueOrDefault(Point.Empty).Y) + bottomOffset.GetValueOrDefault(Point.Empty).Y;
                btm = new Bitmap(w, h);
                using (var g = Graphics.FromImage(btm))
                {
                    g.CopyFromScreen(new Point(x1, y1), Point.Empty, new Size(w, h));
                }
            }
            return btm;
        }
    }
}
