using SaaUI.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SaaUI
{
    /// <summary>
    /// Beautiful and customizable checkbox.
    /// </summary>
    [Description("Beautiful and customizable checkbox.")]
    [ToolboxBitmap(typeof(SaaCheckBox), "icons.SaaCheckBox.bmp")]
    [DefaultEvent("CheckChanged")]
    public class SaaCheckBox : Control
    {
        /// <summary>
        /// Fires when <see cref="Checked"/> property is changed.
        /// </summary>
        [Description("Fires when Checked property is changed.")]
        [Category("Saa")]
        public delegate void OnCheckChanged(object sender, EventArgs e);
        /// <summary>
        /// Fires when <see cref="Checked"/> property is changed.
        /// </summary>
        [Description("Fires when Checked property is changed.")]
        [Category("Saa")]
        public event OnCheckChanged CheckChanged;
        public SaaCheckBox()
        {
            this.Click += SaaCheckBox_Click;
            this.DoubleBuffered = true;
            Radius.Change += Radius1_Change;

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.SupportsTransparentBackColor, true);
            //this.BackColor = Color.FromArgb(10, Color.Red);


        }

        private void Radius1_Change()
        {

            Invalidate();
        }



        private void SaaCheckBox_Click(object sender, EventArgs e)
        {
            switch (MouseClicks)
            {
                case CheckBoxMouseClick.LeftClick:
                    {
                        if (((MouseEventArgs)e).Button == MouseButtons.Left)
                        {
                            this.Checked = !this.Checked;
                            CheckChanged?.Invoke(this, e);
                        }
                        break;
                    }
                case CheckBoxMouseClick.RightClick:
                    {
                        if (((MouseEventArgs)e).Button == MouseButtons.Right)
                        {
                            this.Checked = !this.Checked;
                            CheckChanged?.Invoke(this, e);
                        }
                        break;
                    }
                case CheckBoxMouseClick.AnyClick:
                    {
                        this.Checked = !this.Checked;
                        CheckChanged?.Invoke(this, e);
                        break;
                    }
            }

        }

        private void ResizeControl()
        {

            if (_AutoResize)
            {
                this.MinimumSize = new Size(_BoxWidth + textWidth + _OffWidth + _OffTextX, (textHeight > _BoxHeight ? textHeight : _BoxHeight + 1) + _OffHeight + _OffTextY);
                this.MaximumSize = new Size(_BoxWidth + textWidth + _OffWidth + _OffTextX, (textHeight > _BoxHeight ? textHeight : _BoxHeight + 1) + _OffHeight + _OffTextY);
            }
            else
            {

                this.MinimumSize = new Size(0, 0);
                this.MaximumSize = new Size(0, 0);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.BackColor == Color.Transparent)
            {
                Transparenter tra = new Transparenter();
                tra.MakeTransparent(e.Graphics, this);
            }
            TickMark(e.Graphics);

            base.OnPaint(e);
        }

        Pen tickPen;
        LinearGradientBrush penColor;
        Pen tickPathPen;
        int textWidth = 0;
        int textHeight = 0;
        private void TickMark(Graphics ctx)
        {
            ctx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            tickPen = new Pen(_TickColor, _TickThickness);
            tickPen.LineJoin = _TickJoints;
            tickPen.DashStyle = _TickStyle;

            tickPathPen = new Pen(_TickPathColor, _TickThickness);
            tickPathPen.LineJoin = _TickJoints;
            tickPathPen.DashStyle = _TickStyle;

            textWidth = (int)ctx.MeasureString(Text, Font).Width + 2;
            textHeight = (int)ctx.MeasureString(Text, Font).Height;

            var boxF = new BorderPath(_OffWidth, _OffHeight, _BoxWidth, _BoxHeight, _Radius);
            RectangleF box = boxF.RectangleF;
            int x1 = 3 + _OffX1 + _OffWidth,
                y1 = (int)box.Y + _BoxHeight / 2 + _OffY1,
                x2 = _BoxWidth / 4 + _OffX2 + _OffWidth,
                y2 = (int)box.Y + _BoxHeight - 6 + _OffY2,
                x3 = _BoxWidth - 3 + _OffX3 + _OffWidth,
                y3 = (int)box.Y + 3 + _OffY3;
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(box, _BoxColor, _BoxColor2, _BoxColorAngle);
            ctx.FillPath(linearGradientBrush, boxF.Path);

            Pen borderpen = new Pen(_BorderColor, _BorderThickness);
            borderpen.DashStyle = _BorderStyle;
            if (_BorderThickness > 0)
            {
                ctx.DrawPath(borderpen, boxF.Path);
            }

            if (_TickPath)
            {


                ctx.DrawLines(tickPathPen, new Point[] { new Point(x1,y1), new Point(x2, y2),
            new Point(x2,y2), new Point(x3, y3)});
            }
            if (_Checked)
            {
                ctx.DrawLines(tickPen, new Point[] { new Point(x1,y1), new Point(x2, y2),
            new Point(x2,y2), new Point(x3, y3)});
            }


            int TextX = _BoxWidth + _OffWidth + _OffTextX;
            int TextY = (int)box.Y + _OffTextY;
            ctx.DrawString(Text, Font, Brushes.Black, new Point(TextX, TextY));

            ResizeControl();
            try
            {
                boxF.Path.Dispose();
                boxF.PathBorder.Dispose();
                linearGradientBrush.Dispose();
                borderpen.Dispose();

            }
            catch { }
        }

        int _BorderThickness = 1;
        /// <summary>
        /// Gets or Sets border thickness of the control.
        /// </summary>
        [Description("Gets or Sets border thickness of the control.")]
        [Category("Saa")]
        public int BorderThickness
        {
            get
            {
                return _BorderThickness;
            }
            set
            {
                _BorderThickness = value;
                Invalidate();
            }
        }
        DashStyle _BorderStyle = DashStyle.Solid;
        /// <summary>
        /// Gets or Sets border line style.
        /// </summary>
        [Description("Gets or Sets border line style.")]
        [Category("Saa")]
        public DashStyle BorderStyle
        {
            get
            {
                return _BorderStyle;
            }
            set
            {
                _BorderStyle = value;
                Invalidate();
            }
        }

        Color _BorderColor = Color.LightSkyBlue;
        /// <summary>
        /// Gets or Sets color of the border lines.
        /// </summary>
        [Description("Gets or Sets color of the border lines.")]
        [Category("Saa")]
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



        LineJoin _TickJoints = LineJoin.Round;
        /// <summary>
        /// Gets or Sets how tick joints are connected to each other.
        /// </summary>
        [Description("Gets or Sets how tick joints are connected to each other.")]
        [Category("Saa")]
        public LineJoin TickJoints
        {
            get
            {
                return _TickJoints;
            }
            set
            {
                _TickJoints = value;
                Invalidate();
            }
        }
        DashStyle _TickStyle = DashStyle.Solid;
        /// <summary>
        /// Gets or Sets Tick dash style.
        /// </summary>
        [Description("Gets or Sets Tick dash style.")]
        [Category("Saa")]
        public DashStyle TickStyle
        {
            get
            {
                return _TickStyle;
            }
            set
            {
                _TickStyle = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or Sets which click the control accepts. E.g Mouse Left Click
        /// </summary>
        [Description("Gets or Sets which click the control accepts. E.g Mouse Left Click")]
        [Category("Saa")]
        public CheckBoxMouseClick MouseClicks { get; set; } = CheckBoxMouseClick.LeftClick;

        int _OffTextX = 0;
        int _OffTextY = 3;
        /// <summary>
        /// Gets or Sets how many pixels the text will move from the left side.
        /// </summary>
        [Description("Gets or Sets how many pixels the text will move from the left side.")]
        [Category("Saa")]
        public int OffTextX
        {
            get
            {
                return _OffTextX;
            }
            set
            {
                _OffTextX = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or Sets how many pixels the text will move from up.
        /// </summary>
        [Description("Gets or Sets how many pixels the text will move from up.")]
        [Category("Saa")]
        public int OffTextY
        {
            get
            {
                return _OffTextY;
            }
            set
            {
                _OffTextY = value;
                Invalidate();
            }
        }


        int _OffX1, _OffX2, _OffX3, _OffY1, _OffY2, _OffY3, _OffWidth, _OffHeight = 0;
        /// <summary>
        /// Gets or Sets how many pixels the the box will move from up and left.
        /// </summary>
        [Description("Gets or Sets how many pixels the the box will move from up and left.")]
        [Category("Saa")]
        public int BoxOffset
        {
            get
            {
                return _OffHeight;
            }
            set
            {
                _OffWidth = _OffHeight = value;
                Invalidate();
            }
        }

        //public int OffWidth
        //{
        //    get
        //    {
        //        return _OffWidth;
        //    }
        //    set
        //    {
        //        _OffWidth = value;
        //        Invalidate();
        //    }
        //}
        /// <summary>
        /// Gets or Sets in pixel, Tick Coordinate X1 offset. this is the start point of the tick.
        /// </summary>
        [Description("Gets or Sets in pixel, Tick Coordinate X1 offset. this is the start point of the tick.")]
        [Category("Saa")]
        public int TickOffX1
        {
            get
            {
                return _OffX1;
            }
            set
            {
                _OffX1 = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or Sets in pixel, Tick Coordinate X2 offset. this is the middle point of the tick where joints happen.
        /// </summary>
        [Description("Gets or Sets in pixel, Tick Coordinate X2 offset. this is the middle point of the tick where joints happen.")]
        [Category("Saa")]
        public int TickOffX2
        {
            get
            {
                return _OffX2;
            }
            set
            {
                _OffX2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or Sets in pixel, Tick Coordinate X3 offset. this is the end point of the tick where the end happens.
        /// </summary>
        [Description("Gets or Sets in pixel, Tick Coordinate X3 offset. this is the end point of the tick where the end happens.")]
        [Category("Saa")]
        public int TickOffX3
        {
            get
            {
                return _OffX3;
            }
            set
            {
                _OffX3 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or Sets in pixel, Tick Coordinate Y1 offset. this is the start point of the tick.
        /// </summary>
        [Description("Gets or Sets in pixel, Tick Coordinate Y1 offset. this is the start point of the tick.")]
        [Category("Saa")]
        public int TickOffY1
        {
            get
            {
                return _OffY1;
            }
            set
            {
                _OffY1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or Sets in pixel, Tick Coordinate Y2 offset. this is the middle point of the tick where joints happen.
        /// </summary>
        [Description("Gets or Sets in pixel, Tick Coordinate Y2 offset. this is the middle point of the tick where joints happen.")]
        [Category("Saa")]
        public int TickOffY2
        {
            get
            {
                return _OffY2;
            }
            set
            {
                _OffY2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or Sets in pixel, Tick Coordinate Y3 offset. this is the end point of the tick where the end happens.
        /// </summary>
        [Description("Gets or Sets in pixel, Tick Coordinate Y3 offset. this is the end point of the tick where the end happens.")]
        [Category("Saa")]
        public int TickOffY3
        {
            get
            {
                return _OffY3;
            }
            set
            {
                _OffY3 = value;
                Invalidate();
            }
        }

        Radius _Radius = new Radius();
        /// <summary>
        /// Gets or Sets The radius of the box. The roundness of the egdes.
        /// </summary>
        [Description("Gets or Sets The radius of the box. The roundness of the edges.")]
        [Category("Saa")]
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
        Color _BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));


        bool _Checked = false;
        /// <summary>
        /// Gets or Sets whether tick is Checked. returns TRUE if checked otherwise FALSE.
        /// </summary>
        [Description("Gets or Sets whether tick is Checked. returns TRUE if checked otherwise FALSE.")]
        [Category("Saa")]
        public bool Checked
        {
            get
            {
                return _Checked;
            }
            set
            {
                _Checked = value;
                Invalidate();

            }
        }

        bool _TickPath = true;
        /// <summary>
        /// Gets or Sets whether tick placeholder is visible when unchecked.
        /// </summary>
        [Description("Gets or Sets whether tick placeholder is visible when unchecked.")]
        [Category("Saa")]
        public bool TickPath
        {
            get
            {
                return _TickPath;
            }
            set
            {
                _TickPath = value;
                Invalidate();
            }
        }
        bool _AutoResize = true;
        /// <summary>
        /// Gets or Sets whether the control will take the size of its content than the defined size.
        /// </summary>
        [Description("Gets or Sets whether the control will take the size of its content than the defined size.")]
        [Category("Saa")]
        public bool AutoResize
        {
            get
            {
                return _AutoResize;
            }
            set
            {
                _AutoResize = value;
                Invalidate();
            }
        }
        int _TickThickness = 2;
        /// <summary>
        /// Gets or Sets the thickness of the tick.
        /// </summary>
        [Description("Gets or Sets the thickness of the tick.")]
        [Category("Saa")]
        public int TickThickness
        {
            get
            {
                return _TickThickness;
            }
            set
            {
                _TickThickness = value;
                Invalidate();
            }
        }
        Color _TickColor = Color.White;
        /// <summary>
        /// Gets or Sets the color of the tick.
        /// </summary>
        [Description("Gets or Sets the color of the tick.")]
        [Category("Saa")]
        public Color TickColor
        {
            get
            {
                return _TickColor;
            }
            set
            {
                _TickColor = value;
                Invalidate();
            }
        }

        Color _TickPathColor = Color.LightBlue;
        /// <summary>
        /// Gets or Sets the color of the tick path. The tick placeholder.
        /// </summary>
        [Description("Gets or Sets the color of th tick path. The tick placeholder.")]
        [Category("Saa")]
        public Color TickPathColor
        {
            get
            {
                return _TickPathColor;
            }
            set
            {
                _TickPathColor = value;
                Invalidate();
            }
        }

        Color _BoxColor = Color.LightSkyBlue;
        /// <summary>
        /// Gets or Sets the color of the box.
        /// </summary>
        [Description("Gets or Sets the color of the box.")]
        [Category("Saa")]
        public Color BoxColor
        {
            get
            {
                return _BoxColor;
            }
            set
            {
                _BoxColor = value;
                Invalidate();
            }
        }

        Color _BoxColor2 = Color.LightSkyBlue;
        /// <summary>
        /// Gets or Sets the second color of the box.
        /// </summary>
        [Description("Gets or Sets the second color of the box.")]
        [Category("Saa")]
        public Color BoxColor2
        {
            get
            {
                return _BoxColor2;
            }
            set
            {
                _BoxColor2 = value;
                Invalidate();
            }
        }

        float _BoxColorAngle = 90f;
        /// <summary>
        /// Gets or Sets angle of BackColor and BackColor2 on the control.
        /// </summary>
        [Description("Gets or Sets angle of BackColor and BackColor2 on the control.")]
        [Category("Saa")]
        public float BoxColorAngle
        {
            get
            {
                return _BoxColorAngle;
            }

            set
            {
                _BoxColorAngle = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or Sets Text associated with the control.
        /// </summary>
        [Description("Gets or Sets Text associated with the control.")]
        [Category("Saa")]
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public override string Text
        { get => base.Text; set { base.Text = value; Invalidate(); } }

        int _BoxHeight = 20;
        /// <summary>
        /// Gets or Sets height the box.
        /// </summary>
        [Description("Gets or Sets height the box.")]
        [Category("Saa")]
        public int BoxHeight
        {
            get
            {
                return _BoxHeight;
            }
            set
            {
                _BoxHeight = value;
                Invalidate();
            }
        }

        int _BoxWidth = 20;
        /// <summary>
        /// Gets or Sets width the box.
        /// </summary>
        [Description("Gets or Sets width the box.")]
        [Category("Saa")]
        public int BoxWidth
        {
            get
            {
                return _BoxWidth;
            }
            set
            {
                _BoxWidth = value;
                Invalidate();
            }
        }
    }
}
