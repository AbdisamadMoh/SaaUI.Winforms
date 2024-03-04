using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SaaUI
{
    [ToolboxBitmap(typeof(SaaRichTextBox), "icons.SaaRichTextBox_16.bmp")]
    public class SaaRichTextBox : RichTextBox
    {
        GraphicsPath P = new GraphicsPath();

        protected override void OnPaint(PaintEventArgs pevent)
        {
            //var rec = new RoundedRectangleF(Width, Height, _Radius, _RadiusCorner);
            //this.Region = new Region(rec.Path);
            //pevent.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            base.OnPaint(pevent);

        }



    }
}
