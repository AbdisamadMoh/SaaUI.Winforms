using SaaUI.Properties;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SaaUI
{
    /// <summary>
    /// Beautiful and customizable SaaPictureBox.
    /// </summary>
    [Description("Beautiful and customizable SaaPictureBox.")]
    [ToolboxBitmap(typeof(SaaPictureBox), "icons.SaaPictureBox_16.bmp")]
    public class SaaPictureBox : PictureBox
    {
        public SaaPictureBox()
        {

            Radius.Change += Radius1_Change;

        }

        private void Radius1_Change()
        {

            Invalidate();
        }
        Pen BorderPen;
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;


            var rec = new BorderPath(0, 0, Width, Height, _Radius);
            this.Region = new Region(rec.Path);

            base.OnPaint(e);
            if (_Border > 0)
            {
                LinearGradientBrush BGColor = new LinearGradientBrush(rec.RectangleF, _BorderColor, _BorderColor2, _BorderColorAngle);
                BorderPen = new Pen(BGColor, _Border);
                e.Graphics.DrawPath(BorderPen, rec.PathBorder);
                BGColor.Dispose();
            }
            try
            {
                rec.PathBorder.Dispose();
                rec.Path.Dispose();
            }
            catch { }
        }


        Radius _Radius = new Radius();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Radius Radius
        {
            get
            {
                return _Radius;
            }
            set
            {
                _Radius = value;
                Invalidate();
            }
        }
        int _Border = 0;
        public int Border
        {
            get
            {
                return _Border;
            }
            set
            {
                _Border = value;
                Invalidate();
            }
        }
        Color _BorderColor = Color.LightSkyBlue;
        public Color BorderColor
        {
            get
            {
                return _BorderColor;
            }
            set
            {
                _BorderColor = value;
                Invalidate();
            }
        }
        Color _BorderColor2 = Color.LightSkyBlue;
        public Color BorderColor2
        {
            get
            {
                return _BorderColor2;
            }
            set
            {
                _BorderColor2 = value;
                Invalidate();
            }
        }
        int _BorderColorAngle = 0;
        public int BorderColorAngle
        {
            get
            {
                return _BorderColorAngle;
            }
            set
            {
                _BorderColorAngle = value;
                Invalidate();
            }
        }
    }
}
