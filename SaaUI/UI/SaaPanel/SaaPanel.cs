using SaaUI.Paint;
using SaaUI.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SaaUI
{
    [ToolboxBitmap(typeof(SaaPanel), "icons.SaaPanel_16.bmp")]
    public class SaaPanel : Panel
    {
        public SaaPanel()
        {


            this.BackColor = SaaInternalColors.PrimaryColor;
            Radius.Change += Radius1_Change;
            DoubleBuffered = true;

        }

        private void Radius1_Change()
        {

            Invalidate();
        }

        Pen BorderPen;
        protected override void OnPaint(PaintEventArgs e)
        {

            // e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            DrawPaint paint = new DrawPaint()
            {
                Options = new DrawPaintOptions()
                {
                    BackColor1 = _BackColor,
                    BackColor2 = _BackColor2,
                    BackColorAngle = (int)_BackColorAngle,
                    BorderColor1 = _BorderColor,
                    BorderColor2 = _BorderColor2,
                    BorderColorAngle = _BorderColorAngle,
                    BorderThickness = _Border,
                    Radius = _Radius,
                    X = !_ForceDrawRegion ? 1 : 0,
                    Y = !_ForceDrawRegion ? 1 : 0,
                    Tranparency = _Transparence,
                    SmoothingMode = SmoothingMode.AntiAlias,
                    Width = this.Width - (!_ForceDrawRegion ? 3 : 0),
                    Height = this.Height - (!_ForceDrawRegion ? 3 : 0)//adjusting radius and width,height which exceedes
                }
            };

            if (_ColorType == PanelColorType.Gradient)
            {
                paint.PaintGradient(e.Graphics, this, _ForceDrawRegion);
            }
            else
            {
                paint.Paint(e.Graphics, this, _ForceDrawRegion);
            }
            base.OnPaint(e);

            return;
            var rec = new BorderPath(0, 0, Width, Height, _Radius);
            // this.Region = new Region(rec.Path);

            Transparenter tra = new Transparenter();
            tra.MakeTransparent(e.Graphics, this);
            int transpancePercentage = (int)((((float)_Transparence / 100f) * 255f));
            transpancePercentage = transpancePercentage > 0 ? transpancePercentage : 1;

            Color parentcolor = this.Parent != null ? this.Parent.BackColor : _BackColor;
            Color b1 = _BackColor == Color.Transparent ? Color.FromArgb(transpancePercentage, parentcolor) : Color.FromArgb(transpancePercentage, _BackColor);
            Color b2 = _BackColor2 == Color.Transparent ? Color.FromArgb(transpancePercentage, parentcolor) : Color.FromArgb(transpancePercentage, _BackColor2);
            Color br1 = _BorderColor == Color.Transparent ? Color.FromArgb(transpancePercentage, parentcolor) : Color.FromArgb(transpancePercentage, _BorderColor);
            Color br2 = _BorderColor2 == Color.Transparent ? Color.FromArgb(transpancePercentage, parentcolor) : Color.FromArgb(transpancePercentage, _BorderColor2);

            LinearGradientBrush BGColor = new LinearGradientBrush(rec.RectangleF, br1, br2, _BorderColorAngle);

            if (_ColorType == PanelColorType.Gradient)
            {
                //Recreate radius like of Padding..but backup first
                using (LinearGradientBrush inactiveGB = new LinearGradientBrush(rec.RectangleF, b1, b2, _BackColorAngle))
                {
                    e.Graphics.FillPath(inactiveGB, rec.Path);
                    if (_Border > 0)
                    {
                        BorderPen = new Pen(BGColor, _Border);
                        e.Graphics.DrawPath(BorderPen, rec.Path);
                        BGColor.Dispose();
                    }
                }
            }
            else
            {
                using (SolidBrush backColor = new SolidBrush(b1))
                {
                    e.Graphics.FillPath(backColor, rec.Path);
                    if (_Border > 0)
                    {
                        BorderPen = new Pen(br1, _Border);
                        e.Graphics.DrawPath(BorderPen, rec.PathBorder);

                    }
                }
            }

            base.OnPaint(e);
            try
            {
                //BGColor.Dispose();
                //rec.PathBorder.Dispose();
                //rec.Path.Dispose();
                //BorderPen.Dispose();
                rec.Dispose();
            }
            catch { }
        }
        bool _ForceDrawRegion = true;
        /// <summary>
        /// Gets or Sets whether the panel's region is hard drawn or soft drawn.
        /// </summary>
        [Description("Gets or Sets whether the panel's region is hard drawn or soft drawn.")]
        [Category("Saa")]
        public bool ForceDrawRegion
        {
            get
            {
                return _ForceDrawRegion;
            }
            set
            {
                _ForceDrawRegion = value;
                Invalidate();
            }
        }

        Color _BackColor = SaaInternalColors.PrimaryColor;
        /// <summary>
        /// Gets or Sets first BackColor of the LinearGradient.
        /// </summary>
        [Description("Gets or Sets first BackColor of the LinearGradient.")]
        [Category("Saa")]
        public new Color BackColor
        {
            get
            {
                return _BackColor;
            }
            set
            {
                _BackColor = value;
                base.BackColor = Color.Transparent;
                Invalidate();
            }
        }

        int _Transparence = 100;
        /// <summary>
        /// Gets or Sets transparency pacentage of the panel.
        /// </summary>
        [Description("Gets or Sets transparency pacentage of the panel.")]
        [Category("Saa")]
        public int Transparence
        {
            get
            {
                return _Transparence;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _Transparence = value;
                    Invalidate();
                }
                else
                {
                    throw new Exception("Transparence value should be between 0% and 100%");
                }
            }
        }
        PanelColorType _ColorType = PanelColorType.Default;
        /// <summary>
        /// Gets or Sets whether the background of the panel is gradient or solid. Default is solid. For better performance let it be Default(Solid).
        /// </summary>
        [Description("Gets or Sets whether the background of the panel is gradient or solid. Default is solid. For better performance let it be Default(Solid).")]
        [Category("Saa")]
        public PanelColorType ColorType
        {
            get
            {
                return _ColorType;
            }
            set
            {
                _ColorType = value;
                Invalidate();
            }
        }
        Radius _Radius = new Radius();
        /// <summary>
        /// Gets or Sets the border radius of the control.
        /// </summary>
        [Description("Gets or Sets the border radius of the control."), Category("Saa")]
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
        /// <summary>
        /// Gets or Sets border thickness of the control.
        /// </summary>
        [Description("Gets or Sets border thickness of the control."), Category("Saa")]
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
        /// <summary>
        /// Gets or Sets first color of the border color gradient.
        /// </summary>
        [Description("Gets or Sets first color of the border color gradient."), Category("Saa")]
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
        /// <summary>
        /// Gets or Sets first second of the border color gradient.
        /// </summary>
        [Description("Gets or Sets second color of the border color gradient."), Category("Saa")]
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
        /// <summary>
        /// Gets or Sets at which angle the color gradients will meet.
        /// </summary>
        [Description("Gets or Sets at which angle the color gradients will meet."), Category("Saa")]
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
        protected override bool DoubleBuffered { get => base.DoubleBuffered; set => base.DoubleBuffered = value; }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]


        /// <summary>
        /// Gets or Sets whether to enable double buffering for this control
        /// </summary>
        [Description("Gets or Sets whether to enable double buffering for this control.")]
        [Category("Saa")]
        public bool EnableDoubleBuffering
        {
            get
            {
                return DoubleBuffered;
            }
            set
            {
                DoubleBuffered = value;
            }
        }

        Color _BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
        /// <summary>
        /// Gets or Sets second BackColor of the LinearGradient.
        /// </summary>
        [Description("Gets or Sets second BackColor of the LinearGradient.")]
        [Category("Saa")]
        public Color BackColor2
        {
            get
            {
                return _BackColor2;
            }

            set
            {
                _BackColor2 = value;
                Invalidate();
            }
        }
        float _BackColorAngle = 90f;
        /// <summary>
        /// Gets or Sets angle of BackColor and BackColor2 on the control.
        /// </summary>
        [Description("Gets or Sets angle of BackColor and BackColor2 on the control.")]
        [Category("Saa")]
        public float BackColorAngle
        {
            get
            {
                return _BackColorAngle;
            }

            set
            {
                _BackColorAngle = value;
                Invalidate();
            }
        }
    }

}
