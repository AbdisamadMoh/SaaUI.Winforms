using System;
using SaaUI.Properties;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SaaUI
{
    /// <summary>
    /// Customizable ProgressBar with horizontal and vertical orientation support.
    /// </summary>
    [Description("Customizable ProgressBar with horizontal and vertical orientation support.")]
    [ToolboxBitmap(typeof(SaaProgressBar), "icons.SaaProgressBar.bmp")]
    [DefaultEvent("ValueChanged")]
    public partial class SaaProgressBar : UserControl
    {
        /// <summary>
        /// Fires when the <see cref="Value"/> of the ProgressBar is changed
        /// </summary>
        /// <param name="sender">object of type <see cref="SaaProgressBar"/></param>
        /// <param name="e"></param>
        public delegate void OnValueChanged(object sender, EventArgs e);
        /// <summary>
        /// Fires when the <see cref="Value"/> of the ProgressBar is changed
        /// <para>TIP: You can get the the new value from <see cref="Value"/> or as percentage <see cref="Percentage"/></para>
        /// </summary>
        [Description("Fires when the Value of the ProgressBar is changed."), Category("Saa")]
        public event OnValueChanged ValueChanged;
        public SaaProgressBar()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Size = new Size(200, 20);
            base.BackColor = Color.Transparent;
        }
        SaaToolTip tooltip = new SaaToolTip();
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Draw(e.Graphics);
            base.OnPaint(e);
        }

        private void Draw(Graphics g)
        {

            Brush b = new SolidBrush(_backcolor);
            Brush b2 = new SolidBrush(_color);
            Radius _r = new Radius();

            if (!_vertical)
            {

                var w = this.Width;
                var h = this.Height;
                if (h > w)
                {
                    this.Size = new Size(h, w);
                }
            }
            else
            {
                var w = this.Width;
                var h = this.Height;
                if (w > h)
                {
                    this.Size = new Size(h, w);
                }
            }
            if (!_vertical)
            {
                float current = ((float)_value / (_Maximum - _Minimum)) * this.Width;

                if (_round)
                {
                    _r.TopLeft = _r.TopRight = _r.BottomLeft = _r.BottomRight = this.Height / 2 - 2;


                }
                using (var bx = new BorderPath(0, 0, this.Width, this.Height - 1, _r))
                {
                    g.FillPath(b, bx.Path);
                }
                using (var bx = new BorderPath(0, 0, current, this.Height - 1, _r))
                {
                    if (current > 0)
                    {
                        g.FillPath(b2, bx.Path);
                    }
                }
                using (var pen = new SolidBrush(_textColor))
                {
                    var p = Display == SaaCircularProgressDisplayValue.Percent ? Percentage.ToString() : Display == SaaCircularProgressDisplayValue.Value ? Value.ToString() : "";
                    var txt = _Prefix + p + _Suffix;
                    var ts = g.MeasureString(txt, Font);
                    g.DrawString(txt, _Font, pen, this.Width / 2 - ts.Width / 2 + _textOffset.X, this.Height / 2 - ts.Height / 2 + _textOffset.Y);

                }
            }
            else
            {
                float current = this.Height - (((float)_value / (_Maximum - _Minimum)) * this.Height);
                if (_round)
                {
                    _r.TopLeft = _r.TopRight = _r.BottomLeft = _r.BottomRight = this.Width / 2 - 1;

                }
                using (var bx = new BorderPath(0, 0, this.Width - 1, this.Height, _r))
                {
                    g.FillPath(b, bx.Path);
                }
                using (var bx = new BorderPath(0, current, this.Width - 1, this.Height - current, _r))
                {
                    if (current > 0)
                    {
                        g.FillPath(b2, bx.Path);
                    }
                }
                using (var pen = new SolidBrush(_textColor))
                {
                    var p = Display == SaaCircularProgressDisplayValue.Percent ? Percentage.ToString() : Display == SaaCircularProgressDisplayValue.Value ? Value.ToString() : "";
                    var txt = _Prefix + p + _Suffix;
                    var ts = g.MeasureString(txt, Font);
                    StringFormat frm = new StringFormat(StringFormatFlags.DirectionVertical);
                    g.DrawString(txt, _Font, pen, this.Width / 2 - ts.Height / 2 + _textOffset.X, this.Height / 2 - ts.Width / 2 + _textOffset.Y, frm);
                    frm.Dispose();
                }
            }
            b.Dispose();
            b2.Dispose();
        }
        private void FireValueChanged()
        {
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
        /// <summary>
        /// Increments value of the ProgressBar by the value specified in <see cref="Step"/>
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

        /// <summary>
        /// Gets Percentage value of the ProgressBar. Decimal points is determined by <see cref="DecimalPoints"/>
        /// </summary> 
        [Browsable(false)]
        public double Percentage
        {
            get; private set;
        }

        SaaCircularProgressDisplayValue _Display = SaaCircularProgressDisplayValue.Percent;
        /// <summary>
        /// Gets or Sets how text is displayed in the ProgressBar.
        /// </summary>
        [Description("Gets or Sets how text is displayed in the ProgressBar.")]
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
        /// Gets or Sets text put before Value/Percent/None text displayed in the ProgressBar.
        /// </summary>
        [Description("Gets or Sets text put before Value/Percent/None text displayed in the ProgressBar.")]
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
        /// Gets or Sets text put after Value/Percent/None text displayed in the ProgressBar.
        /// </summary>
        [Description("Gets or Sets text put after Value/Percent/None text displayed in the ProgressBar.")]
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
        /// Gets or Sets how many decimal points will be displayed in the ProgressBar.
        /// </summary>
        [Description("Gets or Sets how many decimal points will be displayed in the ProgressBar.")]
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
        Point _textOffset = Point.Empty;
        /// <summary>
        /// Gets or Sets how far the text should move from left to right (X) and from top to bottom (Y).
        /// </summary>
        [Description("Gets or Sets how far the text should move from left to right (X) and from top to bottom (Y)."), Category("Saa")]
        public Point TextOffset
        {
            get
            {
                return _textOffset;
            }
            set
            {

                _textOffset = value;

                Invalidate();
            }
        }
        Font _Font = SystemFonts.DefaultFont;
        /// <summary>
        /// Gets or Sets font of the text.
        /// </summary>
        [Description("Gets or Sets font of the text."), Category("Saa")]
        public Font TextFont
        {
            get
            {
                return _Font;
            }
            set
            {

                _Font = value;

                Invalidate();
            }
        }
        Color _textColor = Color.Black;
        /// <summary>
        /// Gets or Sets color of the text.
        /// </summary>
        [Description("Gets or Sets color of the text."), Category("Saa")]
        public Color TextColor
        {
            get
            {
                return _textColor;
            }
            set
            {

                _textColor = value;

                Invalidate();
            }
        }

        bool _vertical = false;
        /// <summary>
        /// Gets or Sets whether the progressbar is vertical or horizontal.
        /// </summary>
        [Description("Gets or Sets whether the progressbar is vertical or horizontal."), Category("Saa")]
        public bool Vertical
        {
            get
            {
                return _vertical;
            }
            set
            {

                _vertical = value;

                Invalidate();
            }
        }

        bool _round = false;
        /// <summary>
        /// Gets or Sets whether the progressbar border is rounded.
        /// </summary>
        [Description("Gets or Sets whether the progressbar border is rounded."), Category("Saa")]
        public bool RoundedStyle
        {
            get
            {
                return _round;
            }
            set
            {
                _round = value;
                Invalidate();
            }
        }

        int _Maximum = 100;
        /// <summary>
        /// Gets or Sets maximum value the progressbar accepts.
        /// </summary>
        [Description("Gets or Sets maximum value the progressbar accepts."), Category("Saa")]
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                if (value < _Minimum) throw new Exception("Maximum can not be less than the Minimum");
                _Maximum = value;
                if (Value > _Maximum)
                {
                    Value = _Maximum;

                }
                Invalidate();
            }
        }

        int _Minimum = 0;
        /// <summary>
        /// Gets or Sets minimum value the progressbar accepts.
        /// </summary>
        [Description("Gets or Sets minimum value the progressbar accepts."), Category("Saa")]
        public int Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                if (value > _Maximum) throw new Exception("Minimum can not be greater than the Maximum");
                _Minimum = value;
                if (Value < _Minimum)
                {
                    Value = _Minimum;

                }
                Invalidate();
            }
        }

        int _value = 0;
        /// <summary>
        /// Gets or Sets the current value the progressbar is passing.
        /// </summary>
        [Description("Gets or Sets the current value the progressbar is passing."), Category("Saa")]
        public int Value
        {
            get { return _value; }
            set
            {
                if (value > _Maximum || value < _Minimum) throw new Exception("Value should be in between Minimum and Maximum values.");
                _value = value;
                Invalidate();
                Percentage = Math.Round(((float)_value / (float)(_Maximum - _Minimum)) * 100f, _DecimalPoints);
                FireValueChanged();
            }
        }

        Color _backcolor = Color.LightGray;
        /// <summary>
        /// Gets or Sets background color of the progressbar.
        /// </summary>
        [Description("Gets or Sets background color of the progressbar."), Category("Saa")]
        public Color BackgroundColor
        {
            get { return _backcolor; }
            set { _backcolor = value; Invalidate(); }
        }
        Color _color = SaaInternalColors.PrimaryColor;
        /// <summary>
        /// Gets or Sets color of the progressbar.
        /// </summary>
        [Description("Gets or Sets color of the progressbar."), Category("Saa")]
        public Color Color
        {
            get { return _color; }
            set { _color = value; Invalidate(); }
        }


        #region Hidden Properties
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color BackColor { get => base.BackColor; set { } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
           DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Image BackgroundImage { get => base.BackgroundImage; set { } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
           DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ForeColor { get => base.ForeColor; set { } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
           DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override RightToLeft RightToLeft { get => base.RightToLeft; set { } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
           DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool AutoScroll { get => base.AutoScroll; set { } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
           DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool AutoSize { get => base.AutoSize; set { } }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never),
           DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Font Font { get => base.Font; set { } }


        #endregion
        private void SaaProgressBar_Load(object sender, EventArgs e)
        {

        }
    }
}
