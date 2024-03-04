using System.Drawing;
using System.Windows.Forms;

namespace SaaUI
{
    internal class Transparenter
    {
        public void MakeTransparent(Graphics g, Control control, bool alsoParent = false)
        {
            if (control != null && control.GetType() != typeof(Form))
            {
                var parent = control.Parent;
                if (parent == null) return;
                var bounds = control.Bounds;
                var siblings = parent.Controls;
                int index = siblings.IndexOf(control);
                Bitmap behind = null;
                for (int i = siblings.Count - 1; i > index; i--)
                {
                    var c = siblings[i];
                    if (!c.Bounds.IntersectsWith(bounds)) continue;
                    if (behind == null)
                        behind = new Bitmap(control.Parent.ClientSize.Width, control.Parent.ClientSize.Height);
                    c.DrawToBitmap(behind, c.Bounds);
                }
                if (behind == null) return;
                g.DrawImage(behind, control.ClientRectangle, bounds, GraphicsUnit.Pixel);
                behind.Dispose();
            }
        }
    }
}
