using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SaaUI
{
    /// <summary>
    /// Beautiful and customizable saaPreloader.
    /// </summary>
    [Description("Beautiful and customizable saaPreloader.")]
    [DefaultEvent("Click")]
    [ToolboxBitmap(typeof(SaaPreloader), "icons.SaaPreloader_16.bmp")]
    public partial class SaaPreloader : UserControl
    {
        //   pnl panel;
        Timer _timer;
        float angle;
        int swAngle;
        bool reverse;
        Pen pen;
        public SaaPreloader()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            _timer = new Timer();
            pen = new Pen(Color.Black, 4);
            //panel = new pnl();
            //
            //panel.Dock = DockStyle.Fill;
            //panel.BackColor = Color.Transparent;
            //panel.Paint += Panel_Paint;
            //this.Controls.Add(panel);
            angle = 5;
            swAngle = 360;
            reverse = false;

            _timer.Tick += _timer_Tick;
            _timer.Interval = _SpeedInMilliSeconds;
            _timer.Start();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
            if (angle > _MaxAngle)
            {
                reverse = true;
                angle = _MaxAngle;

            }
            else if (angle < _MinAngle)
            {
                reverse = false;
                angle = _MinAngle;
            }

            if (!reverse)
            {
                angle += _StepUp;
            }
            else
            {
                angle -= _StepDown;
            }
            // angle -= 1;
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            int x = this.Width / 2;
            int y = this.Height / 2;

            int w = this.Width / 2;
            int h = this.Height / 2;

            pen.StartCap = _LineStart;
            pen.EndCap = _LineEnd;
            pen.Color = _LoaderColor;
            pen.Width = _LoaderWidth;
            pen.DashCap = _DashCap;
            pen.DashStyle = _DashStyle;
            pen.Alignment = PenAlignment.Left;
            pen.DashOffset = _DashOffset;

            var ctx = e.Graphics;
            ctx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            if (!_Reverse)
            {
                if (!reverse)
                {
                    ctx.TranslateTransform(x, y);
                    ctx.RotateTransform(angle);

                    ctx.DrawArc(pen, -w / 2, -h / 2, w, h, angle, angle);
                }
                else
                {
                    ctx.TranslateTransform(x, y);
                    ctx.RotateTransform(-angle);
                    ctx.DrawArc(pen, -w / 2, -h / 2, w, h, -angle, angle);

                }
            }
            else
            {
                if (!reverse)
                {
                    ctx.TranslateTransform(x, y);
                    ctx.RotateTransform(-angle);

                    ctx.DrawArc(pen, -w / 2, -h / 2, w, h, -angle, -angle);
                }
                else
                {
                    ctx.TranslateTransform(x, y);
                    ctx.RotateTransform(angle);
                    ctx.DrawArc(pen, -w / 2, -h / 2, w, h, angle, -angle);

                }
            }

            base.OnPaint(e);
        }
        private void Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        protected override void OnResize(EventArgs e)
        {
            if (this.Width > this.Height)
            {
                this.Height = this.Width;
            }
            else if (this.Height > this.Width)
            {
                this.Width = this.Height;
            }
            base.OnResize(e);

        }

        /// <summary>
        /// Gets or Sets whether the loader should start.
        /// </summary>
        [Description("Gets or Sets whether the loader should start.")]
        [Category("Saa")]
        public bool Start
        {
            get
            {
                return _timer.Enabled;
            }
            set
            {
                _timer.Enabled = value;
            }
        }

        bool _Reverse = false;
        /// <summary>
        /// Gets or Sets whether the preloader will go in the reverse direction.
        /// </summary>
        [Description("Gets or Sets whether the preloader will go in the reverse direction.")]
        [Category("Saa")]
        public bool Reverse
        {
            get
            {
                return _Reverse;
            }
            set
            {
                _Reverse = value;
            }
        }
        int _SpeedInMilliSeconds = 20;
        /// <summary>
        /// Gets or Sets speed of the loader in milliseconds.
        /// </summary>
        [Description("Gets or Sets speed of the loader in milliseconds.")]
        [Category("Saa")]
        public int SpeedInMilliSeconds
        {
            get
            {
                return _SpeedInMilliSeconds;
            }
            set
            {
                if (value < 1)
                {
                    throw new Exception($"'{value}' is not valid. Speed should be greater than 0 milliseconds.");
                }
                else
                {
                    _SpeedInMilliSeconds = value;
                    _timer.Interval = _SpeedInMilliSeconds;
                }

            }
        }


        int _StepUp = 4;
        /// <summary>
        /// Gets or Sets steps taken when the loader is going up.
        /// </summary>
        [Description("Gets or Sets steps taken when the loader is going up.")]
        [Category("Saa")]
        public int StepUp
        {
            get
            {
                return _StepUp;
            }
            set
            {
                _StepUp = value;
            }
        }

        int _StepDown = 4;
        /// <summary>
        /// Gets or Sets steps taken when the loader is going down.
        /// </summary>
        [Description("Gets or Sets steps taken when the loader is going down.")]
        [Category("Saa")]
        public int StepDown
        {
            get
            {
                return _StepDown;
            }
            set
            {
                _StepDown = value;
            }
        }

        int _MaxAngle = 360;
        /// <summary>
        /// Gets or Sets maximum angle the loader can reach. It can be between 0 to 360.
        /// </summary>
        [Description("Gets or Sets maximum angle the loader can reach. It can be between 0 to 360.")]
        [Category("Saa")]
        public int MaxAngle
        {
            get
            {
                return _MaxAngle;
            }
            set
            {
                _MaxAngle = value;
            }
        }

        int _MinAngle = 0;
        /// <summary>
        /// Gets or Sets minimum angle the loader can reach. It can be between 0 to 360.
        /// </summary>
        [Description("Gets or Sets minimum angle the loader can reach. It can be between 0 to 360.")]
        [Category("Saa")]
        public int MinAngle
        {
            get
            {
                return _MinAngle;
            }
            set
            {
                _MinAngle = value;
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
        DashCap _DashCap = DashCap.Round;
        DashStyle _DashStyle = DashStyle.Solid;
        /// <summary>
        /// Gets or Sets dash cap of the preloader.
        /// </summary>
        [Description("Gets or Sets dash cap of the preloader.")]
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
        /// Gets or Sets dash style of the preloader.
        /// </summary>
        [Description("Gets or Sets dash style of the preloader.")]
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
        /// Gets or Sets start cap of the line of the preloader.
        /// </summary>
        [Description("Gets or Sets start cap of the line of the preloader.")]
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
        /// Gets or Sets end cap the of the line of the preloader.
        /// </summary>
        [Description("Gets or Sets end cap the of the line of the preloader.")]
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
        Color _LoaderColor = Color.FromArgb(127, 170, 255);
        /// <summary>
        /// Gets or Sets color of the preloader.
        /// </summary>
        [Description("Gets or Sets color of the preloader.")]
        [Category("Saa")]
        public Color LoaderColor
        {
            get
            {
                return _LoaderColor;
            }
            set
            {
                _LoaderColor = value;
                Invalidate();
            }
        }

        int _LoaderWidth = 5;
        /// <summary>
        /// Gets or Sets width of the preloader.
        /// </summary>
        [Description("Gets or Sets width of the preloader.")]
        [Category("Saa")]
        public int LoaderWidth
        {
            get
            {
                return _LoaderWidth;
            }
            set
            {
                _LoaderWidth = value;
                Invalidate();
            }
        }



    }
}
