using SaaUI.Properties;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SaaUI.Paint
{
    internal class DrawPaint
    {
        public BorderPath Paths;
        public LinearGradientBrush BorderGardientColor;
        public LinearGradientBrush GardientBackColor;
        public Pen BorderColorPen;
        public DrawPaintOptions Options { get; set; } = new DrawPaintOptions();
        public void PaintGradient(Graphics graphic, Control control, bool ForceRegion)
        {
            if (graphic == null || control == null) return;
            int _height = Options.Height > 0 ? Options.Height : control.Height;
            int _width = Options.Width > 0 ? Options.Width : control.Width;
            graphic.SmoothingMode = Options.SmoothingMode;
            var rec = new BorderPath(Options.X, Options.Y, _width, _height, Options.Radius);



            if (Options.Tranparency < 100 || !ForceRegion)
            {
                if (!(control is Form))
                {
                    Transparenter tra = new Transparenter();
                    tra.MakeTransparent(graphic, control);
                }
            }
            if (ForceRegion)
            {
                control.Region = new Region(rec.Path);
            }
            else
            {
                control.Region = new Region(new RectangleF(0, 0, control.Width, control.Height));
            }
            int transpancePercentage = (int)((((float)Options.Tranparency / 100f) * 255f));
            transpancePercentage = transpancePercentage > 0 ? transpancePercentage : 1;

            if (control is Form) transpancePercentage = 255;

            Color parentcolor = control.Parent != null ? control.Parent.BackColor : Options.BackColor1;
            Color b1 = Options.BackColor1 == Color.Transparent ? Color.FromArgb(transpancePercentage, parentcolor) : Color.FromArgb(transpancePercentage, Options.BackColor1);
            Color b2 = Options.BackColor2 == Color.Transparent ? Color.FromArgb(transpancePercentage, parentcolor) : Color.FromArgb(transpancePercentage, Options.BackColor2);
            Color br1 = Options.BorderColor1 == Color.Transparent ? Color.FromArgb(transpancePercentage, parentcolor) : Color.FromArgb(transpancePercentage, Options.BorderColor1);
            Color br2 = Options.BorderColor2 == Color.Transparent ? Color.FromArgb(transpancePercentage, parentcolor) : Color.FromArgb(transpancePercentage, Options.BorderColor2);


            LinearGradientBrush BorderColor = new LinearGradientBrush(rec.RectangleF, br1, br2, Options.BorderColorAngle);
            Pen BorderPen = new Pen(BorderColor, Options.BorderThickness);
            LinearGradientBrush BC = new LinearGradientBrush(rec.RectangleF, b1, b2, Options.BackColorAngle);

            graphic.FillPath(BC, rec.Path);
            if (Options.BorderThickness > 0 && Options.DrawPath)
            {
                if (ForceRegion)
                {

                    graphic.DrawPath(BorderPen, rec.PathBorder);


                }
                else
                {
                    graphic.DrawPath(BorderPen, rec.Path);
                }
            }


            try
            {
                if (Options.AutoDispose)
                {
                    rec.Dispose();
                    BorderPen.Dispose();
                    BorderColor.Dispose();
                    BC.Dispose();
                }
                else
                {
                    Paths = rec;
                    BorderGardientColor = BorderColor;
                    GardientBackColor = BC;
                    BorderColorPen = BorderPen;
                }
            }
            catch { }

        }

        public void Paint(Graphics graphic, Control control, bool ForceRegion)
        {
            if (graphic == null || control == null) return;

            int _height = Options.Height > 0 ? Options.Height : control.Height;
            int _width = Options.Width > 0 ? Options.Width : control.Width;

            graphic.SmoothingMode = Options.SmoothingMode;
            var rec = new BorderPath(Options.X, Options.Y, _width, _height, Options.Radius);

            if (Options.Tranparency < 100 || !ForceRegion)
            {
                if (control is Form) return;
                Transparenter tra = new Transparenter();
                tra.MakeTransparent(graphic, control);
            }
            if (ForceRegion)
            {
                control.Region = new Region(rec.Path);
            }
            else
            {
                control.Region = new Region(new RectangleF(0, 0, control.Width, control.Height));
            }

            int transpancePercentage = (int)((((float)Options.Tranparency / 100f) * 255f));
            transpancePercentage = transpancePercentage > 0 ? transpancePercentage : 1;
            if (control is Form) transpancePercentage = 255;
            Color parentcolor = control.Parent != null ? control.Parent.BackColor : Options.BackColor1;
            Color b1 = Options.BackColor1 == Color.Transparent ? Color.FromArgb(transpancePercentage, parentcolor) : Color.FromArgb(transpancePercentage, Options.BackColor1);
            Color br1 = Options.BorderColor1 == Color.Transparent ? Color.FromArgb(transpancePercentage, parentcolor) : Color.FromArgb(transpancePercentage, Options.BorderColor1);

            Pen BorderPen = new Pen(br1, Options.BorderThickness);
            using (SolidBrush backColor = new SolidBrush(b1))
            {
                graphic.FillPath(backColor, rec.Path);
                if (Options.BorderThickness > 0 && Options.DrawPath)
                {
                    if (ForceRegion)
                    {
                        graphic.DrawPath(BorderPen, rec.PathBorder);
                    }
                    else
                    {
                        graphic.DrawPath(BorderPen, rec.Path);
                    }

                }

            }

            try
            {
                rec.Dispose();
                BorderPen.Dispose();
            }
            catch { }

        }

        public void Dispose(bool disposing)
        {
            Dispose();
        }
        public void Dispose()
        {
            Paths.Dispose();
            BorderGardientColor.Dispose();
        }

    }

    internal class DrawPaintOptions
    {
        public Color BackColor1 { get; set; } = SaaInternalColors.PrimaryColor;
        public Color BackColor2 { get; set; } = SaaInternalColors.PrimaryColor;
        public Color BorderColor1 { get; set; } = SaaInternalColors.DarkPrimary;
        public Color BorderColor2 { get; set; } = SaaInternalColors.DarkPrimary;
        public int BorderThickness { get; set; } = 1;
        public bool DrawPath { get; set; } = true;
        public bool FillPath { get; set; } = true;
        public int Tranparency { get; set; } = 100;
        public float X { get; set; } = 0;
        public float Y { get; set; } = 0;
        public int Width { get; set; } = 0;
        public int Height { get; set; } = 0;
        public int BorderColorAngle { get; set; } = 0;
        public int BackColorAngle { get; set; } = 0;
        public Radius Radius { get; set; } = new Radius();
        public SmoothingMode SmoothingMode { get; set; } = SmoothingMode.AntiAlias;
        public bool AutoDispose = true;
    }
}
