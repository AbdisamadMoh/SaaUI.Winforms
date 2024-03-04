using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SaaUI
{
    /// <summary>
    /// Very customizable Saaline.
    /// </summary>
    [Description("Very customizable Saaline.")]
    [ToolboxBitmap(typeof(SaaLine), "icons.SaaLine_16.bmp")]
    public class SaaLine : UserControl
    {
        public SaaLine()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
             ControlStyles.AllPaintingInWmPaint |
             ControlStyles.UserPaint |
             ControlStyles.SupportsTransparentBackColor, true);
            this.Height = 10;
            this.BackColor = Color.Transparent;
        }
        Label lbl = new Label();
        bool isAdded = false;
        protected override void OnPaint(PaintEventArgs e)
        {

            if (_Transparent)
            {
                Transparenter tra = new Transparenter();
                tra.MakeTransparent(e.Graphics, this);
            }

            if (!_Vertical)
            {
                this.Height = this.Height < 10 ? 10 : this.Height;
                int depth = this.Height > 9 ? this.Height / 2 - 9 : 1;
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

                using (Pen pen = new Pen(_LineColor, depth))
                {
                    pen.StartCap = _LineStart;
                    pen.EndCap = _LineEnd;
                    pen.DashCap = _DashCap;
                    pen.DashStyle = _DashStyle;
                    pen.DashOffset = _DashOffset;

                    int pos = LineAlignment == LineAlign.Center ? this.Height / 2 : LineAlignment == LineAlign.End ? this.Height - 1 : LineAlignment == LineAlign.Start ? 1 : _CustomLineAlignment;

                    e.Graphics.DrawLine(pen, (depth / 2) + _StartEdge, pos, (this.Width - depth / 2) - _EndEdge, pos);

                }
            }
            else
            {
                this.Width = this.Width < 10 ? 10 : this.Width;
                int depth = this.Width > 9 ? this.Width / 2 - 9 : 1;
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                using (Pen pen = new Pen(_LineColor, depth))
                {
                    pen.StartCap = _LineStart;
                    pen.EndCap = _LineEnd;

                    pen.DashCap = _DashCap;
                    pen.DashStyle = _DashStyle;
                    pen.Alignment = PenAlignment.Left;
                    pen.DashOffset = _DashOffset;

                    int pos = LineAlignment == LineAlign.Center ? this.Width / 2 : LineAlignment == LineAlign.End ? this.Width - 1 : LineAlignment == LineAlign.Start ? 1 : _CustomLineAlignment;

                    e.Graphics.DrawLine(pen, pos, StartEdge, pos, this.Height - _EndEdge);

                }
            }

            base.OnPaint(e);

        }
        bool _Transparent = false;
        /// <summary>
        /// Gets or Sets line outer body transparency
        /// </summary>
        [Description("Gets or Sets line outer body transparency")]
        [Category("Saa")]
        public bool Transparent
        {
            get { return _Transparent; }
            set { _Transparent = value; Invalidate(); }
        }

        LineAlign _LineAlignment = LineAlign.Center;
        /// <summary>
        /// Gets or Sets alignment of the line in the control.
        /// </summary>
        [Description("Gets or Sets alignment of the line in the control.")]
        [Category("Saa")]
        public LineAlign LineAlignment
        {
            get
            {
                return _LineAlignment;
            }
            set
            {
                _LineAlignment = value;
                Invalidate();
            }
        }

        int _CustomLineAlignment = 0;
        /// <summary>
        /// Gets or Sets custom alignment of the line.
        /// </summary>
        [Description("Gets or Sets custom alignment of the line.")]
        [Category("Saa")]
        public int CustomLineAlignment
        {
            get
            {
                return _CustomLineAlignment;
            }
            set
            {
                _LineAlignment = LineAlign.Custom;
                _CustomLineAlignment = value;

                Invalidate();
            }
        }


        int _StartEdge = 0;
        /// <summary>
        /// Gets or Sets distance between the line start point and the edge of the control.
        /// </summary>
        [Description("Gets or Sets distance between the line start point and the edge of the control.")]
        [Category("Saa")]
        public int StartEdge
        {
            get
            {
                return _StartEdge;
            }
            set
            {
                _StartEdge = value;
                Invalidate();
            }
        }

        int _EndEdge = 0;
        /// <summary>
        /// Gets or Sets distance between the line end point and the edge of the control.
        /// </summary>
        [Description("Gets or Sets distance between the line end point and the edge of the control.")]
        [Category("Saa")]
        public int EndEdge
        {
            get
            {
                return _EndEdge;
            }
            set
            {
                _EndEdge = value;
                Invalidate();
            }
        }
        float _DashOffset = 0;
        /// <summary>
        /// Gets or Sets distance from the start of a line to the start of a dash pattern.
        /// </summary>
        [Description("Gets or Sets distance from the start of a line to the start of a dash pattern.")]
        [Category("Saa")]
        public float DashOffset
        {
            get
            {
                return _DashOffset;
            }
            set
            {
                _DashOffset = value;
                Invalidate();
            }
        }
        DashCap _DashCap = DashCap.Flat;
        DashStyle _DashStyle = DashStyle.Solid;
        /// <summary>
        /// Gets or Sets dash cap of the line.
        /// </summary>
        [Description("Gets or Sets dash cap of the line.")]
        [Category("Saa")]
        public DashCap DashCap
        {
            get
            {
                return _DashCap;
            }
            set
            {
                _DashCap = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or Sets dash style of the line.
        /// </summary>
        [Description("Gets or Sets dash style of the line.")]
        [Category("Saa")]
        public DashStyle DashStyle
        {
            get
            {
                return _DashStyle;
            }
            set
            {
                _DashStyle = value;
                Invalidate();
            }
        }

        LineCap _LineStart = LineCap.Round;
        LineCap _LineEnd = LineCap.Round;
        /// <summary>
        /// Gets or Sets start cap of the line.
        /// </summary>
        [Description("Gets or Sets start cap of the line.")]
        [Category("Saa")]
        public LineCap LineStart
        {
            get
            {
                return _LineStart;
            }
            set
            {
                _LineStart = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or Sets end cap of the line.
        /// </summary>
        [Description("Gets or Sets end cap of the line.")]
        [Category("Saa")]
        public LineCap LineEnd
        {
            get
            {
                return _LineEnd;
            }
            set
            {
                _LineEnd = value;
                Invalidate();
            }
        }
        Color _LineColor = Color.FromArgb(127, 170, 255);
        /// <summary>
        /// Gets or Sets color of the line.
        /// </summary>
        [Description("Gets or Sets color of the line.")]
        [Category("Saa")]
        public Color LineColor
        {
            get
            {
                return _LineColor;
            }
            set
            {
                _LineColor = value;
                Invalidate();
            }
        }
        bool _Vertical = false;
        /// <summary>
        /// Gets or Sets whether the line is vertical(true) or horizontal(false).
        /// </summary>
        [Description("Gets or Sets whether the line is vertical(true) or horizontal(false).")]
        [Category("Saa")]
        public bool Vertical
        {
            get
            {
                return _Vertical;
            }
            set
            {

                if (_Vertical != value)
                {
                    //int h = this.Height;
                    //int w = this.Width;
                    //this.Height = w;
                    //this.Width = h;
                    _Vertical = value;
                    Invalidate();
                }
                //int x = this.Location.X;
                //int y = this.Location.Y;
                //this.Location = new Point(y, x,);




            }

        }

    }
}
