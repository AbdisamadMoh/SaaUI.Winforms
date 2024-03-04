using SaaUI.Paint;
using System.Windows.Forms;

namespace SaaUI.Extensions
{
    internal static class Transparenter
    {
        public static void MakeTransparent(Control control, int transparency)
        {
            if (control != null && control.Parent != null)
            {
                DrawPaint paint = new DrawPaint()
                {
                    Options = new DrawPaintOptions()
                    {
                        Height = control.Height,
                        Width = control.Width,
                        Tranparency = transparency,
                        FillPath = true,
                        BackColor1 = control.BackColor,
                        BorderThickness = 0
                    }
                };
                paint.Paint(control.CreateGraphics(), control, false);
            }
        }
    }
}

