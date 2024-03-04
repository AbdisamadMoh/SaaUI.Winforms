using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SaaUI
{
    /// <summary>
    /// Beautifully designed and customizable SaaCircularProgress.
    /// </summary>
    [DefaultEvent("ValueChanged")]
    [Description(" Beautifully designed and customizable SaaCircularProgress.")]
    [ToolboxBitmap(typeof(SaaCircularProgress), "icons.SaaCircularProgress_16.bmp")]
    public partial class SaaCircularProgress : UserControl
    {
        Timer _timer;
        float _RotateAngle;
        int swAngle;
        Pen pen;
        Pen Pathpen;
        int pbComplete;
        /// <summary>
        /// Fires when the <see cref="Value"/> of the CircularProgress is changed
        /// </summary>
        /// <param name="sender">object of type <see cref="SaaCircularProgress"/></param>
        /// <param name="e"></param>
        public delegate void OnValueChanged(object sender, EventArgs e);
        /// <summary>
        /// Fires when the <see cref="Value"/> of the CircularProgress is changed
        /// <para>TIP: You can get the the new value from <see cref="Value"/> or as percentage <see cref="Percentage"/></para>
        /// </summary>
        [Description("Fires when the Value of the CircularProgress is changed."), Category("Saa")]
        public event OnValueChanged ValueChanged;
        public SaaCircularProgress()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.SupportsTransparentBackColor, true);

            _timer = new Timer();
            pen = new Pen(_LoaderColor, _LoaderWidth);

            Pathpen = new Pen(_PathColor, _PathDepth);
            _RotateAngle = 5;
            swAngle = 360;
            // panel.Paint += Panel_Paint;
            _timer.Tick += _timer_Tick;
            _timer.Interval = _SpeedInMilliSeconds;
            if (!_Circulate) _timer.Stop(); else _timer.Start();

            Invalidate();
        }


        private void _timer_Tick(object sender, EventArgs e)
        {
            Invalidate();
            if (_Circulate)
            {
                if (!_ReverseCirculate)
                {
                    if (_RotateAngle > 359)
                    {
                        _RotateAngle = 0;
                    }
                    else
                    {
                        _RotateAngle += _RotateStep;
                    }
                }
                else
                {
                    if (_RotateAngle < 1)
                    {
                        _RotateAngle = 360;
                    }
                    else
                    {
                        _RotateAngle -= _RotateStep;
                    }
                }
            }

        }
        private void Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {

            UpdateModify(e.Graphics);
            base.OnPaint(e);
        }
        private void UpdateIt()
        {
            UpdateModify(this.CreateGraphics());
        }
        private void UpdateModify(Graphics ctx)
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



            //  var ctx = e.Graphics;
            ctx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            if (_Path)
            {
                Pathpen.Color = _PathColor;
                Pathpen.Width = _PathDepth;
                Pathpen.DashCap = _PathDashCap;
                Pathpen.DashStyle = _PathDashStyle;
                ctx.DrawArc(Pathpen, w / 2, h / 2, w, h, (0), ((int)(360)));
            }

            double pbunit = 360 / (double)_Max;
            if (!_Reverse)
            {
                ctx.DrawArc(pen, w / 2, h / 2, w, h, (_Circulate ? _RotateAngle : _Angle), -((int)(pbComplete * pbunit)));
            }
            else
            {
                ctx.DrawArc(pen, w / 2, h / 2, w, h, (_Circulate ? _RotateAngle : _Angle), ((int)(pbComplete * pbunit)));
            }



            var percent = Math.Round((pbComplete / (double)_Max) * 100, _DecimalPoints);
            _Percentage = percent;
            string showingText = (_Display == SaaCircularProgressDisplayValue.Value ? (_Prefix + pbComplete + _Suffix).ToString() :
                  _Display == SaaCircularProgressDisplayValue.Percent ? (_Prefix + percent + _Suffix).ToString() : (_Prefix + "" + _Suffix));
            var tw = ctx.MeasureString(showingText, Font).Width / 2;
            SolidBrush br = new SolidBrush(this.ForeColor);
            ctx.DrawString(showingText, Font, br, w - (tw > 0 ? tw : 0), h - 3);
            br.Dispose();
            //}
        }

        protected override void OnResize(EventArgs e)
        {
            //if (this.Width > this.Height)
            //{
            //    this.Height = this.Width;
            //}
            //else if (this.Height > this.Width)
            //{
            //    this.Width = this.Height;
            //}
            base.OnResize(e);
            this.Height = this.Width;

        }


        /// <summary>
        /// Increments value of the CircularProgress by the value specified in <see cref="Step"/>
        /// </summary>
        public void PerformStep()
        {
            try
            {
                this.Value += _Step;
                Invalidate();
                FireValueChanged();
            }
            catch { }

        }

        bool _Path = true;
        /// <summary>
        /// Gets or Sets whether to show the path of the CircularProgress.
        /// </summary>
        [Description("Gets or Sets whether to show the path of the CircularProgress.")]
        [Category("Saa")]
        public bool Path
        {
            get
            {
                return _Path;
            }
            set
            {
                _Path = value;
                Invalidate();
            }
        }

        Color _PathColor = Color.FromArgb(192, 192, 255);
        /// <summary>
        /// Gets or Sets path color of the CircularProgress.
        /// </summary>
        [Description("Gets or Sets path color of the CircularProgress.")]
        [Category("Saa")]
        public Color PathColor
        {
            get { return _PathColor; }
            set { _PathColor = value; Invalidate(); }
        }

        int _PathDepth = 10;
        /// <summary>
        /// Gets or Sets path depth of the CircularProgress.
        /// </summary>
        [Description("Gets or Sets path depth of the CircularProgress.")]
        [Category("Saa")]
        public int PathDepth
        {
            get { return _PathDepth; }
            set { _PathDepth = value; Invalidate(); }
        }

        DashCap _PathDashCap = DashCap.Round;
        DashStyle _PathDashStyle = DashStyle.Solid;
        /// <summary>
        /// Gets or Sets path dash cap of the CircularProgress.
        /// </summary>
        [Description("Gets or Sets path dash cap of the CircularProgress.")]
        [Category("Saa")]
        public DashCap PathDashCap
        {
            get
            {
                return _PathDashCap;
            }
            set
            {
                _PathDashCap = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or Sets path dash style of the CircularProgress.
        /// </summary>
        [Description("Gets or Sets path dash style of the CircularProgress.")]
        [Category("Saa")]
        public DashStyle PathDashStyle
        {
            get
            {
                return _PathDashStyle;
            }
            set
            {
                _PathDashStyle = value;
                Invalidate();
            }
        }


        double _Percentage = 0;

        /// <summary>
        /// Gets Percentage value of the CircularProgress. Decimal points is determined by <see cref="DecimalPoints"/>
        /// </summary> 
        [Browsable(false)]
        public double Percentage
        {
            get
            {
                return Math.Round((pbComplete / (double)_Max) * 100, _DecimalPoints);
            }
        }
        int _SpeedInMilliSeconds = 20;
        /// <summary>
        /// Gets or Sets speed of the rotation in milliseconds.
        /// </summary>
        [Description("Gets or Sets speed of the rotation in milliseconds.")]
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


        int _RotateStep = 4;
        /// <summary>
        /// Gets or Sets steps taken when the CircularProgress is rotating.
        /// </summary>
        [Description("Gets or Sets steps taken when the CircularProgress is rotating.")]
        [Category("Saa")]
        public int RotateStep
        {
            get
            {
                return _RotateStep;
            }
            set
            {
                _RotateStep = value;
            }
        }

        bool _Circulate = false;
        /// <summary>
        /// Gets or Sets whether the CircularProgress will rotate.
        /// </summary>
        [Description("Gets or Sets whether the CircularProgress will rotate.")]
        [Category("Saa")]
        public bool Circulate
        {
            get
            {
                return _Circulate;
            }
            set
            {
                _Circulate = value;
                if (value)
                {
                    _timer.Start();
                }
                else
                {
                    _timer.Stop();
                }
                Invalidate();
            }
        }
        bool _ReverseCirculate = false;
        /// <summary>
        /// Gets or Sets whether the CircularProgress will rotate in reverse direction.
        /// </summary>
        [Description("Gets or Sets whether the CircularProgress will rotate in reverse direction.")]
        [Category("Saa")]
        public bool ReverseCirculate
        {
            get
            {
                return _ReverseCirculate;
            }
            set
            {
                _ReverseCirculate = value;
                Invalidate();
            }
        }

        bool _Reverse = false;
        /// <summary>
        /// Gets or Sets whether the CircularProgress value will be incremented/decremented in reverse direction.
        /// </summary>
        [Description("Gets or Sets whether the CircularProgress value will be incremented/decremented in reverse direction.")]
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
                Invalidate();
            }
        }

        SaaCircularProgressDisplayValue _Display = SaaCircularProgressDisplayValue.Percent;
        /// <summary>
        /// Gets or Sets how text is displayed in the CircularProgress.
        /// </summary>
        [Description("Gets or Sets how text is displayed in the CircularProgress.")]
        [Category("Saa")]
        public SaaCircularProgressDisplayValue Display
        {
            get
            {
                return _Display;
            }
            set
            {
                _Display = value;
                Invalidate();
            }
        }

        string _Prefix = "";
        /// <summary>
        /// Gets or Sets text put before Value/Percent/None text displayed in the CircularProgress.
        /// </summary>
        [Description("Gets or Sets text put before Value/Percent/None text displayed in the CircularProgress.")]
        [Category("Saa")]
        public string Prefix
        {
            get
            {
                return _Prefix;
            }
            set
            {
                _Prefix = value;
                Invalidate();
            }
        }

        string _Suffix = "";
        /// <summary>
        /// Gets or Sets text put after Value/Percent/None text displayed in the CircularProgress.
        /// </summary>
        [Description("Gets or Sets text put after Value/Percent/None text displayed in the CircularProgress.")]
        [Category("Saa")]
        public string Suffix
        {
            get
            {
                return _Suffix;
            }
            set
            {
                _Suffix = value;
                Invalidate();
            }
        }

        int _DecimalPoints = 2;
        /// <summary>
        /// Gets or Sets how many decimal points will be displayed in the CircularProgress.
        /// </summary>
        [Description("Gets or Sets how many decimal points will be displayed in the CircularProgress.")]
        [Category("Saa")]
        public int DecimalPoints
        {
            get
            {
                return _DecimalPoints;
            }
            set
            {
                if (value > -1 && value < 16)
                {
                    _DecimalPoints = value;
                    Invalidate();
                }
                else
                {
                    throw new Exception($"'{value}' is not a valid value. Decimal Points should be between 0 and 15.");
                }
            }
        }

        int _Step = 10;
        /// <summary>
        /// Amount to increment current value of the control when called <see cref="PerformStep"/>.
        /// </summary>
        [Description("Amount to increment current value of the control when called PerformStep().")]
        [Category("Saa")]
        public int Step
        {
            get
            {
                return _Step;
            }
            set
            {
                _Step = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or Sets current value of the control.
        /// </summary>
        [Description("Gets or Sets current value of the control.")]
        [Category("Saa")]
        public int Value
        {
            get
            {
                return pbComplete;
            }
            set
            {
                if (value > _Max)
                {
                    throw new Exception($"'{value}' is not valid for 'Value'. 'Value' should be between 'Maximum' and 'Minimum'.");
                }
                else if (value < _Min)
                {

                    throw new Exception($"'{value}' is not valid for 'Value'. 'Value' should be between 'Maximum' and 'Minimum'.");
                }
                else
                {
                    pbComplete = value;
                    Invalidate();
                    FireValueChanged();
                }

            }
        }

        int _Max = 100;
        /// <summary>
        /// Gets or Sets maximum value of the control.
        /// </summary>
        [Description("Gets or Sets maximum value of the control.")]
        [Category("Saa")]
        public int Maximum
        {
            get
            {
                return _Max;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception($"'{value}' is not valid for 'Maximum'. 'Maximum should not be negative.");

                }
                else
                {
                    _Min = (value < _Min ? value : _Min);
                    Value = (value < Value ? value : Value);
                    _Max = value;
                    Invalidate();
                }

            }
        }

        int _Min = 0;
        /// <summary>
        /// Gets or Sets minimum value of the control.
        /// </summary>
        [Description("Gets or Sets minimum value of the control.")]
        [Category("Saa")]
        public int Minimum
        {
            get
            {
                return _Min;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception($"'{value}' is not valid for 'Minimum'. 'Minimum should not be negative.");

                }
                else
                {
                    Maximum = (value > Maximum ? value : _Max);
                    Value = (value > Value ? value : Value);
                    _Min = value;
                    Invalidate();
                }
            }
        }

        int _Angle = 275;
        /// <summary>
        /// Gets or Sets start angle. It should be between 0 to 360.
        /// </summary>
        [Description("Gets or Sets start angle. It should be between 0 to 360.")]
        [Category("Saa")]
        public int StartAngle
        {
            get
            {
                return _Angle;
            }
            set
            {
                _Angle = value;
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
        DashCap _DashCap = DashCap.Round;
        DashStyle _DashStyle = DashStyle.Solid;
        /// <summary>
        /// Gets or Sets dash cap of the CircularProgress.
        /// </summary>
        [Description("Gets or Sets dash cap of the CircularProgress.")]
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
        /// Gets or Sets dash style of the CircularProgress.
        /// </summary>
        [Description("Gets or Sets dash style of the CircularProgress.")]
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

        LineCap _LineStart = LineCap.Flat;
        LineCap _LineEnd = LineCap.Flat;
        /// <summary>
        /// Gets or Sets start cap of the line of the CircularProgress.
        /// </summary>
        [Description("Gets or Sets start cap of the line of the CircularProgress.")]
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
        /// Gets or Sets end cap the of the line of the CircularProgress.
        /// </summary>
        [Description("Gets or Sets end cap the of the line of the CircularProgress.")]
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
        Color _LoaderColor = Color.White;
        /// <summary>
        /// Gets or Sets color of the CircularProgress.
        /// </summary>
        [Description("Gets or Sets color of the CircularProgress.")]
        [Category("Saa")]
        public Color Color
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

        int _LoaderWidth = 4;
        /// <summary>
        /// Gets or Sets width of the CircularProgress.
        /// </summary>
        [Description("Gets or Sets depth of the CircularProgress.")]
        [Category("Saa")]
        public int Depth
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

        private void FireValueChanged()
        {
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
